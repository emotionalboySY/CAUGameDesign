using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFuelManager : MonoBehaviour
{
    public float rotateSpeed = 45.0f;
    //public AudioClip audioEat;
    //AudioSource audioSource;
    
    


    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        //audioSource.clip = audioEat;
        //audioSource.Play(); //Play eatItem audio


        if (other.name == "Player")
        { // when collide with player

            EngineFuelManager call = GameObject.Find("UI").GetComponent<EngineFuelManager>();

            if (call.currentFuel > 3.5)
            {
                call.currentFuel = 5.0f;
            }
            else
            {
                call.currentFuel += 1.5f; // 30% increase

            }
            
            
            


            gameObject.SetActive(false);
        }
    }


}
