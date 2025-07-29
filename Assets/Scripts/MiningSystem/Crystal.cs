using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
<<<<<<< HEAD
=======
using UnityEngine.Tilemaps;
>>>>>>> 39a5b7f (lol)

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

<<<<<<< HEAD
        [SerializeField] private bool hovered;
=======
        private Grid grid;

        [SerializeField] private bool hovered;
        [SerializeField] private bool near;
>>>>>>> 39a5b7f (lol)

        public GameObject CrystalDropPrefab;

        private Transform xf;
<<<<<<< HEAD

        public Transform interactiblesGridLayer;

        private void Start()
        {
            xf = GetComponent<Transform>();
            interactiblesGridLayer = GameObject.Find("Interactibles").transform;
=======
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
>>>>>>> 39a5b7f (lol)
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
<<<<<<< HEAD
            hovered = true;
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
=======
            if (near)
            {
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
                hovered = true;
                interactiblesTilemap.SetTile(cell, hoverTile);
            }
>>>>>>> 39a5b7f (lol)
        }

        private void ExitEvent()
        {
<<<<<<< HEAD
            hovered = false;
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
=======
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
            hovered = false;
            interactiblesTilemap.SetTile(cell, null);
>>>>>>> 39a5b7f (lol)
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (hovered)
            {
<<<<<<< HEAD
                Destroy(gameObject);
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);

                // spawn drops how
=======
                ExitEvent();
                Destroy(gameObject);
>>>>>>> 39a5b7f (lol)
                InstantiateCrystalDrop(crystalType);
            }
        }

        private void InstantiateCrystalDrop(CrystalType crystalType)
        {
            int dropAmount = Random.Range(1, 6);
            Debug.Log("DROP " + dropAmount);
            foreach (var d in Enumerable.Range(0, dropAmount))
            {
<<<<<<< HEAD
                Instantiate(CrystalDropPrefab, xf.position, Quaternion.identity, interactiblesGridLayer);
=======
                Instantiate(CrystalDropPrefab, xf.position, Quaternion.identity, interactiblesTilemap.GetComponent<Transform>());
>>>>>>> 39a5b7f (lol)
            }
        }
    }
}