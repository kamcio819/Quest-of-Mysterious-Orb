using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
   [SerializeField]
   private LineRenderer lineRenderer;

   [SerializeField]
   private Camera mainCamera;

   private void Update() {
       Vector3 pos = GetMousePoint();
       pos.y = 0;
        lineRenderer.SetPosition(1, GetMousePoint());
   }

   private Vector3 GetMousePoint() {
       var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       var plane = new Plane(Vector3.forward, Vector3.zero);
 
        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);
            
        }
        else {
            return Vector3.zero;
        }
    }
}
