using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballAttack : EnemyAttack
{
    private Turret turret;
    private Transform barrel;

    private Transform barrelEnd;
    /// <summary>
    /// Position of the player
    /// </summary>
    private Transform playerPos;

    private GameObject projectile;

    /// <summary>
    /// Delay between shots
    /// </summary>
    private float shootDelay = 1.1f;

    /// <summary>
    /// Second delay the player has to move out of line of fire. 
    /// </summary>
    private float playerGrace = 0.3f;

    /// <summary>
    /// Create a new attack that shoots baseballs
    /// </summary>
    /// <param name="turret"> Turret that is attacking</param>
    /// <param name="barrelEnd">End of the turrets barrel</param>
    /// <param name="playerPos">Player's transform</param>
    public override void Initialize(Enemy turret)
    {
        this.turret = (Turret)turret;
        Initialize(this.turret.GetBarrelEnd(), this.turret.GetPlayerPos(), this.turret.GetBarrel());

        // Get projectile prefab from files
        projectile = Resources.Load<GameObject>("Prefabs/projectile");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="barrelEnd"></param>
    /// <param name="playerPos"></param>
    private void Initialize(Transform barrelEnd, Transform playerPos, Transform barrel)
    {
        this.barrelEnd = barrelEnd;
        this.playerPos = playerPos;
        this.barrel = barrel;
    }

    /// <summary>
    /// Attack the player
    /// </summary>
    public override IEnumerator Attack()
    {
        while (turret.Detected())
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

        turret.SwitchState(Turret.State.SEEK);
        yield break;

    }
}
