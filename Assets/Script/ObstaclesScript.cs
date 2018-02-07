using UnityEngine;
using System.Collections;

public class ObstaclesScript : MonoBehaviour {
    public float objectSpeed = -20f;
	
	// Update is called once per frame
	void Update () {
        if(Time.timeScale == 1)
            transform.Translate(new Vector3(0,objectSpeed,0));
        else if (Time.timeScale >= 0.2)
        {
            transform.Translate(new Vector3(0, objectSpeed/5, 0));
        }
	}
}
