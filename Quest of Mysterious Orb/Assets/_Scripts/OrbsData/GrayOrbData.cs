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
}
