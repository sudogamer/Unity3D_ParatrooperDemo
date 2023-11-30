using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour
{
    Sprite[] spriteSheet;
    SpriteRenderer ren;
    float spriteNum = 0;
    float speed = 38 * 2;
	// Use this for initialization
	void Awake() 
    {
     
        spriteSheet = Resources.LoadAll<Sprite>("explosion");
        ren = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        spriteNum += speed * Time.deltaTime;
        int index = (int)spriteNum;
        if(index > 37)
        {
            index = 37;
            Object.Destroy(gameObject);
        }
        ren.sprite = spriteSheet[index];

	}
}
