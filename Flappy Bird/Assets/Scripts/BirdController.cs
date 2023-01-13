using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float upForce = 200f;
    public bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioSource audioSource = GameControl.instance.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead) 
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == UnityEngine.TouchPhase.Began)
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2 (0, upForce));
                }
            }   
        }  
        else
        {
            return;
        }    
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        isDead = true;
        animator.enabled = false;
        GameControl.instance.BirdDied();
    }
}
