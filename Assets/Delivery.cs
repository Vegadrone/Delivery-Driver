using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.1f;
    //Per creare una ruota di colore dinamica
    [SerializeField] Color32 noPackage = new Color32(0, 0, 0, 0);
    [SerializeField] Color32 withPackage = new Color32(0, 0, 0, 0);
    private string package = "Package";
    private string deliveryStation = "DeliveryStation";
    //Reference al component sprite renderer
    SpriteRenderer spriteRender;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.color = noPackage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == package && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("picked!");
            spriteRender.color = withPackage;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == deliveryStation && hasPackage)
        {
            Debug.Log("delivered");
            hasPackage = false;
            spriteRender.color = noPackage;
        }
       
    }
}
