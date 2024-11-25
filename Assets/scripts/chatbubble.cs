using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    public Color corInicial = Color.green;
    public Color corFinal = Color.red;
    public float duracao = 30.0f;
    private float tempo = 0f;

    private Dictionary<string, List<string>> foodRequests = new Dictionary<string, List<string>>
    {
        { "passa me uma cerverja", new List<string> { "beer" } },
        { "corta me ai uns bocados de carne para comer", new List<string> { "carne_sliced" } },
        { "tem bolo do caco?", new List<string> { "caco" } },
        { "ha para ai ainda cerveja?", new List<string> { "beer" } },
        { "ha poncha?", new List<string> { "copo" } },
        { "ha algum sumo?", new List<string> { "can" } },
        { "quero carne e um bolo no caco", new List<string> { "caco", "carne_sliced" } }
    };

    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;
    private string currentRequest;
    private List<string> currentTags;
    private bool newRequestNeeded = false;

    private string lastRequest;

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

        if (tempo <= duracao)
        {
            tempo += Time.deltaTime;
            iconSpriteRenderer.color = Color.Lerp(corInicial, corFinal, tempo / duracao);
        }
        else
        {
            iconSpriteRenderer.color = corFinal;
            newRequestNeeded = true;
            Debug.Log("new request ta a true");
        }

        if (newRequestNeeded)
        {
            Debug.Log("ola chegou aqui");
            GenerateNewRequest();
            newRequestNeeded = false;
        }
    }

    private void GenerateNewRequest()
    {
        // Gera um novo pedido aleatório
        string newRequest;
        do
        {
            newRequest = GetRandomRequest();
        } while (newRequest == lastRequest); // Evita repetição imediata

        Debug.Log("ola chegou ao GenerateNewRequest");
        lastRequest = newRequest; // Atualiza o último pedido
        currentRequest = newRequest;
        currentTags = foodRequests[newRequest];

        
        textMeshPro = transform.Find("Text (TMP)").GetComponent<TextMeshPro>();

        Setup(newRequest);
        tempo = 0; // Reseta o tempo
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
    }

    public List<string> GetRequestedItems()
    {
        return currentTags;
    }

    public string GetRequestText()
    {
        return currentRequest;
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
        List<string> keys = new List<string>(foodRequests.Keys);
        int randomIndex = Random.Range(0, keys.Count);
        return keys[randomIndex];
    }
}