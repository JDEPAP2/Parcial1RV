using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QueueManager : MonoBehaviour
{
    public OrderManager orders;
    public List<string> active;
    public bool isChange = true, recipeList;

    private Dictionary<int, List<string>> inGameOrders;
    void Start()
    {

        inGameOrders = new Dictionary<int, List<string>>();

        foreach (KeyValuePair<int, List<string>> pair in inGameOrders)
        {
            inGameOrders.Add(pair.Key, pair.Value);
        }
    }

    private void Update()
    {
        if (inGameOrders != null && isChange)
        {
            isChange = false;
            bool first = true;
            foreach (int i in inGameOrders.Keys)
            {
                GameObject copy = Instantiate(gameObject.transform.GetChild(0).gameObject);
                copy.transform.SetParent(transform);
                copy.transform.position = transform.position;
                copy.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                copy.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = orders.menu.getNameRecipe(i);
                if (first)
                {
                    if (recipeList)
                    {

                    }
                }
                else{copy.transform.GetChild(3).gameObject.SetActive(true);}
                copy.SetActive(true);
                first = false;
            }
        }
    }
}
