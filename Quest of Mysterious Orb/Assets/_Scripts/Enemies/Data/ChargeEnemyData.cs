using UnityEngine;

[CreateAssetMenu(fileName = "ChargeEnemyData", menuName = "Quest of Mysterious Orb/ScriptableData/EnemyData/ChargeEnemy", order = 0)]
public class ChargeEnemyData : EnemyData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float acceleretaionFactor;


      public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
      public float AcceleretaionFactor { get => acceleretaionFactor; set => acceleretaionFactor = value; }
   #endregion
}