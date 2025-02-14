using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvaPlayer : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth = 100;
    private float damageBullet = 5;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion;
    [SerializeField]
    private ParticleSystem smallExplosion;

    void Awake()
    {
        lifeBar.fillAmount = 1;
        bigExplosion.Stop();
        smallExplosion.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth; // Cálculo de la relación de salud
            Destroy(other.gameObject); // Destruimos el proyectil
            smallExplosion.Play();
            if (currentHealth <= 0)
            { // Comprobamos si hemos muerto

                Death();
            }
        }
    }
    private void Death()
    {
        Camera.main.transform.SetParent(null); // Antes de destruir el objeto deshacer la jerarquía
        Destroy(gameObject); // Camera.main es la cámara con el
                             // tag "MainCamera"
        bigExplosion.Play();
    }
}