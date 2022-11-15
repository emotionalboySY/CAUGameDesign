using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TMP_Text timeTxt;
    float time = 80f;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
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
