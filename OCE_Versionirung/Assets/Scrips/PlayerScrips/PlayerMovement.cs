using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController charCon;

    private Vector3 movDir = Vector3.zero;
    [SerializeField]
    private float movementSpeed = 10;
    [SerializeField]
    private float jumpPower = 8;
    [SerializeField]
    private float gravity = 20.0f;
    [SerializeField]
    private Transform camara;
    [SerializeField]
    private float xAxis;
    [SerializeField]
    private float yAxis;
    [SerializeField]
    private float xSpeed = 60;
    [SerializeField]
    private float ySpeed = 60;
    [SerializeField]
    private Vector2 xMinMax = new Vector2(-35, 35);
    [SerializeField]
    private float sprintModifier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();

        MovePlayer();
    }

    public void MovePlayer()
    {
        if (charCon.isGrounded)
        {
            movDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            movDir = transform.TransformDirection(movDir);
            movDir *= (Input.GetKey(KeyCode.LeftShift)) ? movementSpeed * sprintModifier : movementSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                movDir.y += jumpPower;
            }
        }
        movDir.y -= gravity * Time.deltaTime;
        charCon.Move(movDir * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        yAxis += Input.GetAxis("Mouse X") * ySpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, yAxis, 0);

        xAxis -= Input.GetAxis("Mouse Y") * xSpeed * Time.deltaTime;
        xAxis = Mathf.Clamp(xAxis, xMinMax.x, xMinMax.y);
        camara.transform.localEulerAngles = new Vector3(xAxis, 0, 0);
    }




}
