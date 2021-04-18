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

    class SpiderMover : IEnemyMover
    {
        /// <summary>
        /// 蜘蛛の「歩き」に関するプログラム
        /// </summary>
        public void Walk()
        {
            
        }

        /// <summary>
        /// 蜘蛛の「ジャンプ」に関するプログラム
        /// </summary>
        public void Jump()
        {

        }

        /// <summary>
        /// 蜘蛛の「飛行」に関するプログラム
        /// </summary>
        public void Fly()
        {

        }

        /// <summary>
        /// 蜘蛛の「透明」に関するプログラム
        /// </summary>
        public void Hide()
        {

        }

        /// <summary>
        /// 蜘蛛の「ダッシュ」に関するプログラム
        /// </summary>
        public void Dash()
        {

        }
    }
}