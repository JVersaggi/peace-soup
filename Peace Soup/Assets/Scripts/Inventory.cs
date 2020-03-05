using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    private Rigidbody player_body;
    private bool has_water = false;

    public Text carrot_text;
    public Text turnip_text;
    public Text pumpkin_text;
    public Text water_get;
    public Text soup_text;

    int turnip_count = 0;
    int carrot_count = 0;
    int pumpkin_count = 0;

    private bool has_called = false;
    // Start is called before the first frame update
    void Start()
    {
      player_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnip_count + pumpkin_count + carrot_count >= 5 && has_water == true && has_called == false)
        {
            StartCoroutine(Fade());
            has_called = true;
        }
    }

    public void AddToInventory(GameObject item)
    {
        if (item.tag != "water_bucket" && inventory.Count < 5 && item.active == true)
        {
            inventory.Add(item);
            item.SetActive(false);
            if(item.tag == "carrot")
            {
                carrot_count += 1;
                carrot_text.text = carrot_count.ToString();
            }
            else if (item.tag == "turnip")
            {
                turnip_count += 1;
                turnip_text.text = turnip_count.ToString();
            }
            else if (item.tag == "pumpkin")
            {
                pumpkin_count += 1;
                pumpkin_text.text = pumpkin_count.ToString();
            }
        }
        else if (item.tag == "water_bucket")
        {
            has_water = true;
            Debug.Log("WATER");
            item.GetComponent<pickup_behavior>().enabled = false;
            water_get.gameObject.SetActive(true);
        }
    }

    public IEnumerator Fade()
    {
        soup_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        soup_text.gameObject.SetActive(false);
    }
}
