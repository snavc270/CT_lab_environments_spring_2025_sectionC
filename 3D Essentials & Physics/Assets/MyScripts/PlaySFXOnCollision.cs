using UnityEngine;

public class PlaySFXOnCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private AudioSource playSound; //play sound source appears on inspector
    public AudioClip collisionSound; 
    void Start()
    {
        playSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (collisionSound != null)
        {
            // Play the collision sound
            playSound.PlayOneShot(collisionSound);
        }
    }
}

