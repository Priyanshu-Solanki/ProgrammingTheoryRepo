using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject centerOfMass;
    [SerializeField] float horsePower;
    [SerializeField] float turnSpeed;
    [SerializeField] float speed;
    public Text speedText;
    public float distance { get; private set;}
    public Text distanceText;
    public GameObject highSpeedAlertTextObject;
    public Text highSpeedAlertText;
    public GameObject oppositeLaneAlertTextObject;
    public Text oppositeLaneAlertText;
    private float startingPosition;
    private float currentPosition;

    private GameManager gameManager;

    private AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    private float currentTime;
    public GameObject body;

    public float highSpeedTime;
    public float totalHighSpeedTime;
    private float highSpeedReachedTime;
    private bool reachingHighSpeed;
    private bool canAddToHighSpeed;

    public float oppositeLaneTime;
    public float totalOppositeLaneTime;
    private float oppositeLaneReachedTime;
    private bool reachingOppositeLane;
    private bool canAddToOppositeLane;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
        playerRb.velocity = new Vector3(0, 0, 5.8f);
        startingPosition = transform.position.z;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        SetColor();
        SetTextColor();
        reachingHighSpeed = true;
        canAddToHighSpeed = true;
        reachingOppositeLane = true;
        canAddToOppositeLane = true;
    }

    void Update()
    {
        Accelaration();
        HighSpeedAlert();
        OppositeLaneAlert();

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        SetSpeed();
        currentPosition = transform.position.z;
        distance = Mathf.Round((currentPosition - startingPosition) / 10);
        SetDistance();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.gameOver = true;
            Time.timeScale = 0;
        }
    }
    private void Accelaration()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (speed > 18 && speed < 300 && !gameManager.isPaused)
        {
            if (verticalInput > 0)
            {
                playerRb.AddForce(Vector3.forward * verticalInput * horsePower);
                if (speed < 100)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        audioSource.volume = 0.8f;
                        audioSource.clip = clip1;
                        audioSource.Play();
                    }

                }
                else if (speed > 100)
                {
                    audioSource.clip = clip2;
                    if (Time.time - currentTime > 1.4f)
                    {
                        audioSource.volume = 0.6f;
                        audioSource.Play();
                        currentTime = Time.time;
                    }

                }
            }
            else
            {
                playerRb.AddForce(Vector3.forward * verticalInput * horsePower * 4);
                if (Input.GetKeyDown(KeyCode.DownArrow) && speed > 30)
                {
                    audioSource.clip = clip3;
                    audioSource.Play();
                }
            }
            if (gameManager.gameOver)
            {
                audioSource.Pause();
            }
        }
        else if (speed < 20)
        {
            playerRb.velocity = new Vector3(0, 0, 5.8f);
        }
    }
    private void HighSpeedAlert()
    {
        if (speed > 100)
        {
            if (reachingHighSpeed)
            {
                highSpeedReachedTime = Time.time;
                reachingHighSpeed = false;
                canAddToHighSpeed = true;
            }
            highSpeedTime = Time.time - highSpeedReachedTime;
            highSpeedAlertText.text = "HIGHSPEED: " + (Mathf.Round(highSpeedTime * 10)) / 10 + "s";
            highSpeedAlertTextObject.SetActive(true);
        }
        else if (speed < 100)
        {
            highSpeedAlertTextObject.SetActive(false);
            if (canAddToHighSpeed)
            {
                totalHighSpeedTime += highSpeedTime;
                canAddToHighSpeed = false;
                reachingHighSpeed = true;
            }

        }
        if (gameManager.gameOver && canAddToHighSpeed)
        {
            if (speed > 100)
            {
                totalHighSpeedTime += highSpeedTime;
                canAddToHighSpeed = false;
            }
        }
    }
    private void OppositeLaneAlert()
    {
        if (MainManager.instance.twoWay)
        {
            if (transform.position.x <= -4)
            {
                if (reachingOppositeLane)
                {
                    oppositeLaneReachedTime = Time.time;
                    reachingOppositeLane = false;
                    canAddToOppositeLane = true;
                }
                oppositeLaneTime = Time.time - oppositeLaneReachedTime;
                oppositeLaneAlertText.text = "OPPOSITE LANE: " + (Mathf.Round(oppositeLaneTime * 10)) / 10 + "s";
                oppositeLaneAlertTextObject.SetActive(true);
            }
            else
            {
                oppositeLaneAlertTextObject.SetActive(false);
                if (canAddToOppositeLane)
                {
                    totalOppositeLaneTime += oppositeLaneTime;
                    canAddToOppositeLane = false;
                    reachingOppositeLane = true;
                }
            }
            if (gameManager.gameOver && canAddToOppositeLane)
            {
                if (transform.position.x <= -4)
                {
                    totalOppositeLaneTime += oppositeLaneTime;
                    canAddToOppositeLane = false;
                }
            }
        }
    }
    public void SetSpeed()
    {
        speedText.text = "Speed : " + speed + "KPH";
    }
    public void SetDistance()
    {
        distanceText.text = "Distance : " + (distance / 100) + "KM";
    }

    private void SetColor()
    {
        if (MainManager.instance.colorNumber == 1)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
        }
        else if (MainManager.instance.colorNumber == 2)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        }
        else if (MainManager.instance.colorNumber == 3)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);

        }
        else if (MainManager.instance.colorNumber == 4)
        {
            body.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
        }
    }
    private void SetTextColor()
    {
        if(MainManager.instance.environmentNumber == 3)
        {
            speedText.color = new Color(1, 1, 1, 1);
            distanceText.color = new Color(1, 1, 1, 1);
        }
    }

}
