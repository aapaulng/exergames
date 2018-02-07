using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
    public string levelToLoad;
    public bool paused;
    public MenuManager UI_MenuManager;
    public Menu UI_PausedMenu;
    public Menu UI_DummyMenu;
    public GameObject MainCamera_KinectManager;
    public int count = 0;
    public int IsUserDetectedCount = 0;

    private static float tempTimeScale = 1f;
    private GestureListener gestureListener;

  

    public void Start()
    {
        gestureListener = Camera.main.GetComponent<GestureListener>();    
    }
	// Update is called once per frame
	public void PauseMenu () {

        if ((Input.GetKey(KeyCode.Escape) )//|| 
           //!MainCamera_KinectManager.GetComponent<KinectManager>().IsUserDetected()) 
           )
        {
            if (count == 0)
            {
                tempTimeScale = Time.timeScale;
                count++;
            }
            Debug.Log("Temptimescale"+tempTimeScale);
            Pause();
        }
        else if (gestureListener.IsRaiseRightHand()) //gestureListener.IsRaiseLeftHand() || gestureListener.IsRaiseRightHand()
        {
            Debug.Log("Resume gameersedsfdsf");
            Resume();
        }

	}

    public void Resume()
    {
        paused = false;
        Time.timeScale = tempTimeScale;
        UI_MenuManager.ShowMenu(UI_DummyMenu);
        count = 0;
        IsUserDetectedCount = 0;
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        UI_MenuManager.ShowMenu(UI_PausedMenu);
    }
}


