using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public List<GameObject> active;
    public bool adds = false;
    public GameObject addPanel;

    // Update is called once per frame
    public void Handle()
    {
        if (adds)
        {
            addPanel.SetActive(true);
        }
        else
        {
            foreach(GameObject g in active)
            {
                g.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }

    public void State()
    {
        adds = !adds;
    }
}
