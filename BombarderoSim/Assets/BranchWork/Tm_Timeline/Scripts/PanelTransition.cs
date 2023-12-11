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
        // Agrega un listener al bot�n para detectar clics
        manualButton.onClick.AddListener(OnManualButtonClick);
    }

    void OnManualButtonClick()
    {
        // Inicia la transici�n
        StartCoroutine(TransitionPanels());
    }

    IEnumerator TransitionPanels()
    {
        // Puedes agregar una animaci�n personalizada o simplemente desactivar/activar los paneles
        canvasMenu.SetActive(false);
        slidersCanvas.SetActive(true);

        // Puedes agregar aqu� una transici�n m�s suave si es necesario

        yield return null;
    }
}
