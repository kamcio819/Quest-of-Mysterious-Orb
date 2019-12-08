using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : ExecutableController<InputData>, IUpdatable, ILateUpdatable, IDisaable, IEnableable, IAwakable
{
    public static Action<Vector2> keyboardInputProvide;
    public static Action<Vector2> mouseInputProvide;
    public static Action<bool> mouseRightButtonClicked;
    public static Action<bool> mouseLeftButtonClicked;
    public static Action<float> mouseScrollWheelMoved;
    public static Action<bool> mouseScrollWheelClicked;
    public static Action<bool> mouseRightButtonPressed;

    private Vector2 keyboardInput = Vector2.zero;
    private Vector2 mouseInput = Vector2.zero;

    public void OnIAwake() {}
    public void OnIEnable() {}

    public void OnIUpdate() {
        mouseInput.x = Input.GetAxis("Horizontal") * Time.deltaTime;
        mouseInput.y = Input.GetAxis("Vertical") * Time.deltaTime;

        if(mouseInput != Vector2.zero) {
            if(mouseInputProvide != null) {
                mouseInputProvide(mouseInput);
            }
        }


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

        if(keyboardInput != Vector2.zero) {
            if(keyboardInputProvide != null) {
                keyboardInputProvide(keyboardInput);
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            if(mouseLeftButtonClicked != null) {
                mouseLeftButtonClicked(true);
            }
        }

        if(Input.GetMouseButtonUp(1)) {
            if(mouseRightButtonClicked != null) {
                mouseRightButtonClicked(true);
            }
        }

        if(Input.GetMouseButton(1)) {
            if(mouseRightButtonPressed != null) {
                mouseRightButtonPressed(true);
            }
        }
        else {
            if(mouseRightButtonPressed != null) {
                mouseRightButtonPressed(false);
            }
        }

        if(mouseScrollWheelMoved != null) {
            mouseScrollWheelMoved(Input.mouseScrollDelta.y);
        }
           
    }

    public void OnIDisable() {}

    public void OnILateUpdate() {}
}
