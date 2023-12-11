using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PanelTransition : MonoBehaviour
{
    public PlayableDirector timeline;

    private void Start()
    {
        // Desactivar el Panel 2 al inicio
        timeline.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        // Activar el Panel 2 y reproducir la transición
        timeline.gameObject.SetActive(true);
        timeline.Play();
    }

    public void RestartScene()
    {
        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Close()
    {
        Application.Quit();
    }
}