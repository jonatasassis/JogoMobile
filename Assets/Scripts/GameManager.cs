using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject painelInicio;
    public static bool inicieiJogo=false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        painelInicio.SetActive(true);

    }
    private void Update()
    {
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

    }
}
