using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public bool isComplete;
    public MenuManager menu;
    public Dictionary<int, List<string>> orders;
    public GameObject start;
    //public List<List<string>> orders;

    void Awake()
    {
        orders = new Dictionary<int, List<string>>();
    }

    // Update is called once per frame
    void Update()
    {
        if(orders.Count > 0)
        {
            start.SetActive(true);
        }else
        {
            start.SetActive(false);
        }
    }

    public void HandleRecipe(int n)
    {
        if (orders.ContainsKey(n))
        {
            orders.Remove(n);
        }
        else
        {
            List<string> recipe = menu.getRecipe(n);
            orders.Add(n, recipe);
        }
       
    }
}
