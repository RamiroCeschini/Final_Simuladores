using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageDetector : MonoBehaviour
{
    private float radio;
    private float da�o = 10;
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
    [SerializeField] private List<MeshRenderer> renderer;

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
                renderer.Add(colisionador.GetComponent<MeshRenderer>());
                colisionador.GetComponent<MeshRenderer>().material = destruido;
                Invoke("RestaurarColor", 3f);
            }
        }
        SumarDa�o();
        Destroy(bomba);       
    }

    private void CalculoPeso()
    {
        radio = ((bomPeso * 30) / 100);
        da�o = da�o + bomPeso;
    }

    private void RestaurarColor()
    {
        foreach (MeshRenderer rend in renderer)
        {
            rend.material = original;
        }
        renderer.Clear();
    }

    private void SumarDa�o()
    {
        foreach (float da�o in da�oEdificios)
        {
            da�oTotal += da�o;
            Debug.Log(da�o);
        }

        Debug.Log("DA�O TOTAL: " + da�oTotal);
        da�oEdificios.Clear();
        da�oTotal = 0;
        
    }

    private void EfectoParticulas()
    {
        GameObject particulasObject = Instantiate(particulas,explosion.position, Quaternion.identity);
        areaDa�o.transform.position = explosion.position;
        areaDa�o.transform.localScale = new Vector3(radio + 2.4f, areaDa�o.transform.localScale.y,radio + 2.4f);
        areaDa�o.SetActive(true);
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
