using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyControle : MonoBehaviour
{
    [Header("Configurações de Status")]
    public float health = 10f;
    public float moveSpeed = 3f;
    public float damageOnContact = 5f;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) playerTransform = player.transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            SeguirJogador();
            ControlarFlip();
        }
    }
    void SeguirJogador()
    {
        Vector2 direcao = (playerTransform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direcao * moveSpeed * Time.deltaTime);
    }
    void ControlarFlip()
    {
        spriteRenderer.flipX = playerTransform.position.x > transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage(damageOnContact);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Morrer();
    }
    void Morrer()
    {
        Destroy(gameObject);
    }


}
