using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : EnemyAttack
{
    private Aerial aerial;

    private Transform playerPos;

    private float speed = 10;

    /// <summary>
    /// </summary>
    /// <param name="aerial">Aerial attacker</param>
    public override void Initialize(Enemy aerial)
    {
        this.aerial = (Aerial)aerial;
        Initialize();
    }

    private void Initialize()
    {
        playerPos = aerial.GetPlayerPos();
    }

    /// <summary>
    /// Time between when player is spotted and dive bombed
    /// </summary>
    private float graceTime = 0.2f;

    /// <summary>
    /// Bat dive bombs the player
    /// </summary>
    public override IEnumerator Attack()
    {
        Vector3 end = playerPos.position;

        yield return new WaitForSeconds(graceTime);
        // Fly towards player location
        while (transform.position != end)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, speed * Time.deltaTime);
            yield return null;
        }

        aerial.SwitchState(Aerial.State.SEEK);
        yield break;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<InGameUIManager>().UpdatePlayerHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<InGameUIManager>().UpdatePlayerHealth();
        }
    }
}
