using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public bool isComplete;
    public OrderManager order;
    public List<string> ingredients;

    // Update is called once per frame
    void Update()
    {
        if (!isComplete)
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        if (ingredients.Contains(name))
        {
            Destroy(collision.gameObject);
            ingredients.Remove(name);
        }
        else
        {

        }
    }
}
