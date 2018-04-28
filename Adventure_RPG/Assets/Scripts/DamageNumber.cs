using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float speed;
    public int damage;
    public Text damageText;

    private void Update()
    {
        damageText.text = damage.ToString();
        transform.position = new Vector3(0, transform.position.y + (speed * Time.deltaTime), 0);
    }
}
