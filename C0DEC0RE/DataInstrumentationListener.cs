//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Data Access Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using C0DEC0RE.Properties;

namespace C0DEC0RE
{
	/// <summary>
	/// Provides the concrete instrumentation for the logical events raised by a <see cref="DataInstrumentationProvider"/> object.
	/// </summary>
	[HasInstallableResourcesAttribute]
	[PerformanceCountersDefinition(counterCategoryName, "CounterCategoryHelpResourceName")]
	[EventLogDefinition("Application", "Enterprise Library Data")]
	internal class DataInstrumentationListener : InstrumentationListener
	{
		static EnterpriseLibraryPerformanceCounterFactory counterCache = new EnterpriseLibraryPerformanceCounterFactory();

		[PerformanceCounter("Connections Opened/sec", "ConnectionOpenedCounterHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
		EnterpriseLibraryPerformanceCounter connectionOpenedCounter;

		[PerformanceCounter("Commands Executed/sec", "CommandExecutedCounterHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
		EnterpriseLibraryPerformanceCounter commandExecutedCounter;

		[PerformanceCounter("Connections Failed/sec", "ConnectionFailedCounterHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
		EnterpriseLibraryPerformanceCounter connectionFailedCounter;

		[PerformanceCounter("Commands Failed/sec", "CommandFailedCounterHelpResource", PerformanceCounterType.RateOfCountsPerSecond32)]
		EnterpriseLibraryPerformanceCounter commandFailedCounter;

		private const string counterCategoryName = "Enterprise Library Data Counters";
		private string instanceName;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataInstrumentationListener"/> class.
		/// </summary>
		/// <param name="instanceName">The name of the <see cref="Database"/> instance this instrumentation listener is created for.</param>
		/// <param name="performanceCountersEnabled"><b>true</b> if performance counters should be updated.</param>
		/// <param name="eventLoggingEnabled"><b>true</b> if event log entries should be written.</param>
		/// <param name="wmiEnabled"><b>true</b> if WMI events should be fired.</param>
		public DataInstrumentationListener(string instanceName,
										   bool performanceCountersEnabled,
										   bool eventLoggingEnabled,
										   bool wmiEnabled)
			: this(instanceName, performanceCountersEnabled, eventLoggingEnabled, wmiEnabled, new AppDomainNameFormatter())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataInstrumentationListener"/> class.
		/// </summary>
		/// <param name="instanceName">The name of the <see cref="Database"/> instance this instrumentation listener is created for.</param>
		/// <param name="performanceCountersEnabled"><b>true</b> if performance counters should be updated.</param>
		/// <param name="eventLoggingEnabled"><b>true</b> if event log entries should be written.</param>
		/// <param name="wmiEnabled"><b>true</b> if WMI events should be fired.</param>
		/// <param name="nameFormatter">The <see cref="IPerformanceCounterNameFormatter"/> that is used to creates unique name for each <see cref="PerformanceCounter"/> instance.</param>
		public DataInstrumentationListener(string instanceName,
										   bool performanceCountersEnabled,
										   bool eventLoggingEnabled,
										   bool wmiEnabled,
										   IPerformanceCounterNameFormatter nameFormatter)
			: base(instanceName, performanceCountersEnabled, eventLoggingEnabled, wmiEnabled, nameFormatter)
		{
			this.instanceName = instanceName;
		}
		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Default handler for the <see cref="DataInstrumentationProvider.connectionOpened"/> event.
		/// </summary>
		/// <remarks>
		/// Increments the "Connections Opened/sec" performance counter.
		/// </remarks>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Data for the event.</param>
		[InstrumentationConsumer("ConnectionOpened")]
		public void ConnectionOpened(object sender, EventArgs e)
		{
			if (PerformanceCountersEnabled) connectionOpenedCounter.Increment();
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Default handler for the <see cref="DataInstrumentationProvider.commandExecuted"/> event.
		/// </summary>
		/// <remarks>
		/// Increments the "Commands Executed/sec" performance counter.
		/// </remarks>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Data for the event.</param>
		[InstrumentationConsumer("CommandExecuted")]
		public void CommandExecuted(object sender, CommandExecutedEventArgs e)
		{
			if (PerformanceCountersEnabled) commandExecutedCounter.Increment();
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Default handler for the <see cref="DataInstrumentationProvider.connectionFailed"/> event.
		/// </summary>
		/// <remarks>
		/// Increments the "Connections Failed/sec" performance counter, fires the ConnectionFailedEvent WMI event and writes 
		/// an error entry to the event log.
		/// </remarks>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Data for the event.</param>
		[InstrumentationConsumer("ConnectionFailed")]
		public void ConnectionFailed(object sender, ConnectionFailedEventArgs e)
		{
			if (PerformanceCountersEnabled) connectionFailedCounter.Increment();
			if (WmiEnabled) System.Management.Instrumentation.Instrumentation.Fire(new ConnectionFailedEvent(instanceName, e.ConnectionString, e.Exception.ToString()));
			if (EventLoggingEnabled)
			{
				string errorMessage
					= string.Format(
						Resources.Culture,
						Resources.ErrorConnectionFailedMessage,
						instanceName);
				string extraInformation
					= string.Format(
						Resources.Culture,
						Resources.ErrorConnectionFailedExtraInformation,
						e.ConnectionString);
				string entryText = new EventLogEntryFormatter(Resources.BlockName).GetEntryText(errorMessage, e.Exception, extraInformation);

				EventLog.WriteEntry(GetEventSourceName(), entryText, EventLogEntryType.Error);
			}
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Default handler for the <see cref="DataInstrumentationProvider.commandFailed"/> event.
		/// </summary>
		/// <remarks>
		/// Increments the "Commands Failed/sec" performance counter, fires the CommandFailedEvent WMI event and writes 
		/// an error entry to the event log.
		/// </remarks>
		/// <param name="sender">Sender of the event.</param>
		/// <param name="e">Data for the event.</param>
		[InstrumentationConsumer("CommandFailed")]
		public void CommandFailed(object sender, CommandFailedEventArgs e)
		{
			if (PerformanceCountersEnabled) commandFailedCounter.Increment();
			if (WmiEnabled) System.Management.Instrumentation.Instrumentation.Fire(new CommandFailedEvent(instanceName, e.ConnectionString, e.CommandText, e.Exception.ToString()));
		}

		/// <summary>
		/// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// Clears the cached performance counter instances.
		/// </summary>
		public static void ClearCounterCache()
		{
			counterCache.ClearCachedCounters();
		}

		/// <summary>
		/// Creates the performance counters to instrument the caching events for the specified instance names.
		/// </summary>
		/// <param name="instanceNames">The instance names for the performance counters.</param>
		protected override void CreatePerformanceCounters(string[] instanceNames)
		{
			connectionOpenedCounter = counterCache.CreateCounter(counterCategoryName, "Connections Opened/sec", instanceNames);
			commandExecutedCounter = counterCache.CreateCounter(counterCategoryName, "Commands Executed/sec", instanceNames);
			connectionFailedCounter = counterCache.CreateCounter(counterCategoryName, "Connections Failed/sec", instanceNames);
			commandFailedCounter = counterCache.CreateCounter(counterCategoryName, "Commands Failed/sec", instanceNames);
		}
	}
}
