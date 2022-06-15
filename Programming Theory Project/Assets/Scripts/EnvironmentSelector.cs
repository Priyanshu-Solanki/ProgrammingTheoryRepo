using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentSelector : MonoBehaviour
{
    public Toggle dayToggle;
    public Toggle sunsetToggle;
    public Toggle nightToggle;

    public Text lightMode;
    public void Start()
    {
        if(dayToggle.isOn)
        {
            MainManager.instance.environmentNumber = 1;
            lightMode.text = "DAY";
        }
        else if (sunsetToggle.isOn)
        {
            MainManager.instance.environmentNumber = 2;
            lightMode.text = "SUNSET";
        }
        else if (nightToggle.isOn)
        {
            MainManager.instance.environmentNumber = 3;
            lightMode.text = "NIGHT";
        }
    }

    public void OnEnableDay()
    {
        if(dayToggle.isOn)
        {
            sunsetToggle.isOn = false;
            nightToggle.isOn = false;
            MainManager.instance.environmentNumber = 1;
            lightMode.text = "DAY";
        }

    }
    public void OnEnableSunset()
    {
        if(sunsetToggle.isOn)
        {
            dayToggle.isOn = false;
            nightToggle.isOn = false;
            MainManager.instance.environmentNumber = 2;
            lightMode.text = "SUNSET";
        }

    }
    public void OnEnableNight()
    {
        if(nightToggle.isOn)
        {
            sunsetToggle.isOn = false;
            dayToggle.isOn = false;
            MainManager.instance.environmentNumber = 3;
            lightMode.text = "NIGHT";
        }

    }
}
