using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    public float rot_speed;
    public GameObject ball;
    public float launch_force;

    private bool is_active = true;
    private float cooldown_timer = 0f;
    private float cooldown_duration = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + rot_speed);
        if (!is_active)
        {
            if (cooldown_timer < cooldown_duration)
            {
                cooldown_timer += Time.deltaTime;
            }
            else
            {
                cooldown_timer = 0;
                is_active = true;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var obj = col.gameObject;
        if (obj.name == "Ball" && is_active)
        {
            obj.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            obj.GetComponent<Rigidbody2D>().AddForce(this.transform.up * launch_force, ForceMode2D.Impulse);
            is_active = false;
        }
    }
}
