using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayerVitalsSystem;

public class PlayerSpawnSetup : MonoBehaviour
{
    public GameObject canvasObject;
    private Canvas canvas;
    private VitalsManager vitalsManager;
    private UISwitchingManager uiSwitcher;
    private ItemPickupCounters itemCounters;

    void Start()
    {
        canvasObject = GameObject.Find("Canvas");

//        vitalsManager = GetComponent<VitalsManager>();
        uiSwitcher = GetComponent<UISwitchingManager>();
        itemCounters = GetComponent<ItemPickupCounters>();

//        vitalsManager.oxygenSlider = canvasObject.transform.Find("OxygenSlider").GetComponent<Slider>();
//        vitalsManager.healthSlider = canvasObject.transform.Find("HealthSlider").GetComponent<Slider>();

        itemCounters.pc = canvasObject.transform.Find("purp").GetComponent<TMP_Text>();
        itemCounters.yc = canvasObject.transform.Find("yelow").GetComponent<TMP_Text>();
        itemCounters.gnc = canvasObject.transform.Find("grn").GetComponent<TMP_Text>();
        itemCounters.gyc = canvasObject.transform.Find("gry").GetComponent<TMP_Text>();

        Debug.Log(itemCounters.pc);
        Debug.Log(itemCounters.yc);
        Debug.Log(itemCounters.gnc);
        Debug.Log(itemCounters.gyc);
    }
}
