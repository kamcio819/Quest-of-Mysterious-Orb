using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "Quest of Mysterious Orb/ScriptableData/Input", order = 0)]
public class InputData : Data
{
    #region MovementKeyboardFactors
    [Range(0f, 1f)] [SerializeField] private float xKeyboardAxisSens;
    [Range(0f, 1f)] [SerializeField] private float yKeyboardAxisSens;
    #endregion

    #region MovementMouseFactors
    [Range(0f, 1f)] [SerializeField] private float xMouseAxisSens;
    #endregion

    public float GetXAxisSens()
    {
        return xKeyboardAxisSens;
    }

    public float GetYAxisSens()
    {
        return yKeyboardAxisSens;
    }

    public float GetMouseXAxisSens()
    {
        return xMouseAxisSens;
    }

}