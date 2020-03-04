using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public GameObject cam;
    public float jump_height;
    private Rigidbody player_body;
    public float movement_speed;
    public bool is_grounded = false;
    public bool has_gun = false;
    private GameObject food_to_pickup;
    public GameObject current_food = null;
    private float total_rotation;
    // Start is called before the first frame update
    void Start()
    {
        player_body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal") * movement_speed,player_body.velocity.y,Input.GetAxisRaw("Vertical") * movement_speed);
        //transform.Translate(movement);
        Vector3 movement = (Input.GetAxisRaw("Horizontal") * movement_speed * transform.right) + (Input.GetAxisRaw("Vertical") * movement_speed * transform.forward);
        movement.y = player_body.velocity.y;
        player_body.velocity = movement;
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded == true)
        {
            //movement.y = jump_height * Physics.gravity.y * -1;
            player_body.AddForce(new Vector3(0, jump_height, 0), ForceMode.Impulse);
            is_grounded = false;
        }
        if(current_food != null)
        {
            //current_food.GetComponent<yellow_fire>().Fire();
            current_food = current_food.GetComponent<pickup_behavior>().Drop();
        }

        if (food_to_pickup != null)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                food_to_pickup.GetComponent<pickup_behavior>().PickUp(this.transform);
                //current_food = food_to_pickup;
                Debug.Log(food_to_pickup);
               
            }
        }

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        vertical = Mathf.Clamp(-vertical, -30, 60);
        //Debug.Log(cam.transform.rotation.x);
        if(cam.transform.rotation.x + Quaternion.Euler(vertical,0,0).x > Quaternion.Euler(-90,0,0).x && cam.transform.rotation.x + Quaternion.Euler(vertical, 0, 0).x < Quaternion.Euler(90, 0, 0).x)
        {
            total_rotation = total_rotation + vertical;
            cam.transform.Rotate(vertical, 0, 0);
            if(current_food != null)
            {
                //current_food.transform.Rotate(vertical/2, 0, 0);
            }
        }
        
        transform.Rotate(0, horizontal, 0);

    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts.Length > 0)
        {
            
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0)
                {
                    is_grounded = true;
                    //Debug.Log(collision.contacts.Length);
                    break;
                }
            }
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "food_pickup")
        {
            Debug.Log("Can pick up");
            food_to_pickup = other.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "food_pickup")
        {
            Debug.Log("Can't pick up");
        }
    }

    public bool has_ball()
    {
        if(current_food != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
