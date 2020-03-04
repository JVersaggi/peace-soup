using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> inventory = new List<GameObject>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
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
    }
}