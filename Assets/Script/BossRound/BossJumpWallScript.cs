using UnityEngine;
using System.Collections;

public class BossJumpWallScript : MonoBehaviour
{
    public float objectSpeed = -20f;
    // Update is called once per frame
    void Start()
    {
        gameObject.transform.position = new Vector3(80f,0.25f,9f);
    }

    void Update()
    {
        if (Time.timeScale == 1)
            transform.Translate(new Vector3(0, 0, objectSpeed/1.5f));
        else if (Time.timeScale >= 0.2)
        {
            transform.Translate(new Vector3(0, 0, objectSpeed/5));
        }
    }
}
