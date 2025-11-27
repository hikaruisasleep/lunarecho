using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableInventoryItem", menuName = "Scriptable Objects/ScriptableInventoryItem")]
public class ScriptableInventoryItem : ScriptableObject
{
    public Sprite image;
    public bool stackable = true;
}
