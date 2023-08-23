using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerIngredient : MonoBehaviour
{
    // Start is called before the first frame update
    public QueueManager queue;
    public MenuManager menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (menu.isInComponent(queue.index)[collision.name] == name)
        {
            queue.activeList.Remove(collision.name);
            Destroy(collision.gameObject);
        }
    }
}
