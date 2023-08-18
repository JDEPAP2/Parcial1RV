using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool isComplete, isOrdering;

    // Update is called once per frame
    void Update()
    {
        if (isComplete)
        {

        }else if (isOrdering)
        {

        }
    }

    public List<string> getRecipe(int n)
    {
        List<string> elements = new List<string>();
        switch (n)
        {
            case 1:
                elements.AddRange(new List<string>(){
                    "huevo",
                    "tocineta",
                    "salchicha",
                    "tomate",
                    "sal"
                });
                break;
            case 2:
                elements.AddRange(new List<string>(){
                    "agua",
                    "cilantro",
                    "zanahoria",
                    "tomate",
                    "cebolla",
                    "sal"
                });
                break;
            case 3:
                elements.AddRange(new List<string>(){
                    "pan",
                    "tocineta",
                    "carne",
                    "tomate",
                    "lechuga",
                    "queso"
                });
                break;
            case 4:
                elements.AddRange(new List<string>(){
                    "cafe",
                    "leche",
                    "crema_batida",
                    "azucar"
                });
                break;
            case 5:
                elements.AddRange(new List<string>(){
                    "agua",
                    "manzana",
                    "fresa",
                    "azucar"
                });
                break;
        }
        return elements;
    }

}
