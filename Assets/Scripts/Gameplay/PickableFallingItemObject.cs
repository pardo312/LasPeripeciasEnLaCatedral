using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableFallingItemObject : FallingItemObject
{
    public float mass;

    protected override void Start()
    {
        base.Start();
        rb.mass = mass;
    }
}