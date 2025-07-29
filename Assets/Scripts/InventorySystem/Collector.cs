using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        var crystal = collision.GetComponent<DroppedCrystal>();
=======
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collect();
        }
>>>>>>> 39a5b7f (lol)
    }
}
