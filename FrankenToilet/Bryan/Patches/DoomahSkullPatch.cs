namespace FrankenToilet.Bryan.Patches;

using FrankenToilet.Core;
using HarmonyLib;
using UnityEngine;

/// <summary> Turns every skull into doomah. </summary>
[PatchOnEntry]
[HarmonyPatch(typeof(Skull))]
public static class DoomahSkullPatch
{
    /// <summary> dooooooooooooomaaaaaaaaaah2 </summary>
    [HarmonyPrefix]
    [HarmonyPatch("Awake")]
    public static void dooooooomahhhhh2(Skull __instance) // i was gonna make blue skulls be blue heavy but i couldnt find the textures for that so deal with it
    {
        var oldSkull = __instance.transform.Find("NewSkull");
        oldSkull.gameObject.SetActive(false);

        var doomah = Object.Instantiate(BundleLoader.Doomah, __instance.transform);
        doomah.transform.localPosition = new(-0.2f, 0f, -0.5f);
        doomah.transform.localEulerAngles = new(0f, 20f, 0f);

        foreach (var mat in doomah.GetComponent<MeshRenderer>().materials)
            mat.shader = DefaultReferenceManager.Instance.masterShader;
    }
}