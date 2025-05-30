using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager instance { get; private set; }

    [SerializeField] private Texture2D defaultCursorTexture;
    [SerializeField] private Texture2D buildCursorTexture;
    [SerializeField] private Texture2D miningCursorTexture;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursor(CursorStatus stat)
    {
        switch (stat)
        {
            case CursorStatus.Default:
                Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
                break;
            case CursorStatus.Build:
                Cursor.SetCursor(buildCursorTexture, new Vector2(buildCursorTexture.width * 0.5f, buildCursorTexture.height * 0.5f), CursorMode.Auto);
                break;
            case CursorStatus.Mining:
                Cursor.SetCursor(miningCursorTexture, Vector2.zero, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
                break;
        }
    }

    public enum CursorStatus
    {
        Default, Build, Mining
    }
}
