using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private GameObject bomba;
    [SerializeField] private Transform bombaTransform;
    [SerializeField] private Material original;
    [SerializeField] private Material destruido;
    [SerializeField] private List<MeshRenderer> renderer;

    public void Explosion()
    {
        Collider[] objetos = Physics.OverlapSphere(bombaTransform.position, radio);
        foreach (Collider colisionador in objetos)
        {
            if (colisionador.TryGetComponent<TMP_Edificio>(out TMP_Edificio edificio)) 
            {
                renderer.Add(colisionador.GetComponent<MeshRenderer>());
                Rigidbody rb = colisionador.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    colisionador.GetComponent<MeshRenderer>().material = destruido;
                    Invoke("RestaurarColor", 3f);
                }
            }
            
        }

        Destroy(bomba);
    }

    private void RestaurarColor()
    {
        foreach (MeshRenderer rend in renderer)
        {
            rend.material = original;
        }
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
