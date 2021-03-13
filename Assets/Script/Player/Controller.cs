using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){ PlayerMover(); }
        if (Input.GetButtonDown("Jump") && _Grounded) { JumpMethod(); }
        if (Input.GetButtonDown("NormalAttack")) { PlayerAttacker(0); }
        if (Input.GetButtonDown("HardAttack")) { PlayerAttacker(1); }
        if (Input.GetKeyDown(KeyCode.Return)) { CameraChange(); }
        Model.PlayerJumper();
    }
}
