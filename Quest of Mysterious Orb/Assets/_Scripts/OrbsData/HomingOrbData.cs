using UnityEngine;

[CreateAssetMenu(fileName = "HomingOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/HomingOrb", order = 0)]
public class HomingOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
   #endregion

   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
   }
}