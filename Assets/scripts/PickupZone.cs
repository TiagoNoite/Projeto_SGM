using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    // Este método é chamado quando um objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou é o que você quer detectar
        if (other.CompareTag("Pickup"))
        {
            Debug.Log("Objeto entrou na zona de pickup: " + other.name);
            // Aqui você pode adicionar a lógica para pegar o objeto
            PegarObjeto(other.gameObject);
        }
    }

    // Este método é chamado quando um objeto sai do trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Debug.Log("Objeto saiu da zona de pickup: " + other.name);
        }
    }

    // Função para lidar com a lógica de pegar o objeto
    private void PegarObjeto(GameObject objeto)
    {
        // Adicione aqui o que você quer fazer quando o objeto for pego
        // Por exemplo, desativar o objeto ou movê-lo para outra posição
        objeto.SetActive(false);
        Debug.Log("Objeto foi pego: " + objeto.name);
    }
}
