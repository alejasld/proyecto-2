using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColaTexto : MonoBehaviour
{
   
    [SerializeField] private TMP_InputField inputNombre;
    [SerializeField] private TMP_InputField inputEmail;
    [SerializeField] private TMP_InputField inputDireccion;

    [SerializeField] private TMP_Text textoCola;
    [SerializeField] private TMP_Text textoInformacion;

    private Queue<string> colaTexto = new Queue<string>();

    public void EnqueueUsuario()
    {
        string nombre = inputNombre.text;
        string email = inputEmail.text;
        string direccion = inputDireccion.text;

        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(direccion))
        {
            textoInformacion.text = "Debe llenar todos los campos antes de agregar.";
            return;
        }

        string usuario = "Nombre: {nombre}, Email: {email}, Dirección: {direccion}";
        colaTexto.Enqueue(usuario);

        ActualizarTextoCola();
        textoInformacion.text = "Se agregó: {usuario}";

        inputNombre.text = "";
        inputEmail.text = "";
        inputDireccion.text = "";
    }

    public void DequeueString()
    {
        if (colaTexto.Count > 0)
        {
            string eliminado = colaTexto.Dequeue();
            ActualizarTextoCola();
            textoInformacion.text = "Se eliminó: {eliminado}";
        }
        else
        {
            textoInformacion.text = "La cola está vacía, no se puede eliminar.";
        }
    }
    public void PeekString()
    {
        if (colaTexto.Count > 0)
        {
            string primero = colaTexto.Peek();
            textoInformacion.text = "En el frente de la cola está: {primero}";
        }
        else
        {
            textoInformacion.text = "La cola está vacía.";
        }
    }

    public void ClearString()
    {
        colaTexto.Clear();
        ActualizarTextoCola();
        textoInformacion.text = "La cola se ha limpiado.";
    }

    private void ActualizarTextoCola()
    {
        textoCola.text = "Cola:\n";
        foreach (string usuario in colaTexto)
        {
            textoCola.text += usuario + "\n";
        }
    }
}