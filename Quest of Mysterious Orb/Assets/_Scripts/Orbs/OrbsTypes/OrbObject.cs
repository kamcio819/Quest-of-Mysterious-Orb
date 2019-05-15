using System;
using UnityEngine;

public abstract class OrbObject : MonoBehaviour
{
   public bool isSpawned;
   public virtual OrbData GetData()
   {
      return null;
   }
}