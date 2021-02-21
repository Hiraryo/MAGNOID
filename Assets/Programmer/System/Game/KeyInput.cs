using UnityEngine;

public class KeyInput : MonoBehaviour
{
    private float _h,_v;

    void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
    }
    public float InputKeyHorizontal
    {
        get{ return _h; }
    }
    public float InputKeyVertical
    {
        get{ return _v; }
    }
}
