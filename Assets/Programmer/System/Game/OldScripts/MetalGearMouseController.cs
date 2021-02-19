//参考：https://qiita.com/K_phantom/items/d5d92955043137a59d8f#%E3%83%A1%E3%82%BF%E3%83%AB%E3%82%AE%E3%82%A2%E3%82%BD%E3%83%AA%E3%83%83%E3%83%89%E7%B3%BB
using UnityEngine;

public class MetalGearMouseController : MonoBehaviour
{

    [SerializeField]
    private Transform pivot = null;
    void Start()
    {
        if (pivot == null)
            pivot = transform.parent;
    }

    [Range(-0.999f, -0.5f)]
    public float minYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float maxYAngle = 0.5f;
    void Update()
    {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        if(Input.GetMouseButton(0))
        {
            //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
            pivot.transform.Rotate(0, X_Rotation, 0);

            //次はY軸の設定です。
            float nowAngle = pivot.transform.localRotation.x;
            //最大値、または最小値を超えた場合、カメラをそれ以上動かない用にしています。
            //カメラが一回転しないようにするのを防ぎます。
            if (-Y_Rotation != 0)
            {
                if (0 < Y_Rotation)
                {
                    if (minYAngle <= nowAngle)
                    {
                        pivot.transform.Rotate(Y_Rotation, 0, 0);
                    }
                }
                else
                {
                    if (nowAngle <= maxYAngle)
                    {
                        pivot.transform.Rotate(Y_Rotation, 0, 0);
                    }
                }
            }
        }
        //操作していると、Z軸がだんだん動いていくので、0に設定してください。
        pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, 0f);
    }
}