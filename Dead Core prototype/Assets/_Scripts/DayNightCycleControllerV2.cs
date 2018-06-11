using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleControllerV2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _dayNightLight;
    [SerializeField, Tooltip("The amount of game-minutes that pass every second")]
    private float _speedOfTime;
    [SerializeField]
    private Text _timeOfDayText;
    [SerializeField]
    private Display _displayMode;

    [SerializeField, ReadOnly]
    private float _totalMinutes;
    [SerializeField, ReadOnly]
    private int _daysSinceStart;


    private void Update()
    {
        _totalMinutes += _speedOfTime * Time.deltaTime;

        // There are 1,440 minutes in a 24-hour day.
        if (_totalMinutes >= 1440)
        {
            // I do not set it to zero in case the speed of time is not a multiple of 1,440 (aka the time ends up X seconds after midnight).
            _totalMinutes -= 1440;
            _daysSinceStart++;
        }

        // Calculates the percentage through the day it currently is, then multiplies that by the maximum rotation, 360.
        float angleOfSun = (_totalMinutes / 1440f) * 360f;
        _dayNightLight.transform.eulerAngles = new Vector3(angleOfSun - 90f, 0f, 0f); // TODO allow any Y-rotation, atm it makes the light flicker after midday

        DisplayTime();
    }

    // TODO move the UI stuff to a different script
    private void DisplayTime()
    {
        int hours = (int)(_totalMinutes / 60f);
        int minutes = (int)_totalMinutes - (hours * 60);


        switch (_displayMode)
        {
            case Display.Hour_12:
                // 00 -> 11 :: AM     12 -> 23 :: PM
                if (hours <= 12)
                    _timeOfDayText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ((hours != 12) ? " AM" : " PM");
                else
                    _timeOfDayText.text = (hours - 12).ToString("00") + ":" + minutes.ToString("00") + " PM";
                break;

            case Display.Hour_24:
                _timeOfDayText.text = hours.ToString("00") + ":" + minutes.ToString("00");
                break;
        }
    }

    public void SetTime(int hours, int minutes)
    {
        _totalMinutes = (hours * 60f) + minutes;
    }

    private enum Display
    {
        Hour_24,
        Hour_12
    }
}
