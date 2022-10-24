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
using System.Configuration;
using C0DEC0RE.Properties;

namespace C0DEC0RE
{
    /// <summary>
	/// Represents the configuration settings that describe an <see cref="IConfigurationSource"/>.
	/// </summary>
    public class ConfigurationSourceElement : NameTypeConfigurationElement
    {
        /// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationSourceElement"/> class with default values.
		/// </summary>
        public ConfigurationSourceElement() 
        {
        }

        /// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationSourceElement"/> class with a name and an type.
		/// </summary>
        /// <param name="name">The instance name.</param>
		/// <param name="type">The type for the represented <see cref="IConfigurationSource"/>.</param>
        public ConfigurationSourceElement(string name, Type type)
            : base(name, type)
		{
		}

		/// <summary>
		/// Returns a new <see cref="IConfigurationSource"/> configured with the receiver's settings.
		/// </summary>
		/// <returns>A new configuration source.</returns>
		protected internal virtual IConfigurationSource CreateSource()
		{
			throw new ConfigurationErrorsException(Resources.ExceptionBaseConfigurationSourceElementIsInvalid);
		}
	}
}
