using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour 
{
    Vector3 lastPos;
    public Vector3 delta;
	void Start () 
    {
        lastPos = Input.mousePosition;
	}
	
	void Update ()
    {
        delta = Input.mousePosition - lastPos;
        lastPos = Input.mousePosition;
	}
}
