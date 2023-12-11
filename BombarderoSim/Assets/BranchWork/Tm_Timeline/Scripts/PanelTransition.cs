using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTransition : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject slidersCanvas;
    public Button manualButton;
    public Button automaticButton;

    void Start()
    {
        // Agrega un listener al botón para detectar clics
        manualButton.onClick.AddListener(OnManualButtonClick);
    }

    void OnManualButtonClick()
    {
        // Inicia la transición
        StartCoroutine(TransitionPanels());
    }

    IEnumerator TransitionPanels()
    {
        // Puedes agregar una animación personalizada o simplemente desactivar/activar los paneles
        canvasMenu.SetActive(false);
        slidersCanvas.SetActive(true);

        // Puedes agregar aquí una transición más suave si es necesario

        yield return null;
    }
}
