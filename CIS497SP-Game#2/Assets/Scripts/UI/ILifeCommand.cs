using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeCommand
{
    void execute();
    void undo();
}
