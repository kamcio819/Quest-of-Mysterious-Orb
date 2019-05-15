using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class RotationController : ExecutableController<InputData, MovementData>, IUpdatable, IEnableable, IDisaable
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3 deltaCursor = Vector3.zero;

    public Vector3 DeltaCursor { get => deltaCursor; set => deltaCursor = value; }

    public void OnIEnable()
    {
        InputController.mouseInputProvide += RotatePlayer;
    }
    public void OnIUpdate()
    {
        Vector3 pos = GetMousePoint();
        DeltaCursor = transform.position - pos;
    }

    public void OnIDisable()
    {    
        InputController.mouseInputProvide -= RotatePlayer;
    }

    public void RotatePlayer(Vector2 mouseInput) {
        Vector3 pos = GetMousePoint();
        Vector3 directionToRotate = pos - transform.position;
        directionToRotate.y = 0;
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.right, directionToRotate) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternionToRotate, ((InputData)GetData<InputData>()).GetMouseXAxisSens() * ((MovementData)GetData<MovementData>()).GetRotatingFactor() * Time.deltaTime);

    }

    private Vector3 GetMousePoint() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }
}
