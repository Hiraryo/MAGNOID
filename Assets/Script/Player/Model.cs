using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    private Vector3 force;
    public static void PlayerMover(Rigidbody myrigid, float moveSpeed, float rotateSpeed)
    {
        myrigid.AddForce(Vector3.forward * moveSpeed * Time.deltaTime);
        //transform.Translate(0, 0, v * moveSpeed * Time.deltaTime);
        //transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);
    }
    public void PlayerJumper(Rigidbody myrigid, float jumpPower)
    {
        force = Vector3.up * jumpPower;
    }
    public static void PlayerAttacker(int pattern)
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
    public static void PlayerAnimator(Animator animator, string animationName, bool flag)
    {
        animator.SetBool(animationName, flag);
    }
    public static void PlayerSideStep()
    {

    }
}
