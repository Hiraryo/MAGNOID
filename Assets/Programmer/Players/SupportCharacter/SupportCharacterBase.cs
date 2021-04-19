//-----------------------------
//引数や返り値は、仮で設定
//-----------------------------
using UnityEngine;

namespace Players.SupportCharacter
{
    public abstract class SupportCharacterBase : MonoBehaviour, ISupportCharacterMover, ISupportCharacterAttacker
    {
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// 操作キャラクターに追従するプログラム
        /// </summary>
        public void Follow()
        {

        }

        /// <summary>
        /// 操作キャラクターのサポートとして、敵への攻撃も行う。
        /// その攻撃についてのプログラム
        /// </summary>
        public void Attack()
        {

        }

        /// <summary>
        /// 「操作キャラクターのガード」についてのプログラム
        /// </summary>
        public void Guard()
        {

        }
    }
}