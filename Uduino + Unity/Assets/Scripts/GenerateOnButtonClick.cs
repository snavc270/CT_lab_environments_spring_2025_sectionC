using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class GenerateOnButtonClick : MonoBehaviour
{
    public int button = 4;
    public GameObject prefab;

    int buttonValue = 0;
    int prevButtonValue = 0;

    void Start ()
    {
        UduinoManager.Instance.pinMode(button, PinMode.Input_pullup);
    }

    void Update ()
    {
        buttonValue = UduinoManager.Instance.digitalRead(button);

        // In this case, we compare the current button value to the previous button value, 
        // to trigger the change only once the value change.
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                PressedDown();
            }
            else if (buttonValue == 1)
            {
                PressedUp();
            }
            prevButtonValue = buttonValue; // Here we assign prev button value to the new value
        }

    }

    void PressedDown()
    {
        //if you want to change the color of another game object on button pressed 
        //buttonGameObject.GetComponent<Renderer>().material.color = Color.red;
        
        //generates a new instance of your GameObject; NOTE you will have to adjust the position 
        Instantiate(prefab, new Vector3(0.47f, 14.75f, 4.475669f), Quaternion.identity);
    }

    void PressedUp()
    {
        //any code you want to happen when button is released
    }
}
