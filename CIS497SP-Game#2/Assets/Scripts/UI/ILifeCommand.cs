/* (Ashton Lively) 
 * (ILifeCommand) 
 * (Project 6) 
 * (Parent Class for AddLife) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeCommand
{
    void execute();
    void undo();
}
