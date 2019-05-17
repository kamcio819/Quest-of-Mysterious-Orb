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
    private Vector3 pos;
    private bool hitFlag = false;

    public Vector3 DeltaCursor { get => deltaCursor; set => deltaCursor = value; }

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
        if(mouseInput != Vector2.zero) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50f, layerMask))
            {
                deltaCursor = transform.position - hit.point;
                deltaCursor.y = 0;
                Vector3 lookPoint = hit.point;

                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                
            }
            else {
            }
        }

    }

    public void OnILateUpdate() {

    }
}
