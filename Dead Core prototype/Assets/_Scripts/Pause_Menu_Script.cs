using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu_Script : MonoBehaviour 
{
    public static bool isPaused;
    public GameObject Pause_Menu_Canvas;

	void Start()
	{
        isPaused = false;
	}

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

	}

    public void Pause()
    {
        Pause_Menu_Canvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        Pause_Menu_Canvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Input_Button()
    {
        Debug.Log("Input button pressed...");
    }
    public void Quit_Button()
    {
        Debug.Log("Quit button pressed...");
    }


}
