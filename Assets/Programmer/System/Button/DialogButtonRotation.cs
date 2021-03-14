using UnityEngine;

[RequireComponent(typeof(KeyInput))]
public class DialogButtonRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private KeyInput _dialogButtonRotationScript;
    private float _hDialogRotation;
    // Start is called before the first frame update
    void Start()
    {
        _dialogButtonRotationScript = GetComponent<KeyInput>();
    }

    // Update is called once per frame
    void Update()
    {
        _hDialogRotation = _dialogButtonRotationScript.InputKeyHorizontal;
        transform.Rotate(0,0,_hDialogRotation * _rotateSpeed);
    }
}
