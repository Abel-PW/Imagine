using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float xRotation;
    float yRotation;

    private Rigidbody rb, camRb;

    private Transform playerTransform;

    [SerializeField]
    private float flySpeed, mouseSpeed;

    [SerializeField]
    private Camera playerCam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camRb = playerCam.GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;

        FlyBob();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);



        if (Input.GetKey("w")) rb.AddForce(transform.forward * flySpeed);

        if (Input.GetKey("s")) rb.AddForce(transform.forward * -flySpeed);

        if (Input.GetKey("a")) rb.AddForce(transform.right * -flySpeed);

        if (Input.GetKey("d")) rb.AddForce(transform.right * flySpeed);

        if (Input.GetKey("space")) rb.AddForce(transform.up * flySpeed);

        if (Input.GetKey(KeyCode.LeftControl)) rb.AddForce(transform.up * -flySpeed);

    }


    IEnumerator FlyBob()
    {
        camRb.AddForce(transform.up * 50, ForceMode.Impulse);

        yield return new WaitForSeconds(1);

        FlyBob();
    }
}
