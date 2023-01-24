using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avantiindietro : MonoBehaviour
{
    public float speed;
    public float distance;
    private Rigidbody2D rb;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        int layer_mask = LayerMask.GetMask("Terreno");
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layer_mask);
        if (groundinfo.collider == false)
        {
            if (movingRight)
            {
                rb.velocity = new Vector2(-speed, 0);
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                rb.velocity = new Vector2(speed, 0);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
