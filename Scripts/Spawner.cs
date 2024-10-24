using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    [Range(0.1f, 20f)]
    public float spawnRate;
    [SerializeField]
    public GameObject spawnObject;
    private float hold;
    private void Start()
    {
        hold = spawnRate;
    }
    private void Update()
    {
        spawnRate -= Time.deltaTime;
        if (spawnRate < 0)
        {
            Instantiate(spawnObject, transform.position, transform.rotation);
            spawnRate = hold;
        }
    }
}
