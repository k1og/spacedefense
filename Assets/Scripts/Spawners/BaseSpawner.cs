using UnityEngine;
using System.Collections;

public abstract class BaseSpawner : MonoBehaviour
{
    public PoolManager objectPool;
    public GameObject currentObject;
    private GameObject tempObject;
    public float spawnRate = 1f;
    private IEnumerator spawningCoroutine;
    public Transform cameraTransform;

    private IEnumerator StartSpawningCoroutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Awake()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    virtual public void StartSpawning()
    {
        spawningCoroutine = StartSpawningCoroutine();
        StartCoroutine(spawningCoroutine);
    }

    virtual public void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }

    private void Spawn()
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
        Vector2 topLeftCamCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, -cameraTransform.position.z));
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
