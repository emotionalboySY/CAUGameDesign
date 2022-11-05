using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private KindOfWindow window = KindOfWindow.Stage;
    public GameObject practice;
    private GameObject current = null;

    enum KindOfWindow {
        Stage,
        Tuning,
        Vehicle
    }

    private void Start() {
        current = practice;
    }
    
    public void onStage() {
        window = KindOfWindow.Stage;
        if (current) {
            current.SetActive(false);
        }
        current = practice;
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
}
