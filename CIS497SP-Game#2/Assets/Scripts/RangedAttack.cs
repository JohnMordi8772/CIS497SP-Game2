using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    Vector3 pos;
    public float dmg = 1;
    // Start is called before the first frame update
    void Awake()
    {
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * 30);
        //Debug.Log(Vector3.Distance(pos, gameObject.transform.position));
        if (Vector3.Distance(gameObject.transform.position, pos) > 20)
        {
            //Debug.Log(Vector3.Distance(pos, gameObject.transform.position));
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        Enemy enemy = collision.GetComponent<Enemy>();
    //        //if(!enemy.rngHit)
    //        //{
    //        //enemy.rngHit = true;
    //        enemy.TakeDamage(dmg);
    //        //}
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //        other.GetComponent<Enemy>().rngHit = false;
    //}
}
