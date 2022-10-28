using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoinManager : MonoBehaviour
{
    public float rotateSpeed = 45.0f;
    

    


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

        

        if (other.name == "Player")
        { // when collide with player
            PlayerController call = GameObject.Find("Player").GetComponent<PlayerController>();
            call.coinCount += 1;
            call.GetItem(call.coinCount);

            gameObject.SetActive(false);
        }
    }


}