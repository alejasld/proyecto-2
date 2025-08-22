using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PilaImagenes : MonoBehaviour
{
    private Stack<Sprite> pilaImagenes = new Stack<Sprite>();

    [SerializeField] private TMP_Text textoTMP;       
    [SerializeField] private Transform panelContenedor; 
    [SerializeField] private GameObject prefabImagen; 

    [SerializeField]
    private List<Sprite> imagenesPredefinidas = new List<Sprite>()
    {
        
    };

    private int indiceImagen = 0;

    public void PushImagen()
    {
        if (indiceImagen < imagenesPredefinidas.Count)
        {
            Sprite nuevaImagen = imagenesPredefinidas[indiceImagen];
            pilaImagenes.Push(nuevaImagen);

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

        foreach (Transform hijo in panelContenedor)
        {
            Destroy(hijo.gameObject);
        }

        textoTMP.text = "Se vació la pila de imágenes.";
        indiceImagen = 0;
    }
}