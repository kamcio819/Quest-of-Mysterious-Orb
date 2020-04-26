using System;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType
{
    BounceOrb,
    ChargingOrb,
    HomingOrb,
    GrayOrb,
}

public class OrbData : Data
{
    [SerializeField]
    protected OrbType orbType;

    [SerializeField]
    protected GameObject orbParticleSystem;

    [SerializeField]
    protected RenderTexture orbRenderTexture;

    [SerializeField]
    [Range(0, 5f)]
    private float cooldownTime;

    [SerializeField]
    [Range(0f, 50f)]
    private float damageGiven;


    public OrbType OrbType { get => orbType; }
    public GameObject ParticleSystem { get => orbParticleSystem; set => orbParticleSystem = value; }
    public RenderTexture OrbRenderTexture { get => orbRenderTexture; set => orbRenderTexture = value; }
    public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
    public float DamageGiven { get => damageGiven; set => damageGiven = value; }

    public virtual void RandomizeParameters() { }
    public virtual List<dynamic> GetData()
    {
        return null;
    }
    public virtual GameObject GetParticleSystem()
    {
        return ParticleSystem;
    }
    public virtual void SetData(List<dynamic> dataTab) { }

}