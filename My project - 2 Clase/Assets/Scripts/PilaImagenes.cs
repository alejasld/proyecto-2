using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PilaImagenes : MonoBehaviour
{
    private Stack<Sprite> pilaImagenes = new Stack<Sprite>();

    [SerializeField] private TMP_Text textoTMP;        // Muestra mensajes (acciones que se hacen)
    [SerializeField] private Transform panelContenedor; // Panel donde se mostrarán las imágenes
    [SerializeField] private GameObject prefabImagen;   // Prefab de un objeto UI Image

    // Lista de imágenes predefinidas (se asignan en el Inspector)
    [SerializeField] private List<Sprite> imagenesPredefinidas = new List<Sprite>();

    private int indiceImagen = 0;

    public void PushImagen()
    {
        if (indiceImagen < imagenesPredefinidas.Count)
        {
            Sprite nuevaImagen = imagenesPredefinidas[indiceImagen];
            pilaImagenes.Push(nuevaImagen);

            // Crear un objeto UI Image dentro del panel y asignar el sprite
            GameObject nuevaUI = Instantiate(prefabImagen, panelContenedor);
            nuevaUI.GetComponent<Image>().sprite = nuevaImagen;
            nuevaUI.name = "Imagen_" + indiceImagen;

            textoTMP.text = "Se agregó la imagen " + nuevaImagen.name + " a la pila.";
            indiceImagen++;
        }
        else
        {
            textoTMP.text = "No hay más imágenes predefinidas para agregar.";
        }
    }

    public void PopImagen()
    {
        if (pilaImagenes.Count > 0)
        {
            Sprite imagenQuitada = pilaImagenes.Pop();

            // Destruir el último hijo del panel (tope de la pila visual)
            Transform ultimoHijo = panelContenedor.GetChild(panelContenedor.childCount - 1);
            Destroy(ultimoHijo.gameObject);

            textoTMP.text = "Se quitó la imagen " + imagenQuitada.name + " de la pila.";
            indiceImagen--;
        }
        else
        {
            textoTMP.text = "No se puede desapilar, la pila está vacía.";
        }
    }

    public void PeekImagen()
    {
        if (pilaImagenes.Count > 0)
        {
            textoTMP.text = "El tope es la imagen " + pilaImagenes.Peek().name;
        }
        else
        {
            textoTMP.text = "La pila está vacía.";
        }
    }

    public void ClearImagenes()
    {
        pilaImagenes.Clear();

        // Destruir todas las imágenes del panel
        foreach (Transform hijo in panelContenedor)
        {
            Destroy(hijo.gameObject);
        }

        textoTMP.text = "Se vació la pila de imágenes.";
        indiceImagen = 0;
    }
}