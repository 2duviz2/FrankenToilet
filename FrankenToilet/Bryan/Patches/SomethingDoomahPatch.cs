namespace FrankenToilet.Bryan.Patches;

using FrankenToilet.Core;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Something Doomah this way comes, replaces something wicked with a png of doomah. </summary>
[PatchOnEntry]
[HarmonyPatch(typeof(Wicked))]
public static class SomethingDoomahPatch
{
    /// <summary> dooooooooooooomaaaaaaaaaah </summary>
    [HarmonyPrefix]
    [HarmonyPatch("Start")]
    public static void dooooooomahhhhh(Wicked __instance)
    {
        __instance.transform.Find("SomethingWicked").gameObject.SetActive(false);

        var doomah = Object.Instantiate(BundleLoader.DoomahReal, __instance.transform);
        doomah.transform.localPosition = new(0f, 5f, 0f);
        foreach (var mat in doomah.GetComponent<MeshRenderer>().materials)
            mat.shader = DefaultReferenceManager.Instance.masterShader;
    }
}