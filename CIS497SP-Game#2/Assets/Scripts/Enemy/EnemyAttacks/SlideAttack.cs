using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAttack : EnemyAttack
{
    private Grounded grounded;
    private Rigidbody2D rgbd;

    /// <summary>
    /// Force of the slide impulse
    /// </summary>
    private Vector2 slideForce = new Vector2(3, 0);
    /// <summary>
    /// Time before the attack begins after spotted
    /// </summary>
    private float graceTime = .1f;

    /// <summary>
    /// </summary>
    /// <param name="grounded">Enemy that is attacking</param>
    public override void Initialize(Enemy grounded)
    {
        this.grounded = (Grounded)grounded;
        rgbd = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Attack the player
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Attack()
    {
        yield return new WaitForSeconds(graceTime);

        // Launch in move direction
        rgbd.AddForce(slideForce * grounded.direction, ForceMode2D.Impulse);

        // ADD HERE : Player lose health if collided

        grounded.SwitchState(Grounded.State.SEEK);

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
