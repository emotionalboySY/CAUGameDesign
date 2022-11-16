using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerPos : MonoBehaviour
{
    public TMP_Text posText;
    public GameObject left;
    public GameObject right;

    // Update is called once per frame
    void Update()
    {
        posText.text = "(" + left.transform.localPosition.ToString() + ") , (" + right.transform.localPosition.ToString() + ")";
    }
}
