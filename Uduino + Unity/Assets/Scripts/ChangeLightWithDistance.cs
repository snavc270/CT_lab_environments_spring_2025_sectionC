using UnityEngine;
using Uduino;

public class ChangeLightWithDistance : MonoBehaviour
{
     //public distancePlane; 

    //created public variable for our light source 
    public Light lightSource; 
    public float minIntensity = 1.0f; //setting a lower limit so light doesn't completely turn off 
    public float maxIntensity = 2.0f; //setting an upper limit so light doesn't get too bright; 

    public float minDistance = 10f; // Closest distance the sensor detects
    public float maxDistance = 300f; // Farthest distance the sensor detects
    float distance = 0;

    public int distance1; 
    public int distance2; 

    void Start() {
      UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void Update()  {  
        if(lightSource == null) return; //if we haven't set a light source, exit out of the function

        //if you wanted to map an object's position to your distance sensor
    //    distancePlane.transform.position = new Vector3(0, 0, distance ); 
        float mappedIntensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.InverseLerp(maxDistance, minDistance, distance1)); 
    
        // Apply intensity to the light
        lightSource.intensity = mappedIntensity;
        

    }

    void DataReceived(string data, UduinoDevice baord) {
       string[] values = data.Split (','); 
       if (values.Length == 2){ //making sure both sensors are sending values
        if (int.TryParse(values[0].Trim(), out int v1) && int.TryParse(values[1].Trim(), out int v2))
            {
                distance1 = v1;
                distance2 = v2;
                Debug.Log($"Parsed Values -> Value 1: {distance1}, Value 2: {distance2}");
            }
       }
     }
}
