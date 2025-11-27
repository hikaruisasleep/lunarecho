using MiningSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickupCounters : MonoBehaviour
{
    public static Dictionary<Crystal.CrystalType, int> collectedItems = new Dictionary<Crystal.CrystalType, int>();

    public TMP_Text pc;
    public TMP_Text yc;
    public TMP_Text gnc;
    public TMP_Text gyc;

    public GameObject canvasObject;

    void CollectItem(Crystal.CrystalType type)
    {
        Debug.Log(type.ToString());

        if (!collectedItems.ContainsKey(type))
        {
            collectedItems.Add(type, 1);
        }
        else if (collectedItems.ContainsKey(type))
        {
            collectedItems[type]++;
        }
    }

    private void OnEnable()
    {
        DroppedCrystal.OnShardCollected += CollectItem;
    }

    private void Start()
    {
        canvasObject = GameObject.Find("Canvas");
        pc = canvasObject.transform.Find("purp").GetComponent<TMP_Text>();
        yc = canvasObject.transform.Find("yelow").GetComponent<TMP_Text>();
        gnc = canvasObject.transform.Find("grn").GetComponent<TMP_Text>();
        gyc = canvasObject.transform.Find("gry").GetComponent<TMP_Text>();

        collectedItems.Add(Crystal.CrystalType.Purple, 0);
        collectedItems.Add(Crystal.CrystalType.Yellow, 0);
        collectedItems.Add(Crystal.CrystalType.Green, 0);
        collectedItems.Add(Crystal.CrystalType.Gray, 0);
    }

    private void Update()
    {
        pc.text = collectedItems[Crystal.CrystalType.Purple].ToString();
        yc.text = collectedItems[Crystal.CrystalType.Yellow].ToString();
        gnc.text = collectedItems[Crystal.CrystalType.Green].ToString();
        gyc.text = collectedItems[Crystal.CrystalType.Gray].ToString();
    }
}
