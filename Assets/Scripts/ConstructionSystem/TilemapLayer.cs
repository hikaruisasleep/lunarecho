using UnityEngine;
using UnityEngine.Tilemaps;

namespace ConstructionSystem
{
    [RequireComponent(typeof(Tilemap))]
    public class TilemapLayer : MonoBehaviour
    {
        protected Tilemap _tilemap { get; private set; }

        protected void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
        }
    }
}