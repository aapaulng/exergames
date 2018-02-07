using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
    public void GameStart()
    {
        DestroyImmediate(Camera.main.gameObject);
        Application.LoadLevel("game");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

	
}
