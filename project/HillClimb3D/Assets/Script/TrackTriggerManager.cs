using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTriggerManager : MonoBehaviour
{
    PlayerController playerController;
    bool isOutFromTrack = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOutFromTrack)
        {
            playerController.GameOver();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            isOutFromTrack = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            isOutFromTrack = true;
        }
    }
}
