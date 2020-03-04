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
            adopted_parent = parent_to_be;
            this.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane * 7));
            Debug.Log(transform.tag);
        }
        else
        {
            if (adopted_parent.tag != "Player")
            {
                adopted_parent = parent_to_be;
                this.GetComponent<Rigidbody>().isKinematic = true;
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane * 7));
            }
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
