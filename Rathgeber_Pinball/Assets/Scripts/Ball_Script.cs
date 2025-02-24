using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball_Script : MonoBehaviour
{
    Rigidbody2D rb;

    public float bump_force = 4f;
    public KeyCode launch_key;
    public int total_points = 0;
    public TextMeshProUGUI score_display;
    public TextMeshProUGUI game_over_text;

    private float launch_force_min = 5f;
    private float launch_force;
    private float launch_force_max = 8f;
    private Vector3 start_pos;
    private int lives = 3;
    private int bumper_points = 20;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        start_pos = this.transform.position;
        launch_force = launch_force_min;
        game_over_text.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -12)
        {
            if (lives > 1)
            {
                transform.position = start_pos;
                rb.linearVelocity = Vector2.zero;
                lives -= 1;
            }
            else
            {
                game_over_text.GetComponent<TextMeshProUGUI>().enabled = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                }
            }
        }
        //Debug.Log(total_points.ToString());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var obj = col.gameObject;
        if(obj.GetComponent<Renderer>().material.name == "Bumper"
            || obj.name == "Bumper")
        {
            rb.AddForce(col.contacts[0].normal * bump_force, ForceMode2D.Impulse);
            total_points += bumper_points;
            score_display.GetComponent<TMPro.TextMeshProUGUI>().text = total_points.ToString();
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
                launch_force += Time.deltaTime;
                //Debug.Log("Charging!");
            }
            else if (Input.GetKeyUp(launch_key))
            {
                rb.AddForce(Vector2.up * launch_force, ForceMode2D.Impulse);
                //Debug.Log("Launching!");
                launch_force = launch_force_min;
            }
        }
    }
}
