using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovingController : Controller<MovementData>, IUpdatable, IDisaable, IEnableable
{
    [SerializeField]
    private CharacterController characterController;

    public void OnIEnable() {
        InputController.keyboardInputProvide += MoveInputProvided;
    }

    public void OnIUpdate() {
        
    }

    public void OnIDisable() {
        InputController.keyboardInputProvide -= MoveInputProvided;
    }

    private void MoveInputProvided(Vector2 keyboardInput) {
        Vector3 moveInput = new Vector3(keyboardInput.x * controllerData.GetSpeedFactor(), 0, keyboardInput.y * controllerData.GetSpeedFactor());
        characterController.Move(moveInput);
    }
}
