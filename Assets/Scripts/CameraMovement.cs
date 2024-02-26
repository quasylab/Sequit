using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public bool eagleEyeCam;
    public float speed;
    public float scrollSpeed;

    private float _horizontalInput;
    private float _verticalInput;
    private float _forwardInput;
    
    private Vector3 _initialPositionEagle = new Vector3(0, 10, 0);
    private Vector3 _initialRotationEagle = new Vector3(90,0,0);
    private Vector3 _initialPositionRotative = new Vector3(0, 1, -10);
    private Vector3 _initialRotationRotative = new Vector3(0, 0, 0);

    private float _staticDistanceVar = 20f;

    // Start is called before the first frame update
    void Start()
    {
        SetRotativeCam();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _forwardInput = Input.GetAxis("Mouse ScrollWheel");
        
        if (eagleEyeCam)
        {
            transform.Translate(Vector3.right * (speed * _horizontalInput * Time.deltaTime));
            transform.Translate(Vector3.up * (speed * _verticalInput * Time.deltaTime));
            transform.Translate(Vector3.forward * (scrollSpeed * _forwardInput * Time.deltaTime));
        }
        else
        {
            transform.LookAt(new Vector3(0,0,0));
            transform.Translate(Vector3.right * (_horizontalInput * Time.deltaTime * 10));
            transform.Translate(Vector3.up * (_verticalInput * Time.deltaTime * 10));
            transform.Translate(Vector3.forward * (_forwardInput * Time.deltaTime * scrollSpeed));
            //TODO Add lower limits
        }
        
    }

    
    public void SetEagleEyeCam()
    {
        transform.position = _initialPositionEagle;
        transform.rotation = Quaternion.Euler(_initialRotationEagle);
        eagleEyeCam = true;
    }

    public void SetRotativeCam()
    {
        transform.position = _initialPositionRotative;
        transform.rotation = Quaternion.Euler(_initialRotationRotative);
        eagleEyeCam = false;
    }

    public void ZoomOut()
    {
        transform.Translate(Vector3.forward * (-_staticDistanceVar));
    }

    public void ZoomIn()
    {
        transform.Translate(Vector3.forward * _staticDistanceVar);
    }
}
