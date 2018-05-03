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
        stats = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            currentDamage = damage + stats.currentAttack;
            other.gameObject.GetComponent<EnemyHealth>().Damage(currentDamage);
            Instantiate(damageParticle, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damage = damage;
        }
    }
}
