using System.Collections;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public abstract void Initialize(Enemy enemy);
    public abstract IEnumerator Attack();
}
