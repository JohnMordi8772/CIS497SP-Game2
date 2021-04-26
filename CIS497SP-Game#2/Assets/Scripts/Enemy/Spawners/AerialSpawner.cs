/* (Ashton Lively) 
 * (AerialSpawner) 
 * (Project 6) 
 * (This spawns in the aerial enemy at a location) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialSpawner : EnemySpawner
{
    ObjectPooler objectPooler;
    bool alreadySpawned = false;

    private void Awake()
    {
        objectPooler = gameObject.GetComponent<ObjectPooler>();
    }

    public override void SpawnEnemy()
    {
        GameObject enemy = objectPooler.SpawnFromPool();
        if (enemy != null && !alreadySpawned)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            alreadySpawned = true;
        }
        //GameObject aerial = Resources.Load<GameObject>("Prefabs/Bat");
        //Instantiate(aerial, transform.position, Quaternion.identity);
    }
}
