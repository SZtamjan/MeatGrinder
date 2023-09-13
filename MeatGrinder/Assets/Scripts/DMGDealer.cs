using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGDealer : MonoBehaviour
{
    public bool isPlayer;

    private Enemies stats;
    private PlayerManager pstats;

    private void Start()
    {
        if(!isPlayer) stats = GetComponent<Enemies>();
        if (isPlayer) pstats = GetComponent<PlayerManager>();
    }

    public void DealDamage()
    {
        if (isPlayer)
        {
            //Player
            
        }
        else
        {
            //Enemy
            //Need to see difference between different enemies
            stats.GetDmg(40f);
        }
    }
}
