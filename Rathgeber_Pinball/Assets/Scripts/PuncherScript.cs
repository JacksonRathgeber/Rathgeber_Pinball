using UnityEngine;

public class PuncherScript : MonoBehaviour
{
    //public string in_axis;
    public GameObject ball;
    public GameObject fist;
    public KeyCode input_key;

    private float punch_force = 6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ball.transform.position);
        float rot = transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(0, 0, -rot);
        fist.transform.eulerAngles = new Vector3(0, 0, -rot);

        if (Input.GetKeyDown(input_key))
        {
            fist.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, punch_force), ForceMode2D.Impulse);
        }
        else if (Input.GetKeyUp(input_key))
        {
            fist.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -punch_force), ForceMode2D.Impulse);
        }
    }

    /*
    void onTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Detected!");
        if (col.gameObject.name == "Ball")
        {
            Debug.Log("Punching!");
            fist.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
    }
    */
}
