using UnityEngine;

public enum OrbType {
   CHARGING,
   BOUNCE,
   SPIRAL
}

public class OrbData : Data {
   [SerializeField]
   private OrbType orbType;
   public virtual void RandomizeParameters() {
      
   }
}