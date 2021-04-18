using UnityEngine;

namespace Enemies
{
    interface IEnemy
    {
        void Walk();
        void Sleep();
        void Attack();
    }
}