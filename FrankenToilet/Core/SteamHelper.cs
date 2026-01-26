using System.Collections.Generic;
using JetBrains.Annotations;
using Steamworks;

namespace FrankenToilet.Core;

[PublicAPI]
public static class SteamHelper
{
    // ReSharper disable once UsageOfDefaultStructEquality
    private static readonly HashSet<SteamId> slopTuberIds =
    [
        76561199195414858L, // linguini
        76561199354650051L  // gronf
    ];

    /// <summary>
    ///     Whether the currently logged-in user is a SlopTuber. >:(
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if the user is logged on and is a registered sloptuber,
    ///     otherwise <see langword="false" />
    /// </returns>
    public static bool IsSlopTuber => SteamClient.IsLoggedOn && slopTuberIds.Contains(SteamClient.SteamId);

    public static string Name => SteamClient.Name;
}