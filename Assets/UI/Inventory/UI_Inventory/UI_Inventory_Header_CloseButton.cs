using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
public class UI_Inventory_Header_CloseButton : MonoBehaviour
{
    private Action closeAction = null;
    private Button closeButton;
    private RectTransform closeButtonRectTransform;

    private void Awake()
    {
        closeButton = GetComponent<Button>();
        closeButtonRectTransform = GetComponent<RectTransform>();

        closeButton.onClick.AddListener(() => closeAction?.Invoke());
    }

    public void Setup(float height, float margin, Action closeAction)
    {
        this.closeAction = closeAction;

        Vector2 buttonSizeDelta;
        buttonSizeDelta.x = height - margin * 2;
        buttonSizeDelta.y = height - margin * 2;

        closeButtonRectTransform.sizeDelta = buttonSizeDelta;
        closeButtonRectTransform.anchoredPosition = Vector3.left * margin;
    }
}