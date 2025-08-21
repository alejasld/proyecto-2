using UnityEngine;
using System.Collections.Generic;

public class PilaTexto : MonoBehaviour
{
    Stack<string> pilaNombres = new Stack<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PushString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushString()
    {
        pilaNombres.Push("David");
        pilaNombres.Push("Maria");
        pilaNombres.Push("Pedro");
    }

    public void PeekButton()
    {
        if (pilaNombres.Count > 0)
        {
            Debug.Log("El elemento del tope es " + pilaNombres.Peek());
        }
        else
        {
            Debug.Log("La pila esta Vacia!! ");
        }
    }

    public void PopButton()
    {
        if (pilaNombres.Count>0)
        {
            Debug.Log("El elemento quitado es " + pilaNombres.Pop());
        }

        else
        {
            Debug.Log("No puedo desapilar, la pila esta Vacia!! ");
        }
    }

    public void ClearString()
    {
        pilaNombres.Clear();
        Debug.Log("Pila Vacia! ");
    }
}
