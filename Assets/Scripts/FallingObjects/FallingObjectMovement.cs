using UnityEngine;

public class FallingObjectMovement : MonoBehaviour
{

    public float speed = 5;
    Transform skin;

    void Awake()
    {
        skin = this.transform.Find("Skin");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        skin.Rotate(0, 0, speed * 5 * Time.deltaTime);
        transform.position += -transform.position.normalized * speed * Time.fixedDeltaTime;
    }
}
