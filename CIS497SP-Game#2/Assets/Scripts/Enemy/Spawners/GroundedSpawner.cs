/* (Ashton Lively) 
 * (GroundedSpawner) 
 * (Project 6) 
 * (This spawns in the ground enemy at a location) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedSpawner : EnemySpawner
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
        //GameObject grounded = Resources.Load<GameObject>("Prefabs/Ground Enemy");

        //Instantiate(grounded, transform.position, Quaternion.identity);
    }
}
