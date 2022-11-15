using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFuelManager : MonoBehaviour
{
    
    public float rotateSpeed = 45.0f;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        
        
        if (other.name == "Player")
        { // when collide with player
            audioSource.Play(0); //Play eatItem audio

            EngineFuelManager call = GameObject.Find("Player/UI/UI").GetComponent<EngineFuelManager>();
            float max = call.maxFuel;

            if (call.currentFuel > max * 0.7f)
            {
                call.currentFuel = max;
            }
            else
            {
                call.currentFuel += max * 0.3f; // 30% increase

            }
            meshRenderer.enabled = false;
            meshCollider.enabled = false;
            Invoke("destroy", audioSource.clip.length);


        }

    }
    void destroy()
    {
        gameObject.SetActive(false);
    }

}
