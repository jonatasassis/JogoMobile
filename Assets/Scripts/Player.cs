using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Vector2 posInicial;
    public  float velocidadeX=0.1f,velocidadeZ,velocidadeZTotal;
    public GameObject player;
    public static bool playerVivo;

    [Header("PowerUps")]

    public int adicionalVelocidade,duracaoPowerUpVelocidade;
    public int duracaoPowerUpInvencibilidade;
    public bool ativarPowerUpVelocidade,ativarPowerUpInvencibilidade;
    public  bool estouInvencivel;
    public Material[] materialEfeito;

    // Start is called before the first frame update
    void Start()
    {
        playerVivo = true;
        estouInvencivel = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        AtivarPowerUps();
        velocidadeZTotal = velocidadeZ + adicionalVelocidade;
        if (playerVivo==true)
        {
            player.transform.Translate(transform.forward * (velocidadeZTotal) * Time.deltaTime);
            if (Input.GetMouseButton(0))
            {
                Movimentacao(Input.mousePosition.x - posInicial.x);
            }
            posInicial = Input.mousePosition;
        }
    }

    public void Movimentacao(float forcaMovimentacao)
    {
        transform.position += Vector3.right * Time.deltaTime*forcaMovimentacao*velocidadeX;
    }

    public void AtivarPowerUps()
    {
        if (ativarPowerUpVelocidade == true)

        {
            adicionalVelocidade = 10;
            player.GetComponent<Renderer>().material = materialEfeito[1];
            duracaoPowerUpVelocidade--;
            if (duracaoPowerUpVelocidade > 0)
            {
                adicionalVelocidade = 10;
            }
            else
            {
                adicionalVelocidade = 0;
                player.GetComponent<Renderer>().material = materialEfeito[0];
                duracaoPowerUpVelocidade = 20;
                ativarPowerUpVelocidade = false;
            }

        }

        //powerUp invencibilidade
        else if (ativarPowerUpInvencibilidade)
        {
            
            player.GetComponent<Renderer>().material = materialEfeito[2];
            duracaoPowerUpInvencibilidade--;
            if (duracaoPowerUpInvencibilidade <= 0)
            {
                ativarPowerUpInvencibilidade = false;
                player.GetComponent<Renderer>().material = materialEfeito[0];
            }
        }
        

    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Inimigo"&& ativarPowerUpInvencibilidade==false)
        {

            playerVivo = false;
            print("morri");


        }
        else if (collision.tag == "powerUPVelocidade")
        {

            ativarPowerUpVelocidade = true;
            print("aumentar velocidade");


        }
        else if (collision.tag == "powerUPInvencibilidade")
        {

            ativarPowerUpInvencibilidade = true;
            print("aumentar velocidade");


        }

    }
}
