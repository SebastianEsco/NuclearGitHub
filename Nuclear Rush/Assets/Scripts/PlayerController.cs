using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool antiDobleSalto;
    Vector3 posicionInicial;
    Piso piso;
    Rigidbody rb;
    [SerializeField] float cantidadQueVaria, velocidadDeRecuperacion;
    public float fuerzaSalto;
    public bool puedeSaltar = true;
    private void Start()
    {
        piso = GetComponent<Piso>();
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        antiDobleSalto = true;
    }

    

    void Update()
    {

        Vector3 posicion = transform.position;
        

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Presionando A o D");
            if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            {
               // Debug.Log("Presionando A y D");
                piso.velocidad = piso.velocidadInicial;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("Presionando D");
                piso.velocidad = piso.velocidadInicial + cantidadQueVaria;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("Presionando A");
                piso.velocidad = piso.velocidadInicial - cantidadQueVaria;
            }
        }
        else
        {
            piso.velocidad = piso.velocidadInicial;
        }

        //Castear Rasho laser
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.75f, 1) && antiDobleSalto) //Tirar el rayo para abajo
        {
            antiDobleSalto = false;
            Invoke("AntiDobleSalto", 0.1f);
            puedeSaltar = true; //Si le está pegando al suelo, puede saltar
        }
        
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar) //Apretar W y estar en el suelo
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode.Impulse);
            puedeSaltar = false;
        }

        //Recuperar posiciòn Inicial de a poquito
        if(transform.position.x < posicionInicial.x)
        {
            transform.position = new Vector3(posicion.x + (velocidadDeRecuperacion * Time.deltaTime), posicion.y, posicion.z);
        }
    }

    public void AntiDobleSalto()
    {
        antiDobleSalto = true;
    }
    

}
