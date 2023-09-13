using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    public StatsScriptSO stats;
    public GameObject dbgr;
    
    private float hp;
    private float dmg;
    
    public GameObject bullet;
    public Transform bulletSpawnAt;

    private Transform playerCam;
    private Vector3 newPosition;
    private void Start()
    {
        playerCam = GetComponentInChildren<Camera>().transform;
        hp = stats.hp;
        dmg = stats.dmg;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dbgr.transform.position = newPosition;
        }
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, bulletSpawnAt.position, Quaternion.identity);
        newPosition = currentBullet.transform.position + playerCam.forward * 10f;
        Bullet blt = currentBullet.GetComponent<Bullet>();
        blt.bulletSpawnAt = bulletSpawnAt;
        blt.newPosition = newPosition;
    }
}
