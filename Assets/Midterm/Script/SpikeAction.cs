using UnityEngine;

public class L4SpikeAction : MonoBehaviour
{
    float speed = 5;

    void Start()
    {
        Application.targetFrameRate = 160;
    }

    void Update()
    {

        float moveVectorX = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            Debug.Log("Spike : ¼Ò¸ê");

        }
    }
}
