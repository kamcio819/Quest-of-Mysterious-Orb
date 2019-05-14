using System;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType {
   CHARGING,
   BOUNCE,
   HOMING,
   GRAY
}

public class OrbData : Data {
    [SerializeField]
    private OrbType orbType;

    public OrbType OrbType { get => orbType; }

    public virtual void RandomizeParameters() {
      
    }

    public virtual List<dynamic> GetData() {
       return null;
    }

    public virtual void SetData(List<dynamic> dataTab)
    {
       
    }
}