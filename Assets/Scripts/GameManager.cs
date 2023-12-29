using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameManager : MonoBehaviour
{

    [Header("Terreno")]
    public GameObject player;
    public GameObject painelInicio;
    public GameObject peca1;
    public GameObject peca2;
    public GameObject peca3;
    public GameObject peca4;

    public GameObject[] tiposPecas;
    public int idPeca, posZPecaFinal;
    public Material materialPecas;
    public Color corPecas;
    public float RandR,RandB,RandG;

    [Header("Variaveis do jogo")]
    public static bool inicieiJogo = false;

    [Header("Animacoes do terreno")]
    public Ease tipoEase;





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
        inicieiJogo = true;
        Time.timeScale = 1;
        painelInicio.SetActive(false);
    }
    private void ReiniciarJogo()
    {
        if (Player.playerVivo == false)
        {

            StartCoroutine("DelayReiniciarJogo");
        }
    }

    IEnumerator DelayReiniciarJogo()
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

        if (Player.QtdFinalPeca > 2 && Player.acrescentarPeca)
        {
            Destroy(peca1);
            idPeca = Random.Range(0, tiposPecas.Length);
            posZPecaFinal = posZPecaFinal + 20;
            RandomCorPecas();
            peca4 = Instantiate(tiposPecas[idPeca], new Vector3(0, 0, posZPecaFinal), Quaternion.identity);
            peca4.transform.DOScaleX(1,0.5f).SetEase(tipoEase);
            peca1 = peca2;
            peca2 = peca3;
            peca3 = peca4;
            Player.acrescentarPeca = false;


        }


    }

    public void RandomCorPecas()
    {
        RandR= Random.Range(0f,2f);
        RandG = Random.Range(0f, 2f);
        RandB = Random.Range(0f, 2f);
        corPecas.r = RandR;
        corPecas.g = RandG;
        corPecas.b = RandB;
        materialPecas.SetColor("_Color",corPecas);


    }

   

}

       
    



