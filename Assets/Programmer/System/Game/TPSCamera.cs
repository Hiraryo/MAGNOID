using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Quaternion _hRotation,_vRotation;
    void Start()
    {
        _hRotation = Quaternion.identity;
        _vRotation = Quaternion.identity;
    }
    void LateUpdate()
    {
        // Move the mouse X to rotate the camera Y
        _hRotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X"),0);
        // Move the mouse Y to rotate the camera X
        _vRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y"),0,0);
        // Rotate the camera
        transform.rotation = _hRotation * _vRotation;
    }
}
