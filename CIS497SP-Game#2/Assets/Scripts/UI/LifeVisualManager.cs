/* (Ashton Lively) 
 * (LifeVisualManager) 
 * (Project 6) 
 * (This manages the adding and removal of the lives visually) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeVisualManager : MonoBehaviour
{
    private LifeVisualInvoker lifeVisualInvoker;
    private AddLife life;

    public void SetVals(InGameUIManager manager)
    {
        lifeVisualInvoker = gameObject.AddComponent<LifeVisualInvoker>();

        life = gameObject.AddComponent<AddLife>();
        life.SetVals(manager);

        lifeVisualInvoker.setCommand(life);
    }

    public void RemoveLife()
    {
        lifeVisualInvoker.LifeLost();
    }

    public void AddLife()
    {
        lifeVisualInvoker.LifeGained();
    }
}
