using UnityEngine;

[CreateAssetMenu(fileName = "UI_InventorySO", menuName = "ScriptableObjects/UI_InventorySO")]
public class UI_InventorySO : ScriptableObject
{
    public InventorySO inventoryData;

    public string headerText;
    public float headerHeight;
    public float headerButtonMargin;

    public float slotSize;
    public float slotSpacing;
    public int slotStartingColumns;

    public float footerHeight;
    public float footerAnchorMargin;

    public float backgroundMargin;
}