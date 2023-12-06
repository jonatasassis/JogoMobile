using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject painelInicio;
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
        Time.timeScale = 1;
        painelInicio.SetActive(false);
    }
    private void ReiniciarJogo()
    {
        if (Player.playerVivo == false)
        {
            Time.timeScale = 0;
            painelInicio.SetActive(true);
            SceneManager.LoadScene(0);

        }
    }

}