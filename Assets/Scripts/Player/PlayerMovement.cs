using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Vector3 mousePos;
    Vector2 mouseWorldPos;

    public float maxSpeed = 1.5f;
    public float radius = 15;

    float angle = 0;
    float desiredAngle = 0;

    float velocity;

    Rigidbody2D rb;
    Vector2 newPosition;


    void Start()
    {
        angle = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
    }
    void FixedUpdate()
    {
        desiredAngle = angle + AngleBetween(rb.position, mouseWorldPos);
        angle = Mathf.SmoothDamp(angle, desiredAngle, ref velocity, 0.1f, maxSpeed, Time.fixedDeltaTime);
        rb.rotation = angle * Mathf.Rad2Deg - 90 + velocity * 15;
        newPosition = new Vector2(
            Mathf.Cos(angle) * radius,
            Mathf.Sin(angle) * radius
        );
        rb.position = newPosition;
    }

    float AngleBetween(Vector3 vector1, Vector3 vector2)
    {
        float dot = vector1.x * vector2.x + vector1.y * vector2.y;
        float det = vector1.x * vector2.y - vector1.y * vector2.x;
        float angle = Mathf.Atan2(det, dot);
        return angle;
    }
}
