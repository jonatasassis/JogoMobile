using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
    // public AudioSource sfxMoedas;
    public static int qtdMoedas,graus;
    public ParticleSystem efeitoMoeda;


    private void Update()
    {
        graus++;
        this.transform.rotation= Quaternion.Euler(graus,0,0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        
      
        //sfxMoedas.Play();
        if (collision.tag == "coletor")
        {
            efeitoMoeda.Play();
            qtdMoedas++;
            //gameObject.SetActive(false);
            Destroy(gameObject,0.1f);
            print("COLETEI");


        }
       
    }
}
