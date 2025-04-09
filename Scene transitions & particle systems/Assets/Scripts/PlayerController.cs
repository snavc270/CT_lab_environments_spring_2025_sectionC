using UnityEngine;

//controlls player movement & rotation
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5.0f; 
    public float rotationSpeed = 120.0f; 
    private Rigidbody rb; 
    public float jumpForce = 5.0f; 
    private void Start(){
        rb = GetComponent<Rigidbody>(); 
    }
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate(){
        float moveVertical = Input.GetAxis("Vertical"); 
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + movement); 

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime; 
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f); 
        rb.MoveRotation(rb.rotation * turnRotation); 
    }
}