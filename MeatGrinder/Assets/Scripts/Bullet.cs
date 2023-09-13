using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bulletSpawnAt;
    public Vector3 newPosition;
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 20f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.GetComponent<DMGDealer>().DealDamage();
        Destroy(gameObject);
    }
    
    
}
