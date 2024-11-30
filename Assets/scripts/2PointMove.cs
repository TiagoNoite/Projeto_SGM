using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform pontoA; // Ponto inicial
    public Transform pontoB; // Ponto final
    public float velocidade = 2.0f; // Velocidade de movimento
    public float velocidadeRotacao = 5.0f; // Velocidade de rotação

    private Transform destinoAtual; // Ponto de destino
    private Animator animator; // Referência ao Animator

    void Start()
    {
        destinoAtual = pontoA; // Começar indo para o ponto A
        animator = GetComponent<Animator>(); // Obter o Animator, se existir
    }

    void Update()
    {
        MoverParaDestino(); // Movimenta-se continuamente entre os pontos
    }

    private void MoverParaDestino()
    {
        // Move o objeto em direção ao destino
        transform.position = Vector3.MoveTowards(transform.position, destinoAtual.position, velocidade * Time.deltaTime);

        // Ativa a animação de andar, se existir
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }

        // Calcula a direção para rotacionar suavemente
        Vector3 direcao = (destinoAtual.position - transform.position).normalized;
        if (direcao != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
        }

        // Verifica se chegou ao destino
        if (Vector3.Distance(transform.position, destinoAtual.position) < 0.1f)
        {
            AlternarDestino(); // Troca o ponto de destino
        }
    }

    private void AlternarDestino()
    {
        // Alterna entre ponto A e ponto B
        destinoAtual = (destinoAtual == pontoA) ? pontoB : pontoA;

        // Para a animação de andar temporariamente
        if (animator != null)
        {
            animator.SetBool("isWalking", false);
        }
    }
}