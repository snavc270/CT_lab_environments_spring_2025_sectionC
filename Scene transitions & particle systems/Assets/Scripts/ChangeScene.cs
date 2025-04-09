using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour 
{
    //create a public variable for the scene name you want to load
    public string sceneName; 
    public void OnTriggerEnter(Collider other)
    {
        //only change scene when the player collides with the GameObect 
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName); //loads the scene name that you enter in your inspector
        }
    }
    
}
