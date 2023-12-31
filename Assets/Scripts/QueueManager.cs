using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QueueManager : MonoBehaviour
{
    public OrderManager orders;
    public List<string> activeList;
    public bool isChange = true, recipeList;
    public int index = 0;
    public GameObject closed;

    private Dictionary<int, List<string>> inGameOrders;

    void Start()
    {
        inGameOrders = new Dictionary<int, List<string>>();

        foreach (KeyValuePair<int, List<string>> pair in orders.orders)
        {
            inGameOrders.Add(pair.Key,  pair.Value.ConvertAll(val => val));
        }

        if(inGameOrders.Count > 0)
        {
            index = inGameOrders.Keys.ToList<int>()[0];
        }
    }

    private void OnEnable()
    {
        inGameOrders = new Dictionary<int, List<string>>();

        foreach (KeyValuePair<int, List<string>> pair in orders.orders)
        {
            inGameOrders.Add(pair.Key, pair.Value.ConvertAll(val => val));
        }

        if (inGameOrders.Count > 0)
        {
            index = inGameOrders.Keys.ToList<int>()[0];
        }
    }

    private void Update()
    {
        if ((inGameOrders != null && inGameOrders.Count > 0 && isChange))
        {
            isChange = false;
            bool first = true;
            int count = gameObject.transform.childCount;
            index = inGameOrders.Keys.ToList<int>()[0];

            if (activeList == null || activeList.Count == 0)
            {activeList = inGameOrders.First().Value;}
            else
            {inGameOrders[inGameOrders.Keys.ToList<int>()[0]] = activeList;}

            for (int i = 1; i < count; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            foreach (int i in inGameOrders.Keys)
            {
                GameObject copy = Instantiate(gameObject.transform.GetChild(0).gameObject);
                copy.transform.SetParent(transform);
                copy.transform.position = transform.position;
                copy.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

                copy.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = orders.menu.getNameRecipe(i);
                if (first)
                {
                    float res = (float) activeList.Count / orders.orders[i].Count;
                    copy.transform.GetChild(2).GetComponent<Image>().fillAmount = 1 - res;
                    if (res == 0)
                    {
                        copy.transform.GetChild(2).GetComponent<Button>().interactable = true;
                    }
                    Debug.Log($"{activeList.Count} y {orders.orders[i].Count} y {res}");
                }
                else{copy.transform.GetChild(3).gameObject.SetActive(true);}
                copy.SetActive(true);
                first = false;
            }
        }else if(gameObject.transform.childCount == 2 && isChange)
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }
    }

    public void RemoveObject()
    {
        inGameOrders.Remove(inGameOrders.Keys.ToList<int>()[0]);

        if(inGameOrders.Count == 0)
        {
            orders.menu.isComplete = true;
            closed.SetActive(true);
        }
        isChange = true;
        recipeList = true;
    }
}
