using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletSpawnAt;
    public Vector3 newPosition;

    public float dmg;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 100f * Time.deltaTime);
        if (transform.position == newPosition) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        //print("I dealt" + dmg);
        other.gameObject.GetComponent<DMGDealer>().DealDamage(dmg);
        Destroy(gameObject);
    }
    
    
}
