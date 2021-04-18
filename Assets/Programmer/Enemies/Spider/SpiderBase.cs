using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spider
{
    public abstract class SpiderBase : MonoBehaviour
    {
        private SpiderMover spiderMover;    //移動に関するクラスを宣言
        private SpiderAttacker spiderAttacker;  //攻撃に関するクラスを宣言

        private void Start()
        {
            spiderMover = new SpiderMover();
            spiderAttacker = new SpiderAttacker();
        }

        private void Update()
        {

        }
    }
}

