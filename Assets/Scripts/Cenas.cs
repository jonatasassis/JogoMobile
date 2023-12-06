using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cenas : MonoBehaviour
{
    public int idLevel;
   

    private void Start()
    {
        
    }
    public void CarregarCena()
    {
        
        SceneManager.LoadScene(idLevel);
    }
}
