using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrayOrbData", menuName = "Quest of Mysterious Orb/ScriptableData/OrbData/GrayOrb", order = 0)]
public class GrayOrbData : OrbData
{
    #region MovementData
    [Range(0, 5f)] [SerializeField] private float movingSpeed;
    #endregion

    public override void RandomizeParameters()
    {
        movingSpeed = Random.Range(0, 5f);
    }

    public override List<dynamic> GetData() {
      List<dynamic> dataToReturn = new List<dynamic>();
      dataToReturn.Add("Moving Speed");
      dataToReturn.Add(movingSpeed);
      return dataToReturn;
   }

    public override void SetData(List<dynamic> dataTab)
    {
       movingSpeed = dataTab[1];
    }
}
