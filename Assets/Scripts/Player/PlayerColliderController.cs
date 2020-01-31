using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class PlayerColliderController : MonoBehaviour
{
    PolygonCollider2D coll;
    HealthManager healthManager;
    void Start()
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

}
