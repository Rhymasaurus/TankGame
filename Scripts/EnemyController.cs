using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Rigidbody2D rb;
    [SerializeField]
    [Range(0.1f, 20f)]
    public float speed;
    private GameObject player;
    [SerializeField]
    [Range(-1f, 20f)]
    float cooldown;
    [SerializeField]
    int dmg;
    [SerializeField]
    public bool debuging = false;

    private float hold;
    void Start()
    {
       player =  GameObject.FindWithTag("Player");
        hold = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.position - player.transform.position;
        transform.up = direction;
        direction.Normalize();
       
        rb.velocity += (-direction * speed);
        if (debuging)
        {
            Debug.Log(direction);
        }
        cooldown -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(cooldown<0 && collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<HealthController>().hp -= dmg;
            cooldown = hold;
            if (debuging)
                Debug.Log($"Player damaged by {gameObject} and has taken {dmg} amount of dmg");
        }
    }

}
