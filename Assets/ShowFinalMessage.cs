using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFinalMessage : MonoBehaviour
{
    public GameObject finalMessage;
    public AudioClip victorySound;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pancake"))
        {
            finalMessage.SetActive(true);
            audioSource.PlayOneShot(victorySound);
        }
    }
}
