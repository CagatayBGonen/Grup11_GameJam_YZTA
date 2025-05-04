using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObj;
    [SerializeField]
    private float followSpeed = 1f;
    [SerializeField]
    private float offsetX = 1f;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.right * followSpeed * Time.deltaTime);
    }
    //private void LateUpdate()
    //{
    //    //Vector3 cameraPosition = new Vector3(targetObj.position.x+offsetX, transform.position.y, -10f);
    //    //transform.position = Vector3.Slerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
        
    //}
}
