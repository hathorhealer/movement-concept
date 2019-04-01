using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1f)]
    public float smoothFactor = 1f;

    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = false;

    public float rotationSpeed = 5.0f;

    Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame

    void Update()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngleHori =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            Quaternion camTurnAngleVerti =
                Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotationSpeed, transform.right*-1);
            _cameraOffset = camTurnAngleHori * _cameraOffset;
            _cameraOffset = camTurnAngleVerti * _cameraOffset;

        }

        playerPos = playerTransform.position;
        
    }
    void FixedUpdate()
    {
        Vector3 newPos = playerPos + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (lookAtPlayer || rotateAroundPlayer) {
            transform.LookAt(playerTransform);
        }
   
    }
}
