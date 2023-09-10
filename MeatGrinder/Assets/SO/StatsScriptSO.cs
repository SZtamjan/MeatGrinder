using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "ScriptableObjects/UnitStats")]
public class StatsScriptSO : ScriptableObject
{
    public float hp;
    public float dmg;
    public float moveSpeed;
}
