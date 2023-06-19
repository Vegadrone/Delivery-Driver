using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //Variables Delcration
    public float stearSpeed = 0.01f;
    public float moveSpeed = 0.001f;
    private string movX = "Horizontal";
    private string movY = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
