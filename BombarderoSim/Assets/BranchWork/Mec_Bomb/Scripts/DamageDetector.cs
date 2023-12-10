using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageDetector : MonoBehaviour
{
    private float radio;
    private float bombDa�o = 10;
    private float da�oTotal;

    [Header("Bomba Configuracion")]
    [SerializeField] private float bomPeso;
    [SerializeField] private GameObject bomba;
    [SerializeField] private Transform bombaTransform;
    [SerializeField] private Transform explosion;
    [SerializeField] private GameObject areaDa�o;

    [Header("Materiales Configuracion")]
    [SerializeField] private Material original;
    [SerializeField] private Material destruido;
    [SerializeField] private List<MeshRenderer> mRenderer;

    [Header("Particulas Configuracion")]
    [SerializeField] private List<ParticleSystem> efectos;
    [SerializeField] private GameObject particulas;

    [Header("Estadisticas")]
    [SerializeField] private List<float> da�oEdificios;
    
    

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
                float da�oEdificio = Vector3.Distance(explosion.position,colisionador.transform.position);
                da�oEdificios.Add(da�oEdificio);
                mRenderer.Add(colisionador.GetComponent<MeshRenderer>());
                colisionador.GetComponent<MeshRenderer>().material = destruido;
                Invoke("RestaurarColor", 3f);
            }
        }
        SumarDa�o();
        Destroy(bomba);       
    }

    private void CalculoPeso()
    {
        radio = ((bomPeso * 30) / 50);
        bombDa�o = bombDa�o + bomPeso;
    }

    private void RestaurarColor()
    {
        foreach (MeshRenderer rend in mRenderer)
        {
            rend.material = original;
        }
        areaDa�o.SetActive(false);
        mRenderer.Clear();
    }

    private void SumarDa�o()
    {
        foreach (float da�o in da�oEdificios)
        {
            da�oTotal += bombDa�o / da�o;
            Debug.Log(da�o);
        }

        Debug.Log("DA�O TOTAL: " + da�oTotal);
        da�oEdificios.Clear();
        da�oTotal = 0;
        
    }

    private void EfectoParticulas()
    {
        GameObject particulasObject = Instantiate(particulas,explosion.position, Quaternion.identity);
        areaDa�o.transform.position = explosion.position + new Vector3 (0,5,0);
        areaDa�o.transform.localScale = new Vector3(radio + 2.4f, areaDa�o.transform.localScale.y,radio + 2.4f);
        areaDa�o.SetActive(true);
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
