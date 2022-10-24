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
using System.ComponentModel;
using System.Configuration.Install;
using System.Management.Instrumentation;
using System.Threading;

namespace C0DEC0RE
{
	/// <summary>
	/// This member supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
	/// Provides the installer for the Core library, installing WMI Events and event log sources defined for this library.
	/// </summary>
	[RunInstaller(true)]
	public partial class CommonWmiInstaller : DefaultManagementProjectInstaller
	{
		/// <summary>
		/// Initializes the installer.
		/// This member supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public CommonWmiInstaller()
		{
			InitializeComponent();

			Installers.Add(new ReflectionInstaller<EventLogInstallerBuilder>());
		}
	}
}