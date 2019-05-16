using UnityEngine;

public abstract class EnemyObject : MonoBehaviour
{
   public bool isSpawned;
   public virtual EnemyData GetData()
   {
      return null;
   }
}