using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    WheelCollider[] frontWheels, backWheels;
    GameObject[] frontWheelMesh, backWheelMesh;
    GameObject handleMesh;

    public float power = 100f;
    public float rot = 45f;
    public float stability = 2.0f;
    Rigidbody rb;
    public int coinCount = 0;
    public int MaxCoin = 3;
    public bool boosterPressed = false; // check if booster button is pressed
    EngineFuelManager theFuel;
    AudioSource audio;
    //engine booster
    public float boosterWeight = 5.0f;
    public Text coinCountFrontText;
    public Text coinCountBackText;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        coinCountFrontText.text = "     / " + MaxCoin;
        coinCountBackText.text = "0   ";
    }
    public void GetItem(int count)
    {
        coinCountBackText.text = count.ToString()+ "   ";
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
        theFuel = FindObjectOfType<EngineFuelManager>();

    }
    void FixedUpdate()
    {
        WheelPosAndAni();
        Move();
    }

    void Update()
    {




        if (Input.GetKeyDown(KeyCode.E) && theFuel.isFuel) // when pressed e button
        {
            boosterPressed = true;
            audio.Play();
        }

        if (Input.GetKeyUp(KeyCode.E ) || theFuel.isEmpty) // when we stop pressing e button
        {
            boosterPressed = false;
            audio.Stop();
        }


    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float accel = Input.GetAxis("Booster");
        //booster
        if (theFuel.isFuel)
        {
            rb.AddRelativeForce(0, 0, rb.mass * boosterWeight * accel);
        }


        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].motorTorque = v * power;
        }

        for (int i = 0; i < backWheels.Length; i++)
        {
            backWheels[i].motorTorque = v * power;
        }

        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].steerAngle = h * rot;
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
            //frontWheelMesh[i].transform.position = wheelPosition;
            frontWheelMesh[i].transform.rotation = wheelRotation;
        }
        if (frontWheels.Length > 0)
        {
            handleMesh.transform.localEulerAngles = new Vector3(0, frontWheels[0].steerAngle, 0);
        }
    }
}
