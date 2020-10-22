using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CamSigue : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetivo;
    public float suavizado = 5f;
    Vector3 desface;
    void Start()
    {
        desface = transform.position - objetivo.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 posicionObjetivo = objetivo.position + desface;
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);
    }
}
