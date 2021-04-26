/* (Ashton Lively) 
 * (Turret) 
 * (Project 6) 
 * (This is the script we attach to the turret to make it work properly) */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    public enum State { ATTACK, SEEK}

    private EnemyAttack attack;
    public EnemySeek seek;

    private LayerMask playerLayer;

    /// <summary>
    /// Barrel of the turret
    /// </summary>
    private Transform barrel;
    /// <summary>
    /// End of the barrel
    /// </summary>
    private Transform firingDistRef;
    private Transform barrelEnd;
    /// <summary>
    /// Position of the player
    /// </summary>
    private Transform playerPos;

    /// <summary>
    /// Distance the turret may detect to. 
    /// </summary>
    private float seekRange = 15f;

    void Awake()
    {
        barrel = transform.Find("Barrel");
        barrelEnd = barrel.transform.Find("Visual");
        firingDistRef = barrel.transform.Find("EndRef");
        firingDistRef.position += (Vector3.left * seekRange);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerLayer = LayerMask.NameToLayer("Player");
        ui = FindObjectOfType<InGameUIManager>();

        seek = gameObject.AddComponent<TurretSeek>() as TurretSeek;
        seek.Initialize(this);
        attack = gameObject.AddComponent<BaseballAttack>() as BaseballAttack;
        attack.Initialize(this);

        SwitchState(State.SEEK);
    }

    /// <summary>
    /// Switch the current behavior
    /// </summary>
    /// <param name="next">Behavior to switch to</param>
    public void SwitchState(State next)
    {
        switch (next)
        {
            case (State.ATTACK):
                StartCoroutine(attack.Attack());
                break;
            case (State.SEEK):
                StartCoroutine(seek.Seek());
                break;
        }
    }

    /// <summary>
    /// Barrel's transform
    /// </summary>
    public Transform GetBarrel()
    {
        return barrel;
    }

    /// <summary>
    /// Player's transform
    /// </summary>
    public Transform GetPlayerPos()
    {
        return playerPos;
    }

    /// <summary>
    /// End of the barrel
    /// </summary>
    public Transform GetBarrelEnd()
    {
        return barrelEnd;
    }

    /// <summary>
    /// Is the player in sight?
    /// </summary>
    public override bool Detected()
    {
        // End of linecast
        Vector3 lookEnd = firingDistRef.position;
        // Cast in direction of look
        RaycastHit2D hit = Physics2D.Linecast(transform.position, lookEnd, (1<<playerLayer));

        if (hit)
        {
            return true;
        }

        return false;
    }
}
