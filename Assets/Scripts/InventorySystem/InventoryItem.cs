using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;

    [HideInInspector] public Transform reparent;
    [HideInInspector] public ScriptableInventoryItem item;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void InitializeItem(ScriptableInventoryItem inventoryItem)
    {
        item = inventoryItem;
        image.sprite = inventoryItem.image;
    }

    public void OnBeginDrag(PointerEventData e)
    {
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData e)
    {
        transform.position = Mouse.current.position.ReadValue();
        reparent = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnEndDrag(PointerEventData e)
    {
        image.raycastTarget = true;
        transform.SetParent(reparent);
    }


}
