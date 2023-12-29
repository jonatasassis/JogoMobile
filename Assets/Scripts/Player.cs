using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public Vector2 posInicial;
    public float velocidadeX = 0.1f;
    public float velocidadeZ;
    public float velocidadeZTotal;
    public float alturaTotal;
    public GameObject[] indicadorPowerUp;
    public GameObject player;
    public static bool playerVivo;
    public float posYInicial;
    public Animator anim;
    public float acrescimoTamanhoplayer,reposicionarPosicaoY;

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
    public static int QtdFinalPeca;
    public static bool acrescentarPeca=false;



    // Start is called before the first frame update
    void Start()
    {
        playerVivo = true;
        ativarPowerUpInvencibilidade= false;
        ativarPowerUpVelocidade= false;
        adicionalVelocidade = 0;
        anim.Play("ANIM_Astronaut_Idle");
        StartCoroutine(DelaySpawn());


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            ativarPowerUpVoo = true;
        }
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
            for (int x = 0; x < indicadorPowerUp.Length; x++)
            {
                indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[1];
            }  
            duracaoPowerUpVelocidade--;
            adicionalVelocidade = 20;

            if(duracaoPowerUpVelocidade<=0)
            {  
                adicionalVelocidade = 0;
                for (int x = 0; x < indicadorPowerUp.Length; x++)
                {
                    indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[0];
                }
                duracaoPowerUpVelocidade = 20;
                ativarPowerUpVelocidade = false;
            }
        }

        //powerUp invencibilidade
        else if (ativarPowerUpInvencibilidade)
        {          
            for (int x = 0; x < indicadorPowerUp.Length; x++)
            {
                indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[2];
            }
            duracaoPowerUpInvencibilidade--;

            if (duracaoPowerUpInvencibilidade <= 0)
            {               
                ativarPowerUpInvencibilidade = false;
                duracaoPowerUpInvencibilidade = 130;

                for (int x = 0; x < indicadorPowerUp.Length; x++)
                {
                    indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[0];
                }
            }
        }

        //powerUp voo
        else if (ativarPowerUpVoo)
        {
           
            player.transform.DOMoveY(posYVoo,duracaoAnimacaoVoo).SetEase(ease);
            for (int x = 0; x < indicadorPowerUp.Length; x++)
            {
                indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[3];
            }
            duracaoPowerUpVoo--;

            if (duracaoPowerUpVoo <= 0)
            {               
                player.transform.DOMoveY(posYInicial, duracaoAnimacaoVoo);
                ativarPowerUpVoo = false;
                duracaoPowerUpVoo = 50;
                for (int x = 0; x < indicadorPowerUp.Length; x++)
                {
                    indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[0];
                }
            }
        }

        //powerUp coletor
        else if (ativarPowerUpColetor)
        {          
            powerUpColetor.transform.DOScale(new Vector3(8,1,1),0);
            for (int x = 0; x < indicadorPowerUp.Length; x++)
            {
                indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[4];
            }
            duracaoPowerUpColetor--;

            if (duracaoPowerUpColetor <= 0)
            {
                powerUpColetor.transform.DOScale(new Vector3(1, 1, 1), 0);     
                ativarPowerUpColetor = false;
                duracaoPowerUpColetor = 100;
                for (int x = 0; x < indicadorPowerUp.Length; x++)
                {
                    indicadorPowerUp[x].GetComponent<Renderer>().material = powerUPMaterial[0];
                }
            }
        }

       
    }
    public void Bounce ()
    {
        player.transform.DOScale(2, 0.1f).SetLoops(2, LoopType.Yoyo);
        player.transform.DOMoveY(1, 0.1f);
        StartCoroutine(DelaySpawn());
        
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
            Bounce();
            ativarPowerUpVelocidade = true;
            print("aumentar velocidade");

        }

        else if (collision.tag == "powerUPInvencibilidade")
        {
            Bounce();
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
            Bounce();
            ativarPowerUpColetor = true;
            print("Ima de moedas Ativado");
        }

        else if (collision.tag == "finalPeca")
        {

            QtdFinalPeca++;
            acrescentarPeca = true;


        }
        

    }
    IEnumerator DelaySpawn()
    {

        yield return new WaitForSeconds(0.3f);
        player.transform.DOScale(1, 0.3f);
        player.transform.DOMoveY(0, 0.2f);

    }
}
