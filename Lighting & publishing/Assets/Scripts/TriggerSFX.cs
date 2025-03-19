using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound; //play sound source appears on inspector

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("TriggerEffect")){
            playSound.Play(); 
            Debug.Log("play sound'"); 
        }
    }
}
