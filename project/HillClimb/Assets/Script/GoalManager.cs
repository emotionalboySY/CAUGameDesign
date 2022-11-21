using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    ScoreManager scoreManager;
    void Awake() {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void stageClear() {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        string stageName = SceneManager.GetActiveScene().name;
        Debug.Log(stageName + "]" + "criterias:");
        for(int i = 0;i < scoreManager.Length;i++){
            //Debug.Log(i + ":Cond=" + scoreManager.scoreCriterias[i].condition);
            //Debug.Log(i + ":current=" + scoreManager.scoreCriterias[i].currentValue);
            //Debug.Log(i + ":target=" + scoreManager.scoreCriterias[i].targetValue);
            //Debug.Log(i + ":clearCheck=" + scoreManager.isCleared(i));
            
            if(scoreManager.isCleared(i)){
                PlayerPrefs.SetInt(stageName + "-star-" + i, 1);
            }
            float score = scoreManager.scoreCriterias[i].currentValue;
            PlayerPrefs.SetInt(stageName + "-cond-" + i, (int)scoreManager.scoreCriterias[i].condition);
            PlayerPrefs.SetFloat(stageName + "-target-" + i, (int)scoreManager.scoreCriterias[i].targetValue);
            PlayerPrefs.SetFloat(stageName + "-score-" + i, score);
            PlayerPrefs.SetString("LastCleared", stageName);
        }
        PlayerPrefs.SetInt(stageName + "-cleared", 1);


        int coin = player.coinCount + PlayerPrefs.GetInt("Coin", 0);
        PlayerPrefs.SetInt("Coin", coin);


        PlayerPrefs.Save();
        SceneManager.LoadScene("GameClear");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            stageClear();
            
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
