using System.Collections;
using UnityEngine;

public abstract class EnemySeek : MonoBehaviour
{
    public abstract void Initialize(Enemy enemy);
    public abstract IEnumerator Seek();
}
