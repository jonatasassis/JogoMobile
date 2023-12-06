using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
   // public AudioSource sfxMoedas;
    private void OnTriggerEnter(Collider collision)
    {
        //efeitoMoeda.Play();
       
        //sfxMoedas.Play();
        if (collision.tag == "Player")
        {
            
            Destroy(gameObject);
            print("COLETEI");


        }
       
    }
}
