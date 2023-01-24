using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingradiscimento : MonoBehaviour
{
    private RectTransform rect;
    public float velocita;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rect.transform.localScale.x < 30)
        {
            rect.transform.localScale += new Vector3(velocita, velocita, 0f);
        }
        else SceneManager.LoadScene("end");

    }
}
