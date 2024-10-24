using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    [SerializeField]
    [Range(0.1f, 10f)]
    public float speed;
    [SerializeField]
    [Range(0.1f, 100f)]
    public float rotationSpeed;
    [SerializeField]
    private Vector2 moveInput;
    [SerializeField]
    public Camera cameraMain;
    private Vector3 mosPos;
    // Update is called once per frame
    [SerializeField]
    [Range(0.1f,360f)]
    public float offsetAngle;


    float hold;
    float timeCount;

    private void Start()
    {

        hold = speed;
       
    }
    private void FixedUpdate()
    {
        
            moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
     
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            hold = speed * 2;
        }
        else
        {
            hold = speed;
        }
        
        moveInput.Normalize();
        rb.velocity = (Vector2)transform.up * moveInput.y * hold;
        rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -moveInput.x * rotationSpeed));
        
        
     }
    
}