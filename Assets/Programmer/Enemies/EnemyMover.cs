using UnityEngine;

namespace Enemies
{
    interface IEnemyMover
    {
        void Move();
    }

    class SpiderMover : IEnemyMover
    {
        public void Move()
        {
            //蜘蛛を動かすプログラム
        }
    }
}