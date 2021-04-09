// プレイヤーに起こるイベントにおけるスコア変化

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdemaePlayer : MonoBehavior{
    public int score = 0;
    private int hitCount = 0;

    // 最初ぼ1回だけ実行
    void Start(){

    }

    // Start()の実行後1フレーム毎に1回実行される
    void Update(){

    }

    // 被弾したとき
    void OnCollisionEnter(Collision col){
        // 被弾原因
        if(col.gameObject.tag == "enemy"){ // 敵と接触した場合、スコア減少
            // 攻撃ヒットボーナスをリセット
            hitCount = 0;
            
            // 最期の被弾原因
            if(col == "die"){ // 死んだ
                // 大幅にスコア減少
            }
            else{ // 死なない場合
                // スコア減少
            }

        }

        // 連続攻撃ヒット数（被弾すればリセット）
        // これは別のファイルで管理した方が良さそう
        // 式： score = score + 1.5^(hitCount) [1<(累乗する定数)<2]
    }

    // エリア内での生存
    // ステージをクリアしたとき
    // エリアのクリア時間

    // スコア（ウデマエポイント）
    // 最大スコアを計算し、最大スコアの何%かで評価する
}