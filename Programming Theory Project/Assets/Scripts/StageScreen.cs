using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageScreen : MonoBehaviour
{
    public Toggle highWayMode;
    public Toggle cityMode;

    public Text gameMode;
    public Text wayMode;
    public Text stage;
    void Start()
    {
        if(highWayMode.isOn)
        {
            MainManager.instance.stageNumber = 1;
            stage.text = "HIGHWAY";
        }
        else if(cityMode.isOn)
        {
            MainManager.instance.stageNumber=2;
            stage.text = "CITY";
        }
    }

    private void Update()
    {
        if (MainManager.instance.modeNumber == 1)
        {
            gameMode.text = "ENDLESS";
        }
        else if (MainManager.instance.modeNumber == 2)
        {
            gameMode.text = "TIME TRIAL";
        }
        if (MainManager.instance.oneWay)
        {
            wayMode.text = "ONEWAY";
        }
        else if (MainManager.instance.twoWay)
        {
            wayMode.text = "TWOWAY";
        }
    }
    public void HighwayMode()
    {
        if(highWayMode.isOn)
        {
            cityMode.isOn = false;
            MainManager.instance.stageNumber = 1;
            stage.text = "HIGHWAY";
        }
    }
    public void CityMode()
    {
        if (cityMode.isOn)
        {
            highWayMode.isOn = false;
            MainManager.instance.stageNumber = 2;
            stage.text = "CITY";
        }
    }

    public void PlayButton()
    {
        if(MainManager.instance.stageNumber == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if(MainManager.instance.stageNumber == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
