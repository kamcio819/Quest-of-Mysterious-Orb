using System;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    [Range(0f, 100f)]
    private float healthPlayer = 100f;

    public PlayerData PlayerData { get => playerData; set => playerData = value; }
    public float HealthPlayer { get => healthPlayer; set => healthPlayer = value; }
}