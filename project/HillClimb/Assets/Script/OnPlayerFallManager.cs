using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerFallManager : MonoBehaviour
{
    PlayerController thePC;
    void Start()
    {
        thePC = FindObjectOfType<PlayerController>();
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "Wheel_F" || other.gameObject.name == "Wheel_B"){
            thePC.GameOver();
        }
    }
}
