using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera MainCamera;
    private AudioSource fulmine;
    public AudioClip fulminacci;
    public Kino.Tube effetto;
    public void Awake()
    {
        StartCoroutine(Temporale());
        fulmine = GetComponent<AudioSource>();
    }

    IEnumerator Temporale()
    {
        int seconds = Random.Range(10,80);
        print(seconds);
        yield return new WaitForSeconds(seconds);
        MainCamera.backgroundColor = Color.white;
        fulmine.PlayOneShot(fulminacci);
        print("we");
        yield return new WaitForSeconds(0.2f);
        MainCamera.backgroundColor = Color.black;
        StartCoroutine(Temporale());
    }

    public void Update()
    {
        if (Input.GetButtonDown("Quality")) effetto.enabled = !effetto.enabled;
    }
}
