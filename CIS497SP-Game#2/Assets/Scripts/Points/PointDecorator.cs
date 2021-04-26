/* (Ashton Lively)
 * (PointDecorator) 
 * (Project 6) 
 * (The decorator for the point system) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointDecorator : Points
{
    public abstract override int PointsEarned();
}
