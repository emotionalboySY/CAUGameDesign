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
    public TMP_Text billTxt;

    [HideInInspector] public float speed;
    [HideInInspector] public float booster;
    [HideInInspector] public float breakValue;
    [HideInInspector] public float fuel;
    [HideInInspector] public int bill = 0;

    private float speedBill = 0;
    private float boosterBill = 0;
    private float breakBill = 0;
    private float fuelBill = 0;

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
        speedBill = Mathf.Abs(speed - PlayerPrefs.GetFloat("Speed", 100));
        CalcBill();
    }
    public void TuningBooster() {
        booster = BoosterWeight.value;
        boosterTxt.text = booster.ToString();
        boosterBill = Mathf.Abs((booster - PlayerPrefs.GetFloat("BoosterWeight", 5)) * 5);
        CalcBill();
    }
    public void TuningBreak() {
        breakValue = BreakWeight.value;
        breakTxt.text = breakValue.ToString();
        breakBill = Mathf.Abs((breakValue - PlayerPrefs.GetFloat("BreakWeight", 5)) * 5);
        CalcBill();
    }
    public void TuningFuel() {
        fuel = FuelBar.value;
        fuelTxt.text = fuel.ToString();
        fuelBill = Mathf.Abs((fuel - PlayerPrefs.GetFloat("Fuel", 5)) * 5);
        CalcBill();
    }
    private void CalcBill(){
        bill = (int) Mathf.Ceil(speedBill + boosterBill + breakBill + fuelBill);
        billTxt.text = bill.ToString();
    }
    public void ClearBill(){
        speedBill = 0;
        boosterBill = 0;
        breakBill = 0;
        fuelBill = 0;
        bill = 0;
        billTxt.text = bill.ToString();
    }
}
