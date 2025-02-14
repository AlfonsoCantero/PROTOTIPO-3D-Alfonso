using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private int speed = 12;
private float distanceToPlayer = 6;
GameObject player;

[SerializeField]
private GameObject bulletPrefab;
[SerializeField]
private Transform[] posRotBullet;
[SerializeField]
private float timeBetweenBullets;
[SerializeField]
private AudioSource shootAudio;
    [SerializeField]
    private ParticleSystem smallExplosion, bigExplosion;    //Variables tipo ParticleSystem

    private float maxHealth = 100;      //Salud máxima
private float currentHealth = 100;  //Salud actual
private float damageBullet = 25;    //Daño causado por el player

void Awake()
{
    shootAudio = GetComponent<AudioSource>();
    player = GameObject.FindGameObjectWithTag("Player");
    InvokeRepeating("Attack", 1, timeBetweenBullets);
}

private void Attack() //Metodo para el ataque
{
    shootAudio.Play();
    for (int i = 0; i < posRotBullet.Length; i++)
    {
        Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
    }
}

void Update()        //Metodo que actualiza cada frame
{
    if (player != null)
    {
        if (player == null)
            return;

        transform.LookAt(player.transform.position);
        FollowPlayer();
    }
}

private void FollowPlayer()   //Metodo de seguimiento de jugador
{
    float distance = Vector3.Distance(transform.position, player.transform.position);
    if (distance > distanceToPlayer)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

private void OnTriggerEnter(Collider other)
{
        Debug.Log("dsaf");
    if (other.CompareTag("Bullet"))         //Si colisiona con bala del jugador
    {
        Debug.Log("Joo");
        smallExplosion.Play();              //Efecto de impacto
        currentHealth -= damageBullet;      //Reduce salud
        Destroy(other.gameObject);          //Destruye la bala
        if (currentHealth <= 0)             //Si no tiene salud
        {
            Death();                        //Muere
        }
    }
}

//Sistema de muerte
private void Death()
{
    bigExplosion.Play();    //Reproducción partículas
    Destroy(gameObject, 0.5f); //Destruimos al enemigo
}

}
