using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private KindOfWindow window = KindOfWindow.Stage; //Stage, Tuning, Vehicle
    private GameObject[] stage; //Practice, Lake Road, etc
    private GameObject current = null; //What window at now?
    private int maxCnt; //max count of page
    private int cnt;

    enum KindOfWindow {
        Stage,
        Tuning,
        Vehicle
    }

    private void Start() {
        GameObject temp = GameObject.Find("Canvas/StageWindow");
        stage = new GameObject[2];

        for(int i = 0; i < stage.Length; i++) {
            stage[i] = temp.transform.GetChild(i).gameObject;
        }
        maxCnt = 1;
        cnt = 0;
        current = stage[cnt];
    }

    public void onStage() {
        window = KindOfWindow.Stage;
        if (current) {
            current.SetActive(false);
        }
        maxCnt = 1;
        cnt = 0;
        current = stage[cnt];
        current.SetActive(true);
    }

    public void onTuning() {
        window = KindOfWindow.Tuning;
        if (current) {
            current.SetActive(false);
        }
    }

    public void onVehicle() {
        window = KindOfWindow.Vehicle;
        if (current) {
            current.SetActive(false);
        }
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
