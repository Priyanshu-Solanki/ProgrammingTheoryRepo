using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{ 
    public GameObject body;
    public Toggle Red;
    public Toggle Black;
    public Toggle White;
    public Toggle Blue;

    public Slider musicSlider;

    public GameObject startScreen;
    public GameObject gameModeScreen; 
    public GameObject menuScreen;
    public GameObject settingsScreen;

    public void Start()
    {
        if(MainManager.instance != null)
        {
            SetColor();
        }
    }

    private void SetColor()
    {
        if(MainManager.instance.colorNumber == 1)
        {
            White.isOn = true;
        }
        else if (MainManager.instance.colorNumber == 2)
        {
            Black.isOn = true;
        }
        else if (MainManager.instance.colorNumber == 3)
        {
            Red.isOn = true;
        }
        else if (MainManager.instance.colorNumber ==4)
        {
            Blue.isOn = true;
        }
    }

    public void OnEnableRed()
{
        if(Red.isOn)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
            White.isOn = false;
            Blue.isOn = false;
            Black.isOn = false;
            MainManager.instance.colorNumber = 3;
        }
   
}

    public void OnEnableBlue()
    {
        if(Blue.isOn)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
            White.isOn = false;
            Black.isOn=false;
            Red.isOn = false;
            MainManager.instance.colorNumber = 4;
        }

    }
    public void OnEnableBlack()
    {
        if(Black.isOn)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
            White.isOn = false;
            Blue.isOn = false;
            Red.isOn = false;
            MainManager.instance.colorNumber = 2;
        }

    }
    public void OnEnableWhite()
    {
        if(White.isOn)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
            Blue.isOn = false;
            Black.isOn = false;
            Red.isOn = false;
            MainManager.instance.colorNumber = 1;
        }

    }

    public void StartButton()
    {
        gameModeScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void SettingsButton()
    {
        menuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
          EditorApplication.ExitPlaymode();
         #else
          Application.Quit();
          #endif
    }
    public void BackButton1()
    {
        gameModeScreen.SetActive(false);
        menuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void BackButton2()
    {
        gameModeScreen.SetActive(true);
        startScreen.SetActive(false);
    }

    public void NextButton()
    {
        gameModeScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void Slider()
    {
        AudioListener.volume = musicSlider.value;
    }
    public void Scene1Button()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene2Button()
    {
        SceneManager.LoadScene(2);
    }
}
