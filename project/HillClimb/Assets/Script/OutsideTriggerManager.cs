using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTriggerManager : MonoBehaviour
{
    PlayerController playerController;
    bool isOutSideTouched = false;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOutSideTouched)
        {
            playerController.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            isOutSideTouched = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player" || other.gameObject.name == "Wheel_F" || other.gameObject.name == "Wheel_B"){
            isOutSideTouched = true;
        }
    }

}
