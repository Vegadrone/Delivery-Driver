using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables Delcration
    [SerializeField] float stearSpeed = 0.01f;
    [SerializeField] float moveSpeed = 0.001f;
    [SerializeField] float bumpSlowdown = 0.001f;
    [SerializeField] float speedBoost = 0.001f;
    private string boost = "BoostSpeed";
    private string movX = "Horizontal";
    private string movY = "Vertical";

    void Update()
    {
        //dichiaro questa variabile qui perché a dufferenza delle altre ho bisogno che venga updatata ogni frame
        //Hai bisogno di moltiplicare il movimento per le variabili dichiarate  per il deltatime in maniera da essere tutto frame indipendent
        float stearAmount = Input.GetAxis(movX) * stearSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis(movY) * moveSpeed * Time.deltaTime;

        //metti il meno su stear amount altrimenti premendo d andrà a sx invece che a dx
        transform.Rotate(0, 0, -stearAmount);
        transform.Translate(0, speedAmount, 0);
    }

    //Qui non devi usare other e tag perché il GO Car è già quello che collide con qualcosa
    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = bumpSlowdown;
    }

    //Qui devi usare other e tag perché il trigger è un GO diverso da Car
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == boost)
        {
            moveSpeed = speedBoost;
        }
    }

   

}
