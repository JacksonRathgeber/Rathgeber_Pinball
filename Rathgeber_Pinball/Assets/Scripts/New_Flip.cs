using UnityEngine;

public class New_Flip : MonoBehaviour
{
    public KeyCode input_key;
    public bool is_left;
    
    private float flip_strength = 20f;
    
    Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input_key))
        {
            if (is_left) rb.AddTorque(flip_strength, ForceMode2D.Impulse);
            else rb.AddTorque(-flip_strength, ForceMode2D.Impulse);
        }
        /*
        else if (Input.GetKeyUp(input_key))
        {
            if (is_left) rb.AddTorque(flip_strength, ForceMode2D.Impulse);
            else rb.AddTorque(-flip_strength, ForceMode2D.Impulse);
        }
        */
    }
}
