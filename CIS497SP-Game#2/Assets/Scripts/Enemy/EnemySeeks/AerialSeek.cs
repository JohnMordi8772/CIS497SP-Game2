using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialSeek : EnemySeek
{
    private Aerial aerial;

    private Transform playerPos;

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
    /// Move around while player has not been detected
    /// </summary>
    public override IEnumerator Seek()
    {
        // Detect in player is in range 
        while (!aerial.Detected())
        {
            // Meander around -- Implement

            yield return null;
        }

        aerial.SwitchState(Aerial.State.ATTACK);
        yield break;
    }
}
