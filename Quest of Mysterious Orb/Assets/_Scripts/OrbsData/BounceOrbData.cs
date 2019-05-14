using UnityEngine;

[CreateAssetMenu(fileName = "BounceOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/BounceOrb", order = 0)]
public class BounceOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float bounceSpeed;
   #endregion

   #region ForceData
      [Range(0,5f)] [SerializeField] private float bounceForce;
   #endregion
   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
      bounceSpeed = Random.Range(0, 5f);
      bounceForce = Random.Range(0, 5f);
   }
}