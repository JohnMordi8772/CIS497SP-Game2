using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Pool pool;
    Queue<GameObject> objectPool = new Queue<GameObject>();
    Spawner spawner;
    bool spawnedOnce;
    // Start is called before the first frame update
    void Start()
    {
        spawnedOnce = false;
        spawner = gameObject.GetComponent<Spawner>();
        if (spawner.type == Spawner.Type.AERIAL)
            pool.prefab = Resources.Load<GameObject>("Prefabs/Bat");
        else if (spawner.type == Spawner.Type.GROUNDED)
            pool.prefab = Resources.Load<GameObject>("Prefabs/Ground Enemy");
        else if (spawner.type == Spawner.Type.TURRET)
            pool.prefab = Resources.Load<GameObject>("Prefabs/Turret");
        FillPoolsWithInactiveObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FillPoolsWithInactiveObjects()
    {
        GameObject obj = pool.prefab;
        obj.GetComponent<Enemy>().objectPooler = this;
        //pool.prefab.SetActive(false);
        objectPool.Enqueue(obj);
    }

    public GameObject SpawnFromPool()
    {
        if (objectPool.Count != 0)
        {
            GameObject temp = objectPool.Dequeue();

            //temp.transform.position = gameObject.transform.position;

            temp.SetActive(true);
            if (spawnedOnce)
            {
                if (spawner.type == Spawner.Type.AERIAL)
                    StartCoroutine(temp.GetComponent<Aerial>().seek.Seek());
                else if (spawner.type == Spawner.Type.GROUNDED)
                    StartCoroutine(temp.GetComponent<Grounded>().seek.Seek());
                else if (spawner.type == Spawner.Type.TURRET)
                    StartCoroutine(temp.GetComponent<Turret>().seek.Seek());
            }
            spawnedOnce = true;
            return temp;

            //temp.GetComponent<Enemy>().Awake();
        }
        else
        {
            return null;
        }
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);

        enemy.GetComponent<Enemy>().health = 2;

        objectPool.Enqueue(enemy);
    }
}