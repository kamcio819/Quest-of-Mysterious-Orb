using System;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType {
   BounceOrb,
   ChargingOrb,
   HomingOrb,
   GrayOrb
}

public class OrbData : Data {
    [SerializeField]
    private OrbType orbType;

    [SerializeField]
    private ParticleSystem particleSystem;

    public OrbType OrbType { get => orbType; }
    public ParticleSystem ParticleSystem { get => particleSystem; set => particleSystem = value; }
    public virtual void RandomizeParameters() {

    }

    public virtual List<dynamic> GetData() {
       return null;
    }

    public virtual ParticleSystem GetParticleSystem() {
       return ParticleSystem;
    }

    public virtual void SetData(List<dynamic> dataTab)
    {

    }
}