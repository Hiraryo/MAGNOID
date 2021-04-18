using UnityEngine;

namespace Enemies
{
    interface IEnemyMover
    {
        void Walk();
        void Jump();
        void Fly();
        void Hide();
        void Dash();
    }
}