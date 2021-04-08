using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
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
    /// Original location the turret is looking at. 
    /// </summary>
    private Vector2 originalLookEnd;

    /// <summary>
    /// Direction the bareel is rotating in
    /// </summary>
    private int rotDir = 1;
    
    /// <summary>
    /// Maximum negative rotation of the barrel
    /// </summary>
    private float minRot = -0.5f;
    /// <summary>
    /// Maximum positiove position of the barrel
    /// </summary>
    private float maxRot = 0.2f;

    /// <summary>
    /// Speed the barell rotates at
    /// </summary>
    private float rotSpeed = 10f;

    /// <summary>
    /// Distance the turret may detect to. 
    /// </summary>
    private float seekRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.Find("Barrel");
        barrelEnd = barrel.transform.Find("Visual");
        firingDistRef = barrel.transform.Find("EndRef");
        firingDistRef.position += (Vector3.left * seekRange);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(Seek());
    }

    public override IEnumerator Seek()
    {
        while (!Detected())
        {
            // Rotate barrel
            float newRot = (rotSpeed * Time.deltaTime) * rotDir;
            barrel.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - newRot));

            float currRot = barrel.rotation.z;

            // Switch drection if end reached
            if (currRot > maxRot)
                rotDir *= -1;
            if (currRot < minRot)
                rotDir *= -1;

            yield return null;
        }

        StartCoroutine(Attack());
        yield break;
    }

    [Tooltip("The projectile the turret shoots.")]
    public GameObject projectile;

    /// <summary>
    /// Delay between shots
    /// </summary>
    private float shootDelay = .4f;

    /// <summary>
    /// Second delay the player has to move out of line of fire. 
    /// </summary>
    private float playerGrace = 0.09f;

    public override IEnumerator Attack()
    {
        while (Detected())
        {
            // Rotate to player
            Vector2 delta = transform.position - playerPos.position;
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle));

            barrel.transform.rotation = rot;

            yield return new WaitForSeconds(playerGrace);
            Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);

            yield return new WaitForSeconds(shootDelay);
        }

        StartCoroutine(Seek());
        yield break;
        
    }

    /// <summary>
    /// Is the player in sight?
    /// </summary>
    private bool Detected()
    {
        // Object first in line of sight
        RaycastHit2D[] hit = new RaycastHit2D[1];

        // Objects the linecast can hit
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.NoFilter();

        // End of linecast
        Vector3 lookEnd = firingDistRef.position;
        // Cast in direction of look
        Physics2D.Linecast(transform.position, lookEnd, contactFilter, hit);

        return (hit[0] == true);
    }
}
