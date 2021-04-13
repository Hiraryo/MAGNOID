using UnityEngine;

namespace Player
{
    interface IInputProvider
    {
        bool GetMove();
        bool GetJump();
        bool GetAttack();
        bool GetSidestep();
        
        Vector3 GetMoveDirection();
    }
}