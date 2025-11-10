using UnityEngine;
using UnityEngine.InputSystem; // 새 입력 시스템

public class TriangleMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        moveInput = Vector2.zero;

        if (keyboard.upArrowKey.isPressed) moveInput.y = 1;
        if (keyboard.downArrowKey.isPressed) moveInput.y = -1;
        if (keyboard.leftArrowKey.isPressed) moveInput.x = -1;
        if (keyboard.rightArrowKey.isPressed) moveInput.x = 1;
    }

    void FixedUpdate() // 물리연산 타이밍
    {
        Vector2 move = moveInput.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}