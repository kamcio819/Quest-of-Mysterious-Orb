using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerRotationController : ExecutableController<InputData, MovementData>, IUpdatable, IEnableable, IDisaable, ILateUpdatable
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3 deltaCursor = Vector3.zero;
    private Vector3 pos = Vector3.zero;

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
        pos = GetMousePoint();
        Vector3 directionToRotate = pos - transform.position;
        directionToRotate.y = 0;
        
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, directionToRotate) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);
    }

    void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, pos, Color.blue);
        Debug.DrawLine(pos - transform.position, pos, Color.green);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(pos, new Vector3(0.2f, 0.2f, 0.2f));
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

    public void OnILateUpdate()
    {
    }
}
