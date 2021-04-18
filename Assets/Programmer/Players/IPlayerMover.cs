using UnityEngine;

namespace Players
{
    interface IPlayerMover
    {
        void Walk();
        void Jump();
        void Sidestep();
        void Dash();
    }
}