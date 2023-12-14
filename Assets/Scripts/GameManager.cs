using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject painelInicio,player,peca1,peca2,peca3,peca4;
    public static bool inicieiJogo=false;

    public GameObject[] tiposPecas;
    public int idPeca,posZPecaFinal;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        painelInicio.SetActive(true);
       
       


    }
    private void Update()
    {
        SpawnPecas();
        ReiniciarJogo();
       

    }
    public void IniciarJogo()
    {
        inicieiJogo= true;
        Time.timeScale = 1;
        painelInicio.SetActive(false);
    }
    private void ReiniciarJogo()
    {
        if (Player.playerVivo == false)
        {

            StartCoroutine("delayReiniciarJogo");
        }
    }

    IEnumerator delayReiniciarJogo()
    {

        yield return new WaitForSeconds(2f);
        Coletaveis.qtdMoedas = 0;
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
        painelInicio.SetActive(true);
        inicieiJogo = false;
        Player.QtdFinalPeca = 0;

    }
    public void SpawnPecas()
    {

        if (Player.QtdFinalPeca > 2&&Player.acrescentarPeca)
        {
            Destroy(peca1);
            idPeca = Random.Range(0, tiposPecas.Length);
            posZPecaFinal = posZPecaFinal + 20;
            peca4= Instantiate(tiposPecas[idPeca], new Vector3(0, 0, posZPecaFinal), Quaternion.identity);
            peca1 = peca2;
            peca2 = peca3;
            peca3 = peca4;
            Player.acrescentarPeca = false;
           

        }
        /*if (posZPlayer >posZPecaFinal-25)
        {
            
                idPeca = Random.Range(0, tiposPecas.Length);
                pecaCriada= Instantiate(tiposPecas[idPeca], new Vector3(0, 0, posZPecaFinal), Quaternion.identity);
                pecasInGame[qtdPecas]=pecaCriada;
                posZPecaFinal = posZPecaFinal + 20;
            Destroy(pecasInGame[qtdPecas-3]);
                qtdPecas++;
           
                
            
        }*/

      
          
    }
      
     }

       
    



