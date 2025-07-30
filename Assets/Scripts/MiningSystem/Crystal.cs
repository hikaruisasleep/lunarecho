using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace MiningSystem
{
    public class Crystal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public enum CrystalType
        {
            Purple,
            Green,
            Yellow,
            Gray
        }

        public CrystalType crystalType;

        private Grid grid;

        [SerializeField] private bool hovered;
        [SerializeField] private bool near;

        public GameObject CrystalDropPrefab;

        private Transform xf;
        private Tilemap interactiblesTilemap;
        private Transform player;

        public Tile hoverTile;

        Vector3Int cell;

        void Awake()
        {
            grid = GameObject.FindAnyObjectByType<Grid>();
            xf = GetComponent<Transform>();
            interactiblesTilemap = gameObject.GetComponentInParent<Tilemap>();
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        void Update()
        {
            float distance = Vector3.Distance(xf.position, player.position);

            if (distance < 1.5f)
            {
                near = true;
                cell = grid.WorldToCell(xf.position);
            }
            else
            {
                near = false;
            }
        }

        public void OnPointerEnter(PointerEventData e)
        {
            EnterEvent();
        }

        public void OnPointerExit(PointerEventData e)
        {
            ExitEvent();
        }

        private void EnterEvent()
        {
            if (near)
            {
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
                hovered = true;
                interactiblesTilemap.SetTile(cell, hoverTile);
            }
        }

        private void ExitEvent()
        {
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
            hovered = false;
            interactiblesTilemap.SetTile(cell, null);
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (hovered)
            {
                ExitEvent();
                Destroy(gameObject);
                InstantiateCrystalDrop(crystalType);
            }
        }

        private void InstantiateCrystalDrop(CrystalType crystalType)
        {
            int dropAmount = Random.Range(1, 6);
            Debug.Log("DROP " + dropAmount);
            foreach (var d in Enumerable.Range(0, dropAmount))
            {
                Instantiate(CrystalDropPrefab, xf.position, Quaternion.identity, interactiblesTilemap.GetComponent<Transform>());
            }
        }
    }
}