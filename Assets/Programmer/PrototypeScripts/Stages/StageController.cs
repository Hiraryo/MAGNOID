//現在時刻、時期（季節）を取得
//結果をModelに渡す
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
        //リアルタイムで環境光を調整
        int now = DateTime.Now.Hour;
        Lighting(now);
    }
}
