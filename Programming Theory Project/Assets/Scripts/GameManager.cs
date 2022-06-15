using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;

    private float score;
    public Text scoreText;
    public Text totalDistanceText;
    public Text highSpeedText;
    public Text oppositeLaneText;
    public GameObject gameOverScreen;

    public GameObject gameScreen;
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    public GameObject infoScreen;
    public GameObject highScoreScreen;
    public GameObject highScoreText;

    public Text oneWayHighScoreEndLessText;
    public Text twoWayHighScoreEndLessText;
    public Text oneWayHighScoreTimeTrialText;
    public Text twoWayHighScoreTimeTrialText;

    public bool isMute;
    public bool isPaused;
    public bool gameOver;

    public GameObject dayCamera;
    public GameObject dayLight;
    public GameObject sunsetCamera;
    public GameObject sunsetLight;
    public GameObject nightCamera;
    public GameObject nightLight;
    public GameObject headLights;

    public float timeLeft;
    public float timeLeftAtStart;
    public Text timeLeftText;
    public GameObject timeLeftTextAlert;
    void Start()
    {
        Time.timeScale = 1;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        isMute = false;
        SetEnvironment();
        CheckMode();
    }

    void Update()
    {
        SetGameOverScreenInfo();
        
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
            ChangeHighScore();
            MainManager.instance.SaveColor();
        }

        if(MainManager.instance.modeNumber == 2 && !isPaused && !gameOver)
        {
            timeLeft = timeLeftAtStart  - Time.timeSinceLevelLoad;
            timeLeftText.text = "TIMELEFT: " + (Mathf.Round(timeLeft*10))/10 + "s";
            if (timeLeft <= 0)
            {
                gameOver = true;
                Time.timeScale = 0;
            }
        }
   
    }

    private void SetGameOverScreenInfo()
    {
        totalDistanceText.text = "TOTAL DISTANCE : " + playerController.distance / 100;
        float highSpeed = (Mathf.Round(playerController.totalHighSpeedTime * 10)) / 10;
        highSpeedText.text = "HIGHSPEED : " + highSpeed;
        float oppositeLane = (Mathf.Round(playerController.totalOppositeLaneTime * 10)) / 10;
        oppositeLaneText.text = "OPPOSITE LANE : " + oppositeLane;
        score = playerController.distance + highSpeed * 10 + oppositeLane * 10;
        scoreText.text = "SCORE" + score;
    }

    private void ChangeHighScore()
    {
        if (MainManager.instance.modeNumber == 1)
        {
            if (score > MainManager.instance.onewayHighscoreEndLess && MainManager.instance.oneWay)
            {
                highScoreText.SetActive(true);
                MainManager.instance.onewayHighscoreEndLess = (int)score;
            }
            else if (score > MainManager.instance.twowayHighscoreEndLess && MainManager.instance.twoWay)
            {
                highScoreText.SetActive(true);
                MainManager.instance.twowayHighscoreEndLess = (int)score;
            }
        }
        else if (MainManager.instance.modeNumber == 2)
        {
            if (score > MainManager.instance.onewayHighscoreTimeTrial && MainManager.instance.oneWay)
            {
                highScoreText.SetActive(true);
                MainManager.instance.onewayHighscoreTimeTrial = (int)score;
            }
            else if (score > MainManager.instance.twowayHighscoreTimeTrial && MainManager.instance.twoWay)
            {
                highScoreText.SetActive(true);
                MainManager.instance.twowayHighscoreTimeTrial = (int)score;
            }
        }
        oneWayHighScoreEndLessText.text = "ONEWAY " + MainManager.instance.onewayHighscoreEndLess;
        twoWayHighScoreEndLessText.text = "TWOWAY " + MainManager.instance.twowayHighscoreEndLess;
        oneWayHighScoreTimeTrialText.text = "ONEWAY " + MainManager.instance.onewayHighscoreTimeTrial;
        twoWayHighScoreTimeTrialText.text = "TWOWAY " + MainManager.instance.twowayHighscoreTimeTrial;
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void RestartButtonScene2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
 

    private void SetEnvironment()
    {
        if(MainManager.instance.environmentNumber == 1)
        {
            dayCamera.SetActive(true);
            dayLight.SetActive(true);
            sunsetCamera.SetActive(false);
            sunsetLight.SetActive(false);
            nightCamera.SetActive(false);
            nightLight.SetActive(false);
            headLights.SetActive(false);
        }
        else if(MainManager.instance.environmentNumber == 2)
        {
            dayCamera.SetActive(false);
            dayLight.SetActive(false);
            sunsetCamera.SetActive(true);
            sunsetLight.SetActive(true);
            nightCamera.SetActive(false);
            nightLight.SetActive(false);
            headLights.SetActive (false);
        }
        else if (MainManager.instance.environmentNumber == 3)
        {
            dayCamera.SetActive(false);
            dayLight.SetActive(false);
            sunsetCamera.SetActive(false);
            sunsetLight.SetActive(false);
            nightCamera.SetActive(true);
            nightLight.SetActive(true);
            headLights.SetActive(true) ;
        }
    }

    private void CheckMode()
    {
        if (MainManager.instance.modeNumber == 2)
        {
            timeLeftAtStart = 100.0f;
            timeLeftTextAlert.SetActive(true);
            timeLeftText.text = "TIMELEFT: " + timeLeftAtStart + "s";
        }
    }
    public void PauseButton()
    {
        if(!gameOver)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }
    public void PlayButton()
    {
        isPaused=false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    public void SettingsButton()
    {
        settingsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void SoundToggle()
    {
        if(!isMute)
        {
            AudioListener.volume = 0;
            isMute = true;
        }
        else
        {
            AudioListener.volume = 1;
            isMute = false;
        }
    }
    public void InfoButton()
    {
        infoScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void BackButtonPauseScreen()
    {
        settingsScreen.SetActive(false) ;
        infoScreen.SetActive(false) ;
        pauseScreen.SetActive(true) ;
    }
    public void HighScoreButton()
    {
        highScoreScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }
    public void BackButtonHighscoreScreen()
    {
        highScoreScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
