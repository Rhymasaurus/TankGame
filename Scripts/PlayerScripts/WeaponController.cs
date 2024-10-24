using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    [Range(0.1f, 100f)]
    public float projectileSpeed;
    [SerializeField]
    [Range(0.1f, 100f)]
    public float range;
    [SerializeField]
    [Range(0, 10)]
    public int dmg;
    [SerializeField]
    [Range(0f, 10f)]
    public float shootingSpeed;
    private float holdtime;
    [SerializeField]
    [Range(0.1f, 10f)]
    public float recoilPower;
    [SerializeField]
    public bool showGizmos = true;
    [SerializeField]
    public Color gizmosColor = Color.green;
   

   
    void Start()
    {
        holdtime = shootingSpeed;
   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1") && shootingSpeed < 0)
        {
            shootGun();
            shootingSpeed = holdtime;

            Vector2 direction = transform.position - transform.parent.position;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = -direction * recoilPower;
           
            
        }
        shootingSpeed -= Time.deltaTime;
      
    }
    public void shootGun()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.DrawWireSphere(transform.parent.parent.parent.position,range);
            Gizmos.color = gizmosColor;
        }
    }
}
