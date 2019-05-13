using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "Quest of Mysterious Orb/ScriptableData/Movement", order = 0)]
public class MovementData : Data {
   #region MovementFactors
      [Range(0,5f)] [SerializeField] private float speedFactor;
      [Range(0,5f)] [SerializeField] private float jumpingFactor;
   #endregion

   public float GetSpeedFactor() {
      return speedFactor;
   }

   public float GetJumpingFactor() {
      return jumpingFactor;
   }
}