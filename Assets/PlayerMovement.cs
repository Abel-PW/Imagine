using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float xPos, yPos;

    [SerializeField]
    private float flySpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey("w")) rb.AddForce(transform.forward * flySpeed);

        if (Input.GetKey("s")) rb.AddForce(transform.forward * -flySpeed);

        if (Input.GetKey("a")) rb.AddForce(transform.right * -flySpeed);

        if (Input.GetKey("d")) rb.AddForce(transform.right * flySpeed);

    }
}
