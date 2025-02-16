using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject linked_portal;
    public GameObject ball;

    private float portal_cooldown = 1f;
    private float cooldown_timer = 0f;
    private bool cooldown_active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown_active)
        {
            cooldown_timer += Time.deltaTime;
            if (cooldown_timer >= portal_cooldown)
            {
                cooldown_active = false;
                cooldown_timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!cooldown_active)
        {
            col.transform.position = linked_portal.transform.position;
            cooldown_active = true;
            linked_portal.GetComponent<PortalScript>().cooldown_active = true;
            Debug.Log("Teleporting!");
        }
        else
        {
            Debug.Log("Cooldown active!");
        }
    }
}
