using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Agregar libreria a llamar
using TMPro;
//Agregar las librerias de las cuales vamos a heredar los metodos necesarios
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //La posicion de nuestro objeto a arrastrar
    private RectTransform rTransform;
    private GameObject copy, find;


    private void Awake()
    {
        GameObject prnt = GameObject.Find("INGREDIENTS_LABEL");
        find = prnt.transform.GetChild(0).gameObject;
    }

    public void OnPointerDown(PointerEventData PeventData)
    {
        copy = Instantiate(gameObject);
        copy.transform.SetParent(transform.parent);
        copy.transform.position = transform.position;
        copy.transform.localScale = transform.localScale;

        rTransform = copy.GetComponent<RectTransform>();
        find.SetActive(true);
        find.GetComponentInChildren<TextMeshProUGUI>().text = handleText(name);
    }

    public void OnBeginDrag(PointerEventData DeventData)
    {
        //Realizar acciones necesarias al arrastrar el objeto
    }

    public void OnEndDrag(PointerEventData EeventData)
    {
        //Realizar acciones necesarias al soltar el objeto
        find.SetActive(false);
        Destroy(copy);

    }

    public void OnDrag(PointerEventData ODeventData)
    {
        //Modificamos nuestro punto de anclaje de la imagen al punto donde se hizo click
        //y poder arrastrar el objeto
        rTransform.anchoredPosition += ODeventData.delta;

    }

    public string handleText(string s)
    {
        s = s.Replace("_", " ");
        s = char.ToUpper(s[0]) + s.Substring(1);
        return s;
    }


}
