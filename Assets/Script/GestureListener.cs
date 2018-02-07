using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    // GUI Text to display the gesture messages.
    public GUIText GestureInfo;
    public Text GestureInfo2;

    private bool swipeLeft;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeDown;

    private bool Squat;
    private bool raiseLeftHand;
    private bool raiseRightHand;

    //Extra
    private bool flyLeft;
    private bool flyRight;
    private bool flyMiddle;
    private bool Flap;

    public bool IsSwipeLeft()
    {
        if (swipeLeft)
        {
            swipeLeft = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeRight()
    {
        if (swipeRight)
        {
            swipeRight = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeUp()
    {
        if (swipeUp)
        {
            swipeUp = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeDown()
    {
        if (swipeDown)
        {
            swipeDown = false;
            return true;
        }

        return false;
    }

    public bool IsSquat()
    {
        if (Squat)
        {
            Squat = false;
            return true;
        }
        return false;
    }

    //Extra
    public bool IsFlyLeft()
    {
        if (flyLeft)
        {
            flyLeft = false;
            return true;
        }

        return false;
    }

    public bool IsFlyRight()
    {
        if (flyRight)
        {
            flyRight = false;
            return true;
        }
        return false;
    }

    public bool IsFlyMiddle()
    {
        if (flyMiddle)
        {
            flyMiddle = false;
            return true;
        }
        return false;
    }

    public bool IsFlap()
    {
        if (Flap)
        {
            Flap = false;
            return true;
        }
        return false;

    }

    public bool IsRaiseLeftHand()
    {
        if (raiseLeftHand)
        {
            raiseLeftHand = false;
            return true;
        }
        return false;

    }

    public bool IsRaiseRightHand()
    {
        if (raiseRightHand)
        {
            raiseRightHand = false;
            return true;
        }
        return false;

    }

    public void UserDetected(uint userId, int userIndex)
    {
        // detect these user specific gestures
        KinectManager manager = KinectManager.Instance;

        		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
        //		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        //		manager.DetectGesture(userId, KinectGestures.Gestures.SwipeDown);
                manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);
                manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);

        //Extra 
        //manager.DetectGesture(userId, KinectGestures.Gestures.FlyLeft);
        //manager.DetectGesture(userId, KinectGestures.Gestures.FlyRight);
        //manager.DetectGesture(userId, KinectGestures.Gestures.FlyMiddle);
        manager.DetectGesture(userId, KinectGestures.Gestures.Flap);
        //manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

        if (GestureInfo != null)
        {
            GestureInfo.GetComponent<GUIText>().text = "";
        }
        if (GestureInfo2 != null)
        {
            GestureInfo2.text = "Gesture : ";
        }
    }

    public void UserLost(uint userId, int userIndex)
    {
        if (GestureInfo != null)
        {
            GestureInfo.GetComponent<GUIText>().text = string.Empty;
        }

        if (GestureInfo2 != null)
        {
            GestureInfo2.text = string.Empty;
        }

    }

    public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture,
        float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
    {
        // don't do anything here
    }

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture,
        KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
    {
        string sGestureText = gesture +"";
        if (GestureInfo != null)
        {
            GestureInfo.GetComponent<GUIText>().text = sGestureText + " detected";
        }

        if (GestureInfo2 != null)
        {
            if (sGestureText.Equals("SwipeLeft"))
                sGestureText = "FlyLeft";
            else if (sGestureText.Equals("SwipeRight"))
                sGestureText = "FlyRight";
            
            GestureInfo2.text = "Gesture : "+ sGestureText;
           
        }

        if (gesture == KinectGestures.Gestures.SwipeLeft)
            swipeLeft = true;
        else if (gesture == KinectGestures.Gestures.SwipeRight)
            swipeRight = true;
        else if (gesture == KinectGestures.Gestures.SwipeUp)
            swipeUp = true;
        else if (gesture == KinectGestures.Gestures.SwipeDown)
            swipeDown = true;
        else if (gesture == KinectGestures.Gestures.FlyLeft)
            flyLeft = true;
        else if (gesture == KinectGestures.Gestures.FlyRight)
            flyRight = true;
        else if (gesture == KinectGestures.Gestures.FlyMiddle)
            flyMiddle = true;
        else if (gesture == KinectGestures.Gestures.Flap)
            Flap = true;
        else if (gesture == KinectGestures.Gestures.Squat)
            Squat = true;
        else if (gesture == KinectGestures.Gestures.RaiseLeftHand)
            raiseLeftHand = true;
        else if (gesture == KinectGestures.Gestures.RaiseRightHand)
            raiseRightHand = true;


        return true;
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture,
        KinectWrapper.SkeletonJoint joint)
    {
        // don't do anything here, just reset the gesture state
        return true;
    }

}
