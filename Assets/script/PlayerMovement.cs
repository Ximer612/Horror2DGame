using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Rigidbody2D m_Rigidbody2D;
    public float runSpeed = 40f;
    private Animator animator;
    float horizontalMove = 0f;
    public bool jump = false;
    private AudioSource suoni;
    public AudioClip idiot;
    public AudioClip urlo;
    public int idiotpoints = 0;
    public TextMeshProUGUI idiotscrita;
    public TextMeshProUGUI fine;
    public GameObject snail;
    public GameObject pauroso;
    public GameObject facciabrutta;
    public GameObject tilemapnascosta;
    private bool puoiprendere=true;
    public AudioSource musica;
    public GameObject pauragui;

    private void Awake()
    {

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        suoni = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("salto", true);
        }
        if (horizontalMove != 0) animator.SetBool("fermo", false); else animator.SetBool("fermo", true);

    }

    public void OnLanding()
    {
        print("toccato terra");
        animator.SetBool("salto", false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        if(this.gameObject.transform.position.y<-24) { this.gameObject.transform.position = new Vector3(0,2,0); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "IdiotCoin" && puoiprendere)
        {
            suoni.PlayOneShot(idiot);
            Destroy(collision.gameObject);
            idiotpoints++;
            addIdiot();
            puoiprendere = false;
            StartCoroutine(Cojones());
        }

        if (collision.tag == "Finish" && puoiprendere)
        {
            puoiprendere = false;
            musica.Stop();
            Instantiate(facciabrutta, new Vector3(50, 7, 0), Quaternion.identity);
            Instantiate(facciabrutta, new Vector3(0, 10, 0), Quaternion.identity);
            Instantiate(facciabrutta, new Vector3(50, 17, 0), Quaternion.identity);
            Instantiate(facciabrutta, new Vector3(-30, -17, 0), Quaternion.identity);
        }

        if (collision.tag == "Respawn")
        {
            pauragui.SetActive(true);
            suoni.PlayOneShot(urlo);
            this.gameObject.SetActive(false);

            //fine.text = "  END?";
        }

    }

    IEnumerator Cojones()
    {
        yield return new WaitForSeconds(3);
        puoiprendere = true;
    }

    void addIdiot()
    {
        switch (idiotpoints)
        {
            case 1:
                idiotscrita.text="YOU";
                break;
            case 2:
                idiotscrita.text = "ARE";
                break;
            case 3:
                idiotscrita.text = "AN";
                break;
            case 4:
                idiotscrita.text = "IDIOT";
                tuttiPresi();
                break;
        }
    }

    void tuttiPresi()
    {
        tilemapnascosta.SetActive(true);
        Instantiate(pauroso, new Vector3(40, 5, 0), Quaternion.identity);
        Destroy(snail);

    }
}