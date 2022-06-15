using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeScreen : MonoBehaviour
{
    public Toggle endlessMode;
    public Toggle timeTrialMode;
    public Toggle oneWay;
    public Toggle twoWay;

    public Text gameMode;
    public Text wayMode;
    public Text highestScore;
    void Start()
    {
        if(endlessMode.isOn)
        {
            MainManager.instance.modeNumber = 1;
            gameMode.text = "ENDLESS";
        }
        else if(timeTrialMode.isOn)
        {
            MainManager.instance.modeNumber = 2;
            gameMode.text = "TIME TRIAL";
        }

        if(oneWay.isOn)
        {
            MainManager.instance.oneWay = true;
            wayMode.text = "ONEWAY";
            if(endlessMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreEndLess;
            }
            else if (timeTrialMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreTimeTrial;
            }
        }
        else if(twoWay.isOn)
        {
            MainManager.instance.twoWay = true;
            wayMode.text = "TWOWAY";
            if(endlessMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreEndLess;
            }
            else if (timeTrialMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreTimeTrial;
            }
        }
    }

    public void EndLessMode()
    {
        if(endlessMode.isOn)
        {
            timeTrialMode.isOn = false;
            MainManager.instance.modeNumber = 1;
            gameMode.text = "ENDLESS";
            if (oneWay.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreEndLess;
            }
            else if (twoWay.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreEndLess;
            }
        }
    }
    public void TimeTrialMode()
    {
        if (timeTrialMode.isOn)
        {
            endlessMode.isOn = false;
            MainManager.instance.modeNumber = 2;
            gameMode.text = "TIME TRIAL";
            if (oneWay.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreTimeTrial;
            }
            else if (twoWay.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreTimeTrial;
            }
        }
    }
    public void OneWay()
    {
        if (oneWay.isOn)
        {
            twoWay.isOn = false;
            MainManager.instance.oneWay = true;
            MainManager.instance.twoWay = false;
            wayMode.text = "ONEWAY";
            if (endlessMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreEndLess;
            }
            else if(timeTrialMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.onewayHighscoreTimeTrial;
            }
        }
    }
    public void TwoWay()
    {
        if (twoWay.isOn)
        {
            oneWay.isOn = false;
            MainManager.instance.oneWay = false;
            MainManager.instance.twoWay = true;
            wayMode.text = "TWOWAY";
            if (endlessMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreEndLess;
            }
            else if (timeTrialMode.isOn)
            {
                highestScore.text = "" + MainManager.instance.twowayHighscoreTimeTrial;
            }
        }
    }
}
