using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

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

        [SerializeField] private bool hovered;

        public GameObject CrystalDropPrefab;

        private Transform xf;

        public Transform interactiblesGridLayer;

        private void Start()
        {
            xf = GetComponent<Transform>();
            interactiblesGridLayer = GameObject.Find("Interactibles").transform;
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
            hovered = true;
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Mining);
        }

        private void ExitEvent()
        {
            hovered = false;
            CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (hovered)
            {
                Destroy(gameObject);
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);

                // spawn drops how
                InstantiateCrystalDrop(crystalType);
            }
        }

        private void InstantiateCrystalDrop(CrystalType crystalType)
        {
            int dropAmount = Random.Range(1, 6);
            Debug.Log("DROP " + dropAmount);
            foreach (var d in Enumerable.Range(0, dropAmount))
            {
                Instantiate(CrystalDropPrefab, xf.position, Quaternion.identity, interactiblesGridLayer);
            }
        }
    }
}