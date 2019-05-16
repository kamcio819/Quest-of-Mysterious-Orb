using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BounceOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/BounceOrb", order = 0)]
public class BounceOrbData : OrbData {
   #region MovementData
      [Range(0,5f)] [SerializeField] private float movingSpeed;
      [Range(0,5f)] [SerializeField] private float bounceSpeed;
   #endregion

   #region ForceData
      [Range(0,5f)] [SerializeField] private float bounceForce;

      public float MovingSpeed { get => movingSpeed; }
      public float BounceSpeed { get => bounceSpeed; }
      public float BounceForce { get => bounceForce; }
   #endregion
   public override void RandomizeParameters()
   {
      movingSpeed = Random.Range(0, 5f);
      bounceSpeed = Random.Range(0, 5f);
      bounceForce = Random.Range(0, 5f);
   }

   public override List<dynamic> GetData() {
      List<dynamic> dataToReturn = new List<dynamic>();
      dataToReturn.Add("Moving Speed");
      dataToReturn.Add(MovingSpeed);
      dataToReturn.Add("Bounce Speed");
      dataToReturn.Add(BounceSpeed);
      dataToReturn.Add("Bounce Force");
      dataToReturn.Add(BounceForce);
      dataToReturn.Add("Orb Cooldown");
      dataToReturn.Add(cooldownTime);
      dataToReturn.Add("Orb Damage");
      dataToReturn.Add(damageGiven);
      return dataToReturn;
   }

    public override void SetData(List<dynamic> dataTab)
    {
       movingSpeed = dataTab[1];
       bounceSpeed = dataTab[3];
       bounceForce = dataTab[5];
       cooldownTime = dataTab[7];
       damageGiven = dataTab[9];
    }

}