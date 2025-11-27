using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap interactiveMap;
    [SerializeField] private Tile hoverTile;

    private Vector3Int previousMousePos = new Vector3Int();

    private Vector2 surface;

    private Transform player;
    private float distance;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3Int mousePos = GetMousePosition();


        if (!mousePos.Equals(previousMousePos) && distance < 1.5f)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(surface.x, surface.y));
            {
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("MineableCrystal"))
                {
                    interactiveMap.SetTile(previousMousePos, null);
                    interactiveMap.SetTile(mousePos, hoverTile);
                    previousMousePos = mousePos;
                }
            }
        }

    }

    Vector3Int GetMousePosition()
    {
        surface = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(surface.x, surface.y));
        return grid.WorldToCell(mouseWorldPos);
    }

}
