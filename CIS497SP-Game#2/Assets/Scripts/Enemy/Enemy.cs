using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health = 3;
    //public bool rngHit = false;
    public abstract bool Detected();

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RngAtk")
            TakeDamage(collision.GetComponent<RangedAttack>().dmg);
    }
}
