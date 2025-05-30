using UnityEngine;
using UnityEngine.Tilemaps;

namespace ConstructionSystem
{
    [CreateAssetMenu(menuName = "Construction/New Constructable Block", fileName = "New Constructable Block")]
    public class ConstructableBlock : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public TileBase Tile { get; private set; }
    }
}