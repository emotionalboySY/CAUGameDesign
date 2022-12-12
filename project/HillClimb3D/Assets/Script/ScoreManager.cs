using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Length;
    public string stageName;

    [System.Serializable]
    public class ScoreCriteria{
        public enum Condition {TimeLessThan, CoinsNotLessThan};
        public Condition condition;
        public float targetValue;
        public float currentValue;
    }
    public ScoreCriteria[] scoreCriterias = new ScoreCriteria[2];
    
    TimeManager timeManager;
    PlayerController thePC;
    
    void Awake(){
        thePC = GameObject.Find("Player").GetComponent<PlayerController>();
        timeManager = GameObject.Find("Time").GetComponent<TimeManager>();
        Length = scoreCriterias.Length;
    }

    void Update(){
        for(int i = 0;i < scoreCriterias.Length;i++){
            switch(scoreCriterias[i].condition){
                case ScoreCriteria.Condition.TimeLessThan:
                    scoreCriterias[i].currentValue = timeManager.time;
                break;
                case ScoreCriteria.Condition.CoinsNotLessThan:
                    scoreCriterias[i].currentValue = (float)thePC.coinCount;
                break;
            }
        }
    }
    
    public bool isCleared(int idx){
        if(idx < 0 || idx >= scoreCriterias.Length){
            return false;
        }
        switch(scoreCriterias[idx].condition){
            case ScoreCriteria.Condition.TimeLessThan:
                return scoreCriterias[idx].currentValue < scoreCriterias[idx].targetValue;
            case ScoreCriteria.Condition.CoinsNotLessThan:
                return scoreCriterias[idx].currentValue >= scoreCriterias[idx].targetValue;
        }
        return false;
    }
}