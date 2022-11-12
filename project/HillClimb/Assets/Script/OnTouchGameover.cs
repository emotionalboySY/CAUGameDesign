using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchGameover : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            player.GameOver();
        }
    }
}
