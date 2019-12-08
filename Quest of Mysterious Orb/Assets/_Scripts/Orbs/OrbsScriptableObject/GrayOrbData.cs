using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrayOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/GrayOrb", order = 0)]
public class GrayOrbData : OrbData
{
    #region MovementData
    [Range(0, 5f)] [SerializeField] private float movingSpeed;

    public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
    #endregion

   public override void RandomizeParameters()
    {
        MovingSpeed = Random.Range(0, 5f);
    }

    public override List<dynamic> GetData() {
      List<dynamic> dataToReturn = new List<dynamic>();
      dataToReturn.Add("Moving Speed");
      dataToReturn.Add(MovingSpeed);
      dataToReturn.Add("Orb Cooldown");
      dataToReturn.Add(CooldownTime);
      dataToReturn.Add("Orb Damage");
      dataToReturn.Add(DamageGiven);
      return dataToReturn;
   }

    public override void SetData(List<dynamic> dataTab)
    {
       MovingSpeed = dataTab[1];
       CooldownTime = dataTab[3];
       DamageGiven = dataTab[5];
    }
}
