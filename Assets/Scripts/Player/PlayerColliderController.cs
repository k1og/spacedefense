using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class PlayerColliderController : MonoBehaviour, IExplodable
{
    PolygonCollider2D coll;
    HealthManager healthManager;
    public GameObject explosion;
    void Awake()
    {
        coll = GetComponent<PolygonCollider2D>();
        coll.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.name != "Planet")
        {
            healthManager = collider.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.Kill();
            }
        }
    }

    public void Explode()
    {
        GameObject explosionInstanse = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionInstanse, 1);
    }

}
