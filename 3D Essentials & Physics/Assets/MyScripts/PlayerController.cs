using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5.0f; 
    public float rotationSpeed = 90.0f; 
    //create a variable of the type rigidbody, and name it rb
    private Rigidbody rb; 
    void Start()
    {
        //create a variable to store our GameObjects rigidbody
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        //getting keyboard input and storing in a variable
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime; 
        //Debug.Log(movement); 
        rb.MovePosition(rb.position + movement); 

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f); 
        rb.MoveRotation(rb.rotation * turnRotation);  
    }
}
