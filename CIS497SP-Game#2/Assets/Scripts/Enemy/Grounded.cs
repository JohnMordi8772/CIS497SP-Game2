using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override IEnumerator Seek()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator Attack()
    {
        throw new System.NotImplementedException();
    }

    public override bool Detected()
    {
        return false;
    }

}
