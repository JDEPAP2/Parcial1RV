using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class HandlerIngredient : MonoBehaviour
{
    // Start is called before the first frame update
    public QueueManager queue;
    public MenuManager menu;
    private List<string> ingredients = new();

    private void Update()
    {
        if (queue.recipeList)
        {
            ingredients.Clear();
            queue.recipeList = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string ObjName = collision.name.Replace("(Clone)", "");
        if ((menu.isInComponent(queue.index).ContainsKey(ObjName) && menu.isInComponent(queue.index)[ObjName] == name && !ingredients.Contains(ObjName))||
            (!menu.isInComponent(queue.index).ContainsKey(ObjName) && !ingredients.Contains(ObjName) && queue.orders.orders[queue.orders.orders.Keys.ToList<int>()[0]].Contains(ObjName)))
        {
            ingredients.Add(ObjName);
            queue.activeList.Remove(ObjName);
            queue.isChange = true;
            Destroy(collision.gameObject);

        }
    }
}
