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
using System.Configuration;

namespace C0DEC0RE
{
    /// <summary>
    /// Represents the configuration settings that describe a <see cref="FileConfigurationSource"/>.
    /// </summary>
    public class FileConfigurationSourceElement : ConfigurationSourceElement
    {
        private const string filePathProperty = "filePath";

        /// <summary>
		/// Initializes a new instance of the <see cref="FileConfigurationSourceElement"/> class with a default name and an empty path.
        /// </summary>
        public FileConfigurationSourceElement() : this("File Configuration Source", string.Empty)
        {
        }

        /// <summary>
		/// Initializes a new instance of the <see cref="FileConfigurationSourceElement"/> class with a name and an path.
		/// </summary>
        /// <param name="name">The instance name.</param>
        /// <param name="filePath">The file path.</param>
        public FileConfigurationSourceElement(string name, string filePath)
            : base(name, typeof(FileConfigurationSource))
		{
            this.FilePath = filePath;
        }


        /// <summary>
        /// Gets or sets the file path. This is a required field.
        /// </summary>
        [ConfigurationProperty(filePathProperty, IsRequired = true)]
        public string FilePath
        {
            get { return (string)this[filePathProperty]; }
            set { this[filePathProperty] = value; }
        }

		/// <summary>
		/// Returns a new <see cref="FileConfigurationSource"/> configured with the receiver's settings.
		/// </summary>
		/// <returns>A new configuration source.</returns>
		protected internal override IConfigurationSource CreateSource()
		{
			IConfigurationSource createdObject = new FileConfigurationSource(FilePath);

			return createdObject;
		}
    }
}
