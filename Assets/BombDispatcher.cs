using UnityEngine;
using System.Collections;

public class BombDispatcher : MonoBehaviour 
{
    System.Random rndTime = new System.Random(23);
    System.Random rndPos = new System.Random(45);
    System.Random rndType = new System.Random(56);

    float time = 0;
    float dispatchTime = 0;
    GameObject bombSeed;
    GameController gameController;

    void Awake()
    {
        gameController = Object.FindObjectOfType<GameController>();
        bombSeed = GameObject.Find("Bomb");
    }

    void DispatchBomb()
    {
        int type = rndType.NextDouble() > 0.95 ? 1 : 0;
        var bomb = Object.Instantiate(bombSeed) as GameObject;
        bomb.AddComponent<BombController>();
        var pos = bomb.transform.position;
        pos.x = -8 + 16 * (float)rndPos.NextDouble();

        bomb.transform.position = pos;

        if (type == 1)
        {
            bomb.name = "Life";
            bomb.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    void RandomizeNext()
    {
        time = 0;
        dispatchTime = 0.5f + 3.5f * (float) rndTime.NextDouble();
        dispatchTime /= gameController.pace;
    }

	void Update () 
    {
        if (time > dispatchTime)
        {
            DispatchBomb();
            RandomizeNext();
        }

        time += gameController.GetTime();

	}
}
