using UnityEngine;
using System.Collections;

public class BossObstaclesScript : MonoBehaviour
{
    public float objectSpeed = -20f;

    void Start()
    {
        //gameObject.transform.position = new Vector3(40f, 1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
            transform.Translate(new Vector3(0, objectSpeed / 1.5f, 0));
        else if (Time.timeScale >= 0.2)
        {
            transform.Translate(new Vector3(0, objectSpeed / 5, 0));
        }
    }
}
