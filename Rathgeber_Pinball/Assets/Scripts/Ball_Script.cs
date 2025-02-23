using UnityEngine;

public class Ball_Script : MonoBehaviour
{
    Rigidbody2D rb;

    public float bump_force = 6f;
    public KeyCode launch_key;

    private float launch_force = 0f;
    private float launch_force_max = 20f;
    private Vector3 start_pos;
    private int lives = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -12)
        {
            if (lives > 0)
            {
                transform.position = start_pos;
                rb.linearVelocity = Vector2.zero;
                lives -= 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var obj = col.gameObject;
        if(obj.GetComponent<Renderer>().material.name == "Bumper"
            || obj.name == "Bumper")
        {
            rb.AddForce(col.contacts[0].normal * bump_force, ForceMode2D.Impulse);
            //Debug.Log("Boing!");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        var obj = col.gameObject;
        if(obj.name == "Ball Launcher")
        {
            if (Input.GetKey(launch_key) && launch_force < launch_force_max)
            {
                launch_force += Time.deltaTime * 2;
                //Debug.Log("Charging!");
            }
            else if (Input.GetKeyUp(launch_key))
            {
                rb.AddForce(Vector2.up * launch_force, ForceMode2D.Impulse);
                //Debug.Log("Launching!");
                launch_force = 0;
            }
        }
    }
}
