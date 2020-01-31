using UnityEngine;
using System.Collections;

public abstract class BaseSpawner : MonoBehaviour
{
    public PoolManager objectPool;
    public GameObject currentObject;
    GameObject tempObject;
    public float spawnRate = 1f;

    virtual public void Start()
    {
        StartSpawning();
    }

    IEnumerator StartSpawningCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(StartSpawningCoroutine());
    }

    public void StopSpawning()
    {
        StopCoroutine(StartSpawningCoroutine());
    }

    virtual public void Spawn()
    {
        for (int i = 0; i < objectPool.gameObjectsList.Count; i++)
        {
            if (objectPool.gameObjectsList[i].activeInHierarchy == false)
            {
                currentObject = objectPool.gameObjectsList[i];
                BeforeSpawn();
                currentObject.SetActive(true);
                break;
            }
            else
            {
                if (i == objectPool.gameObjectsList.Count - 1)
                {
                    tempObject = Instantiate(objectPool.prefab);
                    tempObject.SetActive(false);
                    tempObject.transform.parent = objectPool.transform;
                    objectPool.gameObjectsList.Add(tempObject);
                }
            }
        }
    }
    abstract public void BeforeSpawn();
    public Vector2 GenerateRandomPosition() 
    {
        Vector2 topLeftCamCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, -Camera.main.transform.position.z));
        float offset = 5;
        float radius = Vector3.Distance(topLeftCamCorner, Vector2.zero) + offset;
        float angle = Random.Range(Mathf.PI / 6, 5 * Mathf.PI / 6);;
        if (Random.Range(0, 2) == 0)
        {
            angle = -angle;
        }
        return new Vector2(
            Mathf.Cos(angle) * radius,
            Mathf.Sin(angle) * radius
        );
    }
}
