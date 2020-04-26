using UnityEngine;

[CreateAssetMenu(fileName = "AttackingData", menuName = "Quest of Mysterious Orb/ScriptableData/Attack", order = 0)]
public class AttackingData : Data
{
    #region AttackingFactors
    [Range(0f, 1f)] [SerializeField] private float attackingSpeed;
    [Range(0f, 1f)] [SerializeField] private float attackingRange;
    #endregion

    public float GetAttackingSpeed()
    {
        return attackingSpeed;
    }

    public float GetAttackingRange()
    {
        return attackingRange;
    }

}