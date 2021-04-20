using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Grounded : Enemy
{
    public enum State { ATTACK, SEEK }

    private EnemyAttack attack;
    private EnemySeek seek;

    private LayerMask playerLayer;

    /// <summary>
    /// Direction to move. -1 for left, 1 for right.
    /// </summary>
    public int direction { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");

        // TODO make this change to be direction towards player on spawning
        direction = -1;

        seek = gameObject.AddComponent<GroundSeek>() as GroundSeek;
        seek.Initialize(this);
        attack = gameObject.AddComponent<SlideAttack>() as SlideAttack;
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

    private float detectDistance = 2f;

    /// <summary>
    /// Was the player detected?
    /// </summary>
    public override bool Detected()
    {
        // Detect if player is ahead
        Vector3 lookEnd = transform.position;
        lookEnd.x *= direction * detectDistance;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, lookEnd, (1<<playerLayer));

        if (hit)
        {
            return true;
        }

        return false;
    }

}
