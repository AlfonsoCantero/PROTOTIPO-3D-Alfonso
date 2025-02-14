using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("Configuraci�n del Proyectil")]
    public float speed = 100f;    // Velocidad a la que se mover� el proyectil

    
    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

  
    void Start()
    {
        // Destruir el proyectil despu�s de 5 segundos para evitar acumulaci�n
        Destroy(gameObject, 5f);
    }
}
