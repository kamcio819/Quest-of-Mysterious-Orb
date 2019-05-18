using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraMovingController : ExecutableController<InputData, MovementData>, IUpdatable, ILateUpdatable, IEnableable, IDisaable, IAwakable
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Transform bodyTransform;

    [SerializeField]
    private PlayerRotationController rotationController;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 13, -10);

    public Vector3 Offset { get => offset; set => offset = value; }

    public void OnIAwake() {
        transform.position = bodyTransform.position +  offset;
    }
    public void OnIUpdate() {
        
    }

    public void OnIDisable() {

    }

    public void OnIEnable() {

    }

    public void OnILateUpdate()
    {
        Vector3 pos = rotationController.DeltaCursor;
        pos.y = pos.z;
        pos.z = 0;
        pos.y /= 6;
        pos.x /= 3;
        if(pos != Vector3.zero) {
            transform.position = Vector3.Lerp(transform.position, bodyTransform.position +  offset - pos, ((InputData)GetData<InputData>()).GetMouseXAxisSens() * ((MovementData)GetData<MovementData>()).GetRotatingFactor() * Time.deltaTime);
        }
    }
}
