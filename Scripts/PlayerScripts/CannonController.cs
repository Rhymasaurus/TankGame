using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    private Camera main_cam;
    private Vector2 mosPos;
    [SerializeField]
    private float offsetangle;
    [SerializeField]
    public float rotationSpeed;
    void Start()
    {
        main_cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();        
    }


    private void FixedUpdate()
    {
        var rotationStep = rotationSpeed * Time.fixedDeltaTime;
        mosPos = main_cam.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mosPos.y - transform.position.y, mosPos.x - transform.position.x) * Mathf.Rad2Deg - (offsetangle + transform.rotation.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), -rotationStep).normalized;
    }
}
