using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    private ChatBubble chatBubble;
    private ScoreManager scoreManager;
    private MovimentoAleatorio movimentoAleatorio;
    public float time_given = 3f;

    // Rastreamento do item entregue
    private string deliveredItem = null;

    public AudioSource audioSource;
    public AudioClip itemReceivedSound;

    private void Start()
    {
        chatBubble = FindObjectOfType<ChatBubble>();
        if (chatBubble == null)
            Debug.LogError("ChatBubble não encontrado na cena!");

        movimentoAleatorio = FindObjectOfType<MovimentoAleatorio>();
        if (movimentoAleatorio == null)
            Debug.LogError("MovimentoAleatorio não encontrado na cena!");

        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("ScoreManager não encontrado na cena!");

        if (audioSource == null)
            Debug.LogError("AudioSource não configurado!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item entrou no collider.");
        if (chatBubble == null) return;

        // Obtém o item esperado
        string expectedItem = chatBubble.GetRequestedItem();
        Debug.Log($"Item esperado: {expectedItem}, Item recebido: {other.tag}");

        // Verifica se o item recebido é o esperado
        if (expectedItem == other.tag)
        {
            Debug.Log($"Item correto entregue: {other.name} ({other.tag})");

            if (deliveredItem != other.tag) // Verifica se o item já não foi entregue
            {
                deliveredItem = other.tag;
                scoreManager.sethighscore(100f);
                PlayItemReceivedSound();
                Debug.Log($"Item {other.tag} foi registrado como entregue.");
            }

            other.gameObject.SetActive(false); // Desativa o objeto entregue

            // Processa a entrega
            StartCoroutine(ProcessDelivery());
        }
        else
        {
            Debug.Log($"Item incorreto entregue: {other.name} ({other.tag})");
        }
    }

    private IEnumerator ProcessDelivery()
    {
        yield return new WaitForSeconds(time_given);
        Debug.Log("Entrega concluída! Pedido completo.");
        chatBubble.SetTempo(100f);
        chatBubble.SetDuracao(0.3f);
        movimentoAleatorio.SetGoPointC(0.03f);
        deliveredItem = null; // Reseta o item para o próximo pedido
    }

    private void PlayItemReceivedSound()
    {
        if (audioSource != null && itemReceivedSound != null)
        {
            audioSource.PlayOneShot(itemReceivedSound);
        }
        else
        {
            Debug.LogWarning("AudioSource ou itemReceivedSound não configurados!");
        }
    }
}
