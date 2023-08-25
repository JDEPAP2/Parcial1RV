using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FinalManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI cont, totalT;
    public List<Dictionary<int, List<string>>> totalList = new();
    public OrderManager o;
    public WinHandler win;
    private void OnEnable()
    {
        totalList = win.totalList ;
        float tt = 0;
        string cnt = "";
        foreach (Dictionary<int, List<string>> dic in totalList)
        {
            foreach (int i in dic.Keys)
            {
                tt += o.menu.getPriceRecipe(i);
                cnt += o.menu.getNameRecipe(i) + "\t" + o.menu.getPriceRecipe(i) + "\n";


                for (int k = 0; k < dic[i].Count; k++)
                {

                    if (k > o.menu.getLenRecipe(i) - 1)
                    {
                        cnt += dic[i][k] + "\t" + "4000" + "\n";
                    }
                    else
                    {
                        cnt += dic[i][k] + "\n";
                    }
                }

                if (dic[i].Count != o.menu.getLenRecipe(i))
                {
                    for (int j = o.menu.getLenRecipe(i); j < dic[i].Count; j++)
                    {
                        tt += 4000;
                    }
                }
            }
        }
        totalT.text = tt.ToString();
        cont.text = cnt;

    }

}
