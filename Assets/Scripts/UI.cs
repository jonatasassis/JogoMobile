using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI : MonoBehaviour
{
    public TextMeshProUGUI qtdMoedasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        qtdMoedasText.text = "" + Coletaveis.qtdMoedas;
    }
}
