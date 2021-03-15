using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] [Range(0, 0.5f)] private float maxYAngle = 0.5f;
    [SerializeField] private float _minYAngle;
    private Quaternion _hRotation,_vRotation;
    void Start()
    {
        //_minYAngle = _player.transform.position.y;
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
