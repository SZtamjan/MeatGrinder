using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public StatsScriptSO stats;

    private float hp;
    private float dmg;
    private float moveSpeed;

    private Transform target;
    
    private void Start()
    {
        hp = stats.hp;
        dmg = stats.dmg;
        moveSpeed = stats.moveSpeed;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        target = players[0].transform;
    }

    private void Update()
    {
        //Rotate towards player
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        
        //Move towards player
        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newPos.x, transform.position.y, newPos.z);
    }
}
