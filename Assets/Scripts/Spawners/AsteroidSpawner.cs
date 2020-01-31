public class AsteroidSpawner : BaseSpawner
{
    override public void BeforeSpawn()
    {
        currentObject.transform.position = GenerateRandomPosition();
    }
}
