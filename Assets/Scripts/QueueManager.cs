using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QueueManager : MonoBehaviour
{
    public OrderManager orders;
    public GameObject obj;
    public bool isChange = true;

    private Dictionary<int, List<string>> inGameOrders;
    void Start()
    {
        inGameOrders = orders.orders;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChange)
        {
            isChange = false;
            foreach (int i in inGameOrders.Keys)
            {
                GameObject copy = Instantiate(gameObject.transform.GetChild(0).gameObject);
                copy.transform.SetParent(transform);
                copy.transform.position = transform.position;
                copy.transform.localScale = transform.localScale;

                copy.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = orders.menu.getNameRecipe(i+1);
                copy.SetActive(true);
            }
        }
    }
}
