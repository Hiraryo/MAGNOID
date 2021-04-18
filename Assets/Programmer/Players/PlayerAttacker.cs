using UnityEngine;

namespace Players
{
    interface IPlayerAttacker
    {
        void Attack();
    }

    class PlayerAttacker : IPlayerAttacker
    {
        public void Attack()
        {
            //ハルの攻撃プログラム
        }
    }
}