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
using System.IO;

namespace C0DEC0RE
{
	/// <summary>
	/// Watcher for configuration sections in configuration files.
	/// </summary>
	/// <remarks>
	/// This implementation uses a <see cref="ConfigurationChangeFileWatcher"/> to watch for changes 
	/// in the configuration files.
	/// </remarks>
	public class ConfigurationFileSourceWatcher : ConfigurationSourceWatcher
	{
		private string configurationFilepath;

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationFileSourceWatcher"/> class.
		/// </summary>
		/// <param name="configurationFilepath">The path for the configuration file to watch.</param>
		/// <param name="configSource">The identification of the configuration source.</param>
		/// <param name="refresh"><b>true</b> if changes should be notified, <b>false</b> otherwise.</param>
		/// <param name="changed">The callback for changes notification.</param>
		public ConfigurationFileSourceWatcher(string configurationFilepath, string configSource, bool refresh, ConfigurationChangedEventHandler changed)
			: base(configSource, refresh, changed)
		{
			this.configurationFilepath = configurationFilepath;

			if (refresh)
			{
				SetUpWatcher(changed);
			}
		}

		private void SetUpWatcher(ConfigurationChangedEventHandler changed)
		{
			this.configWatcher = new ConfigurationChangeFileWatcher(GetFullFileName(this.configurationFilepath, this.ConfigSource), this.ConfigSource);
			this.configWatcher.ConfigurationChanged += changed;
		}

		/// <summary>
		/// Gets the full file name associated to the configuration source.
		/// </summary>
		/// <param name="configurationFilepath">The path for the main configuration file.</param>
		/// <param name="configSource">The configuration source to watch.</param>
		/// <returns>The path to the configuration file to watch. It will be the same as <paramref name="configurationFilePath"/>
		/// if <paramref name="configSource"/> is empty, or the full path for <paramref name="configSource"/> considered as a 
		/// file name relative to the main configuration file.</returns>
		public static string GetFullFileName(string configurationFilepath, string configSource)
		{
			if (string.Empty == configSource)
			{
				// watch app.config/web.config
				return configurationFilepath;
			}
			else
			{
				// watch an external file
				if (!Path.IsPathRooted(configSource))
				{
					return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configSource);
				}
				else
				{
					return configSource;
				}
			}
		}
	}
}
