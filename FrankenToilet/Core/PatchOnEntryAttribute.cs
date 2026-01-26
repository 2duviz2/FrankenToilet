using System;
using JetBrains.Annotations;

namespace FrankenToilet.Core;

/// <summary>
///     Marker attribute to indicate that a patch class will be applied in the Plugin.Awake method.
/// </summary>
[PublicAPI]
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal sealed class PatchOnEntryAttribute : Attribute;