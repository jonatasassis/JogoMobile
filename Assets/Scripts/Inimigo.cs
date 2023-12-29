using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [Header("Variaveis Inimigo")]
    public List<Transform> posicoesInimigo;
    public float cooldownEntrePosicoes,duracao;
    public int posicaoInimigoId=0;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(MovimentacaoInimigo());
    }

    
    IEnumerator MovimentacaoInimigo()
    {
        cooldownEntrePosicoes = 0;
        while (true)
        {
            var posicaoInicialInimigo = transform.position;
            while (cooldownEntrePosicoes< duracao)
            {
                transform.position = Vector3.Lerp(posicaoInicialInimigo, posicoesInimigo[posicaoInimigoId].transform.position,(cooldownEntrePosicoes/duracao));
                cooldownEntrePosicoes += Time.deltaTime;
                yield return null;
            }
            posicaoInimigoId++;

            if (posicaoInimigoId >= posicoesInimigo.Count)
            {
                posicaoInimigoId = 0;
                
                
            }
            cooldownEntrePosicoes = 0;
            yield return null; 
        }
    }
   
   
}
