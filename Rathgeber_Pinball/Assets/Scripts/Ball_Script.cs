using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -12)
        {
            transform.position = new Vector3(-12, 2.5f, 0);
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
