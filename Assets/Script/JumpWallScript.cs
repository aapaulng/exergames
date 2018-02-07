using UnityEngine;
using System.Collections;

public class JumpWallScript : MonoBehaviour
{
    public float objectSpeed = -20f;
    // Update is called once per frame
    void Start()
    {
        gameObject.transform.position = new Vector3(0f,0.25f,42);
    }

    void Update()
    {
        if (Time.timeScale == 1)
            transform.Translate(new Vector3(0, 0, objectSpeed));
        else if (Time.timeScale >= 0.2)
        {
            transform.Translate(new Vector3(0, 0, objectSpeed/5));
        }
    }
}
