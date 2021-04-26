/* (John Mordi) 
 * (Pool) 
 * (Project 6) 
 * (Classifies what the object pooler is using) */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size = 1;
}