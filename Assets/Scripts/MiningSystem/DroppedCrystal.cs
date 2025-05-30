using UnityEngine;

public class DroppedCrystal : MonoBehaviour, ICollectible
{
    float distX;
    float distY;

    float rot;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        distX = Random.Range(0, 0.5f);
        distY = Random.Range(0, 0.5f);

        rot = Random.Range(0f, 360f);

        int signX = Random.Range(0, 2);
        int signY = Random.Range(0, 2);

        distX = signX > 0 ? distX : distX * -1;
        distY = signY > 0 ? distY : distY * -1;

        rb.AddForce(new Vector2(distX, distY), ForceMode2D.Impulse);
        rb.AddTorque((rot * Mathf.Deg2Rad) * rb.inertia, ForceMode2D.Impulse);
    }

    public void Collect()
    {

    }
}
