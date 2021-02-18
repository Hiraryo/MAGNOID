//このプログラムは、主人公(HAL2)の処理を記述したものです。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RigidBodyコンポーネントを自動的に追加
[RequireComponent(typeof(Rigidbody))]

public class HAL2Controller : MonoBehaviour
{
    [SerializeField] private GameObject _fpsCamera,_tpsCamera;
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
    private float _h,_v;
    //ジャンプキー(今回はスペース)を押し続けた時間を測るためのフラグ（true : 押された, false : 離した）
    private bool _JumpTrigger = false;
    //地面に足がついているかを判定するフラグ（true : 接地している, false : 接地していない）
    private bool _Grounded = true;
    //移動方向
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody _myrigid;
    private Animator _animator;
    void Start()
    {
        _myrigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        InputGetKey();
        MoveMethod();
        if (Input.GetButtonDown("Jump")&&_Grounded) {JumpMethod();}
        if (Input.GetButtonDown("NormalAttack")) {AttackMethod(0);}
        if (Input.GetButtonDown("HardAttack")) {AttackMethod(1);}
        if (Input.GetKeyDown(KeyCode.F)) {SidestepMethod();}
        if (Input.GetKeyDown(KeyCode.Return)) {CameraChange();}
    }

    //キーボードの入力受付
    void InputGetKey()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }

    //移動処理
    void MoveMethod()
    {
        //移動速度の判定(移動：WASD or カーソルキー、ダッシュ：左シフトキー)
        _moveSpeed = (Input.GetButton("Dash")) ? _dashSpeed : _walkSpeed;

        //移動
        transform.Translate(0,0,_v * _moveSpeed * Time.deltaTime);

        //回転
        transform.Rotate(0, _h * _rotateSpeed * Time.deltaTime,0);

        _moveDirection = _v * gameObject.transform.forward;
        _JumpTrigger = (_Grounded) ? false : true;
        if(_Grounded == true)
        {
            if(_moveDirection.magnitude > 0.1f)
            {
                _animator.SetFloat("Speed", _moveDirection.magnitude);
            }
            else
            {
                _animator.SetFloat("Speed",0f);
            }
            _animator.SetBool("Jump",false);
        }
    }

    //ジャンプ処理
    void JumpMethod()
    {
        _Grounded = false;
        _myrigid.AddForce(Vector3.up * _jumpPower);
        _animator.SetBool("Jump",true);
        //浮遊時間の計測
        if(_JumpTrigger == true)
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
        _fpsCamera.SetActive(!_fpsCamera.activeSelf);
        _tpsCamera.SetActive(!_tpsCamera.activeSelf);
    }

    //接地判定
    void OnCollisionEnter(Collision HAL2)
    {
        if(HAL2.gameObject.tag == "Ground")
        {
            _Grounded = true;
        }
    }
}