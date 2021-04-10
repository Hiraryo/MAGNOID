//動かす手段を書く。物理演算を書く
//Controllerから受け取った入力から、ハルを決まった方向に動かす
//入出力はView。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private float _jumpPower = 10.0f;
    private float _nowSpeed;
    protected bool _isGrounded = true;
    [SerializeField] protected Rigidbody _myrigid;
    private Vector3 _moveDirection, _nowPosition,_inputDirection;
    // Start is called before the first frame update
    void Start()
    {
        _myrigid = this.GetComponent<Rigidbody>();
    }

    protected void Move(float h, float v, float speed)
    {
        _myrigid.AddForce(Vector3.forward * v * speed);
        _myrigid.AddForce(Vector3.right * h * speed);
    }

    protected void Jump()
    {
        if (_isGrounded)
        {
            _myrigid.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    //攻撃(通常：マウス左クリック、強攻撃：マウス右クリック)
    protected void Attack(int pattern)
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

    //回避
    protected void Sidestep(float h, float v, float speed)
    {
        //現在の移動速度
        _nowSpeed = _myrigid.velocity.magnitude;
        if(_nowSpeed > 0)
        {
            h = (h > 0.0f) ? -1.0f : 0.0f;
            v = (v > 0.0f) ? -1.0f : 0.0f;
            _inputDirection = new Vector3(v, 0, h);
            //現在の方向ベクトルを取得
            _moveDirection = transform.position - _nowPosition;
            //方向ベクトルを更新
            _nowPosition = transform.position;
            //入力された方向キーと方向ベクトルが異なれば、入力方向に移動させて回避を実現。入力された方向と方向ベクトルが同じであれば、それは移動なので回避は行わない。
            if(_moveDirection != _inputDirection)
            {
                Debug.Log(_inputDirection);
                //入力方向に回避
                _myrigid.AddForce(_inputDirection * speed, ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}
