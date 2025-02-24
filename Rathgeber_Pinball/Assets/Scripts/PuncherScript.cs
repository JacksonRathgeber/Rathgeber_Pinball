using UnityEngine;

public class PuncherScript : MonoBehaviour
{
    //public string in_axis;
    public GameObject ball;
    public GameObject fist;
    public KeyCode input_key;
    public bool is_on_right;

    private float punch_force = 40f;
    private int side_int;
    private Vector3 fist_pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        side_int = is_on_right ? -1 : 1;
        fist_pos = fist.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(ball.transform.position);
        float rot = transform.eulerAngles.x;
        Vector3 rot_vect = new Vector3(0, 0, -rot);
        transform.eulerAngles = rot_vect;
        fist.transform.eulerAngles = rot_vect;

        if (Input.GetKeyDown(input_key))
        {
            //fist.transform.position = Vector3.Lerp(fist.transform.position, this.transform.position + this.transform.right * 2, 0.3f);
            fist.GetComponent<Rigidbody2D>().AddForce(this.transform.right * punch_force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(input_key))
        {
            //fist.transform.position = fist_pos;
            fist.GetComponent<Rigidbody2D>().AddForce(-this.transform.right * punch_force, ForceMode2D.Impulse);
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
