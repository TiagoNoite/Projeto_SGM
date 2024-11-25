using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBeer : MonoBehaviour
{
    public GameObject objetoParaCriar;
    public float rotacaoX = 0f;
    public float rotacaoY = 0f;
    public float rotacaoZ = 0f;

    private List<GameObject> objetosNoTrigger = new List<GameObject>();
    private bool spawnBloqueado = false; // Flag para evitar spawns múltiplos

    private void Start()
    {
        if (objetoParaCriar == null)
        {
            Debug.LogWarning("Por favor, defina um objeto para ser criado no campo 'objetoParaCriar'!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Adiciona o objeto à lista se ele não estiver lá
        if (!objetosNoTrigger.Contains(other.gameObject))
        {
            objetosNoTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
{
    // Remove o objeto da lista quando ele sair
    if (objetosNoTrigger.Contains(other.gameObject))
    {
        objetosNoTrigger.Remove(other.gameObject);
       
    }

    // Inicia a rotina de criação apenas se não houver objetos restantes
    if (objetosNoTrigger.Count == 0 && !spawnBloqueado)
    {
        
        StartCoroutine(CriarObjetoSeVazio());
    }
}

    private IEnumerator CriarObjetoSeVazio()
    {
        spawnBloqueado = true; // Bloqueia novos spawns durante a espera

        yield return new WaitForSeconds(0.5f);

        // Cria o objeto apenas se ainda não houver objetos no trigger
        if (objetosNoTrigger.Count == 0 && objetoParaCriar != null)
        {
            Quaternion rotacaoPersonalizada = Quaternion.Euler(rotacaoX, rotacaoY, rotacaoZ);
            Instantiate(objetoParaCriar, transform.position, rotacaoPersonalizada);
        }

        spawnBloqueado = false; // Libera o bloqueio
    }
}
