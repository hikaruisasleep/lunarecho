using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    public Sprite inventorySlotSprite;
    public Sprite inventorySlotSpriteSelected;

    public Image imageRenderer;

    void Start()
    {
        imageRenderer = GetComponent<Image>();
        imageRenderer.sprite = inventorySlotSprite;
    }
}
