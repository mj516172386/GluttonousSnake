using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config 
{
    [Header("MAP OBJ SIZE Space")]
    public const int MAP_SIZE = 20;
    public static E_PlayerTrans e_Player = E_PlayerTrans.left;
}
public enum E_PlayerTrans
{
    up,
    down,
    left,
    right,
}