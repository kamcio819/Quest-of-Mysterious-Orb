using UnityEngine;

[CreateAssetMenu(fileName = "PatrolEnemyData", menuName = "Quest of Mysterious Orb/ScriptableData/EnemyData/PatrolEnemy", order = 0)]
public class PatrolEnemyData : EnemyData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float waitIdleTime;

      public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
      public float WaitIdleTime { get => waitIdleTime; set => waitIdleTime = value; }
   #endregion
}