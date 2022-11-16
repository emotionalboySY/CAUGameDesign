using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleReturn : MonoBehaviour
{
    public GameObject origin;
    public GameObject controller;
    public bool Activate = false;

    public void Attach()
    {
        controller.GetComponent<XRInteractorLineVisual>().enabled = false;
        Activate = true;
    }

    public void Return()
    {
        controller.GetComponent<XRInteractorLineVisual>().enabled = true;
        Activate = false;
        gameObject.transform.position = origin.transform.position;
        gameObject.transform.rotation = origin.transform.rotation;
    }
}
