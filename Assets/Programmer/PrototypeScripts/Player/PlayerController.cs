//ControllerはPlayerが動くという目的だけを実行したいだけ
//移動速度などは、PlayerModelで求める。
//移動の手段や、物理演算(Rigidbody or 自作）はViewで行う。
//入出力の管理はController（ここ）で行う。

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : PlayerView
{
    private float _walk = 10.0f;
    private float _dash = 15.0f;
    private float _moveSpeed;
    private float h, v;
    private int up, down, left, right;
    private float _beforeVerticalSpeed, _beforeHorizontalSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { base.Jump(); }
        if (Input.GetMouseButtonDown(0)) { base.Attack(0); }
        if (Input.GetMouseButtonDown(1)) { base.Attack(1); }
        
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        _moveSpeed = (Input.GetKey(KeyCode.LeftShift)) ? _dash : _walk;
        base.Move(h, v, _moveSpeed);
        if ((h != 0.0f || v != 0.0f) && h != v)    //前後移動、左右移動を始めて、斜め移動ではない時
        { SidestepCheck(); }
        else { CountReset(); }
    }

    //HACK:あまり綺麗ではないが一応以下のコードで1フレーム1入力を検出
    //todo:後で改善
    //FIXME:2回連続ではなくても動作してしまう。
    //移動方向の逆方向を2回連続で押された時
    private void SidestepCheck()
    {
        if (v > 0.0f && _beforeVerticalSpeed == 0.0f)
        {
            up++;
            if(up == 2)
            {
                Debug.Log("前へ回避");
                CountReset();
            }
            Debug.Log("前");
        }

        if (v < 0.0f && _beforeVerticalSpeed == 0.0f)
        {
            down++;
            if(down == 2)
            {
                Debug.Log("後ろへ回避");
                CountReset();
            }
            Debug.Log("後ろ");
            v = -v;
        }
        if(h > 0.0f && _beforeHorizontalSpeed == 0.0f)
        {
            right++;
            if(right == 2)
            {
                Debug.Log("右へ回避");
                CountReset();
            }
            Debug.Log("右");
        }
        if(h < 0.0f && _beforeHorizontalSpeed == 0.0f)
        {
            left++;
            if(left == 2)
            {
                Debug.Log("左へ回避");
                CountReset();
            }
            Debug.Log("左");
            h = -h;
        }
        _beforeVerticalSpeed = v;
        _beforeHorizontalSpeed = h;

        /*---------------------------------------------------------------*/
        /*
        for (int i = 0; floatNumbers[i] >= 2; i++)
        {
            Debug.Log("floatNumbers[" + i + "] = " + floatNumbers[i]);
            Debug.Log(floatNumbers[i] + "へ回避");
            floatNumbers[i] = 0;
        }
        */


        //_beforebackSpeed = -v;
        /*
        if (v < 0.0f && _beforeMoveSpeed == 0.0f)
        {
            right++;
            Debug.Log("後ろ");
            _beforeMoveSpeed = -v;
        }
        */
        /*
        if (h != 0.0f && v != 0.0f)  //一瞬だけ斜め移動になった時を回避とみなす
        {
            count++;
            Debug.Log("cout = "+count);
            yield break;
        }
        if (count >= 2)
        {
            count = 0;
            Debug.Log("回避成功");
            yield break;
        }
        */

        /*---------------------------------------------------------------*/

        /*
        if ((h != 0.0f && v == 0.0f) || h < v)
        {
            
        }
        */
        //floatNumbers = new[] { h, v };
        //float max = floatNumbers.Max();

        //Debug.Log("左-h : " + -h + ", 右h : " + h + ", 前v : " + v + ", 後ろ-v : " + -v);
        //Debug.Log(floatNumbers[0]);

        /*
        if(max == floatNumbers[0])
        {
            Debug.Log("左h : "+max);
        }
        if (max == floatNumbers[1])
        {
            Debug.Log("右-h : " + max);
        }
        if (max == floatNumbers[2])
        {
            Debug.Log("前v : " + max);
        }
        if (max == floatNumbers[3])
        {
            Debug.Log("後ろ-v : " + max);
        }
        */



        /*
        //Mathf.Abs(_up);
        //途中で終了
        yield break;

        //中断して次のフレームから再開
        yield return null;
        */
        /*---------------------------------------------------------------*/
    }
    private void CountReset()
    {
        up = 0;
        down = 0;
        right = 0;
        left = 0;
    }
}
