using System.Collections;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public Level currentLevel;
    public Transform player;
    ShootingController playerShootingController;
    PlayerMovement playerMovement;
    public FallingObjectSpawner asteroidSpawner;
    public Animator uiAnimator;

    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerShootingController = player.GetComponentInChildren<ShootingController>();
    }

    void Start()
    {
        currentLevel.number = 0; // get finished levels
        // currentLevel.minAmointOfTime = 5;
        // currentLevel.minAmountOfAsteroids = 5;
        currentLevel.spawnRate = 2;
        // currentLevel.maxAsteroidHP = 1;
        currentLevel.minAmountOfAsteroids = 1;
        currentLevel.minAmointOfTime = 1;
    }

    void Update()
    {
        if (!currentLevel.isPlaying) {
            if (Input.GetMouseButtonDown(0))
            {
                StartNextLevel();
            }
        }
    }

    public void StartNextLevel()
    {
        if (currentLevel.isFinished)
        {
            // currentLevel.number++;
            // currentLevel.minAmointOfTime++;
            // currentLevel.minAmountOfAsteroids++;
            // currentLevel.spawnRate -= 1;
            currentLevel.maxAsteroidHP++;
        }

        StartCoroutine(StartLevelCoroutine());
    }

    IEnumerator StartLevelCoroutine()
    {
        uiAnimator.Play("CanvasOut");
        float currentClipLenght = uiAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        yield return new WaitForSeconds(currentClipLenght);
        asteroidSpawner.spawnRate = currentLevel.spawnRate;
        asteroidSpawner.maxHP = currentLevel.maxAsteroidHP;
        playerShootingController.StartSpawning();
        asteroidSpawner.StartSpawning();
        playerMovement.enabled = true;
        currentLevel.isPlaying = true;
        yield return new WaitForSeconds(currentLevel.minAmointOfTime);
        yield return new WaitUntil(() => currentLevel.minAmountOfAsteroids <= asteroidSpawner.spawnedObjectsAmount);
        asteroidSpawner.StopSpawning();
        yield return new WaitUntil(() => !asteroidSpawner.HasActiveObjects());
        playerShootingController.StopSpawning();
        playerMovement.enabled = false;
        currentLevel.isPlaying = false;
        currentLevel.isFinished = true;
        uiAnimator.Play("CanvasIn");
        yield return new WaitForSeconds(currentClipLenght);
        yield return null;
    }
}
