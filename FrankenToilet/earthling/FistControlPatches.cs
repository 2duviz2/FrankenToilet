using UnityEngine;
using FrankenToilet.Core;
using HarmonyLib;

namespace FrankenToilet.earthling;

[PatchOnEntry]
[HarmonyPatch(typeof(FistControl))]
public static class FistControlPatches
{
    [HarmonyPrefix]
    [HarmonyPatch("UpdateFistIcon")]
    public static void SwapArmsBeforeUpdatingIcon(FistControl __instance)
    {
        __instance.currentVarNum = (__instance.currentVarNum + 1) % 2;
    }

    [HarmonyPostfix]
    [HarmonyPatch("UpdateFistIcon")]
    public static void SwapArmsAfterUpdatingIcon(FistControl __instance)
    {
        __instance.currentVarNum = (__instance.currentVarNum + 1) % 2;
    }
}