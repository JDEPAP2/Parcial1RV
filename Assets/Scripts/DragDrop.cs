using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Agregar libreria a llamar
using TMPro;
using Unity.VisualScripting;
//Agregar las librerias de las cuales vamos a heredar los metodos necesarios
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //La posicion de nuestro objeto a arrastrar
    private RectTransform rTransform;
    private GameObject copy, find;
    private bool repeat;
    public AudioSource audio; 

    private void Awake()
    {
        GameObject prnt = GameObject.Find("INGREDIENTS_LABEL");
        find = prnt.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if(copy.IsDestroyed() && repeat)
        {
            find.SetActive(false);
            setOpacity(1f);
            repeat = false;
        }
    }

    public void OnPointerDown(PointerEventData PeventData)
    {
    }

    public void OnBeginDrag(PointerEventData DeventData)
    {
        copy = Instantiate(gameObject);
        copy.transform.SetParent(transform.parent);
        copy.transform.position = transform.position;
        copy.transform.localScale = transform.localScale;
        repeat = true;
        rTransform = copy.GetComponent<RectTransform>();
        find.SetActive(true);
        find.GetComponentInChildren<TextMeshProUGUI>().text = handleText(name);
        setOpacity(0f);
        audio.Play();
    }

    public void OnEndDrag(PointerEventData EeventData)
    {       
        Destroy(copy);
    }

    public void OnDrag(PointerEventData ODeventData)
    {
        if (!copy.IsDestroyed())
        {
            rTransform.anchoredPosition += ODeventData.delta;
        }
    }

    public string handleText(string s)
    {
        s = s.Replace("_", " ");
        s = char.ToUpper(s[0]) + s.Substring(1);
        return s;
    }

    public void setOpacity(float number)
    {
        Color color = gameObject.GetComponent<Image>().color;
        color.a = number;
        gameObject.GetComponent<Image>().color = color;
    }

}
