namespace FrankenToilet.Bryan;

using FrankenToilet.Core;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Video;

/// <summary> Die </summary>
public static class BundleLoader
{
    /// <summary> Spooky scary asset bundle oooooo </summary>
    public static AssetBundle assetBundle;

    /// <summary> amercia </summary>
    public static VideoClip Amercia;

    /// <summary> Comic sands. </summary>
    public static TMP_FontAsset ComicSands;

    /// <summary> Comic sands. </summary>
    public static Font ComicSandsLegacy;

    /// <summary> silly </summary>
    public static Sprite UlraKil, ulakill, DoomahImg, Trans;

    /// <summary> the budget was dropped for maurice </summary>
    public static GameObject MauriceBad;

    /// <summary> Real doomah trust </summary>
    public static GameObject DoomahReal, Doomah;

    /// <summary> ULTRAKILL projectile prefab. </summary>
    public static GameObject Projectile;

    /// <summary> ha ha ha ha </summary>
    public static RuntimeAnimatorController BadLaughingSkullAnim;

    /// <summary> such an evil lil fella :3 </summary>
    public static AudioClip BadLaughing;

    /// <summary> Load the asset bundle. </summary>
    public static void Load()
    {
        GrabEmbeddedBundle();

        Amercia = assetBundle.LoadAsset<VideoClip>("assets/amercia.mp4");
        ComicSands = assetBundle.LoadAsset<TMP_FontAsset>("assets/comicsans.asset");
        ComicSandsLegacy = assetBundle.LoadAsset<Font>("assets/comicsanslegacy.ttf");
        UlraKil = assetBundle.LoadAsset<Sprite>("assets/ultrakill wingdings.png");
        ulakill = assetBundle.LoadAsset<Sprite>("assets/title.png");
        DoomahImg = assetBundle.LoadAsset<Sprite>("assets/doomah.png");
        Trans = assetBundle.LoadAsset<Sprite>("assets/trans.png");
        MauriceBad = assetBundle.LoadAsset<GameObject>("assets/mauricebad.prefab");
        DoomahReal = assetBundle.LoadAsset<GameObject>("assets/doomahreal.prefab");
        Doomah = assetBundle.LoadAsset<GameObject>("assets/doomah.prefab");
        BadLaughingSkullAnim = assetBundle.LoadAsset<RuntimeAnimatorController>("assets/bad laughing skull.controller");
        BadLaughing = assetBundle.LoadAsset<AudioClip>("assets/1bitahh.mp3");

        Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Attacks and Projectiles/Projectile.prefab").WaitForCompletion();
        Projectile = Addressables.LoadAssetAsync<GameObject>("Assets/Prefabs/Attacks and Projectiles/Projectile.prefab").WaitForCompletion();
    }

    /// <summary> Grabs the embedded asset bundle. </summary>
    public static void GrabEmbeddedBundle()
    {
        // get the stream for the embedded asset bundle
        Stream bundleStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FrankenToilet.Bryan.fuckyou.bundle");

        // load the asset bundle (ty unity for adding loadfromstream)
        assetBundle = AssetBundle.LoadFromStream(bundleStream);
    }

    #region Debug

    /// <summary> Gets all the asset names in the asset bundle and logs it. </summary>
    public static void GetAllAssetNames() => // assets/amercia.mp4, assets/comicsans.asset, assets/minos prime.wav, assets/ultrakill wingdings.png
        LogHelper.LogInfo(string.Join(", ", assetBundle.GetAllAssetNames()));

    /// <summary> Grabs all the paths to all embedded assets and logs it. </summary>
    public static void GrabEmbeddedAssetPaths() =>
        LogHelper.LogInfo($"Embedded Assets: {string.Join(", ", Assembly.GetExecutingAssembly().GetManifestResourceNames())}");

    #endregion
}
