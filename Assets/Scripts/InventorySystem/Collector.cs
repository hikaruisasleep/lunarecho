using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crystal = collision.GetComponent<DroppedCrystal>();
    }
}
