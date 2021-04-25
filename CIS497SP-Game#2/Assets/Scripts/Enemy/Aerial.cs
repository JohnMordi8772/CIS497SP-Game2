using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerial : Enemy
{
    public enum State { ATTACK, SEEK }

    private EnemyAttack attack;
    private EnemySeek seek;

    private Transform playerPos;

    private float playerRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        seek = gameObject.AddComponent<AerialSeek>() as AerialSeek;
        seek.Initialize(this);
        attack = gameObject.AddComponent<BatAttack>() as BatAttack;
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
    /// Get Player's transform
    /// </summary>
    public Transform GetPlayerPos()
    {
        return playerPos;
    }

    /// <summary>
    /// Detect if player is in range
    /// </summary>
    /// <returns></returns>
    public override bool Detected()
    {
        float distanceToPlayer = Vector3.Distance(playerPos.position, transform.position);
        
        if (distanceToPlayer <= playerRange)
        {
            return true;
        }

        return false;
    }
}
