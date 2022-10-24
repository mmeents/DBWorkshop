//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Data Access Application Block
//===============================================================================
// Copyright � Microsoft Corporation. All rights reserved.
// Adapted from ACA.NET with permission from Avanade Inc.
// ACA.NET copyright � Avanade Inc. All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

namespace C0DEC0RE
{
	/// <summary>
	/// Represents the description of an oracle package mapping.
	/// </summary>
	/// <remarks>
	/// <see cref="IOraclePackage"/> is used to specify how to transform store procedure names 
	/// into package qualified Oracle stored procedure names.
	/// </remarks>
	/// <seealso cref="OracleDatabase"/>
	public interface IOraclePackage
	{
		/// <summary>
		/// When implemented by a class, gets the name of the package.
		/// </summary>
		/// <value>
		/// The name of the package.
		/// </value>
		string Name
		{ get; }

		/// <summary>
		/// When implemented by a class, gets the prefix for the package.
		/// </summary>
		/// <value>
		/// The prefix for the package.
		/// </value>
		string Prefix
		{ get; }
	}
}
