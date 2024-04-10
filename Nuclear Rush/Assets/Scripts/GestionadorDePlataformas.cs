using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionadorDePlataformas : MonoBehaviour
{

    [SerializeField] private GameObject[] plataforma1 = new GameObject[4];
    [SerializeField] private GameObject[] plataforma2 = new GameObject[4];
    [SerializeField] private GameObject[] plataforma3 = new GameObject[4];
    [SerializeField] private GameObject moduloDeTransformacion;
    [SerializeField] private int modulosPreTransformacion;
    int contadorDeModulosPasados;
    int aleatorio, numeroModulos, moduloActual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject EscogerPlataforma()
    {
        if(moduloActual == 0)
        {
            numeroModulos = plataforma1.Length;
        }
        else if(moduloActual == 1)
        {
            numeroModulos = plataforma2.Length;
        }
        else if(moduloActual == 2)
        {
            numeroModulos = plataforma3.Length;
        }

        GameObject plataformaEscogida = null;

        aleatorio = Random.Range(0, numeroModulos); //Escoger numero aleatorio

        if (contadorDeModulosPasados == modulosPreTransformacion)
        {
            Debug.Log("MODULO DE TRANSFORMACION ACTIVADO, CAMBIANDO DE ZONA");
            contadorDeModulosPasados = 0;
            moduloActual++;
            return moduloDeTransformacion;
        }

        if (moduloActual == 0)
        {
            plataformaEscogida = plataforma1[aleatorio];
        }
        else if (moduloActual == 1)
        {
            plataformaEscogida = plataforma2[aleatorio];
        }
        if (moduloActual == 2)
        {
            plataformaEscogida = plataforma3[aleatorio];
        }

        contadorDeModulosPasados++;

        return plataformaEscogida;
    }
   
}
