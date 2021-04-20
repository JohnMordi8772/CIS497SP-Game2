using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSeek : EnemySeek
{
    private Grounded grounded;
    /// <summary>
    /// Size of the enemy's collider
    /// </summary>
    private Vector3 groundedSize;

    /// <summary>
    /// Speed of the move
    /// </summary>
    private float speed = 4f;

    /// <summary>
    /// Layer the ground platforms are on
    /// </summary>
    private LayerMask platformLayer;

    /// <summary>
    /// </summary>
    /// <param name="grounded">Grounded enemy that is seeking</param>
    public override void Initialize(Enemy grounded)
    {
        this.grounded = (Grounded)grounded;
        groundedSize = grounded.GetComponent<Collider2D>().bounds.extents;
        platformLayer = LayerMask.NameToLayer("Platform");
    }
    
    public override IEnumerator Seek()
    {
        // Wait for player to get into range before attacking
        while(!grounded.Detected())
        {
            // Move in set direction
            grounded.transform.Translate(Vector2.right * grounded.direction * speed * Time.deltaTime);

            Vector3 pos = grounded.transform.position;
            // If no ground ahead, switch direction
            // Get the x position to check for platforms in plus additional buffer
            float xHalf = groundedSize.x - 0.3f;
            float checkPosX = pos.x + (xHalf * grounded.direction);

            // Get y position to check for platforms in
            float checkPosY = pos.y - 0.8f;
            Vector3 checkPos = new Vector3(checkPosX, checkPosY, 0);

            // Check if there is no ground ahead
            Collider2D spaceHit = Physics2D.OverlapBox(checkPos, groundedSize * 2, 0, (1<<platformLayer));
            if (!spaceHit)
            {
                grounded.direction *= -1;
            }

            // Check if there is a barrier ahead
            Vector3 end = new Vector3(pos.x + (grounded.direction), pos.y, 0);
            RaycastHit2D barrierHit = Physics2D.Linecast(pos, end, (1<<platformLayer));
            if(barrierHit)
            {
                grounded.direction *= -1;
            }

            yield return null;
        }

        grounded.SwitchState(Grounded.State.ATTACK);
        yield break;
    }
}
