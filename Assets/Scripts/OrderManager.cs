using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public bool isComplete;
    public MenuManager menu;
    public Dictionary<int, List<string>> orders;
    //public List<List<string>> orders;

    void Start()
    {
        orders = new Dictionary<int, List<string>>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
        foreach (List<string> e in orders.Values)
        {
            string mss = "";
            foreach ( string l in e)
            {
                mss += l + ",";
            }
            Debug.Log("Hay:" + mss + "\n");
        }
    }
}
