using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "Quest of Mysterious Orb/ScriptableData/Input", order = 0)]
public class InputData : Data {
   #region MovementKeyboardFactors
      [Range(0,10f)] [SerializeField] private float xAxisSens;
      [Range(0,10f)] [SerializeField] private float yAxisSens;
   #endregion

   #region MovementMouseFactors
      [Range(5f,10f)] [SerializeField] private float xMouseAxisSens;
      [Range(5f,10f)] [SerializeField] private float xMouseAxisFactor;
      #endregion

   public float GetXAxisSens() {
      return xAxisSens;
   }

   public float GetYAxisSens() {
      return yAxisSens;
   }

   public float GetMouseXAxisSens() {
      return xMouseAxisSens;
   }

   public float GetMouseXAxisFactor() {
      return xMouseAxisFactor;
   }
}