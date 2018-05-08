using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    public GameObject damageParticle;
    public Transform hitPoint;
    public GameObject damageNumber;

    PlayerStats stats;
    int currentDamage;

    void Start()
    {
        stats = FindObjectOfType<PlayerStats>(); // Find the players stats
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime") // If the player collides with the slime
        {
            currentDamage = damage + stats.currentAttack; // Damage the slime
            other.gameObject.GetComponent<EnemyHealth>().Damage(currentDamage);
            Instantiate(damageParticle, hitPoint.position, hitPoint.rotation); // Display damage particles
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damage = damage;
        }
    }
}
