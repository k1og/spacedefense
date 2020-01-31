using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public int spawnCount = 50;
    public List<GameObject> gameObjectsList;
    GameObject tempGameObject;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            tempGameObject = Instantiate(prefab);
            gameObjectsList.Add(tempGameObject);
            tempGameObject.transform.parent = this.transform;
            tempGameObject.SetActive(false);
        }
    }
}
