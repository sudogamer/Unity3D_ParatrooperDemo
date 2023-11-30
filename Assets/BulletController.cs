using UnityEngine;

public class BulletController : MonoBehaviour
{
    float SPEED = 15f;

    GameController gameController;

    void Start()
    {
        gameController = Object.FindObjectOfType<GameController>();
        float angle = (transform.eulerAngles.z + 90) * 2 * 3.14f / 360;

        var pos = transform.position;

        pos.x += 1 * Mathf.Cos(angle);
        pos.y += 1 * Mathf.Sin(angle);

        transform.position = pos;
    }

    void Update()
    {
        float angle = (transform.eulerAngles.z + 90) * 2 * 3.14f / 360;

        var pos = transform.position;

        pos.x += SPEED * Mathf.Cos(angle) * gameController.GetTime();
        pos.y += SPEED * Mathf.Sin(angle) * gameController.GetTime();

        transform.position = pos;

        if (Mathf.Abs(pos.x) > 10 || Mathf.Abs(pos.y) > 6) Object.Destroy(gameObject); 
    }
}

