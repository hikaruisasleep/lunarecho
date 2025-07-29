using UnityEngine;

public class InventoryManager : MonoBehaviour
{
<<<<<<< HEAD

=======
    public static InventoryManager instance { get; private set; }

    public InventorySlot[] slots;
    public GameObject itemPrefab;

    public void AddItem(ScriptableInventoryItem item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.GetComponentInChildren<ScriptableInventoryItem>() == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    public void SpawnNewItem(ScriptableInventoryItem item, InventorySlot slot)
    {
        GameObject newItemGO = Instantiate(itemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();

        inventoryItem.InitializeItem(item);
    }
>>>>>>> 39a5b7f (lol)
}
