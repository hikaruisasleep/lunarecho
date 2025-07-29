<<<<<<< HEAD
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite inventorySlotSprite;
    public Sprite inventorySlotSpriteSelected;

    private Image imageRenderer;

    [SerializeField] private bool currentlySelected;

    void Start()
    {
        imageRenderer = GetComponent<Image>();
        imageRenderer.sprite = inventorySlotSprite;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        currentlySelected = true;
=======
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public void OnPointerEnter(PointerEventData e)
    {
>>>>>>> 39a5b7f (lol)
        imageRenderer.sprite = inventorySlotSpriteSelected;
    }

    public void OnPointerExit(PointerEventData e)
    {
<<<<<<< HEAD
        currentlySelected = false;
        imageRenderer.sprite = inventorySlotSprite;
    }
=======
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
>>>>>>> 39a5b7f (lol)
}
