using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoinManager : MonoBehaviour
{
    public float rotateSpeed = 45.0f;
    AudioSource audioSource;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;
    
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
            PlayerController call = GameObject.Find("Player").GetComponent<PlayerController>();
            call.coinCount += 1;
            call.GetItem(call.coinCount);
            audioSource.Play(0);
            //gameObject.SetActive(false);
            meshRenderer.enabled = false;
            meshCollider.enabled = false;
            Invoke("destroy", audioSource.clip.length);
        }
    }

    void destroy(){
        gameObject.SetActive(false);
    }
}