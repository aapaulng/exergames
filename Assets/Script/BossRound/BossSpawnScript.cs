using UnityEngine;
using System.Collections;

public class BossSpawnScript : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject powerup;

    float timeElapsed = 0;
    float spawnCycle = 3.5f;
    bool spawnPowerup = true;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int randomNumber = Random.Range(0, 56);
        if (timeElapsed > spawnCycle)
        {
            GameObject temp1;
            GameObject temp2;
            GameObject temp3;
            GameObject temp4;
            GameObject temp5;
            if (randomNumber >= 25)
            {
                temp1 = (GameObject)Instantiate(powerup);
                temp2 = (GameObject)Instantiate(powerup);
                temp3 = (GameObject)Instantiate(powerup);
                temp4 = (GameObject)Instantiate(powerup);
                Vector3 pos = temp1.transform.position;
                temp1.transform.position = new Vector3(Random.Range(-1, 2) * 2 +80 , pos.y, pos.z);
                temp2.transform.position = new Vector3(Random.Range(-1, 2) * 2 +80 , pos.y, pos.z+2);
                temp3.transform.position = new Vector3(Random.Range(-1, 2) * 2 +80 , pos.y, pos.z+4);
                temp4.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z + 6);
            }
            else
            {
                temp1 = (GameObject)Instantiate(obstacle);
                temp2 = (GameObject)Instantiate(obstacle);
                temp3 = (GameObject)Instantiate(obstacle);
                temp4 = (GameObject)Instantiate(obstacle);
                temp5 = (GameObject)Instantiate(obstacle);
                Vector3 pos = temp1.transform.position;
                temp1.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z);
                temp2.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z+2);
                temp3.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z+4);
                temp4.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z + 6);
                temp5.transform.position = new Vector3(Random.Range(-1, 2) * 2 + 80, pos.y, pos.z + 8);
            }
            

            timeElapsed -= spawnCycle;
            spawnPowerup = !spawnPowerup;
        }
    }
}
