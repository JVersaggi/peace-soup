using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoupCombos : MonoBehaviour
{

    private string[] turnip_array = { "", "Raw ", "Wild ", "Fresh ", "Succulent ", "Turnip " };
    private string[] carrot_array = {"", "Plain ", "Juicy ", "Hearty ", "Creamy ", "Carrot "};
    private string[] pumpkin_array = {"", "Pungent ", "Ripe ", "Full ", "Autumnal ", "Pumpkin "};

    public Text soup_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // sweet and sweet
        // sweet and sour
        // sweet and bland
        // sour and sour
        // sour and bland
        // bland and bland
    }

    public void Interact(GameObject player)
    {
        List<GameObject> inventory = player.GetComponent<Inventory>().inventory;
        int turnip_count = 0;
        int carrot_count = 0;
        int pumpkin_count = 0;
        foreach(GameObject item in inventory)
        {
            if(item.tag == "turnip")
            {
                turnip_count += 1;
            }
            else if(item.tag == "carrot")
            {
                carrot_count += 1;
            }
            else if(item.tag == "pumpkin")
            {
                pumpkin_count += 1;
            }
        }
        string response = turnip_array[turnip_count] + carrot_array[carrot_count] + pumpkin_array[pumpkin_count] + "Soup";
        Debug.Log(response);
        soup_text.text = response;
        StartCoroutine(Fade());

    }

    public IEnumerator Fade()
    {
        soup_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        soup_text.gameObject.SetActive(false);
    }
}
