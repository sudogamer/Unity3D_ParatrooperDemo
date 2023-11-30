using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour 
{
    MouseController mouse;
    float rot = 0;
    GameController gameController;
    void Awake()
    {
        gameController = Object.FindObjectOfType<GameController>();
        mouse = Object.FindObjectOfType<MouseController>();
    }

    void Shoot()
    {
        var bullet = Object.Instantiate(gameObject) as GameObject;
        Object.Destroy(bullet.GetComponent<GunController>());
        bullet.name = "Bullet";
        var s = bullet.transform.localScale;
        s.y = 1;
        bullet.transform.localScale = s;
        bullet.AddComponent<BulletController>();

    }

	void Update () 
    {
        rot -= 15f * mouse.delta.x * gameController.GetTime();
        rot = Mathf.Clamp(rot, -80, 80);
        transform.eulerAngles = new Vector3(0, 0, rot);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}
}
