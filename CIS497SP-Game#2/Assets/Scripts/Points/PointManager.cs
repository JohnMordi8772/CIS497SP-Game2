/* (Ashton Lively)
 * (PointManager) 
 * (Project 6) 
 * (Manages the general give and take of points) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    Points points;

    public PointManager()
    {
        points = new PlayerPoints();
    }

    public void AddPoints()
    {
        points = new EnemyPoints(points);
    }

    public int GetPoints()
    {
        return points.PointsEarned();
    }
}
