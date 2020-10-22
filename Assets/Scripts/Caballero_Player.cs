using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Caballero_Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D caballeroRB;
    public float maxVelocidad;
    Animator caballeroAnim;

    bool puedeMover = true; //detectar movimiento
    //Saltar
    bool enSuelo = false;
    float checkearRadioSuelo = 0.2f;
    public LayerMask capaSuelo;
    public Transform chequearSuelo;
    public float poderSalto;

    bool voltearCaballero = true;
    SpriteRenderer caballeroRender;
    void Start()
    {

        caballeroRB = GetComponent<Rigidbody2D>();
        caballeroRender = GetComponent<SpriteRenderer>();
        caballeroAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeMover && enSuelo && Input.GetAxis("Jump")>0)
        {
            caballeroAnim.SetBool("EstaEnSuelo",false);
            caballeroRB.velocity = new Vector2(caballeroRB.velocity.x, 0f);
            caballeroRB.AddForce(new Vector2(0, poderSalto), ForceMode2D.Impulse);
            enSuelo = false;
        }
        enSuelo = Physics2D.OverlapCircle(chequearSuelo.position, checkearRadioSuelo,capaSuelo);
        
        caballeroAnim.SetBool("EstaEnSuelo", enSuelo);
        float mover = Input.GetAxis("Horizontal");
         
        caballeroRB.velocity = new Vector2(mover * maxVelocidad, caballeroRB.velocity.y);
        if (puedeMover)
        {
            if (mover > 0 && !voltearCaballero)
            {
                Voltear();
            }
            else if (mover < 0 && voltearCaballero)
            {
                Voltear();
            }
            caballeroRB.velocity = new Vector2(mover * maxVelocidad, caballeroRB.velocity.y);
            //El movimiento del pj
            caballeroAnim.SetFloat("VelMovimiento", Math.Abs(mover));

        } else
        {
            caballeroRB.velocity = new Vector2(0, caballeroRB.velocity.y);
            caballeroAnim.SetFloat("VelMovimiento", 0);
        }
    }
    void Voltear()
    {
        voltearCaballero = !voltearCaballero;
        caballeroRender.flipX = !caballeroRender.flipX;
    }
    public void togglePuedeMover()
    {
        puedeMover = !puedeMover;
    }
}
