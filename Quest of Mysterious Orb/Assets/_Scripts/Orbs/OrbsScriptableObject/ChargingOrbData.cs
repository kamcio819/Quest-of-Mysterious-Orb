using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChargingOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/ChargingOrb", order = 0)]
public class ChargingOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float acceleretaionFactor;

      public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
      public float AcceleretaionFactor { get => acceleretaionFactor; set => acceleretaionFactor = value; }
   #endregion

   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
      acceleretaionFactor = Random.Range(0, 5f);
   }

   public override List<dynamic> GetData() {
      List<dynamic> dataToReturn = new List<dynamic>();
      dataToReturn.Add("Moving Speed");
      dataToReturn.Add(movingSpeed);
      dataToReturn.Add("Acceleretaion Factor");
      dataToReturn.Add(acceleretaionFactor);
      dataToReturn.Add("Orb Cooldown");
      dataToReturn.Add(CooldownTime);
      dataToReturn.Add("Orb Damage");
      dataToReturn.Add(DamageGiven);
      return dataToReturn;
   }

    public override void SetData(List<dynamic> dataTab)
    {
       movingSpeed = dataTab[1];
       acceleretaionFactor = dataTab[3];
       CooldownTime = dataTab[5];
       DamageGiven = dataTab[7];
    }
}