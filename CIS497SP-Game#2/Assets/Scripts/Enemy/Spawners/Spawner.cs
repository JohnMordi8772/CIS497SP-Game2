using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Spawner : MonoBehaviour
{
    public enum Type { GROUNDED, AERIAL, TURRET}
    public Type type;

    private EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case (Type.GROUNDED):
                spawner = gameObject.AddComponent<GroundedSpawner>() as GroundedSpawner;
                break;
            case (Type.AERIAL):
                spawner = gameObject.AddComponent<AerialSpawner>() as AerialSpawner;
                break;
            case (Type.TURRET):
                spawner = gameObject.AddComponent<TurretSpawner>() as TurretSpawner;
                break;
        }
    }
}
