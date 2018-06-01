using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleController : MonoBehaviour
{
    public GameObject dayNightLight;
    public float hour;
    private float xSpeed;
    public Text timeOfDayText;
    //public Quaternion rotation;

    void Start ()
    {
        xSpeed = 10;
        //rotation = new Quaternion(90, -30, 0, 0); //Only useful when you wan to set the starting time
	}
	
	// The rotation needs sorting i.e. making it go from 1 - 360 rather than up and down and up again.
	void Update ()
    {
        timeOfDayText.text = "" + Mathf.Round(hour) + ":00";//Sort out second half, figure out algorithm to get minutes out
        dayNightLight.transform.Rotate(xSpeed * Time.deltaTime, 0, 0);
        if (dayNightLight.transform.eulerAngles.x > 0)
        {
            hour = dayNightLight.transform.eulerAngles.x / 15;
        }
        else
        {
            hour = (dayNightLight.transform.eulerAngles.x + 360) / 15;
        }
        Debug.Log(dayNightLight.transform.eulerAngles.x);
        Debug.Log(hour);
	}
}
