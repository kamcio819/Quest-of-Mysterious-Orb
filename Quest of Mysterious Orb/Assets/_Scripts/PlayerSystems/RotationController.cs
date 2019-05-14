using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class RotationController : Controller<InputData>, IUpdatable, IEnableable, IDisaable
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Camera mainCamera;

    public void OnIEnable()
    {
        InputController.mouseInputProvide += RotatePlayer;
    }
    public void OnIUpdate()
    {

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
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternionToRotate, controllerData.GetMouseXAxisSens() * controllerData.GetMouseXAxisFactor() * Time.deltaTime);

    }

    private Vector3 GetMousePoint() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }
}
