using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> inventory = new List<GameObject>();
    private Rigidbody player_body;
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
      inventory.Add(collision.GameObject);
      Destroy(collision.gameObject);
    }
}
