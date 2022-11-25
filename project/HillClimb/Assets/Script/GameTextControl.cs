using UnityEngine;
using System.Collections;

public class GameTextControl : MonoBehaviour
{
    public GameObject readText;
    public static GameTextControl instance;


    void Awake()
    {
        if (GameTextControl.instance == null)
            GameTextControl.instance = this;
    }
    // Use this for initialization
    void Start()
    {
        readText.SetActive(true);
        StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 3)
        {
            readText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            readText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}