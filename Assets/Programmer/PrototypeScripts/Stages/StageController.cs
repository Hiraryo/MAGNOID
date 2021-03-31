using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : StageView
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        int now = DateTime.Now.Hour;
        Lighting(now);
    }
}
