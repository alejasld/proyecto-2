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

        string usuario = "Nombre: {nombre}, Email: {email}, Direcci�n: {direccion}";
        colaTexto.Enqueue(usuario);

        ActualizarTextoCola();
        textoInformacion.text = "Se agreg�: {usuario}";

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
            textoInformacion.text = "Se elimin�: {eliminado}";
        }
        else
        {
            textoInformacion.text = "La cola est� vac�a, no se puede eliminar.";
        }
    }
    public void PeekString()
    {
        if (colaTexto.Count > 0)
        {
            string primero = colaTexto.Peek();
            textoInformacion.text = "En el frente de la cola est�: {primero}";
        }
        else
        {
            textoInformacion.text = "La cola est� vac�a.";
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