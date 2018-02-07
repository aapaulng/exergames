using UnityEngine;
using System.Collections;

public class BossGroundControl : MonoBehaviour {
    //Material texture offset rate
    float speed = .5f * 9;
	
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
	}
}
