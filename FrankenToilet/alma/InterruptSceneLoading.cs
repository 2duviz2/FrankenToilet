using UnityEngine;
using HarmonyLib;
using UnityEngine.SceneManagement;
using FrankenToilet.Core;
using System;

/*
 * This piece of code is responsible for the jumpscare on scene load.
 * I am not responcible for any possible heart attacks caused from this.
 * 
 * To be honest, I wanted to include more, however I got mentally exhausted
 * trying to figure out how to do this. This doesn't even work the intented way.
 */
namespace FrankenToilet.alma;
[EntryPoint]
internal class InterruptSceneLoading : MonoBehaviour
{
    [EntryPoint]
    public static void Awake()
    {
        LogHelper.LogInfo("[alma] Started");
        try
        {
            AssetBundle bundle = Functions.GetBundle("FrankenToilet.alma.scenes.bundle");
            AssetBundle assetsBundle = Functions.GetBundle("FrankenToilet.alma.assets.bundle");
        }
        catch (Exception ex)
        {
            LogHelper.LogError($"[alma] Failed to load the bundle:{ex}");
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneHelper.CurrentScene != "Bootstrap")
        {
            try
            {
                Harmony.CreateAndPatchAll(typeof(InterruptSceneLoading));
            } catch (Exception ex) { LogHelper.LogError(ex); }

            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}

[PatchOnEntry]
[HarmonyPatch(typeof(SceneHelper), nameof(SceneHelper.LoadScene))]
public class PatchSceneHelperLoadScene
{
    public static bool Prefix()
    {
        int percentage = new System.Random().Next(1,101);
        if (percentage >= 90)
        {
            LogHelper.LogInfo("[alma] Loading into 'fear' scene...");
            SceneManager.LoadScene("fear");
            return false;
        }
        return true;
    }
}