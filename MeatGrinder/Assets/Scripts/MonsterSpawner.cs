using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject enemy;

    //spawn limits
    private float[] spawnArea = new float[2];
    
    
    private void Start()
    {
        //X and Y limits
        spawnArea[0] = 20f;
        spawnArea[1] = -20f;

        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        //change expression to work with GameManager - if not dead then
        while (true)
        {
            float randomX = Random.Range(spawnArea[0], spawnArea[1]);
            float fixedY = 0.1f;
            float randomZ = Random.Range(spawnArea[0], spawnArea[1]);
            
            GameObject obj = Instantiate(enemy, new Vector3(randomX, fixedY, randomZ), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
}
