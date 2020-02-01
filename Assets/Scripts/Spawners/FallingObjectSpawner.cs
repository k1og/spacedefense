using UnityEngine;

public class FallingObjectSpawner : BaseSpawner
{
    public int spawnedObjectsAmount;
    public int maxHP;
    private HealthManager currentObjectHeathManager;
    public bool HasActiveObjects()
    {
        for (int i = 0; i < objectPool.gameObjectsList.Count; i++)
        {
            if (objectPool.gameObjectsList[i].activeInHierarchy == true)
            {
                return true;
            }
        }
        return false;
    }

    override public void StartSpawning()
    {
        spawnedObjectsAmount = 0;
        base.StartSpawning();
    }
    override public void BeforeSpawn()
    {
        currentObjectHeathManager = currentObject.GetComponent<HealthManager>();
        currentObjectHeathManager.HP = Random.Range(1, maxHP + 1);
        currentObject.transform.position = GenerateRandomPosition();
        spawnedObjectsAmount += 1;
    }
}
