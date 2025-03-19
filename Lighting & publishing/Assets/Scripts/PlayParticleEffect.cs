using UnityEngine;

public class PlayParticleEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private ParticleSystem particleEffect; // Drag your Particle System here in the inspector

    void Start(){
        particleEffect = GetComponent<ParticleSystem>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collides with a specific object (optional)
        if (collision.gameObject.CompareTag("TriggerEffect"))
        {
            // Play the particle effect
            particleEffect.Play();
            Debug.Log("play"); 
        }
    }
}
