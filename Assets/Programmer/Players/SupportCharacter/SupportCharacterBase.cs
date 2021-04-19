using UnityEngine;

namespace Players.SupportCharacter
{
    public abstract class SupportCharacterBase : MonoBehaviour, IMover, IAttacker
    {
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// メインキャラクターに追従するプログラム
        /// </summary>
        public void Follow()
        {

        }

        /// <summary>
        /// メインキャラクターのサポートとして、敵への攻撃も行う
        /// </summary>
        public void Attack()
        {

        }

        /// <summary>
        /// 「メインキャラクターのガード」に関するプログラム
        /// </summary>
        public void Guard()
        {

        }
    }
}