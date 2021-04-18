using UnityEngine;

namespace Enemies
{
    interface IEnemyAttacker
    {
        void Attack();
        void Level();
        void Status();
    }

    class SpiderAttacker : IEnemyAttacker
    {
        /// <summary>
        /// 蜘蛛の攻撃スタイルを決めるプログラム（近距離・中距離・遠距離）
        /// </summary>
        public void Attack()
        {
            
        }

        /// <summary>
        /// 蜘蛛のレベルを決めるプログラム
        /// </summary>
        public void Level()
        {
            
        }

        /// <summary>
        /// 蜘蛛の状態を決めるプログラム(活発かなど)
        /// </summary>
        public void Status()
        {

        }

        /// <summary>
        /// 糸を出して攻撃する
        /// </summary>
        private void AttackYarn()
        {

        }
    }

}