using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    float ellapsedTime;
    public enum Condition {TimeLessThan, CoinsNotLessThan, ClearStage};
    [System.Serializable]
    public class ScoreCriteria{
        public Condition condition;
        public float targetValue;
        float currentValue;
    }
    public ScoreCriteria[] scoreCriterias = new ScoreCriteria[3];
    void OnStart(){
        ellapsedTime = Time.timeSinceLevelLoad;
    }

    
}
