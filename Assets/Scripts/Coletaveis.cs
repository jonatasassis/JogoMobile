using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
    // public AudioSource sfxMoedas;
    public static int qtdMoedas,graus;


    private void Update()
    {
        graus++;
        this.transform.rotation= Quaternion.Euler(graus,0,0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        //efeitoMoeda.Play();
       
        //sfxMoedas.Play();
        if (collision.tag == "coletor")
        {
            qtdMoedas++;
            gameObject.SetActive(false);
            Destroy(gameObject,1);
            print("COLETEI");


        }
       
    }
}
