using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(0.1f, 100f)]
    public float projectileSpeed;
    [SerializeField]
    [Range(0.1f, 100f)]
    public float range;
    [SerializeField]
    [Range(0.1f,10f)]
    public float dmg;

    [SerializeField]

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
