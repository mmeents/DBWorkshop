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

namespace C0DEC0RE
{
	internal class ReflectionCachePolicy : IReflectionCachePolicy
	{
		private ConfigurationReflectionCache reflectionCache;

		internal ReflectionCachePolicy(ConfigurationReflectionCache reflectionCache)
		{
			this.reflectionCache = reflectionCache;
		}

		public ConfigurationReflectionCache ReflectionCache
		{
			get { return this.reflectionCache; }
		}
	}
}
