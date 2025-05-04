using UnityEngine;

public class CleanerFollower : MonoBehaviour
{
   public Transform player;
    public float followDistance = 30f;

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPos = player.position - new Vector3(followDistance, 0, 0);
            transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);

        }
    }
}
