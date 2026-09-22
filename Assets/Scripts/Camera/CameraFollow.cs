using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0f, 3f, -5f);
    [SerializeField] float followSmoothing = 8f;
    [SerializeField] bool lookAtTarget = true;
    [SerializeField] float lookAtHeightOffset = 1f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothing * Time.deltaTime);

        if (lookAtTarget)
        {
            transform.LookAt(target.position + Vector3.up * lookAtHeightOffset);
        }
    }
}