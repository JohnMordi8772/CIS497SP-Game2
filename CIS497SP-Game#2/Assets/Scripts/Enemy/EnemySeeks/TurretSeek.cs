/* (Ashton Lively) 
 * (TurretSeek) 
 * (Project 6) 
 * (This allows the turret to aim at the player and follow their actions) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSeek : EnemySeek
{
    private Turret turret;
    private Transform barrel;

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
    private float rotSpeed = 30f;

    /// <summary>
    /// </summary>
    /// <param name="turret">Turret that is seeking</param>
    public override void Initialize(Enemy turret)
    {
        this.turret = (Turret)turret;
        Initialize(this.turret.GetBarrel());
    }

    /// <summary>
    /// </summary>
    /// <param name="barrel">Barrel transform</param>
    private void Initialize(Transform barrel)
    {
        this.barrel = barrel;
    }

    /// <summary>
    /// Seek/Patrol for the player
    /// </summary>
    public override IEnumerator Seek()
    {
        while (!turret.Detected())
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

        turret.SwitchState(Turret.State.ATTACK);
        yield break;
    }
}
