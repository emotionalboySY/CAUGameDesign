using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TuningManager : MonoBehaviour
{
    private Slider SpeedBar;
    private Slider BoosterWeight;
    private Slider BreakWeight;
    private Slider FuelBar;

    public TMP_Text speedTxt;
    public TMP_Text boosterTxt;
    public TMP_Text breakTxt;
    public TMP_Text fuelTxt;

    [HideInInspector] public float speed;
    [HideInInspector] public float booster;
    [HideInInspector] public float breakValue;
    [HideInInspector] public float fuel;

    // Start is called before the first frame update
    void Start()
    {
        SpeedBar = GameObject.Find("Canvas/Tuning/TuningWindow/SpeedBar").GetComponent<Slider>();
        BoosterWeight = GameObject.Find("Canvas/Tuning/TuningWindow/BoosterWeight").GetComponent<Slider>();
        BreakWeight = GameObject.Find("Canvas/Tuning/TuningWindow/BreakWeight").GetComponent<Slider>();
        FuelBar = GameObject.Find("Canvas/Tuning/TuningWindow/FuelBar").GetComponent<Slider>();

        speed = PlayerPrefs.GetFloat("Speed", 100);
        booster = PlayerPrefs.GetFloat("BoosterWeight", 5);
        breakValue = PlayerPrefs.GetFloat("BreakWeight", 5);
        fuel = PlayerPrefs.GetFloat("Fuel", 5);

        speedTxt.text = speed.ToString();
        boosterTxt.text = booster.ToString();
        breakTxt.text = breakValue.ToString();
        fuelTxt.text = fuel.ToString();

        SpeedBar.value = speed;
        BoosterWeight.value = booster;
        BreakWeight.value = breakValue;
        FuelBar.value = fuel;
    }

    public void TuningSpeed() {
        speed = SpeedBar.value;
        speedTxt.text = speed.ToString();
    }
    public void TuningBooster() {
        booster = BoosterWeight.value;
        boosterTxt.text = booster.ToString();
    }
    public void TuningBreak() {
        breakValue = BreakWeight.value;
        breakTxt.text = breakValue.ToString();
    }
    public void TuningFuel() {
        fuel = FuelBar.value;
        fuelTxt.text = fuel.ToString();
    }
}
