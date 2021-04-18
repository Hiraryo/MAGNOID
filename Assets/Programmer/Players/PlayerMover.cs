using UnityEngine;

namespace Players
{
    interface IPlayerMover
    {
        void Move();
    }

    class PlayerMover : IPlayerMover
    {
        public void Move()
        {
            //ハルの動きについてのプログラム
        }
    }
}