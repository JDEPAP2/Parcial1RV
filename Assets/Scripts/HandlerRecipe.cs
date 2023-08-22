using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class HandlerRecipe : MonoBehaviour
{
    public OrderManager o;
    public TextMeshProUGUI text;
    public Image recipeImg;
    public List<string> titles;
    public List<Sprite> images;

    Dictionary<int, List<string>> orders;
    int index;
    GameObject past, next;

    // Update is called once per frame
    public void ChangeRecipe(bool isInverse) {

        if ( orders != null && orders.Count > 0)
        {
            if (isInverse){
                if(index > 0)
                {index--;}
            }
            else{
                if(index < orders.Count)
                {index++;}
            }
        }
        SetRecipe();
    }

    public void SetRecipe()
    {
        if (orders != null && orders.Count > 0)
        {
            text.text = o.menu.getNameRecipe(orders.Keys.ToList<int>()[index]);
            recipeImg.sprite = images[orders.Keys.ToList<int>()[index] - 1];

            if (orders.Count == 1){
                past.SetActive(false);
                next.SetActive(false);
            }else if(index == 0)
            {
                past.SetActive(false);
                next.SetActive(true);
            }
            else if(index == orders.Count-1)
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
    }
}
