using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    int score;

    GameObject[] indicators = new GameObject[5];

    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            indicators[i] = i == 0 ? GameObject.Find("Indicator")
                : Object.Instantiate(indicators[0]) as GameObject;
            indicators[i].SetActive(false);

            if (i == 0) continue;

            var pos = indicators[0].transform.position;
            pos.x += i * 0.7f;
            indicators[i].transform.position = pos;

            if (i >= 3)
            {
                indicators[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }

    public void Set(int score, int lives)
    {
        this.score = score;

        for (int i = 0; i < 5; i++)
        {
            indicators[i].SetActive(lives > 0);
            lives--;
        }
    }

    void OnGUI()
    {
        var style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(15, 50, 100, 50), "SCORE: " + score, style);
    }
}
