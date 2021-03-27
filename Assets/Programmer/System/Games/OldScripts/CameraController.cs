//このプログラムは、FPS/TPS視点の切り替えや揺れなどカメラに関する処理を記述したものです。
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject = null;     // 視点となるオブジェクト
    private Vector3 lookPos = Vector3.zero;     // 実際にカメラを向ける座標
    public float lookPlayDistance = 0.3f;   // 視点の遊び
    public float followSmooth = 4.0f;       // 追いかけるときの速度

    public float cameraDistance = 5.5f;        // 視点からカメラまでの距離
    public float cameraHeight = 2.0f;          // デフォルトのカメラの高さ
    float currentCameraHeight = 2.5f;          // 現在のカメラの高さ

    public float cameraPlayDiatance = 0.3f;    // 視点からカメラまでの距離の遊び
    public float leaveSmooth = 20.0f;          // 離れるときの速度

    public float cameraHeightMin = 2.0f;    // カメラの最低の高さ
    public float cameraHeightMax = 3.0f;    // カメラの最大の高さ

    void UpdateLookPosition()
    {
        // 目標の視点と現在の視点の距離を求める
        Vector3 vec = followObject.transform.position - lookPos;
        float distance = vec.magnitude;

        if (distance > lookPlayDistance)
        {   // 遊びの距離を超えていたら目標の視点に近づける
            float move_distance = (distance - lookPlayDistance) * (Time.deltaTime * followSmooth);
            lookPos += vec.normalized * move_distance;
        }
    }

    void UpdateCameraPosition()
    {
        // XZ平面におけるカメラと視点の距離を取得する
        Vector3 xz_vec = followObject.transform.position - transform.position;
        xz_vec.y = 0;
        float distance = xz_vec.magnitude;

        // カメラの移動距離を求める
        float move_distance = 0;
        if (distance > cameraDistance + cameraPlayDiatance)
        {   // カメラが遊びを超えて離れたら追いかける
            move_distance = distance - (cameraDistance + cameraPlayDiatance);
            move_distance *= Time.deltaTime * followSmooth;
        }
        else if (distance < cameraDistance - cameraPlayDiatance)
        {   // カメラが遊びを超えて近づいたら離れる
            move_distance = distance - (cameraDistance - cameraPlayDiatance);
            move_distance *= Time.deltaTime * leaveSmooth;
        }

    　　　　// 新しいカメラの位置を求める
        Vector3 camera_pos = transform.position + (xz_vec.normalized * move_distance);

    // 高さは常に現在の視点からの一定の高さを維持する
        //camera_pos.y = lookPos.y + currentCameraHeight;

        //transform.position = camera_pos;
    }

    void FixedUpdate()
    {
        if(followObject == null) return;

        UpdateLookPosition();
        UpdateCameraPosition();

        transform.LookAt(lookPos);
    }

/*
    public void Roll(float x, float y)
    {
        // 移動前の距離を保存する
        float prev_distance = Vector3.Distance(followObject.transform.position, transform.position);
        Vector3 pos = transform.position;

        // 横に移動する
        pos += transform.right * x;

        // 縦に移動する
        currentCameraHeight = Mathf.Clamp(currentCameraHeight + y, cameraHeightMin, cameraHeightMax);
        pos.y = lookPos.y + currentCameraHeight;

        // 移動後の距離を取得する
        float after_distance = Vector3.Distance(followObject.transform.position, pos);

        // 視点を対象に向けて近づける（遊びをなくす）
        lookPos = Vector3.Lerp(lookPos, followObject.transform.position, 0.1f);

        // カメラの更新
        transform.position = pos;
        transform.LookAt(lookPos);

        // 平行移動により若干距離が変わるので補正する
        transform.position += transform.forward * (after_distance - prev_distance);
    }

*/
    public void Reset(float rate = 1)
    {
        // 視点対象に近づける
        lookPos = Vector3.Lerp(lookPos, followObject.transform.position, rate);

        // 高さをデフォルトに近づける
        currentCameraHeight = Mathf.Lerp(currentCameraHeight, cameraHeight, rate);

        // カメラを基本位置に近づける
        Vector3 pos_goal = followObject.transform.position;
        pos_goal -= followObject.transform.forward * cameraDistance;
        pos_goal.y = followObject.transform.position.y + currentCameraHeight;
        transform.position = Vector3.Lerp(transform.position, pos_goal, rate);

        // 視線を更新する
        //transform.LookAt(lookPos);
    }
}