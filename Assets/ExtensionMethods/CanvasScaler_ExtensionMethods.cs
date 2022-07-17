using UnityEngine;
using UnityEngine.UI;

public static class CanvasScalerExtensionMethods
{
    public static float ScreenScaleRatio(this CanvasScaler scaler)
    {
        Vector2 referenceResolution = scaler.referenceResolution;
        Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

        float widthRatio = currentResolution.x / referenceResolution.x;
        float heightRatio = currentResolution.y / referenceResolution.y;
        float ratio = Mathf.Lerp(widthRatio, heightRatio, scaler.matchWidthOrHeight);

        return 1 / ratio;
    }
}
