using System;
using UnityEngine;

public abstract class OrbObject : MonoBehaviour
{
   public virtual OrbData GetData()
   {
      return null;
   }
}