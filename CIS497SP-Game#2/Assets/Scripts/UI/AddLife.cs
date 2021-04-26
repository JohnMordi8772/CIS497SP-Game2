/* (Ashton Lively) 
 * (AddLife) 
 * (Project 6) 
 * (This adds lives and removes them from the screen) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife : MonoBehaviour, ILifeCommand
{
    private InGameUIManager ui;

    private Transform heartTray;
    private Stack<GameObject> hearts = new Stack<GameObject>();
    private GameObject heartIcon;

    public void SetVals(InGameUIManager manager)
    {
        ui = manager;
        heartIcon = Resources.Load<GameObject>("Prefabs/Heart");
        heartTray = GameObject.Find("Hearts").transform;
    }
    public void execute()
    {
        GameObject newheart = Instantiate(heartIcon, heartTray);
        hearts.Push(newheart);
    }

    public void undo()
    {
        GameObject remove = hearts.Pop();
        Destroy(remove);
    }
}
