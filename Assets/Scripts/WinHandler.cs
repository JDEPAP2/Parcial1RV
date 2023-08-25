using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class WinHandler : MonoBehaviour
{
    public TextMeshProUGUI total, cont;
    public GameObject item, finish, content;
    public List<Sprite> images;
    public List<Dictionary<int, List<string>>> totalList = new();
    public OrderManager o;
    private void OnEnable()
    {
        
        for(int i = 1; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        Debug.Log(o.orders.Keys);
        float tot = 0;
        foreach (int i in o.orders.Keys)
        {
            tot += o.menu.getPriceRecipe(i);

            GameObject copy = Instantiate(item);
            copy.transform.SetParent(item.transform.parent.transform);
            copy.transform.position = item.transform.position;
            copy.transform.localScale = item.transform.localScale;

            copy.transform.GetChild(0).GetComponent<Image>().sprite = images[i - 1];
            copy.GetComponentInChildren<TextMeshProUGUI>().text = o.menu.getNameRecipe(i);
            copy.SetActive(true);

            Debug.Log(o.orders[i].Count);
            Debug.Log(o.menu.getLenRecipe(i));
            if (o.orders[i].Count != o.menu.getLenRecipe(i)) {
                for(int j = o.menu.getLenRecipe(i); j < o.orders[i].Count; j++)
                {
                    tot += 4000;
                }
            }
        }
        total.text = tot.ToString();
        totalList.Add(o.orders);

     }

    public void Finish()
    {
        finish.SetActive(true);
    }
}
