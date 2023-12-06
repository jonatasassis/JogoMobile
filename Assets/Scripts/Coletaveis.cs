using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
    // public AudioSource sfxMoedas;
    public static int qtdMoedas;
    private void OnTriggerEnter(Collider collision)
    {
        //efeitoMoeda.Play();
       
        //sfxMoedas.Play();
        if (collision.tag == "Player")
        {
            qtdMoedas++;
            gameObject.SetActive(false);
            Destroy(gameObject,1);
            print("COLETEI");


        }
       
    }
}
