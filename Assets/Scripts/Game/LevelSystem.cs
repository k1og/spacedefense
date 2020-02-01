using System.Collections;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public Level currentLevel;
    public ShootingController playerShootingController;
    public FallingObjectSpawner asteroidSpawner;
    
    void Start()
    {
        currentLevel.number = 0; // get finished levels
        currentLevel.minAmointOfTime = 5;
        currentLevel.minAmountOfAsteroids = 5;
        currentLevel.spawnRate = 5;
        currentLevel.maxAsteroidHP = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!currentLevel.isPlaying) {
                StartNextLevel();
            }
        }
    }

    public void StartNextLevel()
    {
        if (currentLevel.isFinished)
        {
            currentLevel.number++;
            currentLevel.minAmointOfTime++;
            currentLevel.minAmountOfAsteroids++;
            currentLevel.spawnRate -= 0.5f;
            currentLevel.maxAsteroidHP++;
        }

        StartCoroutine(StartLevelCoroutine());
    }

    IEnumerator StartLevelCoroutine()
    {
        asteroidSpawner.spawnRate = currentLevel.spawnRate;
        asteroidSpawner.maxHP = currentLevel.maxAsteroidHP;
        playerShootingController.StartSpawning();
        asteroidSpawner.StartSpawning();
        currentLevel.isPlaying = true;
        yield return new WaitForSeconds(currentLevel.minAmointOfTime);
        yield return new WaitUntil(() => currentLevel.minAmountOfAsteroids <= asteroidSpawner.spawnedObjectsAmount);
        yield return new WaitUntil(() => !asteroidSpawner.HasActiveObjects());
        playerShootingController.StopSpawning();
        asteroidSpawner.StopSpawning();
        currentLevel.isPlaying = false;
        currentLevel.isFinished = true;
        yield return null;
    }
}
