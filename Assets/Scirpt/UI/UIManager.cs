using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1f), fadeTime, false).SetEase(Ease.InOutQuart);
        canvasGroup.DOFade(1, fadeTime);
    }
}
