using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dusman : MonoBehaviour
{
    public float speed = 2f;

    public int startHealth = 100;
    private float health;
        

    public int value = 50;

    public GameObject deathEffect;

    [Header("Can")]
    public Image healthBar;


    private bool isDead = false;
    private Transform target;
    private int wavepointIndex = 0;

    //izlenecek ilk yol atandı
    private void Start()
    {
        target = IzlenecekYol.points[0];
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health/startHealth;
        if(health <= 0 && !isDead)
        {
            Die();
        }

    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += value;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.2f);

        Dalga.EnemiesAlive--;

        Destroy(gameObject);
    }

    //haraket ayarlaması yapıldı
    private void Update()
    {
        //hızı ayarlandı
        Vector2 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //hedef noktaya varmasına 0.2 sn kala yön değiştirmesi ayarlandı
        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    //bir sonraki izlenecek yolu bulması ayarlandı
    void GetNextWaypoint()
    {
        if(wavepointIndex >= IzlenecekYol.points.Length-1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = IzlenecekYol.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Dalga.EnemiesAlive--;
        Destroy(gameObject);
    }

}
