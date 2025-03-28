using UnityEngine;
using System.Collections;
using Uduino; //adding the Uduino 'library' to our code
public class BlinkLED : MonoBehaviour
{
    UduinoManager u; // creating an instance of our Uduino manager so we don't have to type it over and over again
    public int greenPin = 12; 
    public int redPin = 13; 
    void Start()
    {
        UduinoManager.Instance.pinMode(greenPin, PinMode.PWM);
        UduinoManager.Instance.pinMode(redPin, PinMode.PWM);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("GreenTarget")) // Replace "TargetObject" with your tag
        {
            UduinoManager.Instance.analogWrite(greenPin, 255);
        }
        if (other.gameObject.CompareTag("RedTarget")){
            UduinoManager.Instance.analogWrite(redPin, 255);
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("GreenTarget")){
            UduinoManager.Instance.analogWrite(greenPin, 0);
        }
        if (other.gameObject.CompareTag("RedTarget")){
            UduinoManager.Instance.analogWrite(redPin, 0);
        }
    }
}
