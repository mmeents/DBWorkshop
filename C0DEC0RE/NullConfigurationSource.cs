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

namespace C0DEC0RE
{
	/// <summary>
	/// Represents a null configuration source that always returns null for a section.
	/// </summary>
	public class NullConfigurationSource : IConfigurationSource
	{
		/// <summary>
		/// Returns null for the section.
		/// </summary>
		/// <param name="sectionName">The section name to retrieve.</param>
		/// <returns>Always <see langword="null"/>.</returns>
		public ConfigurationSection GetSection(string sectionName)
		{
			return null;
		}

        /// <summary>
		/// Null implementation of <see cref="IConfigurationSource.Add(IConfigurationParameter, string, ConfigurationSection)"/> that 
		/// ignores the request.
        /// </summary>
		/// <param name="saveParameter">The <see cref="IConfigurationParameter"/> that represents the location where 
		/// to save the updated configuration.</param>
		/// <param name="sectionName">The name by which the <paramref name="configurationSection"/> should be added.</param>
		/// <param name="configurationSection">The configuration section to add.</param>
		public void Add(IConfigurationParameter saveParameter, string sectionName, ConfigurationSection configurationSection)
        {            
        }

		/// <summary>
		/// Null implementation of <see cref="IConfigurationSource.Remove(IConfigurationParameter, string)"/> that 
		/// ignores the request.
		/// </summary>
		/// <param name="removeParameter">The <see cref="IConfigurationParameter"/> that represents the location where 
		/// to save the updated configuration.</param>
		/// <param name="sectionName">The name of the section to remove.</param>
		public void Remove(IConfigurationParameter removeParameter, string sectionName)
        {
        }

        /// <summary>
        /// Adds a handler to be called when changes to section <code>sectionName</code> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler.</param>
        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
        }

        /// <summary>
        /// Remove a handler to be called when changes to section <code>sectionName</code> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler.</param>
        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
        }
    }
}
