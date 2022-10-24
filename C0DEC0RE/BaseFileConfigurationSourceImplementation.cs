//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Core
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;

namespace C0DEC0RE
{
	/// <summary>
	/// This type supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
	/// Represents the implementation details for file-based configuration sources.
	/// </summary>
	/// <remarks>
	/// This implementation deals with setting up the watcher over the configuration files to detect changes and update
	/// the configuration representation. It also manages the change notification features provided by the file based 
	/// configuration sources.
	/// </remarks>
	public abstract class BaseFileConfigurationSourceImplementation : IDisposable
	{
		/// <summary>
		/// This field supports the Enterprise Library infrastructure and is not intended to be used directly from your code.		
		/// ConfigSource value for sections that existed in configuration but were later removed.
		/// </summary>
		public const string NullConfigSource = "__null__";

		private object lockMe = new object();
		private ConfigurationSourceWatcher configFileWatcher;
		private Dictionary<string, ConfigurationSourceWatcher> watchedConfigSourceMapping;
		private Dictionary<string, ConfigurationSourceWatcher> watchedSectionMapping;
		private bool refresh = true;
		private string configurationFilepath;

		private object eventHandlersLock = new object();
		private EventHandlerList eventHandlers = new EventHandlerList();

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Initializes a new instance of the <see cref="FileConfigurationSourceImplementation"/> class.
		/// </summary>
		/// <param name="configurationFilepath">The path for the main configuration file.</param>
		/// <param name="refresh"><b>true</b>if runtime changes should be refreshed, <b>false</b> otherwise.</param>
		public BaseFileConfigurationSourceImplementation(string configurationFilepath, bool refresh)
			: this(configurationFilepath)
		{
			this.refresh = refresh;
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Initializes a new instance of the <see cref="FileConfigurationSourceImplementation"/> class.
		/// </summary>
		/// <param name="configurationFilepath">The path for the main configuration file.</param>
		public BaseFileConfigurationSourceImplementation(string configurationFilepath)
		{
			this.configurationFilepath = configurationFilepath;
			this.watchedConfigSourceMapping = new Dictionary<string, ConfigurationSourceWatcher>();
			this.watchedSectionMapping = new Dictionary<string, ConfigurationSourceWatcher>();
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Retrieves the specified <see cref="ConfigurationSection"/> from the configuration file, and starts watching for 
		/// its changes if not watching already.
		/// </summary>
		/// <param name="sectionName">The section name.</param>
		/// <returns>The section, or <see langword="null"/> if it doesn't exist.</returns>
		public abstract ConfigurationSection GetSection(string sectionName);

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Sets up a watcher for <paramref name="configurationSection"/> under the name <paramref name="sectionName"/>.
		/// </summary>
		/// <remarks>
		/// A watcher will be created if the section is not already being watched. The watcher will be watching the file specified
		/// by <see cref="ConfigurationSection.SectionInformation"/>.
		/// </remarks>
		/// <param name="sectionName">The name of the configuration section to watch.</param>
		/// <param name="configurationSection">The configuration section to watch.</param>
		protected void SetConfigurationWatchers(string sectionName, ConfigurationSection configurationSection)
		{
			if (configurationSection != null)
			{
				lock (lockMe)
				{
					if (!IsWatchingSection(sectionName))	// should only be true sporadically
					{
						SetWatcherForSection(sectionName, configurationSection.SectionInformation.ConfigSource);
					}
				}
			}
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Adds a handler to be called when changes to section <code>sectionName</code> are detected.
		/// </summary>
		/// <param name="sectionName">The name of the section to watch for.</param>
		/// <param name="handler">The handler.</param>
		public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
		{
			lock (eventHandlersLock)
			{
				eventHandlers.AddHandler(sectionName, handler);
			}
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Remove a handler to be called when changes to section <code>sectionName</code> are detected.
		/// </summary>
		/// <param name="sectionName">The name of the section to watch for.</param>
		/// <param name="handler">The handler.</param>
		public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
		{
			lock (eventHandlersLock)
			{
				eventHandlers.RemoveHandler(sectionName, handler);
			}
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="configSource">The name of the updated configuration source.</param>
		/// <devdoc>
		/// Only needs to deal with concurrency to get the current sections and to update the watchers.
		/// 
		/// Rationale:
		/// - Sections' are only added or updated.
		/// - For this notification, all sections in the config file must be updated, and sections in external 
		/// files must be refreshed only if the config source changed.
		/// - why not check after the original set of sections is retrieved?
		/// -- Sections might have been added to the listener set after the original set is retrieved, but...
		/// -- If they were added after the original set was retrieved, then they are up to date.
		/// --- For this to happen, they couldn't have been read before the o.s., otherwise they would be a listener for them.
		/// --- So, the retrieved information must be fresh (checked this with a test). 
		/// -- What about other changes?
		/// --- Erased sections: only tested in the config file watching thread, because the meta configuration 
		/// is kept in the configuration file.
		/// ---- Even if the external file an external is deleted because of the deletion, and this change is processed
		/// before the config file change, the refresh for the external section will refresh all the sections for the file and 
		/// notify a change, without need for checking the change. The change would later be picked up by the config file watcher 
		/// which will notify again. This shouldn't be a problem.
		/// --- External sections with changed sources. If they existed before, they must have been in the config file and there 
		/// was an entry in the bookeeping data structures.
		/// - Concurrent updates for sections values should be handled by the system.config fx
		/// </devdoc>
		public void ConfigSourceChanged(string configSource)
		{
			IDictionary<string, string> localSectionsToRefresh = new Dictionary<string, string>();
			IDictionary<string, string> externalSectionsToRefresh = new Dictionary<string, string>();

			IDictionary<string, string> sectionsWithChangedConfigSource;
			ICollection<string> sectionsToNotify = new List<string>();

			// get two separate lists with the sections of interest
			lock (lockMe)
			{
				if (configFileWatcher != null)
				{
					AddSectionsToUpdate(configFileWatcher, localSectionsToRefresh);
				}
				foreach (ConfigurationSourceWatcher watcher in watchedConfigSourceMapping.Values)
				{
					if (watcher != configFileWatcher)
					{
						AddSectionsToUpdate(watcher, externalSectionsToRefresh);
					}
				}
			}

			RefreshAndValidateSections(localSectionsToRefresh, externalSectionsToRefresh, out sectionsToNotify, out sectionsWithChangedConfigSource);

			UpdateWatchersForSections(sectionsWithChangedConfigSource);

			// notify changes (out of lock)
			NotifyUpdatedSections(sectionsToNotify);
		}

		private void AddSectionsToUpdate(ConfigurationSourceWatcher watcher, IDictionary<string, string> sectionsToUpdate)
		{
			foreach (string section in watcher.WatchedSections)
			{
				sectionsToUpdate.Add(section, watcher.ConfigSource);
			}
		}

		// must be called outside of lock
		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Refreshes the configuration sections from the main configuration file and determines which sections have suffered notifications
		/// and should be notified to registered handlers.
		/// </summary>
		/// <param name="localSectionsToRefresh">A dictionary with the configuration sections residing in the main configuration file that must be refreshed.</param>
		/// <param name="externalSectionsToRefresh">A dictionary with the configuration sections residing in external files that must be refreshed.</param>
		/// <param name="sectionsToNotify">A new collection with the names of the sections that suffered changes and should be notified.</param>
		/// <param name="sectionsWithChangedConfigSource">A new dictionary with the names and file names of the sections that have changed their location.</param>
		protected abstract void RefreshAndValidateSections(IDictionary<string, string> localSectionsToRefresh, IDictionary<string, string> externalSectionsToRefresh, out ICollection<string> sectionsToNotify, out IDictionary<string, string> sectionsWithChangedConfigSource);

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Refreshes the configuration sections from an external configuration file.
		/// </summary>
		/// <param name="sectionsToRefresh">A collection with the names of the sections that suffered changes and should be refreshed.</param>
		protected abstract void RefreshExternalSections(string[] sectionsToRefresh);

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// </summary>
		/// <param name="configSource">The name of the updated configuration source.</param>
		public void ExternalConfigSourceChanged(string configSource)
		{
			string[] sectionsToNotify;

			lock (lockMe)
			{
				ConfigurationSourceWatcher watcher = null;
				this.watchedConfigSourceMapping.TryGetValue(configSource, out watcher);
				sectionsToNotify = new string[watcher.WatchedSections.Count];
				watcher.WatchedSections.CopyTo(sectionsToNotify, 0);
			}

			RefreshExternalSections(sectionsToNotify);

			NotifyUpdatedSections(sectionsToNotify);
		}

		/// <summary>
		/// Releases the resources used by the change watchers.
		/// </summary>
		public void Dispose()
		{
			foreach (IDisposable watcher in this.watchedConfigSourceMapping.Values)
			{
				watcher.Dispose();
			}
		}

		internal ICollection<string> WatchedConfigSources
		{
			get { return this.watchedConfigSourceMapping.Keys as ICollection<string>; }
		}

		internal ICollection<string> WatchedSections
		{
			get { return this.watchedSectionMapping.Keys as ICollection<string>; }
		}

		internal IDictionary<string, ConfigurationSourceWatcher> ConfigSourceWatcherMappings
		{
			get { return this.watchedConfigSourceMapping; }
		}

		internal EventHandlerList SectionChangedHandlers
		{
			get { return this.eventHandlers; }
		}

		// must be called outside lock
		private bool IsWatchingSection(string sectionName)
		{
			return this.watchedSectionMapping.ContainsKey(sectionName);
		}

		// must be called outside lock
		private bool IsWatchingConfigSource(string configSource)
		{
			return this.watchedConfigSourceMapping.ContainsKey(configSource);
		}

		// must be called outside lock
		private void UpdateWatchersForSections(IDictionary<string, string> sectionsChangingSource)
		{
			lock (lockMe)
			{
				foreach (KeyValuePair<string, string> sectionSourcePair in sectionsChangingSource)
				{
					UpdateWatcherForSection(sectionSourcePair.Key, sectionSourcePair.Value);
				}
			}
		}

		// must be called outside lock
		private void UpdateWatcherForSection(string sectionName, string configSource)
		{
			ConfigurationSourceWatcher currentSectionWatcher = null;
			this.watchedSectionMapping.TryGetValue(sectionName, out currentSectionWatcher);

			if (currentSectionWatcher == null || currentSectionWatcher.ConfigSource != configSource)
			{
				if (currentSectionWatcher != null)
				{
					UnlinkWatcherForSection(currentSectionWatcher, sectionName);
				}

				if (configSource != null)
				{
					SetWatcherForSection(sectionName, configSource);
				}
			}
		}

		// must be called inside lock
		private ConfigurationSourceWatcher CreateWatcherForConfigSource(string configSource)
		{
			ConfigurationSourceWatcher watcher = null;

			if (string.Empty == configSource)
			{
				watcher = new ConfigurationFileSourceWatcher(this.configurationFilepath,
					configSource,
					this.refresh,
					new ConfigurationChangedEventHandler(OnConfigurationChanged));
				configFileWatcher = watcher;
			}
			else
			{
				watcher = new ConfigurationFileSourceWatcher(this.configurationFilepath,
					configSource,
					this.refresh && !NullConfigSource.Equals(configSource),
					new ConfigurationChangedEventHandler(OnExternalConfigurationChanged));
			}

			this.watchedConfigSourceMapping.Add(configSource, watcher);

			return watcher;
		}

		// must be called inside lock
		private void RemoveConfigSourceWatcher(ConfigurationSourceWatcher watcher)
		{
			this.watchedConfigSourceMapping.Remove(watcher.ConfigSource);
			(watcher as IDisposable).Dispose();
		}

		// must be called inside lock
		private void SetWatcherForSection(string sectionName, string configSource)
		{
			ConfigurationSourceWatcher currentConfigSourceWatcher = null;
			this.watchedConfigSourceMapping.TryGetValue(configSource, out currentConfigSourceWatcher);

			if (currentConfigSourceWatcher == null)
			{
				currentConfigSourceWatcher = CreateWatcherForConfigSource(configSource);
			}
			else
			{
				currentConfigSourceWatcher.StopWatching();
			}
			LinkWatcherForSection(currentConfigSourceWatcher, sectionName);
			currentConfigSourceWatcher.StartWatching();

			// must watch the app.config if not watching already
			if ((string.Empty != configSource) && (!IsWatchingConfigSource(string.Empty)))
			{
				CreateWatcherForConfigSource(string.Empty).StartWatching();
			}
		}

		// must be called inside lock
		private void LinkWatcherForSection(ConfigurationSourceWatcher watcher, string sectionName)
		{
			this.watchedSectionMapping.Add(sectionName, watcher);
			watcher.WatchedSections.Add(sectionName);
		}

		// must be called inside lock
		private void UnlinkWatcherForSection(ConfigurationSourceWatcher watcher, string sectionName)
		{
			this.watchedSectionMapping.Remove(sectionName);
			watcher.WatchedSections.Remove(sectionName);
			if (watcher.WatchedSections.Count == 0 && configFileWatcher != watcher)
			{
				RemoveConfigSourceWatcher(watcher);
			}
		}

		private void OnConfigurationChanged(object sender, ConfigurationChangedEventArgs args)
		{
			ConfigSourceChanged(args.SectionName);
		}

		private void OnExternalConfigurationChanged(object sender, ConfigurationChangedEventArgs args)
		{
			ExternalConfigSourceChanged(args.SectionName);
		}

		// must be called outside lock
		private void NotifyUpdatedSections(IEnumerable<string> sectionsToNotify)
		{
			foreach (string sectionName in sectionsToNotify)
			{
				Delegate[] invocationList = null;

				lock (eventHandlersLock)
				{
					ConfigurationChangedEventHandler callbacks = (ConfigurationChangedEventHandler)eventHandlers[sectionName];
					if (callbacks == null)
					{
						continue;
					}
					invocationList = callbacks.GetInvocationList();
				}

				ConfigurationChangedEventArgs eventData = new ConfigurationChangedEventArgs(sectionName);
				try
				{
					foreach (ConfigurationChangedEventHandler callback in invocationList)
					{
						if (callback != null)
						{
							callback(this, eventData);
						}
					}
				}
				catch// (Exception e)
				{
					//EventLog.WriteEntry(GetEventSourceName(), Resources.ExceptionEventRaisingFailed + GetType().FullName + " :" + e.Message);
				}
			}
		}
	}
}
