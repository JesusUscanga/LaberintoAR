using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float aceler = 8f, rever = 4f, velMax = 50f, torque = 180f, fuerzaGravedad = 10f, dragEnPiso = 3f; //Variables --Para algo hab�a definido velMax y nunca la ocup�

    private float velInput, giro;

    private bool enPiso; //True para indicar que el auto est� tocando el piso

    public LayerMask queEsPiso;
    public float enPisoRay = 0.5f;
    public Transform puntoPiso;

    private void Start()
    {
        rb.transform.parent = null;
    }

    private void Update()
    {
        //Control del auto
        velInput = 0f;
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            velInput = CrossPlatformInputManager.GetAxis("Vertical") * aceler * 1000f;
        }
        else if (CrossPlatformInputManager.GetAxis("Vertical") < 0)
        {
            velInput = CrossPlatformInputManager.GetAxis("Vertical") * rever * 1000f;
        }

        giro = CrossPlatformInputManager.GetAxis("Horizontal");

        //S�lo gira si el auto est� en el piso y avanzando
        if (enPiso)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, giro * torque * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical"), 0f));
        }

        transform.position = rb.transform.position;
    }

    private void FixedUpdate()
    {
        //Para ver si el auto est� o no tocando el piso
        enPiso = false;
        RaycastHit hit;

        if (Physics.Raycast(puntoPiso.position, -transform.up, out hit, enPisoRay, queEsPiso))
        {
            enPiso = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (enPiso)
        {
            rb.drag = dragEnPiso;
            if (Math.Abs(velInput) > 0)
            {
                rb.AddForce(transform.forward * velInput);
            }
        }
        //Si no, va a aplicar una fuerza hac�a abajo
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * -fuerzaGravedad * 100f);
        }
    }
}
