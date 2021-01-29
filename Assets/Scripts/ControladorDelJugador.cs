using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDelJugador : MonoBehaviour
{
    Rigidbody miRigidbody;
    public float velocidad;
    Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        //print(vertical);
        //print(horizontal);
        miRigidbody.AddForce(new Vector3(horizontal*velocidad, 0, vertical*velocidad));
    }

    private void OnTriggerEnter(Collider entro)
    {
        if (entro.CompareTag("Finish"))
        {
            print("Ganaste");
        }else if (entro.CompareTag("Enemigos"))
        {
            miRigidbody.MovePosition(posicionInicial);
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
