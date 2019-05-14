using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : Controller<InputData>, IUpdatable, IDisaable, IEnableable
{
    public static Action<Vector2> keyboardInputProvide;

    private Vector2 keyboardInput = Vector2.zero;

    public void OnIEnable() {

    }

    public void OnIUpdate() {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
                keyboardInput.x = controllerData.GetXAxisSens();
                keyboardInput.y = controllerData.GetYAxisSens();
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {
                keyboardInput.x = -controllerData.GetXAxisSens();
                keyboardInput.y = controllerData.GetYAxisSens();
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {
                keyboardInput.x = controllerData.GetXAxisSens();
                keyboardInput.y = -controllerData.GetYAxisSens();
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
                keyboardInput.x = -controllerData.GetXAxisSens();
                keyboardInput.y = -controllerData.GetYAxisSens();
            }
            else if (Input.GetKey(KeyCode.A)) {
                keyboardInput.y = 0;
                keyboardInput.x = -controllerData.GetXAxisSens();
            }
            else if (Input.GetKey(KeyCode.D)) {
                keyboardInput.y = 0;
                keyboardInput.x = controllerData.GetXAxisSens();
            }
            else if (Input.GetKey(KeyCode.W)) {
                keyboardInput.x = 0;
                keyboardInput.y = controllerData.GetYAxisSens();
            }
            else if (Input.GetKey(KeyCode.S)) {
                keyboardInput.x = 0;
                keyboardInput.y = -controllerData.GetYAxisSens();
            }
            else {
                keyboardInput = Vector2.zero;
            }

            if(keyboardInputProvide != null) {
                keyboardInputProvide(keyboardInput);
            }
    }

    public void OnIDisable() {

    }
}
