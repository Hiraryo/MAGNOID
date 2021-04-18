using UnityEngine;

namespace Players
{
    interface IPlayerJumper
    {
        void Jump();
    }

    class PlayerJumper : IPlayerJumper
    {
        public void Jump()
        {
            //ハルのジャンププログラム
        }
    }
}