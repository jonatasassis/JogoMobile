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

    [Header("PowerUp")]

    public int adicionalVelocidade,duracaoPowerUpVelocidade;
    public bool ativarPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        playerVivo = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpVelocidade();
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

    public void PowerUpVelocidade()
    {
        if (ativarPowerUp == true)
        {
            adicionalVelocidade = 10;
            duracaoPowerUpVelocidade--;
            if (duracaoPowerUpVelocidade > 0)
            {
                adicionalVelocidade = 10;
            }
            else
            {
                adicionalVelocidade = 0;
                duracaoPowerUpVelocidade = 20;
                ativarPowerUp = false;
            }
        }
        

    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Inimigo")
        {

            playerVivo = false;
            print("morri");


        }
        else if (collision.tag == "powerUp")
        {

            ativarPowerUp = true;
            print("aumentar velocidade");


        }

    }
}
