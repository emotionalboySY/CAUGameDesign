using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    //PlayerController thePC;
    //void Start() {
        
    //    thePC = FindObjectOfType<PlayerController>();

    //}
    //void Update() {
        
    //    if (thePC.coinCount > 50)
    //    {
    //        Able();
    //    }
    //    else
    //    {
    //        Disable();
    //    }
    //    Debug.Log(thePC.coinCount);
        
    
    //}
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            int coin = player.coinCount + PlayerPrefs.GetInt("Coin", 0);
            PlayerPrefs.SetInt("Coin", coin); 
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameClear");
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);

    }
    void Able()
    {
        gameObject.SetActive(true);
    }
}
