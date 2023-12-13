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
    public float velocidadeX = 0.1f;
    public float velocidadeZ;
    public float velocidadeZTotal;
    public float alturaTotal;
    public GameObject player;
    public static bool playerVivo;
    public float posYInicial;
    public Animator anim;

    [Header("PowerUpVelocidade")]
    public int adicionalVelocidade;
    public int duracaoPowerUpVelocidade;
    private bool ativarPowerUpVelocidade;

   [Header("PowerUpInvencibilidade")]
    public int duracaoPowerUpInvencibilidade;
    public bool ativarPowerUpInvencibilidade;

    [Header("PowerUpVoo")]
    public int duracaoPowerUpVoo;
    public Ease ease;
    public float posYVoo;
    public float duracaoAnimacaoVoo;
    public bool ativarPowerUpVoo;

    [Header("PowerUpColetor")]
    public bool ativarPowerUpColetor;
    public GameObject powerUpColetor;
    public float duracaoAnimacaoPowerUpColetor;
    public int duracaoPowerUpColetor;

    [Header("UIPlayer")]
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
        anim.Play("ANIM_Astronaut_Idle");



    }

    // Update is called once per frame
    void Update()
    {
        AtivarPowerUps();
        velocidadeZTotal = velocidadeZ + adicionalVelocidade;
        
        if (playerVivo==true && GameManager.inicieiJogo)
        {
           
            player.transform.Translate(transform.forward * (velocidadeZTotal) * Time.deltaTime);
            anim.Play("ANIM_Astronaut_Run");
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
        //powerUp velocidade
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

        //powerUp voo
        else if (ativarPowerUpVoo)
        {
            powerUPText.text = "Voar";
            player.transform.DOMoveY(posYVoo,duracaoAnimacaoVoo).SetEase(ease);
            player.GetComponent<Renderer>().material = powerUPMaterial[3];
            duracaoPowerUpVoo--;

            if (duracaoPowerUpVoo <= 0)
            {
                powerUPText.text = "";
                player.transform.DOMoveY(posYInicial, duracaoAnimacaoVoo).SetEase(ease);
                ativarPowerUpVoo = false;
                player.GetComponent<Renderer>().material = powerUPMaterial[0];
            }
        }

        //powerUp coletor
        else if (ativarPowerUpColetor)
        {
            powerUPText.text = "Imã de moedas";
            powerUpColetor.transform.DOScale(new Vector3(8,1,1),0);
            player.GetComponent<Renderer>().material = powerUPMaterial[4];
            duracaoPowerUpColetor--;

            if (duracaoPowerUpColetor <= 0)
            {
                powerUpColetor.transform.DOScale(new Vector3(1, 1, 1), 0);
                powerUPText.text = "";
                ativarPowerUpColetor = false;
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
            anim.Play("ANIM_Astronaut_Death");
            transform.DOMoveZ(-1f,0.5f).SetRelative();


        }
        else if (collision.tag == "powerUPVelocidade")
        {

            ativarPowerUpVelocidade = true;
            print("aumentar velocidade");


        }
        else if (collision.tag == "powerUPInvencibilidade")
        {

            ativarPowerUpInvencibilidade = true;
            print("estou invencivel");


        }
        else if (collision.tag == "powerUPVoo")
        {

            ativarPowerUpVoo = true;
            print("estou voando");


        }

        else if (collision.tag == "powerUPColetor")
        {

            ativarPowerUpColetor = true;
            print("Ima de moedas Ativado");


        }


    }
}
