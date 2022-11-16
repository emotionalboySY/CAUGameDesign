using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    WheelCollider[] frontWheels, backWheels;
    GameObject[] frontWheelMesh, backWheelMesh;
    GameObject handleMesh;

    public float power;
    public float rotSensitive = 60f;
    public float stability = 1.5f;
    public float tiltWeight = 0.2f;
    Rigidbody rb;
    public int coinCount = 0; // Remember, we will use PlayerPrefs value as "Coin", Integer value type.
    public int MaxCoin = 15; //Maybe, make it different when stage changed.
    public bool boosterPressed = false; // check if booster button is pressed
    EngineFuelManager theFuel;
    AudioSource playerAudio;
    //engine booster
    public float boosterWeight;
    //break power
    public float breakPower;

    public TMP_Text coinCountFrontText;
    public TMP_Text coinCountBackText;

    public GameObject leftC;
    public GameObject rightC;

    HandleReturn leftHandle;
    HandleReturn rightHandle;

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        coinCountFrontText.text = "/" + MaxCoin;
        coinCountBackText.text = "0";

        power = PlayerPrefs.GetFloat("Speed", 100);
        boosterWeight = PlayerPrefs.GetFloat("BoosterWeight", 5);
        breakPower = PlayerPrefs.GetFloat("BreakWeight", 5);
    }

    public void GetItem(int count)
    {
        coinCountBackText.text = count.ToString();
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    void Start()
    {
        frontWheelMesh = GameObject.FindGameObjectsWithTag("FrontWheelMesh");
        backWheelMesh = GameObject.FindGameObjectsWithTag("BackWheelMesh");
        handleMesh = GameObject.FindGameObjectWithTag("HandleMesh");
        GameObject[] fwcObjects = GameObject.FindGameObjectsWithTag("FrontWheelCollider");
        GameObject[] bwcObjects = GameObject.FindGameObjectsWithTag("BackWheelCollider");
        frontWheels = new WheelCollider[fwcObjects.Length];
        backWheels = new WheelCollider[bwcObjects.Length];
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i] = fwcObjects[i].GetComponent<WheelCollider>();
        }
        for (int i = 0; i < backWheels.Length; i++)
        {
            backWheels[i] = bwcObjects[i].GetComponent<WheelCollider>();
        }
        for (int i = 0; i < frontWheelMesh.Length; i++)
        {
            frontWheels[i].transform.position = frontWheelMesh[i].transform.position;
        }

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -stability, 0);
        theFuel = GameObject.Find("Player/UI/UI").GetComponent<EngineFuelManager>();
        leftHandle = GameObject.Find("Player/left handle").GetComponent<HandleReturn>();
        rightHandle = GameObject.Find("Player/right handle").GetComponent<HandleReturn>();

    }
    void FixedUpdate()
    {
        WheelPosAndAni();
        Move();
        if (leftHandle.Activate && rightHandle.Activate)
        {
            Rotate();
        }
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) && leftHandle.Activate && rightHandle.Activate) // break button
        {
            Break();
        }

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("Stage1"); //Final: Lobby. This is temp.
        }
    }

    void Move()
    {
        if (OVRInput.Get(OVRInput.Button.Two) && theFuel.isFuel && leftHandle.Activate && rightHandle.Activate) // go forward
        {
            playerAudio.Play();
            theFuel.currentFuel -= Time.deltaTime * 0.2f;
            for (int i = 0; i < frontWheels.Length; i++)
            {
                frontWheels[i].motorTorque = power;
            }

            for (int i = 0; i < backWheels.Length; i++)
            {
                backWheels[i].motorTorque = power;
            }

        } else
        {
            playerAudio.Stop();
            for (int i = 0; i < frontWheels.Length; i++)
            {
                frontWheels[i].motorTorque = 0;
            }

            for (int i = 0; i < backWheels.Length; i++)
            {
                backWheels[i].motorTorque = 0;
            }
        }
    }

    void Rotate()
    {
        float rot = (leftC.transform.localPosition.z - rightC.transform.localPosition.z) * rotSensitive;
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].steerAngle = rot;
        }
        //transform.Rotate(new Vector3(0, 0, -h * tiltWeight));
    }

    void Booster() {
        rb.AddRelativeForce(0, 0, rb.mass * boosterWeight);
    }

    void Break() {
        if (rb.velocity.magnitude > 5.0f) {
            rb.AddRelativeForce(0, 0, -rb.mass * breakPower);
        }
    }

    void WheelPosAndAni()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < backWheels.Length; i++)
        {
            backWheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            backWheelMesh[i].transform.position = wheelPosition;
            backWheelMesh[i].transform.rotation = wheelRotation;
        }

        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            frontWheelMesh[i].transform.rotation = wheelRotation;
        }
        if (frontWheels.Length > 0)
        {
            handleMesh.transform.localEulerAngles = new Vector3(0, frontWheels[0].steerAngle, 0);
        }
    }
}
