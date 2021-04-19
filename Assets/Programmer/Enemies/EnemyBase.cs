using UnityEngine;

namespace Enemies
{
    public abstract class EnemyBase : MonoBehaviour, IEnemyAttacker, IEnemyMover
    {
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// 敵の攻撃スタイルを決めるプログラム（近距離・中距離・遠距離）
        /// </summary>
        public void Attack()
        {

        }

        /// <summary>
        /// 敵のレベルを決めるプログラム
        /// </summary>
        public void Level()
        {

        }

        /// <summary>
        /// 敵の状態を決めるプログラム(活発かなど)
        /// </summary>
        public void Status()
        {

        }

        /// <summary>
        /// 敵の「歩き」に関するプログラム
        /// </summary>
        public void Walk()
        {

        }

        /// <summary>
        /// 敵の「ジャンプ」に関するプログラム
        /// </summary>
        public void Jump()
        {

        }

        /// <summary>
        /// 敵の「飛行」に関するプログラム
        /// </summary>
        public void Fly()
        {

        }

        /// <summary>
        /// 敵の「透明」に関するプログラム
        /// </summary>
        public void Hide()
        {

        }

        /// <summary>
        /// 敵の「ダッシュ」に関するプログラム
        /// </summary>
        public void Dash()
        {

        }
    }
}