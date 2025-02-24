using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public GameObject ball;
    public TextMeshProUGUI score_display;

    private int points_awarded = 50;
    private bool is_active = true;
    private float cooldown_duration = 1f;
    private float cooldown_counter = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_active)
        {
            if (cooldown_duration > cooldown_counter)
            {
                cooldown_counter += Time.deltaTime;
            }
            else
            {
                cooldown_counter = 0;
                is_active = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (is_active && col.gameObject.name == "Ball")
        {
            int total_points = ball.GetComponent<Ball_Script>().total_points;
            total_points += points_awarded;
            score_display.GetComponent<TMPro.TextMeshProUGUI>().text = total_points.ToString();
            is_active = false;
        }
    }
}
