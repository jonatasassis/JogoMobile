using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
   
    public static int tipoPowerUp;
    

    public void Start()
    {
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Player")
        {
          
            gameObject.SetActive(false);
            Destroy(gameObject,5);


        }

    }
}
