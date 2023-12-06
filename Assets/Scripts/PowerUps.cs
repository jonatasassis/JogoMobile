using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Player")
        {
          
            gameObject.SetActive(false);
            Destroy(gameObject,5);


        }

    }
}
