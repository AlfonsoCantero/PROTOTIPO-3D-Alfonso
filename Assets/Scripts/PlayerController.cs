using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables p�blicas para ajustar desde el Inspector de Unity
    [Header("Configuraci�n de Movimiento")]
    public float moveSpeed = 50f;        // Velocidad de movimiento del jugador
    public float turnSpeed = 125f;       // Velocidad de rotaci�n del jugador

    [Header("Configuraci�n de Disparo")]
    public GameObject bulletPrefab;       // Prefab del proyectil que dispararemos
    public Transform[] shootPoints;       // Puntos desde donde saldr�n los disparos
    public AudioSource shootAudio;        // Componente para el sonido del disparo

   
   
    
    void Start()
    {
        // Bloquear y ocultar el cursor para el control del juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    
    void Update()
    {
        Movement();   // Maneja el movimiento
        Turning();    // Maneja la rotaci�n
        Shooting();   // Maneja el disparo
    }



    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }



    private void Turning()
    {
        // Obtener movimiento del rat�n en X e Y
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        // Crear vector de rotaci�n y aplicarlo
        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    
    
    
    private void Shooting()
    {
        // Si se presiona el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            shootAudio.Play();  // Reproducir sonido de disparo

            // Crear un proyectil en cada punto de disparo
            foreach (Transform shootPoint in shootPoints)
            {
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            }
        }
    }
}
