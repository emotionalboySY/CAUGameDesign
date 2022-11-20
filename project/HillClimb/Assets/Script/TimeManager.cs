using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    Text timeTxt;
    float time = 120f;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        timeTxt = GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0) {
            player.GameOver();
        } else {
            time -= Time.deltaTime;
            timeTxt.text = Mathf.Floor(time).ToString();
        }
    }
}
