/* (Ashton Lively) 
 * (GroundedSpawner) 
 * (Project 6) 
 * (This spawns in the ground enemy at a location) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedSpawner : EnemySpawner
{
    public override void SpawnEnemy()
    {
        GameObject grounded = Resources.Load<GameObject>("Prefabs/Ground Enemy");
        // Spawn turret 
        Instantiate(grounded, transform.position, Quaternion.identity);

        // Attach script to turret
        // TODO
    }
}
