/* (Ashton Lively) 
 * (Enemy) 
 * (Project 6) 
 * (Parent class for enemies that allow them to take damage and such) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;

    public InGameUIManager ui;
    //public bool rngHit = false;
    public abstract bool Detected();

    private void Awake()
    {
        health = 2;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            ui.UpdatePoints();
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RngAtk")
            TakeDamage(collision.GetComponent<RangedAttack>().dmg);
    }
}
