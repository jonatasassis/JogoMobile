using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Vector2 posInicial;
    public  float velocidadeX=0.1f,velocidadeZ,velocidadeZTotal,alturaTotal;
    public GameObject player;
    public static bool playerVivo;
    public float posYInicial;

    [Header("PowerUps")]

    public int adicionalVelocidade,duracaoPowerUpVelocidade;
    public int duracaoPowerUpInvencibilidade;
    public int duracaoPowerUpVoo;
    public Ease ease;
    public float posYVoo, duracaoAnimacaoVoo;
    private bool ativarPowerUpVelocidade,ativarPowerUpInvencibilidade, ativarPowerUpVoo;
    public Material[] powerUPMaterial;
    public TextMeshProUGUI powerUPText;

    // Start is called before the first frame update
    void Start()
    {
        playerVivo = true;
        ativarPowerUpInvencibilidade= false;
        ativarPowerUpVelocidade= false;
        powerUPText.text = "";
        adicionalVelocidade = 0;


        
       
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
        if (ativarPowerUpVelocidade)

        {
            powerUPText.text = "Velocidade";
            adicionalVelocidade = 10;
            player.GetComponent<Renderer>().material = powerUPMaterial[1];
            duracaoPowerUpVelocidade--;
            if (duracaoPowerUpVelocidade > 0)
            {
                adicionalVelocidade = 10;
            }
            else
            {
                powerUPText.text = "";
                adicionalVelocidade = 0;
                player.GetComponent<Renderer>().material = powerUPMaterial[0];
                duracaoPowerUpVelocidade = 20;
                ativarPowerUpVelocidade = false;
            }

        }

        //powerUp invencibilidade
        else if (ativarPowerUpInvencibilidade)
        {
            powerUPText.text = "Invencibilidade";
            player.GetComponent<Renderer>().material = powerUPMaterial[2];
            duracaoPowerUpInvencibilidade--;
            if (duracaoPowerUpInvencibilidade <= 0)
            {
                powerUPText.text = "";
                ativarPowerUpInvencibilidade = false;
                player.GetComponent<Renderer>().material = powerUPMaterial[0];
            }
        }

        else if (ativarPowerUpVoo)
        {
            powerUPText.text = "Voar";
            player.transform.DOMoveY(posYVoo,duracaoAnimacaoVoo).SetEase(ease);
            //player.transform.position = new Vector3(player.transform.position.x,posYVoo, player.transform.position.z);
            player.GetComponent<Renderer>().material = powerUPMaterial[3];
            duracaoPowerUpVoo--;
            if (duracaoPowerUpVoo <= 0)
            {
                powerUPText.text = "";
                player.transform.DOMoveY(posYInicial, duracaoAnimacaoVoo).SetEase(ease);
                //player.transform.position = new Vector3(player.transform.position.x, 0.9f, player.transform.position.z);
                ativarPowerUpVoo = false;
                player.GetComponent<Renderer>().material = powerUPMaterial[0];
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
        else if (collision.tag == "powerUPVoo")
        {

            ativarPowerUpVoo = true;
            print("aumentar velocidade");


        }


    }
}
