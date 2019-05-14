using UnityEngine;

public enum OrbType {
   CHARGING,
   BOUNCE,
   HOMING,
   GRAY
}

public class OrbData : Data {
    [SerializeField]
    private OrbType orbType;

    public OrbType OrbType { get => orbType; }

    public virtual void RandomizeParameters() {
      
   }
}