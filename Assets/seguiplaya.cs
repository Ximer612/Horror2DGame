using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguiplaya : MonoBehaviour
{
    public float speed;
    private Transform target;
    private SpriteRenderer spriterendere;
    public Sprite boccaaperta;
    public Sprite boccachiusa;
    // Use this for initialization
    private void Awake()
    {
        spriterendere = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform != null) transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") spriterendere.sprite = boccaaperta;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") spriterendere.sprite = boccachiusa;
    }
}
