using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Canvas))]
public class UI_Inventory : MonoBehaviour
{
    [Header("Configuration Data")]
    [SerializeField] private UI_InventorySO configData;

    [Space(10)]
    [Header("Editor References")]
    [SerializeField] private UI_Inventory_Header header;
    [SerializeField] private UI_Inventory_SlotGrid slotGrid;
    [SerializeField] private UI_Inventory_Footer footer;

    [SerializeField] private RectTransform mainLayoutTransform;

    private CanvasScaler canvasScaler;
    private CanvasScaler CanvasScaler
    {
        get
        {
            if (canvasScaler == null) canvasScaler = GetComponent<CanvasScaler>();

            return canvasScaler;
        }
        set
        {
            canvasScaler = value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return mainLayoutTransform.anchoredPosition;
        }
        set
        {
            mainLayoutTransform.anchoredPosition = value;
        }
    }

    private void OnEnable()
    {
        if (!IsValidData())
        {
            this.enabled = false;
            return;
        }

        Invoke("Teste", 2f);
    }

    public void Teste()
    {
        Setup(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Drag(Vector2 dragDeltaScreenPosition)
    {
        float scaleRatio = CanvasScaler.ScreenScaleRatio();
        Vector2 localSpaceDelta = dragDeltaScreenPosition * scaleRatio;

        Vector2 position;
        position = Position + localSpaceDelta;
        position.x = Mathf.Clamp(position.x, 0f, CanvasScaler.referenceResolution.x - mainLayoutTransform.sizeDelta.x);
        position.y = Mathf.Clamp(position.y, 0f, CanvasScaler.referenceResolution.y - mainLayoutTransform.sizeDelta.y);

        Position = position;
    }

    private bool IsValidData()
    {
        return true;
    }

    private void Setup(Vector2 groupPosition)
    {
        if (!IsValidData()) return;

        int columns, lines;
        columns = Mathf.CeilToInt(Mathf.Sqrt(configData.inventoryData.Capacity));
        lines = Mathf.FloorToInt(Mathf.Sqrt(configData.inventoryData.Capacity));

        float windowHeight = 0f;
        float windowWidth = configData.slotSize * columns + (columns + 1) * configData.slotSpacing;

        Vector2 elementPosition = configData.backgroundMargin * (Vector2.up + Vector2.right);
        footer.Setup(elementPosition, windowWidth, configData.footerHeight, configData.footerAnchorMargin);

        elementPosition += Vector2.up * configData.footerHeight;
        float slotsHeight = lines * configData.slotSize + (lines + 1) * configData.slotSpacing;
        slotGrid.Setup(elementPosition, configData.slotSize, configData.slotSpacing, lines, columns, configData.inventoryData);

        elementPosition += Vector2.up * slotsHeight;
        header.Setup(elementPosition, configData.headerText, windowWidth, configData.headerHeight, configData.headerButtonMargin, Close, Drag);

        windowHeight = configData.headerHeight + slotsHeight + configData.footerHeight;

        mainLayoutTransform.anchoredPosition = groupPosition;
        mainLayoutTransform.sizeDelta = new Vector2(windowWidth, windowHeight) + 2 * configData.backgroundMargin * Vector2.one;
    }
}