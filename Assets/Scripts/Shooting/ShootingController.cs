public class ShootingController : BaseSpawner
{
    override public void BeforeSpawn()
    {
        currentObject.transform.position = transform.position;
        currentObject.transform.rotation = transform.rotation;
    }
}
