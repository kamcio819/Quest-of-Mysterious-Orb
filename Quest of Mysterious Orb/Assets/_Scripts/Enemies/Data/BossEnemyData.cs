using UnityEngine;

[CreateAssetMenu(fileName = "BossEnemyData", menuName = "Quest of Mysterious Orb/ScriptableData/EnemyData/BossEnemy", order = 0)]
public class BossEnemyData : EnemyData {
    #region MovementData
      [Range(0,5f)] [SerializeField] private float rotateFactor;
      [Range(0,5f)] [SerializeField] private float shootingCooldown;

      [Range(0,5f)] [SerializeField] private float shotTimer = 1f;
      [Range(5f,30f)] [SerializeField] private float lookRadius = 10f;
      [Range(0,5f)] [SerializeField] private float rotationSpeed = 5f;
      [Range(0,5f)] [SerializeField] private float timer = 1f;


      public float RotateFactor { get => rotateFactor; set => rotateFactor = value; }
      public float ShootingCooldown { get => shootingCooldown; set => shootingCooldown = value; }
      public float ShotTimer { get => shotTimer; set => shotTimer = value; }
      public float LookRadius { get => lookRadius; set => lookRadius = value; }
      public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
      public float Timer { get => timer; set => timer = value; }

   #endregion
}