using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    public GameObject obstacle;
    public GameObject powerup;
    public GameObject jumpWall;

    float timeElapsed = 0;
    float spawnCycle = 0.5f;
    bool spawnPowerup = true;
	
	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        int randomNumber = Random.Range(-1, 56);
        if (timeElapsed > spawnCycle) {
            GameObject temp;
            if (randomNumber>=25)
            {
                temp = (GameObject)Instantiate(powerup);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-1, 2)*2, pos.y, pos.z);
            }
            else if(randomNumber>=0)
            {
                temp = (GameObject)Instantiate(obstacle);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(Random.Range(-1, 2) * 2, pos.y, pos.z);
            }
            else
            {
                temp = (GameObject)Instantiate(jumpWall);
                Vector3 pos = temp.transform.position;
                temp.transform.position = new Vector3(0, pos.y, pos.z);
            }

            timeElapsed -= spawnCycle;
            spawnPowerup = !spawnPowerup;
        }
	}
}
