using UnityEngine;

public class PuncherScript : MonoBehaviour
{
    //public string in_axis;
    public GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetAxis(in_axis) > 0) { }
        transform.LookAt(ball.transform.position);
        float rot = transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(0, 0, -rot);
    }
}
