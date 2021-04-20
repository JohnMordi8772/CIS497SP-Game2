using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialSpawner : EnemySpawner
{
    public override void SpawnEnemy()
    {
        GameObject aerial = Resources.Load<GameObject>("Prefabs/Bat");
        // Spawn turret 
        Instantiate(aerial, transform.position, Quaternion.identity);

        // Attach script to turret
        // TODO
    }
}
