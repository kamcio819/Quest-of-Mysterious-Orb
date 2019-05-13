using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "Quest of Mysterious Orb/ScriptableData/Input", order = 0)]
public class InputData : Data {
   #region MovementFactors
      [Range(0,10f)] [SerializeField] private float xAxisSens;
      [Range(0,10f)] [SerializeField] private float yAxisSens;
   #endregion

   public float GetXAxisSens() {
      return xAxisSens;
   }

   public float GetYAxisSens() {
      return yAxisSens;
   }
}