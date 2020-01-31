using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AsteroidController : MonoBehaviour, IExplodable
{
    public PoolManager asteroidExplosionPool;
    GameObject currentaAsteroidExplosion;
    GameObject tempAsteroidExplosion;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        asteroidExplosionPool = GameObject.Find("AsteroidExplosionPool").GetComponent<PoolManager>();
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        HealthManager healthManager = collider.gameObject.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.TakeDamage(damage);
        }
    }


    public void Explode()
    {
        for (int i = 0; i < asteroidExplosionPool.gameObjectsList.Count; i++)
        {
            if (asteroidExplosionPool.gameObjectsList[i].activeInHierarchy == false)
            {
                currentaAsteroidExplosion = asteroidExplosionPool.gameObjectsList[i];
                currentaAsteroidExplosion.transform.position = transform.position;
                currentaAsteroidExplosion.SetActive(true);
                break;
            }
            else
            {
                if (i == asteroidExplosionPool.gameObjectsList.Count - 1)
                {
                    tempAsteroidExplosion = Instantiate(asteroidExplosionPool.prefab);
                    tempAsteroidExplosion.SetActive(false);
                    tempAsteroidExplosion.transform.parent = asteroidExplosionPool.transform;
                    asteroidExplosionPool.gameObjectsList.Add(tempAsteroidExplosion);
                }
            }
        }
    }
}
