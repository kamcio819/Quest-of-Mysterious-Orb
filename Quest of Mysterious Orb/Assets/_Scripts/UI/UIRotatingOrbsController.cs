using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotatingOrbsController : ExecutableController<MovementData>, IEnableable, IUpdatable, IDisaable, ILateUpdatable
{
   public void OnIDisable()
   {
   }

   public void OnIEnable()
   {
   }

   public void OnILateUpdate()
   {
   }

   public void OnIUpdate()
   {
       transform.RotateAround(transform.position, Vector3.up, 35f * Time.deltaTime);
   }
}
