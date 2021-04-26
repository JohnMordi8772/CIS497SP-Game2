/* (Ashton Lively) 
 * (TurretSpawner) 
 * (Project 6) 
 * (This spawns in the turret at a location) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawner : EnemySpawner
{
    public override void SpawnEnemy()
    {
        GameObject turret = Resources.Load<GameObject>("Prefabs/Turret");
        // Spawn turret 
        Instantiate(turret, transform.position, Quaternion.identity);

        // Attach script to turret
        // TODO
    }
}
