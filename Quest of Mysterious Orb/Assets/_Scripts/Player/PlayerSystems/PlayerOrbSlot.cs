using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrbSlot : MonoBehaviour
{
   [SerializeField]
   private List<OrbObject> orbObjects;

   public List<OrbObject> OrbObjects { get => orbObjects; set => orbObjects = value; }
}
