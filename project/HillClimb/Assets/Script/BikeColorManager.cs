using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeColorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] bikeColorString = { "Red", "Blue", "Violet" };
    public int bikeColor;
    GameObject bodyMesh, handleMesh;
    void Start()
    {
        bodyMesh = GameObject.Find("Body");
        handleMesh = GameObject.Find("Handle");
        int bikeColor = PlayerPrefs.GetInt("BikeColor", 0);
        if (bikeColor < 0 || bikeColor > bikeColorString.Length)
        {
            bikeColor = 0;
        }
        Texture2D bodyTexture = Resources.Load<Texture2D>("Body_Texture_" + bikeColorString[bikeColor]);
        bodyMesh.GetComponent<Renderer>().material.mainTexture = bodyTexture;
        Texture2D handleTexture = Resources.Load<Texture2D>("Handle_Texture_" + bikeColorString[bikeColor]);
        handleMesh.GetComponent<Renderer>().material.mainTexture = handleTexture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
