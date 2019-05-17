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
    private Vector3 pos = new Vector3();

    public Vector3 DeltaCursor { get => deltaCursor; set => deltaCursor = value; }

    public void OnIEnable()
    {
        InputController.mouseInputProvide += RotatePlayer;
    }
    public void OnIUpdate()
    {
        DeltaCursor = transform.position - pos;
    }

    public void OnIDisable()
    {    
        InputController.mouseInputProvide -= RotatePlayer;
    }

    public void RotatePlayer(Vector2 mouseInput) {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            pos = hit.point;
        }

    }

    void OnDrawGizmosSelected()
    {
        Debug.DrawLine(transform.position, pos, Color.blue);
        Debug.DrawLine(pos - transform.position, pos, Color.green);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(pos, new Vector3(0.2f, 0.2f, 0.2f));
    }

    public void OnILateUpdate()
    {
        Vector3 directionToRotate = pos - transform.position;
        directionToRotate.y = 0;
        
        Quaternion quaternionToRotate = Quaternion.FromToRotation(transform.forward, directionToRotate) * transform.rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionToRotate, 20f);
    }
}
