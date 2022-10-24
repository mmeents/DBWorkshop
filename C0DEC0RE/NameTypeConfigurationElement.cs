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
using System.ComponentModel;
using System.Configuration;

namespace C0DEC0RE
{
	/// <summary>
	/// Represents a <see cref="ConfigurationElement"/> that has a name and type.
	/// </summary>
	public class NameTypeConfigurationElement : NamedConfigurationElement, IObjectWithNameAndType
	{
		/// <summary>
		/// Name of the property that holds the type of <see cref="EnterpriseLibrary.Common.Configuration.NameTypeConfigurationElement"/>.
		/// </summary>
		public const string typeProperty = "type";

		/// <summary>
		/// Intialzie an instance of the <see cref="NameTypeConfigurationElement"/> class.
		/// </summary>
		public NameTypeConfigurationElement()
		{
		}

		/// <summary>
		/// Initialize an instance of the <see cref="NameTypeConfigurationElement"/> class
		/// </summary>
		/// <param name="name">The name of the element.</param>
		/// <param name="type">The <see cref="Type"/> that this element is the configuration for.</param>
		public NameTypeConfigurationElement(string name, Type type) : base(name)
		{			
			this.Type = type;
		}		

		/// <summary>
		/// Gets or sets the <see cref="Type"/> the element is the configuration for.
		/// </summary>
		/// <value>
		/// The <see cref="Type"/> the element is the configuration for.
		/// </value>
		[ConfigurationProperty(typeProperty, IsRequired= true)]
		[TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]		
		public Type Type
		{
			get
			{
				return (Type)this[typeProperty];
			}
			set
			{
				this[typeProperty] = value;
			}
		}

        internal new ConfigurationPropertyCollection Properties
        {
            get { return base.Properties; }
        }
	}
}
