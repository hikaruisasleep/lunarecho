using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UISwitchingManager : MonoBehaviour
{
    InputActionMap actionMap_game;
    InputAction invKey;
    InputAction bldKey;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject invCanvas;

    [SerializeField] private bool isInBuildMode = false;

    private List<GameObject> canvases = new();

    void Start()
    {
        actionMap_game = InputSystem.actions.FindActionMap("Game");
        invKey = actionMap_game.FindAction("Inventory");
        bldKey = actionMap_game.FindAction("Build Mode");

        if (!mainCanvas) Debug.LogError("Main UI Canvas not set");
        if (invCanvas) canvases.Add(invCanvas);
    }

    void Update()
    {
        if (invKey.WasPressedThisFrame())
        {
            if (invCanvas.activeSelf == true || invCanvas.activeInHierarchy == true)
            {
                MainUI();
            }
            else
            {
                OpenInventoryWindow();
            }
        }

        if (bldKey.WasPressedThisFrame())
        {
            if (!isInBuildMode)
            {
                isInBuildMode = true;
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Build);
            }
            else
            {
                isInBuildMode = false;
                CursorManager.instance.SetCursor(CursorManager.CursorStatus.Default);
            }
        }
    }

    void OpenInventoryWindow()
    {
        mainCanvas.SetActive(false);
        invCanvas.SetActive(true);
    }

    void MainUI()
    {
        foreach (GameObject c in canvases)
        {
            c.SetActive(false);
        }
        mainCanvas.SetActive(true);
    }
}
