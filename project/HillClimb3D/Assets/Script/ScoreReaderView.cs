using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreReaderView : MonoBehaviour
{
    void Start()
    {
        string clearedStageName = PlayerPrefs.GetString("LastCleared", "");
        if(clearedStageName == "") {
            GameObject.Find("ScoreBoard").SetActive(false);
            return;
        }
        GameObject[] scoreBoard = new GameObject[2];
        Sprite GOLDSTAR = Resources.Load<Sprite>("star-gold");
        for(int i = 0;i < 2;i++) {
            scoreBoard[i] = GameObject.Find("GameStar " + i);
            Debug.Log(scoreBoard[i]);
            Debug.Log(scoreBoard[i].transform.GetChild(0));
        }
        for(int i = 0;i < 2;i++) {
            int cleared = PlayerPrefs.GetInt(clearedStageName + "-star-" + i, 0);
            ScoreManager.ScoreCriteria.Condition condition = (ScoreManager.ScoreCriteria.Condition)PlayerPrefs.GetInt(clearedStageName + "-cond-" + i, 0);
            float score = PlayerPrefs.GetFloat(clearedStageName + "-score-" + i, 0);
            float target = PlayerPrefs.GetFloat(clearedStageName + "-target-" + i, 0);
            string text = "";
            switch (condition) {
                case ScoreManager.ScoreCriteria.Condition.CoinsNotLessThan:
                    text = "Coins: " + score + " / " + target;
                    break;
                case ScoreManager.ScoreCriteria.Condition.TimeLessThan:
                    text = "Time Limit:" + Mathf.Round(score * 100) / 100 + " / " + target;
                    break;
            }
            scoreBoard[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(text);
            if (cleared == 1) {
                scoreBoard[i].transform.GetChild(0).GetComponent<Image>().sprite = GOLDSTAR;
            }
        }
        PlayerPrefs.SetString("LastCleared", "");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
