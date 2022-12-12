using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    Text timeTxt;
    public float maxTime = 120f;
    public float time;
    public float remainingTime;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        timeTxt = GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        time = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.timeSinceLevelLoad;
        remainingTime = maxTime - time;
        if(remainingTime <= 0) {
            player.GameOver();
        } else {
            timeTxt.text = Mathf.Floor(remainingTime).ToString();
        }
    }
}
