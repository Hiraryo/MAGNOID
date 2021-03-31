//動かす手段を書く。物理演算を書く
//Controllerから受け取った入力から、ハルを決まった方向に動かす
//入出力はView。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerController))]
public class PlayerView : MonoBehaviour
{
    private float _jumpPower = 10.0f;
    
    private bool _isGrounded = true;
    [SerializeField]private Rigidbody _myrigid;

    
    // Start is called before the first frame update
    void Start()
    {
        _myrigid = this.GetComponent<Rigidbody>();
        PlayerModel playermodel = new PlayerModel(100,20);
        Debug.Log(playermodel.HP);
    }
    
    public void Move(float h, float v, float speed)
    {
        _myrigid.AddForce(Vector3.forward * v * speed);
        _myrigid.AddForce(Vector3.right * h * speed);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _myrigid.AddForce(Vector3.up * _jumpPower,ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    //攻撃(通常：マウス左クリック、強攻撃：マウス右クリック)
    public void Attack(int pattern)
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
    public void Sidestep()
    {
        Debug.Log("回避");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}