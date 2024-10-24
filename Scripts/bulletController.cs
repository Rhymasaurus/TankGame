using System;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    private int dmg;
    private float projectileSpeed;
    private float range;
    [SerializeField]
    public GameObject explosionPrefab;
    void Start()
    {
        dmg = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponController>().dmg;
        projectileSpeed = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponController>().projectileSpeed;
        range = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponController>().range;
        
        

    }

    System.Collections.IEnumerator animationRoutine(float duration)
    {
        Debug.Log($"time Started {Time.time}, watied for {duration}");
        yield return new WaitForSeconds(duration);
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * projectileSpeed;
        if (findDistance(GameObject.FindGameObjectWithTag("Player").transform.position) > range)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthController>().hp -= dmg;
            Instantiate(explosionPrefab, transform.position,transform.rotation);
            Destroy(gameObject);
        }

    }
        
    public float findDistance(Vector2 point)
    {
        return Mathf.Sqrt(Mathf.Pow(point.x - transform.position.x, 2) + Mathf.Pow(point.y - transform.position.y, 2));
    }
    
    
}
