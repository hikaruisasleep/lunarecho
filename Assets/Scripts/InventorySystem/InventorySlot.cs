using UnityEngine.EventSystems;

public class InventorySlot : Slot, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public void OnPointerEnter(PointerEventData e)
    {
        imageRenderer.sprite = inventorySlotSpriteSelected;
    }

    public void OnPointerExit(PointerEventData e)
    {
        imageRenderer.sprite = inventorySlotSprite;
    }

    public void OnDrop(PointerEventData e)
    {
        if (transform.childCount == 0)
        {
            InventoryItem item = e.pointerDrag.GetComponent<InventoryItem>();
            item.reparent = transform;
        }
    }
}
