// This program has written a processing related to the player (HAL2)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatically add RigidBody components
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(KeyInput))]

public class HAL2Controller : MonoBehaviour
{
    [SerializeField] private GameObject _fpsCamera,_tpsCamera;
    [SerializeField] private float _walkSpeed = 20.0f;
    [SerializeField] private float _dashSpeed = 30.0f;
    [SerializeField] private float _rotateSpeed = 150.0f;
    [SerializeField] private float _jumpPower = 120.0f;
    private float _flyingTime = 0.0f;
    private float _instantInputTime = 5.0f;
    private float _moveSpeed;
    private float _hPlayer,_vPlayer;
    // SidestepMethod called when the this value becomes 0
    private int _instantInputCount = 2;
    // Variable to confirm the input state of the jump key. (true : pushed, false : released)
    private bool _JumpTrigger = false;
    // Variable to confirm the whether player is landing a ground. (true : landing, false : not landing)
    private bool _Grounded = true;
    private Vector3 _moveDirection = Vector3.zero;
    private Rigidbody _myrigid;
    private Animator _animator;
    private KeyInput _playerControllerScript;
    void Start()
    {
        _myrigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerControllerScript = GetComponent<KeyInput>();
    }

    void FixedUpdate()
    {
        _hPlayer = _playerControllerScript.InputKeyHorizontal;
        _vPlayer = _playerControllerScript.InputKeyVertical;
    }

    void Update()
    {
        MoveMethod();
        if (Input.GetButtonDown("Jump")&&_Grounded) {JumpMethod();}
        if (Input.GetButtonDown("NormalAttack")) {AttackMethod(0);}
        if (Input.GetButtonDown("HardAttack")) {AttackMethod(1);}
        if (Input.GetKeyDown(KeyCode.Return)) {CameraChange();}
    }

    void MoveMethod()
    {
        // When the player stops and _instantInputCount variable is greater than 0.
        /*
        _instantInputTime -= 0.01f;
        _instantInputCount = 1;
        if(_instantInputTime >= 0.0f)
        {
            SidestepMethod();
            _instantInputCount = 0;
            _instantInputTime = 5.0f;
        }
        if (_instantInputTime >= 0.0f && _instantInputCount != 0)
        {
            Debug.Log("OOOOOOOOOOOOOOOOOKKKKKKKKKKKKKKKK");
            _instantInputCount = 2;
            _instantInputTime = 5.0f;
        }
        Debug.Log("_instantInputCount : " + _instantInputCount + ", _instantInputTime : " + _instantInputTime + "_hPlayer : " + _hPlayer + ", _vPlayer : " + _vPlayer);
        */

        // Judge the movement speed. ("MOVE" : WASD or Cursor key, "DASH" : Left shift key)
        _moveSpeed = (Input.GetButton("Dash")) ? _dashSpeed : _walkSpeed;

        transform.Translate(0,0,_vPlayer * _moveSpeed * Time.deltaTime);

        transform.Rotate(0, _hPlayer * _rotateSpeed * Time.deltaTime,0);

        _moveDirection = _vPlayer * gameObject.transform.forward;
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

    void JumpMethod()
    {
        _Grounded = false;
        _myrigid.AddForce(Vector3.up * _jumpPower);
        _animator.SetBool("Jump",true);
        // Measure the floating time
        if(_JumpTrigger == true)
        {
            _flyingTime += 0.01f;
        }
    }

    void AttackMethod(int pattern)
    {
        switch (pattern)
        {
            // Normal attack
            case 0:
                Debug.Log("通常攻撃");
                break;

            // Strong attack
            case 1:
                Debug.Log("強攻撃");
                break;

            default:
                break;
        }
    }

    void SidestepMethod()
    {
        //_instantInputCount = 2;
        Debug.Log("回避");
    }

    void CameraChange()
    {
        _fpsCamera.SetActive(!_fpsCamera.activeSelf);
        _tpsCamera.SetActive(!_tpsCamera.activeSelf);
    }

    void OnCollisionEnter(Collision HAL2)
    {
        if(HAL2.gameObject.tag == "Ground")
        {
            _Grounded = true;
        }
    }
}