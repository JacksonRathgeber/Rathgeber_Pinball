using UnityEngine;

public class PuncherScript : MonoBehaviour
{
    //public string in_axis;
    public GameObject ball;
    public GameObject fist;
    public KeyCode input_key;
    public bool is_on_right;

    private float punch_force = 20f;
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
        this.transform.right = ball.transform.position - this.transform.position;

        if (Input.GetKey(input_key))
        {
            //fist.transform.position = Vector3.Lerp(fist.transform.position, this.transform.position + this.transform.right * 2, 0.3f);
            fist.GetComponent<Rigidbody2D>().AddForce(this.transform.right * punch_force, ForceMode2D.Impulse);
        }
        else if (Vector3.Distance(fist.transform.position, this.transform.position)>0.1)
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
