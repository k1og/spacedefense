using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlanetColliderController : MonoBehaviour
{
    HealthManager healthManager;

    void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag != "Player")
        {
            healthManager = collider.gameObject.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.Kill();
            }
        }
    }

}
