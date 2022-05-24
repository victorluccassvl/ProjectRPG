using UnityEngine;

public class Teste : MonoBehaviour
{
    public InventorySO inventory;
    public void Start()
    {
        inventory = ScriptableObject.CreateInstance<InventorySO>();

        inventory.Setup(10);
    }
}
