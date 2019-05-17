using System;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
   [SerializeField]
   private PlayerData playerData;

   public PlayerData PlayerData { get => playerData; set => playerData = value; }
}