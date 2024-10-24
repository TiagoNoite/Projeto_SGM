using UnityEngine;
using System.Collections;

public class MovimentoAleatorio : MonoBehaviour
{
    public Transform pontoA; // Primeiro ponto de destino
    public Transform pontoB; // Segundo ponto de destino
    public Transform pontoC; // Terceiro ponto de destino
    public float velocidade = 2.0f; // Velocidade de movimento do personagem
    public float velocidadeRotacao = 5.0f; // Velocidade da rotação do personagem
    private Transform destinoAtual; // Ponto para onde o personagem está se movendo
    private bool esperando = false; // Verifica se está esperando
    private Animator animator; // Referência ao Animator
    private bool noPontoC = false; // Verifica se está no ponto C
    private bool podeMover = false; // Controla quando a personagem pode se mover

    void Start()
    {
        // Referência ao componente Animator anexado ao personagem
        animator = GetComponent<Animator>();

        // Começa movendo para o ponto A
        destinoAtual = pontoA;
        // Define que o personagem pode se mover inicialmente
        podeMover = true;
    }

    void Update()
    {
        if (podeMover && !noPontoC)
        {
            // Move o personagem em direção ao destino atual
            transform.position = Vector3.MoveTowards(transform.position, destinoAtual.position, velocidade * Time.deltaTime);

            // Atualiza o parâmetro do Animator para "andar"
            animator.SetBool("isWalking", true);

            // Rotaciona o personagem na direção do movimento
            Vector3 direcao = (destinoAtual.position - transform.position).normalized;
            if (direcao != Vector3.zero)
            {
                Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
            }

            // Verifica se o personagem chegou no destino
            if (Vector3.Distance(transform.position, destinoAtual.position) < 0.1f)
            {
                // Verifica se o destino é o ponto C
                if (destinoAtual == pontoC)
                {
                    // Fica indefinidamente no ponto C
                    noPontoC = true;
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    // Inicia a espera antes de definir o próximo destino
                    StartCoroutine(EsperarNoDestino());
                }
                // Para o movimento enquanto espera
                podeMover = false;
            }
        }
    }

    IEnumerator EsperarNoDestino()
    {
        // Atualiza o parâmetro do Animator para "idle"
        animator.SetBool("isWalking", false);

        // Espera por um tempo aleatório entre 1 e 5 segundos
        float tempoDeEspera = 3.0f;
        yield return new WaitForSeconds(tempoDeEspera);

        // Decide o próximo destino: chance de ir para o ponto C
        float chanceIrParaPontoC = 0.3f; // 30% de chance de ir para o ponto C
        if (Random.value < chanceIrParaPontoC)
        {
            destinoAtual = pontoC;
        }
        else
        {
            // Alterna entre o ponto A e B
            destinoAtual = (destinoAtual == pontoA) ? pontoB : pontoA;
        }

        // Define que o personagem pode se mover novamente
        podeMover = true;
    }
}

