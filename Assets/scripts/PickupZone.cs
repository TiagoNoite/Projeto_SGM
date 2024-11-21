using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    // Referência ao componente ChatBubble
    private ChatBubble chatBubble;
    public float time_given =3f;

    // Lista para rastrear os itens entregues
    private List<string> deliveredItems = new List<string>();

    private void Start()
    {
        // Busca o componente ChatBubble na mesma GameObject ou em outro local
        chatBubble = FindObjectOfType<ChatBubble>();
        if (chatBubble == null)
        {
            Debug.LogError("ChatBubble não encontrado na cena!");
        }
    }

    // Este método é chamado quando um objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (chatBubble == null) return;

        // Obtém as tags esperadas
        List<string> expectedTags = chatBubble.GetRequestedItems();

        // Verifica se a tag do objeto está na lista de tags esperadas
        if (expectedTags.Contains(other.tag))
        {
            Debug.Log($"Item correto entregue: {other.name} ({other.tag})");
            if (!deliveredItems.Contains(other.tag))
            {
                deliveredItems.Add(other.tag);
                Debug.Log($"Item {other.tag} foi registrado como entregue.");
            }

            // Desativa o objeto como se tivesse sido entregue
            other.gameObject.SetActive(false);

            // Verifica se todos os itens foram entregues
            if (AllItemsDelivered(expectedTags))
            {
                StartCoroutine(ProcessDelivery());
            }
        }
        else
        {
            Debug.Log($"Item incorreto entregue: {other.name} ({other.tag})");
        }
    }

    // Método para verificar se todos os itens foram entregues
    private bool AllItemsDelivered(List<string> expectedTags)
    {
        foreach (string tag in expectedTags)
        {
            if (!deliveredItems.Contains(tag))
            {
                return false;
            }
        }
        return true;
    }

    // Coroutine para processar o tempo de espera antes de finalizar a entrega
    private IEnumerator ProcessDelivery()
    {
        Debug.Log("Todos os itens entregues! Processando...");
        yield return new WaitForSeconds(time_given); // Tempo de espera de 3 segundos
        Debug.Log("Entrega concluída! Pedido completo.");
        deliveredItems.Clear(); // Reseta a lista para o próximo pedido
    }
}
