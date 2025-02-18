
using UnityEngine;

public class Flipper_Script : MonoBehaviour
{
    public float target_angle_abs;
    public float swing_speed;
    public string in_axis;
    public GameObject col;

    private float dir;
    private float rot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir = -this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        //COLLISIONS ARE JANKY, USE TORQUE INSTEAD OF SETTING ROTATION

        rot = this.transform.rotation.z;

        if (Input.GetAxis(in_axis) > 0)
        {
            if (rot < target_angle_abs)
            {
                transform.Rotate(Vector3.forward * swing_speed * Time.deltaTime * dir);
                //col.GetComponent<Rigidbody2D>().AddTorque(swing_speed * dir * 10000, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (Mathf.Abs(rot) > 0.01)
            {
                transform.Rotate(Vector3.forward * swing_speed * Time.deltaTime * -dir);
            }
        }
    }
}
