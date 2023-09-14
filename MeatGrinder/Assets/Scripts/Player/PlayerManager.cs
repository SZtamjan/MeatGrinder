using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public StatsScriptSO stats;

    private float hp;
    private float dmg = 0f;
    private Transform playerCam;
    
    [Header("Bullet")]
    public GameObject bullet;
    public Transform bulletSpawnAt;
    
    [Header("Guns")]
    public GameObject spawnGunAt;
    private GameObject currentGun;
    public List<GunStatsSO> gunLvl;
    
    private void Start()
    {
        playerCam = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ChangeGunTo(0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ChangeGunTo(1);
        }
    }

    public void ChangeGunTo(int index)
    {
        if(currentGun != null) Destroy(currentGun);
        currentGun = Instantiate(gunLvl[index].gun,spawnGunAt.transform);
        currentGun.transform.localPosition = gunLvl[index].position;
        dmg = gunLvl[index].dmg;
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, bulletSpawnAt.position, Quaternion.identity);
        Bullet blt = currentBullet.GetComponent<Bullet>();
        blt.newPosition = currentBullet.transform.position + playerCam.forward * 100f;
        blt.dmg = dmg;

    }
}
