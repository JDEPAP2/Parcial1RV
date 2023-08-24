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

    public int getLenRecipe(int n)
    {

        switch (n)
        {
            case 1:
                return 3;
            case 2:
                return 5;
            case 3:
                return 6;
            case 4:
                return 4;
            case 5:
                return 7;
        }

        return 0;
    }


    public int getPriceRecipe(int n)
    {

        switch (n)
        {
            case 1:
                return 12000;
            case 2:
                return 20000;
            case 3:
                return 15000;
            case 4:
                return 7000;
            case 5:
                return 9000;
        }

        return 0;
    }


    public Dictionary<string,string> isInComponent(int n)
    {
        Dictionary<string, string> res = new();

        switch (n)
        {
            case 1:
                res.Add("salchicha", "cuchillo");
                res.Add("tocineta", "sarten");
                res.Add("huevo", "sarten");
                break;
            case 2:
                res.Add("agua", "microondas");
                res.Add("cebolla_roja", "cuchillo");
                res.Add("cebolla_larga", "sarten");
                res.Add("zanahoria", "microondas");
                res.Add("sal", "sarten");
                break;
            case 3:
                res.Add("pan", "sarten");
                res.Add("tocineta", "cuchillo");
                res.Add("tomate", "cuchillo");
                res.Add("lechuga", "cuchillo");
                res.Add("carne", "microondas");
                res.Add("queso", "sarten");
                break;
            case 4:
                res.Add("cafe", "cafetera");
                res.Add("leche", "microondas");
                res.Add("azucar", "cafetera");
                res.Add("crema_batida", "cafetera");
                break;
            case 5:
                res.Add("agua", "cafetera");
                res.Add("manzana", "cuchillo");
                res.Add("toronja", "cuchillo");
                res.Add("limon", "cuchillo");
                res.Add("fresa", "cuchillo");
                res.Add("miel", "cafetera");
                res.Add("cereza", "cafetera");
                break;
        }
        return res;
    }
}
