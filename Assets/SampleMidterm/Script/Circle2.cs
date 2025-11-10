using UnityEngine;
using UnityEngine.InputSystem;

public class CircleForceLike : MonoBehaviour
{
    public float speed = 5f;
    public float accel = 5f; // ���ӵ� (AddForce ������)
    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        input = Vector2.zero;

        if (keyboard.upArrowKey.isPressed) input.y = 1;
        if (keyboard.downArrowKey.isPressed) input.y = -1;
        if (keyboard.leftArrowKey.isPressed) input.x = -1;
        if (keyboard.rightArrowKey.isPressed) input.x = 1;
    }

    void FixedUpdate()
    {
        // ��ǥ �ӵ� ���
        Vector2 targetVel = input.normalized * speed;

        // ���� �ӵ��� ������ targetVel�� ���� (����ó�� ���̰�)
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVel, accel * Time.fixedDeltaTime);
    }
}