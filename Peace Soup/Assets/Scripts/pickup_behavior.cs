using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_behavior : MonoBehaviour
{
    public Transform adopted_parent = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(Transform parent_to_be)
    {
        if (adopted_parent == null)
        {
            Debug.Log(transform.tag);
            parent_to_be.gameObject.GetComponent<Inventory>().AddToInventory(this.gameObject);
        }
        

    }

    public GameObject Drop()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            adopted_parent = null;
            this.GetComponent<Rigidbody>().isKinematic = false;
            return null;
        }
        else
        {
            return this.gameObject;
        }
    }

    public void Fire()
    {

    }
}
