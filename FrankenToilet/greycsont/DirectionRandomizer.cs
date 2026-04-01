using UnityEngine;

using FrankenToilet.Core;

namespace FrankenToilet.greycsont;


public static class DirectionRandomizer
{
    public static int randomDirection;

    public static void GenerateRandomDirection() => randomDirection = Random.Range(0, 4);

    public static Vector3 Randomize4Dir(Vector3 direction)
    {
        Vector3 resultDir;

        var camT = MonoSingleton<CameraController>.Instance?.transform;

        switch ((Direction)randomDirection)
        {
            case Direction.Upwards:
                resultDir = camT.up;
                break;
            case Direction.Backwards:
                resultDir = -direction;
                break;
            case Direction.Right:
                if (Mathf.Abs(Vector3.Dot(direction.normalized, Vector3.up)) > 0.94f)
                    resultDir = Quaternion.AngleAxis(90, camT.up) * direction;
                else
                {
                    resultDir = Quaternion.AngleAxis(90, Vector3.up) * direction;
                    resultDir.y = -resultDir.y;
                }
                break;
            case Direction.Left:
                if (Mathf.Abs(Vector3.Dot(direction.normalized, Vector3.up)) > 0.94f)
                {
                    resultDir = Quaternion.AngleAxis(-90, camT.up) * direction;
                    resultDir.y = -resultDir.y;
                }
                else
                {
                    resultDir = Quaternion.AngleAxis(-90, Vector3.up) * direction;
                    resultDir.y = -resultDir.y;
                }

                break;
            default:
                resultDir = direction;
                LogHelper.LogDebug("[greycsont] FUCK IENUMERATOR");
                break;
        }

        LogHelper.LogDebug($"[greycsont] Direction: {(Direction)randomDirection}");
        LogHelper.LogDebug($"[greycsont] input: {direction.x} {direction.y} {direction.z}");
        LogHelper.LogDebug($"[greycsont] resultDir: {resultDir.x} {resultDir.y} {resultDir.z}");

        return resultDir;;
    }
}


