//ハルの状態をどのようにするかを定義するプログラム
//入出力とは関係ないものをModelに。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Object
{
    /*
    /// <summary>
    /// ゲーム開始時にこのコンストラクタを呼び、プレイヤーのパラメータを設定
    /// </summary>
    public int HP, AP;
    public PlayerModel(int hp, int ap)
    {
        this.HP = hp;
        this.AP = ap;
    }
    */

    
    

    /// <summary>
    /// ハルの移動速度を求める
    /// </summary>
    /// <param name="_walkSpeed">歩行速度</param>
    /// <param name="_dashSpeed">走行速度</param>
    /// <param name="_rotateSpeed">回転速度</param>
    /// <param name="_jumpPower">ジャンプ力</param>
    /// <param name="_flyingTime">浮遊時間</param>
    /// <param name="_nowSpeed">現在の移動速度</param>
    /// <param name="_h">水平方向の入力状態を代入</param>
    /// <param name="_v">鉛直方向の入力状態を代入</param>
    /// <param name="_isJumpTrigger">ジャンプキーを押し続けた時間を測るためのフラグ（押された時がtrue、離した時がfalse）</param>
    /// <param name="_isGrounded">地面に足がついているかを判定するフラグ（接地している時はtrue、接地していない時はfalse）</param>
    /// <param name="_moveDirection">移動方向</param>
    ///


    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーの腕前からハルの攻撃力を求める
    /// </summary>
    ///
    private void CalcAttack()
    {

    }

    /// <summary>
    /// ハルのジャンプ力を求める
    /// </summary>
    ///
    private void CalcJumpPower()
    {

    }
}
