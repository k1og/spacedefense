using UnityEngine;

// Consider separation
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 transformUp;

    // FIXME: speed 0.05 pool lags
    public float speed = 150;
    public int damage = 1;

    Vector2 topLeftCamCorner;
    float farthestVisibleDistance;
    float bulletDistance;
    float offset = 10;

    void OnEnable()
    {
        bulletDistance = 0;
        transformUp = new Vector2(transform.up.x, transform.up.y);
    }

    void Start() 
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        topLeftCamCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, -Camera.main.transform.position.z));
        farthestVisibleDistance = Vector2.Distance(topLeftCamCorner, Vector2.zero);
    }

    void FixedUpdate()
    {
        bulletDistance = Vector2.Distance(rb.transform.position, Vector2.zero);
        rb.position = rb.position + transformUp * speed * Time.fixedDeltaTime;
    }

    void Update()
    {
        // TODO: Separate in general component ?
        if (farthestVisibleDistance + offset < bulletDistance)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag != "Player" && collider.tag != "Bullet")
        {
            HealthManager healthManager = collider.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damage);
            }
            this.gameObject.SetActive(false);
        }
    }
}
