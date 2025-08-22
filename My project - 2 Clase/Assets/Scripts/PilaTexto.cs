using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PilaTexto : MonoBehaviour
{
    Stack<string> pilaNombres = new Stack<string>();
    [SerializeField] private TMP_Text textoTMP;  
    [SerializeField] private TMP_Text textoPila;
    [SerializeField] private TMP_InputField inputNombre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoTMP.text = "Ingrese un nombre en el campo para agregarlo a la pila.";
        ActualizarTextoPila();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushString()
    {
        string nombre = inputNombre.text;

        if (!string.IsNullOrEmpty(nombre)) // Evita añadir si está vacío
        {
            pilaNombres.Push(nombre);
            textoTMP.text = "Se agregó: " + nombre;
            inputNombre.text = ""; // Limpia el input después de usarlo
        }
        else
        {
            textoTMP.text = "Por favor ingrese un nombre válido.";
        }

        ActualizarTextoPila();
    }

    public void PeekButton()
    {
        if (pilaNombres.Count > 0)
        {
            textoTMP.text = "El elemento del tope es " + pilaNombres.Peek();
        }
        else
        {
            textoTMP.text = "La pila esta Vacia!! ";
        }
        ActualizarTextoPila();
    }

    public void PopButton()
    {
        if (pilaNombres.Count>0)
        {
            textoTMP.text = "El elemento quitado es " + pilaNombres.Pop();
        }

        else
        {
            textoTMP.text = "No se puede desapilar, la pila esta Vacia!! ";
        }
        ActualizarTextoPila();
    }

    public void ClearString()
    {
        pilaNombres.Clear();
        textoTMP.text = " Se vacio la pila ";
        ActualizarTextoPila();
    }

    private void ActualizarTextoPila()
    {
        if (pilaNombres.Count == 0)
        {
            textoPila.text = "Pila vacía! ";
            return;
        }

        string contenido = "Contenido de la pila:\n";
        foreach (string nombre in pilaNombres)
        {
            contenido += nombre + "\n";
        }

        textoPila.text = contenido;
    }
}
