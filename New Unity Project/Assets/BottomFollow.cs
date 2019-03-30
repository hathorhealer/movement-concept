using UnityEngine;

public class BottomFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }

}
