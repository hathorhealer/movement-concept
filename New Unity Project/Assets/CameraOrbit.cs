using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 10f;

    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = false;

    public float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotateAroundPlayer) {
            Quaternion camTurnAngle = 
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            _cameraOffset = camTurnAngle * _cameraOffset;
        }
        Vector3 newPos = playerTransform.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (lookAtPlayer || rotateAroundPlayer) {
            transform.LookAt(playerTransform);
        }
   
    }
}
