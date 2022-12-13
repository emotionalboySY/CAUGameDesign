using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OVR;

public class ReturnToLobby : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start)) // when pressed Restart button R
        {
            SceneManager.LoadScene("Lobby"); // load current Stage
        }
    }
}
