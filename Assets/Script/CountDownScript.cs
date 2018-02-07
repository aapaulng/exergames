using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountDownScript : MonoBehaviour {
    public AudioSource countdownSound;
    public bool isCountDown = false;
    public GameObject character;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject ground;
    public GameObject UI_CountDown;
    public const int countMax = 3;
    public int countDown;
    public int counter;
    public bool state;


    void Awake()
    {
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();


        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = false;
        }

        //disable all script attached to wall & ground
        //disable the animation of character
        character.GetComponent<Animation>().enabled = false;
        character.GetComponent<AudioSource>().enabled = false;
        wall1.GetComponent<GroundControl>().enabled = false;
        wall2.GetComponent<GroundControl>().enabled = false;
        ground.GetComponent<GroundControl>().enabled = false;
        UI_CountDown.GetComponent<Image>().enabled = true;
        UI_CountDown.GetComponentInChildren<Text>().enabled = true;
        //call the countdown function

        
    }

    void Start() {
        StopCoroutine("CountDownFunction");
        StartCoroutine("CountDownFunction");
    }

    IEnumerator CountDownFunction()
    {
  
        countdownSound.PlayDelayed(.4f);
        //start countdown
        for (countDown = countMax; countDown > -1; countDown--)
        {
            if (countDown != 0)
            {
                //display the number to screen via GUIText
                UI_CountDown.GetComponentInChildren<Text>().text = countDown.ToString();
                Debug.Log(countDown + "come into for loop");
                //add 1 second delay
                yield return new WaitForSeconds(1);
                //Paul, the line below is Marvelous to tackle stupid StartCorrutine Problem (maybe)
                //Wait(1, () =>
                //{
                //    Debug.Log("1 seconds is lost forever");
                //});
                // Debug.Log("after wait 1 second");
            }
            else
            {
                //display GO on GUIText
                UI_CountDown.GetComponentInChildren<Text>().text = "GOOO!!";
                yield return new WaitForSeconds(1);
                //Wait(4, () =>
                //{
                //    Debug.Log("1 seconds is lost forever");
                //});
                //stop the sound
                countdownSound.Stop();
                isCountDown = true;
            }
        }

        //enable all script and animation when count is down
        MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scriptComponentsGameControl)
        {
            script.enabled = true;
        }

        wall1.GetComponent<GroundControl>().enabled = true;
        wall2.GetComponent<GroundControl>().enabled = true;
        ground.GetComponent<GroundControl>().enabled = true;
        character.GetComponent<Animation>().enabled = true;
        character.GetComponent<AudioSource>().enabled = true;
        //disable GUI text once count is down
        UI_CountDown.GetComponent<Image>().enabled = false;
        UI_CountDown.GetComponentInChildren<Text>().enabled = false;

    }

    //Paul, this is Marvelous to tackle stupid StartCorrutine Problem(maybe)
    //public void Wait(float seconds, Action action) 
    //{
    //    StartCoroutine(_wait(seconds, action));
    //}

    //Paul, this is Marvelous to tackle stupid StartCorrutine Problem(maybe)
    //IEnumerator _wait(float time, Action callback)
    //{
    //    yield return new WaitForSeconds(time);
    //    callback();
    //}
}
 