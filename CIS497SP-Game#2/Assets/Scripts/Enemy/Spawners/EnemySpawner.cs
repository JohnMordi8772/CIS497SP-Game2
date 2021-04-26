/* (Ashton Lively) 
 * (EnemySpawner) 
 * (Project 6) 
 * (This spawns in the enemy when it comes into contact with the player) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public abstract void SpawnEnemy();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemy();
        }
    }
        

    
}
