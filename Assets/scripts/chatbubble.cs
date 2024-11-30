using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public Color corInicial = Color.green;
    public Color corFinal = Color.red;
    public float duracao = 30.0f;
    private float tempo = 0f;

    private Dictionary<string, string> foodRequests = new Dictionary<string, string>
    {
        { "passa me uma cerverja", "beer" },
        { "corta me ai uns bocados de carne", "carne_sliced" },
        { "tem bolo do caco?", "caco" },
        { "ha para ai ainda cerveja?", "beer" },
        { "ha poncha?", "copo" },
        { "ha algum sumo?", "can" },
        { "tem para ai carne ainda", "carne_sliced" },
        { "quero um bolo no caco", "caco" }
    };

    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;
    private string currentRequest; // Agora é string
    private string currentTags; // Agora é string
    private bool newRequestNeeded = false;

    private void Awake()
    {
        iconSpriteRenderer = transform.Find("timer").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text (TMP)").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        iconSpriteRenderer.color = corInicial;
        GenerateNewRequest();
        newRequestNeeded = true;
    }

    private void Update()
    {
        if (tempo < duracao)
        {
            tempo += Time.deltaTime;
            iconSpriteRenderer.color = Color.Lerp(corInicial, corFinal, tempo / duracao);
        }
        else
        {
            iconSpriteRenderer.color = corFinal;
        }

        if (tempo >= duracao - 0.1f)
        {
            newRequestNeeded = true;
            Debug.Log("new request ta a true");
        }

        if (newRequestNeeded)
        {
            Debug.Log("chegou aqui ao if");
            GenerateNewRequest();
            newRequestNeeded = false;
        }
    }

    private void GenerateNewRequest()
    {
        string newRequest = GetRandomRequest(); // Obtém uma chave aleatória
        currentRequest = newRequest; // Atualiza o pedido atual
        currentTags = foodRequests[newRequest]; // Obtém o valor associado

        Setup(newRequest); // Passa o texto para exibição
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
    }

    public string GetRequestedItem()
    {
        return currentTags; // Retorna o item atual
    }

    public string GetRequestText()
    {
        return currentRequest; // Retorna o texto do pedido
    }

    public float GetTempo()
    {
        return tempo;
    }

    public float GetDuracao()
    {
        return duracao;
    }

    public void SetTempo(float time)
    {
        tempo = time;
    }

    public void SetDuracao(float time)
    {
        if (duracao > 20)
        {
            duracao -= time;
            Debug.Log("Nova duração: " + duracao);
        }
    }

    private string GetRandomRequest()
    {
        List<string> keys = new List<string>(foodRequests.Keys); // Obtém todas as chaves
        int randomIndex = Random.Range(0, keys.Count);
        return keys[randomIndex]; // Retorna uma chave aleatória
    }
}
