using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObj;
    [SerializeField]
    private float followSpeed = 1f;
    [SerializeField]
    private float offsetY = 1f;
    [SerializeField]
    private float offsetX = 1f;

    private void LateUpdate()
    {
        Vector3 cameraPosition = new Vector3(targetObj.position.x+offsetX, targetObj.position.y + offsetY, -10f);
        transform.position = Vector3.Slerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }
}
