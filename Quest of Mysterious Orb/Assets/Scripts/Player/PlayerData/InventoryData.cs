using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Quest of Mysterious Orb/ScriptableData/Inventory", order = 0)]
public class InventoryData : Data
{
    #region InventoryFactors
    [Range(1f, 5f)] [SerializeField] private int maximumCapacity;
    #endregion

    public int GetCapacity()
    {
        return maximumCapacity;
    }

}