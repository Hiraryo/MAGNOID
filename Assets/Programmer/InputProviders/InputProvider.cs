using UnityEngine;
using Player;

namespace InputProviders
{
    public class InputProvider : IInputProvider
    {
        public bool GetMove()
        {
            return Input.GetButton("Dash");
        }

        public bool GetJump()
        {
            return Input.GetButton("Jump");
        }

        public bool GetAttack()
        {
            return Input.GetButton("Attack");
        }

        public bool GetSidestep()
        {
            return Input.GetButton("Kaihi");
        }

        public Vector3 GetMoveDirection()
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}