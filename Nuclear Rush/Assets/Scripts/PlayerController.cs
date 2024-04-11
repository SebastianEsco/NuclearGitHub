using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public bool jugando, vivo; //vivo es literalmente para usar todo. Jugando es para hacer ciertas acciones antes de dejar de estar vivo.
    bool antiDobleSalto;
    [SerializeField] Vector3 posicionInicial;
    Piso piso;
    Rigidbody rb;
    [SerializeField] float cantidadQueVaria, velocidadDeRecuperacion;
    public float fuerzaSalto;
    public bool puedeSaltar = true;

    bool puedeDeslizarse;
    [SerializeField] float tiempoDeDeslizamiento;
    public GameObject hitBoxParado, hitBoxSentado;


    //Acido
    bool muriendoEnAcido;

    private void Start()
    {
        piso = GetComponent<Piso>();
        rb = GetComponent<Rigidbody>();
        antiDobleSalto = true;
        puedeDeslizarse = true;
        hitBoxSentado.SetActive(false);
        jugando = true;
        vivo = true;
    }

    

    void Update()
    {
        if (vivo)
        {
            if (jugando)
            {
                Acelerando();

                Saltar();

                RecuperarPosicionInicial();

                Deslizarse();
            }
            else if (!jugando && muriendoEnAcido)
            {
                hitBoxParado.SetActive(false);
                hitBoxSentado.SetActive(false);
                rb.useGravity = false;
                if(piso.velocidad > 0)
                {
                    piso.velocidad -= 0.01f * Time.deltaTime;
                }
                
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
            }
        }
        else
        {
            piso.velocidad = 0;
        }
        

    }


    public void Acelerando()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Presionando A o D");
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
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
    }

    

    public void Saltar()
    {
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
    }

    public void AntiDobleSalto()
    {
        antiDobleSalto = true;
    }

    public void RecuperarPosicionInicial()
    {

        Vector3 posicion = transform.position;
        //Recuperar posición Inicial de a poquito
        if (transform.position.x < posicionInicial.x)
        {
            transform.position = new Vector3(posicion.x + (velocidadDeRecuperacion * Time.deltaTime), posicion.y, posicion.z);
        }
    }

    public void Deslizarse()
    {
        if(puedeSaltar && puedeDeslizarse && Input.GetKeyDown(KeyCode.S)) //Revisar que no esté en el aire ni deslizandose
        {
            CambiarHitBox(); //Cambiar a sentado
            Invoke("CambiarHitBox", tiempoDeDeslizamiento);
            puedeDeslizarse = false;
            
        }
    }

    public void CambiarHitBox()
    {
        if (hitBoxParado.activeSelf)
        {
            hitBoxSentado.SetActive(true); //Se sienta
            hitBoxParado.SetActive(false);
        }
        else
        {
            hitBoxSentado.SetActive(false); //Se para
            hitBoxParado.SetActive(true);
            puedeDeslizarse = true;
        }

    } //Deslizar



    //----ACIDO----
    public void VelocidadEnAcido()
    {
        piso.velocidad = 0.1f;
    }

    public void VelocidadFueraDeAcido()
    {
        piso.velocidad = piso.velocidadInicial;
    }

    public void SecuenciaDeMuerteEnAcido()
    {
        muriendoEnAcido = true;
        jugando = false;
        Invoke("PantallaDeMuerte", 5); 
        //Activar Animación de muerte en acido
        
    }

    public void PantallaDeMuerte() //De momento lo coloco en este script pero sería bueno ponerlo en otro lado para no saturar este
    {
        vivo = false;
        Debug.Log("Murió :(");
    }


}
