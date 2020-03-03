using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempCharacter : MonoBehaviour
{

    CharacterController playChar;
    GameObject virtualNeck; //allowing up to rotate the camera without tilting
    public float speed = 5;
    public float mouseSensitivity = 100;
    public float gravity;
    public float jumpStr;
    public float yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Hi.");
        playChar = GetComponent<CharacterController>();
        virtualNeck = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement Controls
        if (Input.GetKey(KeyCode.W))
        {
            playChar.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playChar.Move(transform.forward * -1.0f * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playChar.Move(transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playChar.Move(transform.right * -1.0f * speed * Time.deltaTime);
        }

        // getting the mouse location without using evil Quaternions
        if (Input.GetAxis("Mouse X") != 0.0f)
        {
            transform.Rotate(transform.up * mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse X"));
        }

        if (Input.GetAxis("Mouse Y") != 0.0f)
        {
            virtualNeck.transform.Rotate(-Vector3.right * mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse Y"));
        }

        //Gravity Code
        yVelocity = yVelocity + (gravity * Time.deltaTime);
        playChar.Move(Vector3.up * yVelocity);

        if (Input.GetKey(KeyCode.Space))
        {
            yVelocity = jumpStr;
        }
    }

}
