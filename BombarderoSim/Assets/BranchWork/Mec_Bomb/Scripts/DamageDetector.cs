using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageDetector : MonoBehaviour
{
    private float radio;
    private float bombDaño = 10;
    private float dañoTotal;

    [Header("Bomba Configuracion")]
    [SerializeField] private float bomPeso;
    [SerializeField] private GameObject bomba;
    [SerializeField] private Transform bombaTransform;
    [SerializeField] private Transform explosion;
    [SerializeField] private GameObject areaDaño;

    [Header("Materiales Configuracion")]
    [SerializeField] private Material original;
    [SerializeField] private Material destruido;
    [SerializeField] private List<MeshRenderer> mRenderer;

    [Header("Particulas Configuracion")]
    [SerializeField] private List<ParticleSystem> efectos;
    [SerializeField] private GameObject particulas;

    [Header("Estadisticas")]
    [SerializeField] private List<float> dañoEdificios;
    
    

    public void Explosion()
    {
        explosion = bombaTransform; 
        CalculoPeso();
        Collider[] objetos = Physics.OverlapSphere(explosion.position, radio);
        EfectoParticulas();
        foreach (Collider colisionador in objetos)
        {
            if (colisionador.TryGetComponent<TMP_Edificio>(out TMP_Edificio edificio)) 
            {
                float dañoEdificio = Vector3.Distance(explosion.position,colisionador.transform.position);
                dañoEdificios.Add(dañoEdificio);
                mRenderer.Add(colisionador.GetComponent<MeshRenderer>());
                colisionador.GetComponent<MeshRenderer>().material = destruido;
                Invoke("RestaurarColor", 3f);
            }
        }
        SumarDaño();
        Destroy(bomba);       
    }

    private void CalculoPeso()
    {
        radio = ((bomPeso * 30) / 50);
        bombDaño = bombDaño + bomPeso;
    }

    private void RestaurarColor()
    {
        foreach (MeshRenderer rend in mRenderer)
        {
            rend.material = original;
        }
        areaDaño.SetActive(false);
        mRenderer.Clear();
    }

    private void SumarDaño()
    {
        foreach (float daño in dañoEdificios)
        {
            dañoTotal += bombDaño / daño;
            Debug.Log(daño);
        }

        Debug.Log("DAÑO TOTAL: " + dañoTotal);
        dañoEdificios.Clear();
        dañoTotal = 0;
        
    }

    private void EfectoParticulas()
    {
        GameObject particulasObject = Instantiate(particulas,explosion.position, Quaternion.identity);
        areaDaño.transform.position = explosion.position + new Vector3 (0,5,0);
        areaDaño.transform.localScale = new Vector3(radio + 2.4f, areaDaño.transform.localScale.y,radio + 2.4f);
        areaDaño.SetActive(true);
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
