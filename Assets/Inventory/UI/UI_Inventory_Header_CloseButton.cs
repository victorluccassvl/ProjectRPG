using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
public class UI_Inventory_Header_CloseButton : MonoBehaviour
{
    [SerializeField] private RectTransform closeButtonRectTransform;
    [SerializeField] private Button closeButton;
    private Action closeAction = null;

    private void Awake()
    {
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