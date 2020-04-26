using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "Quest of Mysterious Orb/ScriptableData/Movement", order = 0)]
public class MovementData : Data
{
    #region KeyboardMovementFactors
    [Range(1f, 5f)] [SerializeField] private float speedFactor;
    [Range(1f, 5f)] [SerializeField] private float rotatingFactor;
    #endregion

    public float GetSpeedFactor()
    {
        return speedFactor;
    }

    public float GetRotatingFactor()
    {
        return rotatingFactor;
    }
}