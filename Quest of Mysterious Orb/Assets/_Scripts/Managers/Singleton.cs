using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : class
{
   private static T instance;

   public static T Instance { get { return instance; } }

   protected virtual void Awake() {
      if (instance != null && instance != this as T) {
         Destroy(this.gameObject);
      }
      else {
         instance = this as T;
      }

      DontDestroyOnLoad(this);
   }
}