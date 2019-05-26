using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovingController : ExecutableController<MovementData>, IUpdatable, IDisaable, IEnableable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private CharacterController characterController;

    public void OnIAwake() {}

    public void OnIEnable() {
        InputController.keyboardInputProvide += MoveInputProvided;
    }

    public void OnIUpdate() { }

    public void OnIDisable() {
        InputController.keyboardInputProvide -= MoveInputProvided;
    }

    private void MoveInputProvided(Vector2 keyboardInput) {
        Vector3 moveInput = new Vector3(keyboardInput.x * controllerData.GetSpeedFactor(), 0, keyboardInput.y * controllerData.GetSpeedFactor());
        moveInput.x = Mathf.Lerp(0, moveInput.x, 20f * Time.deltaTime);
        moveInput.z = Mathf.Lerp(0, moveInput.z, 20f * Time.deltaTime);
        characterController.Move(moveInput);

        if(keyboardInput != Vector2.zero) {
            SoundManager.Instance.PlaySound("LAG - Karyna_movement", GetComponent<AudioSource>());
        }
    }

    public void OnILateUpdate() {}
}
