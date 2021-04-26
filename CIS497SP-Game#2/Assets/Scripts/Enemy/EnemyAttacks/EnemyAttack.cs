/* (Ashton Lively) 
 * (EnemyAttack) 
 * (Project 6) 
 * (Parent class of Enemy Attacks) */

using System.Collections;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public abstract void Initialize(Enemy enemy);
    public abstract IEnumerator Attack();
}
