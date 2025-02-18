using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Flipper")
        {
            rb.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
        }
    }
}
