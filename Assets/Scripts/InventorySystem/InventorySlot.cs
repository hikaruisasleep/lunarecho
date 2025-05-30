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
        imageRenderer.sprite = inventorySlotSpriteSelected;
    }

    public void OnPointerExit(PointerEventData e)
    {
        currentlySelected = false;
        imageRenderer.sprite = inventorySlotSprite;
    }
}
