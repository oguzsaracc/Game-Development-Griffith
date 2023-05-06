using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipe : MonoBehaviour
{
    public Logic logic;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
     logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            source.PlayOneShot(clip);
            logic.addScore(1);
        }

    }
}
