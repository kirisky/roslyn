﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Roslyn.LanguageServer.Protocol;

using System.Text.Json.Serialization;

/// <summary>
/// Class representing the parameters sent for the client/registerCapability request.
///
/// See the <see href="https://microsoft.github.io/language-server-protocol/specifications/specification-current/#registrationParams">Language Server Protocol specification</see> for additional information.
/// </summary>
internal sealed class RegistrationParams
{
    /// <summary>
    /// Gets or sets the set of capabilities that are being registered.
    /// </summary>
    [JsonPropertyName("registrations")]
    [JsonRequired]
    public Registration[] Registrations
    {
        get;
        set;
    }
}
