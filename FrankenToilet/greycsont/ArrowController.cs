using UnityEngine;
using UnityEngine.UI;
using FrankenToilet.Core;
using FrankenToilet.mercy.Features;

namespace FrankenToilet.greycsont;

public static class ArrowController
{
    public static Canvas canvas => UnityPathHelper.FindCanvas();
    public static GameObject imgObj
    {
        get
        {
            if (field == null)
            {
                field = new GameObject("HammerArrowIndicator");
                imgObj.transform.SetParent(canvas.transform, false);
                imgObj.transform.SetAsLastSibling();
            }
            return field;
        }
        set;
    }
    public static AudioSource source
    {
        get
        {
            return imgObj.GetComponent<AudioSource>() ?? imgObj.AddComponent<AudioSource>();
        }
    }

    public static void GenerateImage(float timeInSeconds)
    {
        LogHelper.LogDebug($"[greycsont] truestop time: {timeInSeconds}");

        var hammer = ShotgunHammerPatch.lastActiveHammer;
        if (hammer == null) return;
        if (hammer.target == null) return;
        if (hammer.hitEnemy == null) return;

        if (canvas == null) return;

        imgObj = new GameObject("HammerArrowIndicator");

        var clip = AssetBundleController.audioCaches["sam_" + DirectionRandomizer.randomDirection];

        if (clip != null)
        {
            source.SetSpatialBlend(0f);
            source.volume = 1f;
            source.PlayOneShot(clip, 1f);
        }

        var img = imgObj.AddComponent<Image>();
        img.sprite = AssetBundleController.arrowSprites[Random.Range(0, AssetBundleController.arrowSprites.Length)];
        img.SetNativeSize();

        var color = img.color;
        color.a = 0.7f;
        img.color = color;

        var rect = imgObj.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;

        rect.localEulerAngles = new Vector3(0, 0, -90f * DirectionRandomizer.randomDirection);

        rect.localScale = new Vector3(1.3f, 1.3f, 1.3f);

        imgObj.AddComponent<DestoryTimer>().lifetime = timeInSeconds;

        LogHelper.LogDebug($"[greycsont] created {img.name}");

    }
}