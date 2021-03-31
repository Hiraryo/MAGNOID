//このプログラムは、主人公(HAL2)について記述したものです。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewNotUse : MonoBehaviour
{
    [SerializeField] private float applySpeed = 0.2f;       // 振り向きの適用速度
    //[SerializeField] private PlayerFollowCamera refCamera;  // カメラの水平回転を参照する用
    //歩行速度
    [SerializeField] private float _walkSpeed = 5.0f;
    //走行速度
    [SerializeField] private float _dashSpeed = 10.0f;
    //回転速度
    [SerializeField] private float _rotateSpeed = 120.0f;
    //ジャンプ力
    [SerializeField] private float _jumpPower = 400.0f;
    //浮遊時間
    private float _flyingTime = 0.0f;
    //移動速度
    private float _moveSpeed;
    //水平方向と鉛直方向の入力状態を代入（h : 水平, v : 鉛直）
    private float _h, _v;
    //ジャンプキー(今回はスペース)を押し続けた時間を測るためのフラグ（true : 押された, false : 離した）
    private bool _isJumpTrigger = false;
    //地面に足がついているかを判定するフラグ（true : 接地している, false : 接地していない）
    private bool _isGrounded = true;
    //移動方向
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody _myrigid;
    private Animator _animator;
    private void Start()
    {
        _myrigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) { JumpMethod(); }
        if (Input.GetMouseButtonDown(0)) { AttackMethod(0); }
        if (Input.GetMouseButtonDown(1)) { AttackMethod(1); }
        if (Input.GetKeyDown(KeyCode.F)) { SidestepMethod(); }
    }

    private void View()
    {

    }

    //キーボードの入力受付
    void InputGetKey()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        _moveDirection.x = (_h == 0.0f) ? 0.0f : _h;
        _moveDirection.z = (_v == 0.0f) ? 0.0f : _v;
        Debug.Log("_h : " + _h + "_v : " + _v);
    }

    //移動処理
    void MoveMethod()
    {
        //移動速度の判定(移動：WASD or カーソルキー、ダッシュ：左シフトキー)
        _moveSpeed = (Input.GetButton("Dash")) ? _dashSpeed : _walkSpeed;

        //移動(速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します)
        _moveDirection = _moveDirection.normalized * _moveSpeed * Time.deltaTime;
        _isJumpTrigger = (_isGrounded) ? false : true;
        if (_moveDirection.magnitude > 0.0f)
        {
            if (_isGrounded == true)
            {
                _animator.SetFloat("Speed", _moveDirection.magnitude);
                _animator.SetBool("Jump", false);
            }
            else
            {
                _animator.SetFloat("Speed", 0f);
            }
            // プレイヤーの回転(transform.rotation)の更新
            // 無回転状態のプレイヤーのZ+方向(後頭部)を、
            // カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            //transform.rotation = Quaternion.Slerp(transform.rotation,
                                                //Quaternion.LookRotation(refCamera.hRotation * _moveDirection),
                                                //applySpeed);

            // プレイヤーの位置(transform.position)の更新
            // カメラの水平回転(refCamera.hRotation)で回した移動方向(_moveDirection)を足し込みます
            //transform.position += refCamera.hRotation * _moveDirection;
        }
    }

    //ジャンプ処理
    void JumpMethod()
    {
        _isGrounded = false;
        _myrigid.AddForce(Vector3.up * _jumpPower);
        _animator.SetBool("Jump", true);
        //浮遊時間の計測
        if (_isJumpTrigger == true)
        {
            _flyingTime += 0.01f;
        }
    }

    //攻撃(通常：マウス左クリック、強攻撃：マウス右クリック)
    void AttackMethod(int pattern)
    {
        switch (pattern)
        {
            //通常攻撃
            case 0:
                Debug.Log("通常攻撃");
                break;

            //強攻撃
            case 1:
                Debug.Log("強攻撃");
                break;

            default:
                break;
        }
    }
    //回避(Fキー)
    void SidestepMethod()
    {
        Debug.Log("回避");
    }

    void CameraChange()
    {

    }

    //接地判定
    void OnCollisionEnter(Collision HAL2)
    {
        if (HAL2.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}