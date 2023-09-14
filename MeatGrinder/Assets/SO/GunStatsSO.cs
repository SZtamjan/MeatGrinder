using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunStats", menuName = "ScriptableObjects/GunStats")]
public class GunStatsSO : ScriptableObject
{
    public GameObject gun;

    [Header("Pos")] 
    public Vector3 position;
    public Vector3 rotation;
    public float dmg;

    [Header("Is FullAuto")] 
    public bool isFullAuto;
    public float fireRate;
}
