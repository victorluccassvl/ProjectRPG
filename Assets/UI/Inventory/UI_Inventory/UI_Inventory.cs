using UnityEngine;

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

    [SerializeField] private RectTransform backgroundTransform;
    [SerializeField] private RectTransform mainLayoutTransform;

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

    float valueTest = 100f;
    Vector2 originalPos;

    private void Awake()
    {
        originalPos = Position;
    }
    private void Update()
    {
        Position = Vector2.zero;
    }

    private void OnEnable()
    {
        if (!IsValidData())
        {
            this.enabled = false;
            return;
        }

        Invoke("Setup", 1f);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void Expand(float horizontalOffset)
    {
        int columnsToAddOrRemove = Mathf.FloorToInt(horizontalOffset / (configData.slotSize + configData.slotSpacing));

        if (columnsToAddOrRemove == 0) return;
        if (columnsToAddOrRemove < 0 && configData.slotStartingColumns == 1) return;
        if (columnsToAddOrRemove > 0 && configData.slotStartingColumns + columnsToAddOrRemove > configData.inventoryData.Capacity) return;

        configData.slotStartingColumns += columnsToAddOrRemove;
        Setup();
    }

    private bool IsValidData()
    {
        return true;
    }

    private void Setup()
    {
        if (!IsValidData()) return;

        Vector2 position = Vector2.zero;

        float windowHeight = 0f;
        float windowWidth = configData.slotSize * configData.slotStartingColumns;
        windowWidth += (configData.slotStartingColumns + 1) * configData.slotSpacing;
        header.Setup(position, configData.headerText, windowWidth, configData.headerHeight, configData.headerButtonMargin, Close);

        int slotLines = Mathf.CeilToInt(((float)configData.inventoryData.Capacity) / configData.slotStartingColumns);
        position += Vector2.down * configData.headerHeight;
        slotGrid.Setup(position, configData.slotSize, configData.slotSpacing, configData.slotStartingColumns, slotLines, configData.inventoryData);

        float slotsHeight = slotLines * configData.slotSize + (slotLines + 1) * configData.slotSpacing;
        position += Vector2.down * slotsHeight;
        footer.Setup(position, configData.footerHeight, windowWidth, configData.footerAnchorMargin, Expand);

        windowHeight = configData.headerHeight + slotsHeight + configData.footerHeight;
        backgroundTransform.sizeDelta = new Vector2(windowWidth + configData.backgroundMargin * 2, windowHeight + configData.backgroundMargin * 2);
        backgroundTransform.anchoredPosition = configData.backgroundMargin * (Vector2.left + Vector2.up);
    }
}