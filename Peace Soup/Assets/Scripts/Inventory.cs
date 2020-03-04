using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> inventory = new List<GameObject>();
<<<<<<< HEAD
   
=======
    private Rigidbody player_body;
>>>>>>> Controller
    // Start is called before the first frame update
    void Start()
    {
      player_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
      if (collision.gameObject.tag == "turnip")
      {
        inventory.Add(collision.gameObject);
        Destroy(collision.gameObject);
      }
      else if(collision.gameObject.tag == "carrot")
      {
        inventory.Add(collision.gameObject);
        Destroy(collision.gameObject);
      }
      else if(collision.gameObject.tag == "pumpkin")
      {
        inventory.Add(collision.gameObject);
        Destroy(collision.gameObject);
      }
=======
      inventory.Add(collision.transform.gameObject);
      Destroy(collision.gameObject);
>>>>>>> Controller
    }
}