using UnityEngine;

[CreateAssetMenu(fileName = "SprialOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/SprialOrb", order = 0)]
public class SprialOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float orbitingFactor;
   #endregion

   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
      orbitingFactor = Random.Range(0, 5f);
   }
}