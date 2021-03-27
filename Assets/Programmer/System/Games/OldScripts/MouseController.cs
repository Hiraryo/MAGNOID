//参考：https://qiita.com/K_phantom/items/d5d92955043137a59d8f#%E3%82%B7%E3%83%A5%E3%83%BC%E3%83%86%E3%82%A3%E3%83%B3%E3%82%B0%E7%B3%BB
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    void Start()
    {
        if(character == null)
            character = transform.parent;
    }
    
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle  = 0.5f;
    // Update is called once per frame
    void Update()
    {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        //ワールド座標でのY軸回転(左右)
        transform.Rotate(Y_Rotation, X_Rotation, 0);
    }
}