using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float xPos, yPos;

    private Rigidbody rb;

    private Transform playerTransform;

    [SerializeField]
    private float flySpeed, mouseSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;

        if (Input.GetKey("w")) rb.AddForce(transform.forward * flySpeed);

        if (Input.GetKey("s")) rb.AddForce(transform.forward * -flySpeed);

        if (Input.GetKey("a")) rb.AddForce(transform.right * -flySpeed);

        if (Input.GetKey("d")) rb.AddForce(transform.right * flySpeed);

        if (Input.GetKey("space")) rb.AddForce(transform.up * flySpeed);

        if (Input.GetKey(KeyCode.LeftControl)) rb.AddForce(transform.up * -flySpeed);

        playerTransform.Rotate(Vector3.up * mouseX);

    }
}
