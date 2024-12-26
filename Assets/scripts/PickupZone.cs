using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    private ChatBubble chatBubble;
    private ScoreManager scoreManager;
    private MovimentoAleatorio movimentoAleatorio;


    // Rastreamento do item entregue
    public GameObject chat;
    public AudioSource audioSource;
    public AudioClip itemReceivedSound;

    private void Start()
    {
       
        movimentoAleatorio = FindObjectOfType<MovimentoAleatorio>();
        if (movimentoAleatorio == null)
            Debug.LogError("MovimentoAleatorio não encontrado na cena!");

        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("ScoreManager não encontrado na cena!");

        if (audioSource == null)
            Debug.LogError("AudioSource não configurado!");
    }

     void OnTriggerStay(Collider other){
         Debug.Log("ta no stay");
     }


    private void OnTriggerEnter(Collider other)
    {
        // Obtém o item esperado
        string expectedItem = chat.GetComponent<ChatBubble>().GetRequestedItem();
      

        // Verifica se o item recebido é o esperado
        if (expectedItem == other.tag)
        {   
             PlayItemReceivedSound();
            Debug.Log($"Item correto entregue: {other.name} ({other.tag})");

            scoreManager.sethighscore(100f);
           
            Debug.Log($"Item {other.tag} foi registrado como entregue.");
           
            other.gameObject.SetActive(false); // Desativa o objeto entregue

            // Processa a entrega
            chat.GetComponent<ChatBubble>().SetTempo(100f);
            chat.GetComponent<ChatBubble>().SetDuracao(0.3f);
            movimentoAleatorio.SetGoPointC(0.03f);

        }
        else
        {
            Debug.Log($"Item incorreto entregue: ({expectedItem}) !==({other.tag})");
        }
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
