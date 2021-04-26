/* (Ashton Lively) 
 * (EnemySeek) 
 * (Project 6) 
 * (This is the parent class of all Enemy Seekers) */

using System.Collections;
using UnityEngine;

public abstract class EnemySeek : MonoBehaviour
{
    public abstract void Initialize(Enemy enemy);
    public abstract IEnumerator Seek();
}
