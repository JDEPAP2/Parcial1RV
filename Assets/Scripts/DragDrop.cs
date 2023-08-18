using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Agregar libreria a llamar

//Agregar las librerias de las cuales vamos a heredar los metodos necesarios
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //La posicion de nuestro objeto a arrastrar
    private RectTransform rTransform;

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
    }

    //
    public void OnPointerDown(PointerEventData PeventData)
    {
        //Realizar acciones necesarias al clickear o seleccionar el objeto
    }

    public void OnBeginDrag(PointerEventData DeventData)
    {
        //Realizar acciones necesarias al arrastrar el objeto
    }

    public void OnEndDrag(PointerEventData EeventData)
    {
        //Realizar acciones necesarias al soltar el objeto
    }

    public void OnDrag(PointerEventData ODeventData)
    {
        //Modificamos nuestro punto de anclaje de la imagen al punto donde se hizo click
        //y poder arrastrar el objeto
        rTransform.anchoredPosition += ODeventData.delta;
    }


}
