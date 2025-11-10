using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float moveAcceleration = 5f; // 가속도
    public float jumpAcceleration = 10f; // 점프 가속도
    public float maxMovePower = 4f; // 최고 이동속도
    public float maxJumpPower = 10f; // 최고 점프속도

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        Vector2 velocity = rb.linearVelocity;

        // 좌우 이동
        if (keyboard.leftArrowKey.isPressed)
            velocity.x -= moveAcceleration * Time.deltaTime;
        else if (keyboard.rightArrowKey.isPressed)
            velocity.x += moveAcceleration * Time.deltaTime;
        else
            // 키를 떼면 서서히 감속
            velocity.x = Mathf.Lerp(velocity.x, 0, 0.1f);

        // 최고 속도 제한
        velocity.x = Mathf.Clamp(velocity.x, -maxMovePower, maxMovePower);

        // 점프
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded)
        {
            velocity.y = jumpAcceleration;
            isGrounded = false;
        }

        // 최고 점프 속도 제한
        velocity.y = Mathf.Clamp(velocity.y, -maxJumpPower, maxJumpPower);

        rb.linearVelocity = velocity;
    }

    // 바닥 감지용
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}