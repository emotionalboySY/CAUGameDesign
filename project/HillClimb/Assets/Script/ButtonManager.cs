using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*
Speed(float)
BoosterWeight(float)
BreakWeight(float)
Fuel(Float)
*/

public class ButtonManager : MonoBehaviour
{
    static int STAGE_NUM = 2; // num of stage
    static int VEHICLE_NUM = 1; // num of vehicle

    private KindOfWindow window = KindOfWindow.Stage; //Stage, Tuning, Vehicle
    private GameObject[] stage; //Practice, Lake Road, etc
    private GameObject tuning;
    private GameObject current = null; //What window at now?
    private GameObject left;
    private GameObject right;
    private GameObject start;
    private GameObject save;

    public TMP_Text coinTxt;
    private int maxCnt; //max count of page
    private int cnt;
    TuningManager tuner;

    enum KindOfWindow {
        Stage,
        Tuning,
        Vehicle
    }

    private void Start() {
        tuner = GameObject.Find("TuningManagement").GetComponent<TuningManager>();
        coinTxt.text = PlayerPrefs.GetInt("Coin", 0).ToString();
        tuning = GameObject.Find("Canvas/Tuning/TuningWindow");
        left = GameObject.Find("Canvas/BigWindow/SmallWindow/leftArrow");
        right = GameObject.Find("Canvas/BigWindow/SmallWindow/rightArrow");
        start = GameObject.Find("Canvas/BigWindow/Start");
        save = GameObject.Find("Canvas/BigWindow/Save");

        GameObject temp = GameObject.Find("Canvas/StageWindow");
        stage = new GameObject[STAGE_NUM];
        for(int i = 0; i < STAGE_NUM; i++) {
            stage[i] = temp.transform.GetChild(i).gameObject;
        }

        onStage();
    }

    public void onStage() {
        window = KindOfWindow.Stage;
        if (current) {
            current.SetActive(false);
        }
        maxCnt = STAGE_NUM - 1;
        cnt = 0;
        current = stage[cnt];
        current.SetActive(true);
        left.SetActive(true);
        right.SetActive(true);
        start.SetActive(true);
        save.SetActive(false);
    }

    public void onTuning() {
        window = KindOfWindow.Tuning;
        if (current) {
            current.SetActive(false);
        }
        left.SetActive(false);
        right.SetActive(false);
        start.SetActive(false);
        save.SetActive(true);
        tuning.SetActive(true);
        current = tuning;
    }

    public void onVehicle() {
        window = KindOfWindow.Vehicle;
        if (current) {
            current.SetActive(false);
        }
        maxCnt = VEHICLE_NUM - 1;
        cnt = 0;
        left.SetActive(true);
        right.SetActive(true);
        start.SetActive(false);
        save.SetActive(true);
    }

    public void onStart() {
        switch(cnt) {
            case 0:
                SceneManager.LoadScene("Practice");
                break;
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
        }
    }

    public void onSave() {
        switch(window) {
            case KindOfWindow.Tuning:
                PlayerPrefs.SetFloat("Speed", tuner.speed);
                PlayerPrefs.SetFloat("BoosterWeight", tuner.booster);
                PlayerPrefs.SetFloat("BreakWeight", tuner.breakValue);
                PlayerPrefs.SetFloat("Fuel", tuner.fuel);
                PlayerPrefs.Save();
                break;
            case KindOfWindow.Vehicle:
                break;
        }
    }

    public void onLeftArrow() {
        current.SetActive(false);
        
        if (cnt == 0) {
            cnt = maxCnt;
        } else {
            cnt -= 1;
        }

        switch(window) {
            case KindOfWindow.Stage:
                current = stage[cnt];
                break;
            case KindOfWindow.Vehicle:
                break;
        }
        current.SetActive(true);
    }

    public void onRightArrow() {
        current.SetActive(false);
        
        if (cnt == maxCnt) {
            cnt = 0;
        } else {
            cnt += 1;
        }

        switch(window) {
            case KindOfWindow.Stage:
                current = stage[cnt];
                break;
            case KindOfWindow.Vehicle:
                break;
        }
        current.SetActive(true);
    }
}
