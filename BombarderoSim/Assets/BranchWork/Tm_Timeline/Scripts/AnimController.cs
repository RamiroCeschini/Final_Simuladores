using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OpacityChange(float value)
    {
        // Establecer el parámetro 'Opacity' en el valor deseado
        animator.SetFloat("Opacity", value);
    }
}
