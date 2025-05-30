using UnityEngine;

namespace ConstructionSystem
{
    public class ConstructableLayer : TilemapLayer
    {
        public void Construct(Vector3 worldCoordinates, ConstructableBlock block)
        {
            var coordinates = _tilemap.WorldToCell(worldCoordinates);

            if (block.Tile != null)
            {
                _tilemap.SetTile(coordinates, block.Tile);
            }
        }
    }
}