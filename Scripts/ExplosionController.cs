using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float lifetime;
    [SerializeField]
    [Range(0.1f, 10f)]
    public float explosionRadius;
    [SerializeField]
    [Range(0.1f, 100f)]
    public float explosivePowerMulti;
    [SerializeField]
    private Collider2D[] inExplosion = null;

    [SerializeField]
    public bool showingGizmos;
    public Color gizmosColor;
    // Update is called once per frame
 
    public void explode()
    {
        inExplosion = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D overlap in inExplosion)
        {
            Rigidbody2D overlapRigidbody = overlap.GetComponent<Rigidbody2D>();
            if(overlap.GetComponent<HealthController>() != null)
            {
              overlap.GetComponent<HealthController>().hp -= GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponController>().dmg;
            }
            Vector2 distanceVector = overlap.transform.position - transform.position;
            if(distanceVector.magnitude > 0)
            {
                float explosivePower = explosivePowerMulti / distanceVector.magnitude;
                overlapRigidbody.AddForce(distanceVector.normalized * explosivePower);
            }
        }
    }
    private void Start()
    {
        explode();

        transform.localScale += new Vector3(explosionRadius, explosionRadius,0);
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
          
            Destroy(gameObject);
        }
     
    }
    private void OnDrawGizmos()
    {
        
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        
    }

}
