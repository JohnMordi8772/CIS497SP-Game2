using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeVisualInvoker : MonoBehaviour
{
    private ILifeCommand command;

    public void setCommand(ILifeCommand command)
    {
        this.command = command;
    }

    public void LifeGained()
    {
        command.execute();
    }

    public void LifeLost()
    {
        command.undo();
    }
}
