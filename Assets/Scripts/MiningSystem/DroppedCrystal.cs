<<<<<<< HEAD
=======
using MiningSystem;
>>>>>>> 39a5b7f (lol)
using UnityEngine;

public class DroppedCrystal : MonoBehaviour, ICollectible
{
    float distX;
    float distY;

    float rot;

    Rigidbody2D rb;

<<<<<<< HEAD
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

=======
    [SerializeField] Crystal.CrystalType crystalType;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
>>>>>>> 39a5b7f (lol)
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

<<<<<<< HEAD
    public void Collect()
    {

=======
    public static event System.Action<Crystal.CrystalType> OnShardCollected = delegate { };
    bool isFollowing;
    Vector3 target;

    public void Collect()
    {
        Destroy(gameObject);
        OnShardCollected?.Invoke(crystalType);
    }

    void FixedUpdate()
    {
        if (isFollowing)
        {
            Vector2 targetDir = (target - transform.position).normalized;
            rb.linearVelocity = new Vector2(targetDir.x, targetDir.y) * 2f;
        }
    }

    public void setTarget(Vector3 pos)
    {
        target = pos;
        isFollowing = true;
>>>>>>> 39a5b7f (lol)
    }
}
