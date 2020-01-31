using UnityEngine;

public class FallingObjectMovement : MonoBehaviour
{

    public float speed = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * 5 * Time.deltaTime);
        transform.position += -transform.position.normalized * speed * Time.fixedDeltaTime;
    }
}
