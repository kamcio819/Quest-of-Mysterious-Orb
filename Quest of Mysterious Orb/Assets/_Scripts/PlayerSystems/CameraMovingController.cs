using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Camera))]
public class CameraMovingController : ExecutableController<InputData, MovementData>, IUpdatable, IEnableable, IDisaable
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private Transform bodyTransform;

    [SerializeField]
    private RotationController rotationController;

    private Vector3 offset = new Vector3(0, 13, -23);

    public Vector3 Offset { get => offset; set => offset = value; }

    public void OnIUpdate() {
        Vector3 pos = rotationController.DeltaCursor;
        pos.y = pos.z;
        pos.z = 0;
        pos.y /= 6;
        pos.x /= 3;
        transform.position = Vector3.Lerp(transform.position,bodyTransform.position +  offset - pos, ((InputData)GetData<InputData>()).GetMouseXAxisSens() * ((MovementData)GetData<MovementData>()).GetRotatingFactor() * Time.deltaTime);
    }

    public void OnIDisable() {

    }

    public void OnIEnable() {

    }

}
