using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] SpriteRenderer spriteRend;
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine("HitIndicated", 0.2f);
    }
    IEnumerator HitIndicated(float seconds)
    {
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(seconds);
        spriteRend.color = Color.white;
    }
}
