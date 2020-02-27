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
    private GameObject weapon_to_pickup;
    public GameObject current_weapon = null;
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
        if(current_weapon != null)
        {
            //current_weapon.GetComponent<yellow_fire>().Fire();
            current_weapon = current_weapon.GetComponent<pickup_behavior>().Drop();
        }

        if (weapon_to_pickup != null)
        {
            if(Input.GetKeyDown(KeyCode.E) && current_weapon == null)
            {
                weapon_to_pickup.GetComponent<pickup_behavior>().PickUp(this.transform);
                current_weapon = weapon_to_pickup;
                //weapon_to_pickup.transform.parent = cam.transform;
                //weapon_to_pickup.transform.position = cam.transform.position + transform.right;
                //weapon_to_pickup.transform.rotation = transform.rotation;
                
                //weapon_to_pickup.transform.Rotate(total_rotation/2, 0, 0);
                //weapon_to_pickup.GetComponent<Rigidbody>().isKinematic = true;
                //current_weapon = weapon_to_pickup;
                //weapon_to_pickup = null;
            }

            else if (Input.GetKeyDown(KeyCode.E) && current_weapon != null)
            {
                current_weapon.transform.parent = null;
                current_weapon.transform.position = weapon_to_pickup.transform.position;
                current_weapon.transform.rotation = weapon_to_pickup.transform.rotation;
                current_weapon.GetComponent<Rigidbody>().isKinematic = false;
                current_weapon = null;

                weapon_to_pickup.transform.parent = cam.transform;
                weapon_to_pickup.transform.position = cam.transform.position + transform.right;
                //weapon_to_pickup.transform.Rotate(total_rotation/2, 0, 0);
                weapon_to_pickup.transform.rotation = cam.transform.rotation;
                weapon_to_pickup.GetComponent<Rigidbody>().isKinematic = true;
                current_weapon = weapon_to_pickup;
                weapon_to_pickup = null;
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
            if(current_weapon != null)
            {
                //current_weapon.transform.Rotate(vertical/2, 0, 0);
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
        
        if (other.gameObject.tag == "weapon_pickup")
        {
            Debug.Log("Can pick up");
            weapon_to_pickup = other.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "weapon_pickup")
        {
            Debug.Log("Can't pick up");
        }
    }

    public bool has_ball()
    {
        if(current_weapon != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
