using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract IEnumerator Seek();
    public abstract IEnumerator Attack();
}
