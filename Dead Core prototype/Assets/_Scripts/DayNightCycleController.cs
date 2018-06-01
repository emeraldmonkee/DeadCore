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

    void Start()
    {
        xSpeed = 10;
        //rotation = new Quaternion(90, -30, 0, 0); //Only useful when you wan to set the starting time
    }

    // The rotation needs sorting i.e. making it go from 1 - 360 rather than up and down and up again.
    void Update()
    {
        timeOfDayText.text = "" + Mathf.Round(hour) + ":00";//Sort out second half, figure out algorithm to get minutes out
        dayNightLight.transform.Rotate(xSpeed * Time.deltaTime, 0, 0);
        //float angle = Mathf.Atan(dayNightLight.transform.rotation.y, dayNightLight.transform.rotation.x) * Mathf.Rad2Deg;
        //float angle = dayNightLight.transform.eulerAngles.x;
        //dayNightLight.transform.eulerAngles = new Vector3(Mathf.Clamp(transform.rotation.eulerAngles.x, 1, 360), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        /*if (angle < 0)
        {
            angle += 360;
        }
        if (angle > 90 && angle < 180)
        {
            angle += 90;
        }
        /*else if (angle > 90)
        {
            angle -= 180;
        }*/
        
        Vector3 angle = GetAngle(dayNightLight.transform.rotation);
        if (angle.x < 0)
        {
            angle.x += 360;
        }
        hour = angle.x / 15;
        Debug.Log(angle.x);
    }

    public Vector3 GetAngle(Quaternion rotation)
    {
        float angle = Mathf.Atan2(2 * rotation.x * rotation.w - 2 * rotation.y * rotation.z, 1 - 2 * rotation.x * rotation.x - 2 * rotation.z * rotation.z);
        angle += Mathf.PI;
        angle /= 2f * Mathf.PI;
        angle *= 100f;
        return new Vector3(angle, 0, 0);
    }
}
