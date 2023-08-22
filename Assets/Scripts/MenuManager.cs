using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public OrderManager orders;
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
                });
                break;
            case 2:
                elements.AddRange(new List<string>(){
                    "agua",
                    "zanahoria",
                    "cebolla_larga",
                    "cebolla_roja",
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
                    "toronja",
                    "cereza",
                    "limon",
                    "manzana",
                    "fresa",
                    "miel"
                });
                break;
        }
        return elements;
    }


    public string getNameRecipe(int n)
    {
        
        switch (n)
        {
            case 1:
                return "Huevos Rancheros";
            case 2:
                return "Sancocho Rosano";
            case 3:
                return "Hamburguesa Angus";
            case 4:
                return "Capuccino Late";
            case 5:
                return "Infusion Tropical";
        }

        return "";
    }

}
