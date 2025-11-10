using UnityEngine;
using UnityEngine.InputSystem; // 새 입력 시스템

public class SquareMove : MonoBehaviour
{
    public float speed = 5f; // Inspector에서 조절 가능

    void Update() // 게임 로직 타이밍
    {
        var keyboard = Keyboard.current;
        Vector2 dir = Vector2.zero;

        if (keyboard.upArrowKey.isPressed) dir.y = 1;
        if (keyboard.downArrowKey.isPressed) dir.y = -1;
        if (keyboard.leftArrowKey.isPressed) dir.x = -1;
        if (keyboard.rightArrowKey.isPressed) dir.x = 1;

        transform.position += (Vector3)(dir.normalized * speed * Time.deltaTime);
    }
}