using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController14 : MonoBehaviour
{
    int speed = 15;
    int jumpForce = 25;
    int gravityModifier = 5;
    Rigidbody rb;
    bool Grounded;
    bool onStartCube;
    bool onMoveCube;
    bool onHPlane;
    bool onVPlane;
    public GameObject Player;
    public GameObject MoveCube;
    // Start is called before the first frame update
    void Start()
    {
        onHPlane = false;
        onVPlane = false;
        onStartCube = true;
        onMoveCube = false;
        Grounded = true;
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        PlayerJump();
    }
    private void PlayerJump()
	{
        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
		{
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Grounded = false;
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("StartCube"))
		{
            Grounded = true;
            onStartCube = true;
            print("Grounded on Start Cube");
		}
        else if (collision.gameObject.CompareTag("MoveCube"))
		{
            Grounded = true;
            onMoveCube = true;
            print("Grounded on Moving Cube");
            Player.transform.SetParent(MoveCube.transform);
		}
        else if (collision.gameObject.CompareTag("HPlane"))
		{
            Grounded = true;
            onHPlane = true;
            print("Grounded on Horizontal Plane");
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("StartCube"))
		{
            Grounded = false;
            onStartCube = false;
            print("Ungrounded");
		}
        else if (collision.gameObject.CompareTag("MoveCube"))
		{
            Grounded = false;
            onMoveCube = false;
            print("Ungrounded");
		}
        else if (collision.gameObject.CompareTag("HPlane"))
		{
            Grounded = false;
            onHPlane = false;
            print("Ungrounded");
		}
	}
}
