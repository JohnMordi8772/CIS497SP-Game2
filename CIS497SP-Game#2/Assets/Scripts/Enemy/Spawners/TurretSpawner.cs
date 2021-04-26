/* (Ashton Lively, John Mordi) 
 * (TurretSpawner) 
 * (Project 6) 
 * (This spawns in the turret at a location) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : EnemySpawner
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
        //GameObject turret = Resources.Load<GameObject>("Prefabs/Turret");
        //// Spawn turret 
        //Instantiate(turret, transform.position, Quaternion.identity);

        //// Attach script to turret
        //// TODO
    }
}
