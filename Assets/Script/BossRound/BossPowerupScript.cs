using UnityEngine;
using System.Collections;

public class BossPowerupScript : MonoBehaviour
{
    public float objectSpeed = -20f;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
            transform.Translate(new Vector3(0, 0, objectSpeed / 1.5f));
        else if (Time.timeScale >= 0.2)
        {
            transform.Translate(new Vector3(0, 0, objectSpeed / 5));
        }
    }
}
