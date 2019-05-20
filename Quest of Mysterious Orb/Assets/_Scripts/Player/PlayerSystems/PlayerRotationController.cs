using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerRotationController : ExecutableController<InputData, MovementData>, IUpdatable, IEnableable, IDisaable, ILateUpdatable, IAwakable
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3 deltaCursor = Vector3.zero;
    private static Vector3 cursorPosition;
    private bool hitFlag = false;

    public Vector3 DeltaCursor { get => deltaCursor; set => deltaCursor = value; }
    public static Vector3 CursorPosition { get => cursorPosition; set => cursorPosition = value; }

    public void OnIAwake() {}

    public void OnIEnable()
    {
        InputController.mouseInputProvide += RotatePlayer;
    }
    public void OnIUpdate() {}

    public void OnIDisable()
    {    
        InputController.mouseInputProvide -= RotatePlayer;
    }

    private void RotatePlayer(Vector2 input) {
       if(input != Vector2.zero) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50f, layerMask))
            {
                deltaCursor = transform.position - hit.point;
                deltaCursor.y = 0;
                cursorPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                
            }
            else {
            }
       }
       else {
           deltaCursor = Vector3.zero;
       }
    }

    public void OnILateUpdate() {}
}
