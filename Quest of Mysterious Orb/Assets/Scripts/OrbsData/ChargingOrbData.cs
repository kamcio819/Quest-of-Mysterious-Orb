using UnityEngine;

[CreateAssetMenu(fileName = "ChargingOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/ChargingOrb", order = 0)]
public class ChargingOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float acceleretaionFactor;
   #endregion

   [SerializeField] private ParticleSystem chargingOrbParticle;

   public ParticleSystem ChargingOrbParticle { get => chargingOrbParticle; set => chargingOrbParticle = value; }

   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
      acceleretaionFactor = Random.Range(0, 5f);
   }
}