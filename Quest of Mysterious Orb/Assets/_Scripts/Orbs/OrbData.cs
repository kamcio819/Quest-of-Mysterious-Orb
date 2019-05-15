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
    private ParticleSystem orbParticleSystem;

    [SerializeField]
    private RenderTexture orbRenderTexture;

    public OrbType OrbType { get => orbType; }
    public ParticleSystem ParticleSystem { get => orbParticleSystem; set => orbParticleSystem = value; }
    public RenderTexture OrbRenderTexture { get => orbRenderTexture; set => orbRenderTexture = value; }
    
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