using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleReturn : MonoBehaviour
{
    public GameObject origin;
    public GameObject controller;
    public GameObject oculusTouch;
    public GameObject hand;
    public bool Activate = false;

    public void Attach()
    {
        controller.GetComponent<XRInteractorLineVisual>().enabled = false;
        oculusTouch.SetActive(false);
        hand.SetActive(true);
        Activate = true;
    }

    public void Return()
    {
        controller.GetComponent<XRInteractorLineVisual>().enabled = true;
        oculusTouch.SetActive(true);
        hand.SetActive(false);
        Activate = false;
        gameObject.transform.position = origin.transform.position;
        gameObject.transform.rotation = origin.transform.rotation;
    }
}