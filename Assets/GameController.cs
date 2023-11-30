using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    bool gameOn = true;
    float timer = 0;
    int lives = 3;
    int score = 0;
    public float pace = 1;
    

    GunController gunController;

    void Awake()
    {
        gunController = Object.FindObjectOfType<GunController>();
    }

	void Start () 
    {
        LogStats();
	}

    void LogStats()
    {
        Debug.Log("Lives: " + lives + ", Score: " + score);
        GetComponent<ScoreController>().Set(score, lives);
    }

    public void ResetGame(bool destroy = false)
    {
        Debug.Log("You Lose");
        if (destroy)
        {
            gunController.transform.parent.gameObject.SetActive(false);
        }

        gameOn = false;
        
    }

    void OnGUI()
    {
        if(gameOn) return;

        var style = new GUIStyle();
        style.fontSize = 75;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(300, 150, 1000, 1000), "GAME OVER", style);
    }

    public float GetTime()
    {
        return gameOn? Time.deltaTime:0;
    }

    public void ModScore(int num)
    {
        score += num;
        LogStats();
    }

    public void ModLives(int num)
    {
        lives += num;
        if (num == 0) lives = 0;
        lives = System.Math.Min(lives, 5);
        LogStats();
        if (lives <= 0) ResetGame(num == 0);
    }
    void Update()
    {
        if (gameOn)
        {
            pace += 0.05f * GetTime();
            pace = Mathf.Min(pace, 3);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > 4)
            {
                timer = 0;
                gameOn = true;
                lives = 3;
                score = 0;
                pace = 1;
                gunController.transform.parent.gameObject.SetActive(true);
                var bc = Object.FindObjectsOfType<BombController>();
                foreach (var o in bc)
                {
                    Object.Destroy(o.gameObject);
                }

                LogStats();
            }
        }

    }

}

