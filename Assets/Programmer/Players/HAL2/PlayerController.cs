//ControllerはPlayerが動くという目的だけを実行したいだけ
//移動速度などは、PlayerModelで求める。
//移動の手段や、物理演算(Rigidbody or 自作)はViewで行う。
//入出力の管理はController(ここ)で行う。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerView
{
    private float _walk = 10.0f;
    private float _dash = 15.0f;
    private float _moveSpeed,_sideStepSpeed = 10.0f;
    private float h, v;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { base.Jump(); }
        if (Input.GetMouseButtonDown(0)) { base.Attack(0); }
        if (Input.GetMouseButtonDown(1)) { base.Attack(1); }
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        _moveSpeed = (Input.GetKey(KeyCode.LeftShift)) ? _dash : _walk;
        base.Move(h, v, _moveSpeed);
        if (Input.GetKeyDown(KeyCode.RightShift)) { base.Sidestep(h, v, _sideStepSpeed); }
    }
}
