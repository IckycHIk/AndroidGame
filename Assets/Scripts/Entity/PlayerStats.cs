using System;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct PlayerStats 
{

    [Range(1, 10)]
    public int healt;
    [HideInInspector]
    public int coins;




}