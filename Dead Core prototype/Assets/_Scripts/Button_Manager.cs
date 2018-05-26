using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public void Start_Btn()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings_Btn()
    {
        //Settings code
    }

    public void Quit_Btn()
    {
        Application.Quit();
    }
}
