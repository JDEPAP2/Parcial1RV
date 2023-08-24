using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class handlerAdd : MonoBehaviour
{
    public OrderManager o;
    public TextMeshProUGUI text;
    public Image recipeImg;
    public List<Sprite> images;

    Dictionary<int, List<string>> orders;
    int index;
    GameObject past, next;
    bool inCode;

    public void UpdateList()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("add");
        foreach (GameObject o in obj)
        {
            Toggle t = o.GetComponentInChildren<Toggle>();
            if (t != null)
            {
                inCode = true;
                t.isOn = false;
                t.interactable = true;
                inCode = false;
            }
        }

        List<string> active = orders[orders.Keys.ToList<int>()[index]];

        for(int i = 0; i < active.Count; i++)
        {
            foreach (GameObject ob in obj)
            {
                Debug.Log("entro");
                Toggle t = ob.GetComponentInChildren<Toggle>();
                if (ob.name == ("add" + active[i]) && t != null)
                {
                    inCode = true;
                    if (i < o.menu.getLenRecipe(orders.Keys.ToList<int>()[index]))
                    {
                        t.interactable = false;
                    }
                    else
                    {
                        t.isOn = true;
                    }
                    inCode = false;
                }
            }
        }

    }

    // Update is called once per frame
    public void ChangeRecipe(bool isInverse)
    {

        if (orders != null && orders.Count > 0)
        {
            if (isInverse)
            {
                if (index > 0)
                { index--; }
            }
            else
            {
                if (index < orders.Count)
                { index++; }
            }
        }
        SetRecipe();
    }

    public void SetRecipe()
    {
        if (orders != null && orders.Count > 0)
        {
            text.text = o.menu.getNameRecipe(orders.Keys.ToList<int>()[index]);
            if (recipeImg != null)
            {
                recipeImg.sprite = images[orders.Keys.ToList<int>()[index] - 1];
            }

            if (orders.Count == 1)
            {
                past.SetActive(false);
                next.SetActive(false);
            }
            else if (index == 0)
            {
                past.SetActive(false);
                next.SetActive(true);
            }
            else if (index == orders.Count - 1)
            {
                past.SetActive(true);
                next.SetActive(false);
            }
            else
            {
                past.SetActive(true);
                next.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        orders = o.orders;
        index = 0;
        if (past == null)
        {
            past = GameObject.Find("past");
            next = GameObject.Find("next");
        }
        SetRecipe();
        UpdateList();
    }

    public void AddItem(string name)
    {
        if (!inCode)
        {
            Debug.Log("22222222");
            if (orders[orders.Keys.ToList<int>()[index]].Contains(name))
            {
                orders[orders.Keys.ToList<int>()[index]].Remove(name);
            }
            else
            {
                orders[orders.Keys.ToList<int>()[index]].Add(name);
            }
        }
        inCode = false;

    }

}
