using UnityEngine;

namespace Enemies
{
    interface IEnemyAttacker
    {
        void Attack();
    }

    class SpiderAttacker : IEnemyAttacker
    {
        public void Attack()
        {
            //蜘蛛の攻撃プログラム
        }
    }

}