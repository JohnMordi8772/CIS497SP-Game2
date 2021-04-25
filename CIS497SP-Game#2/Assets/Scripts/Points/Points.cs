using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Points
{
    public Points() { }
    public virtual int PointsEarned()
    {
        return 0;
    }
}
