﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.CodeAnalysis.Host.Mef;

/// <summary>
/// This interface is provided purely to enable some shared logic that handles multiple kinds of 
/// metadata that share the Language property. It should not be used to find exports via MEF,
/// use LanguageMetadata instead.
/// </summary>
internal interface ILanguageMetadata
{
    string Language { get; }
}
