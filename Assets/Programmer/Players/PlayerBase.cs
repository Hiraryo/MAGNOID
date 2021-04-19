//-----------------------------
//引数や返り値は、仮で設定
//-----------------------------
using UnityEngine;

namespace Players
{
    public abstract class PlayerBase : MonoBehaviour, IPlayerMover, IPlayerAttacker
    {
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// 操作キャラクターを歩かせるプログラム
        /// </summary>
        public void Walk()
        {

        }

        /// <summary>
        /// 操作キャラクターの「ジャンプ」についてのプログラム
        /// </summary>
        public void Jump()
        {

        }

        /// <summary>
        /// 操作キャラクターの「回避」についてのプログラム
        /// </summary>
        public void Sidestep()
        {

        }

        public void Dash()
        {

        }

        public void Attack()
        {

        }
    }
}