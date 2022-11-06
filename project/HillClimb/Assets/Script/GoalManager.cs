using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            int coin = player.coinCount + PlayerPrefs.GetInt("Coin", 0);
            PlayerPrefs.SetInt("Coin", coin); 
            SceneManager.LoadScene("Lobby");
        }
    }
}
