using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("Configuración del Proyectil")]
    public float speed = 100f;    // Velocidad a la que se moverá el proyectil

    
    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

  
    void Start()
    {
        // Destruir el proyectil después de 5 segundos para evitar acumulación
        Destroy(gameObject, 5f);
    }
}
