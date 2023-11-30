using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour 
{

    float SPEED = 2f;

    GameController gameController;
    GameObject explosionSeed;

    void Awake()
    {
        gameController = Object.FindObjectOfType<GameController>();
        explosionSeed = GameObject.Find("ExplosionSeed");
        SPEED *= gameController.pace;
    }
	// Update is called once per frame
	void Update ()
    {
        var pos = transform.position;
        pos.y -= SPEED * gameController.GetTime();
        transform.position = pos;
	}

    void Explode()
    {
        var explosion = Object.Instantiate(explosionSeed) as GameObject;
        explosion.name = "Explosion";
        explosion.AddComponent<ExplosionController>();
        explosion.transform.position = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bomb") return;

        if (other.gameObject.name == "BottomPlane")
        {
            if (gameObject.name != "Life") gameController.ModLives(-1);
        }

        else if (other.gameObject.name == "Bullet")
        {
            gameController.ModScore(10);
            if (gameObject.name == "Life")
            {
                gameController.ModLives(1);
                gameController.ModScore(10);
            }
            Object.Destroy(other.gameObject);
        }

        else if (other.gameObject.name == "GunBase" || other.gameObject.name == "GunHead")
        {
            if (gameObject.name != "Life")
            {
                gameController.ModLives(0);
                Explode();
            }
            else
            {
                gameController.ModLives(1);
            }

        }

        Explode();
        Object.Destroy(gameObject);
        
    }
}
