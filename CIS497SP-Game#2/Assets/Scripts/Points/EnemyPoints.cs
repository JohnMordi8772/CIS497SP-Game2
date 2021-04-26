/* (Ashton Lively) 
 * (EnemyPoints) 
 * (Project 6) 
 * (Gives points when an enemy is defeated) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : PointDecorator
{
    Points points;

    public EnemyPoints(Points points)
    {
        this.points = points;
    }

    public override int PointsEarned()
    {
        return points.PointsEarned() + 1;
    }
}
