using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 2f;
    public float repeatWidth = 20f; // tekrarlancak Sprite geniþliði 
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
