using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class OrderManager : MonoBehaviour
{
    public bool isComplete, restart;
    public MenuManager menu;
    public List<Toggle> toggles;
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
        if (orders.ContainsKey(n) && !restart)
        {
            orders.Remove(n);
        }
        else if(!restart)
        {
            List<string> recipe = menu.getRecipe(n);
            orders.Add(n, recipe);
        }
       
    }

    public void Restart()
    {
        restart = true;
        orders.Clear();
        foreach (Toggle t in toggles)
        {
            t.isOn = false;
        }
        restart = false;
    }
}
