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
        { "corta me ai uns bocados de carne para comer", new List<string> { "carne" } },
        { "cota me ai uns bocados de carne para comer", new List<string> { "carne" } },
        { "tem bolo do caco?", new List<string> { "caco" } },
        { "ha para ai ainda cerveja?", new List<string> { "beer" } },
        { "ha poncha?", new List<string> { "copo" } },
        { "quero carne e um bolo no caco", new List<string> { "caco", "carne" } }
    };

    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;
    private string randomRequest;
    private List<string> currentTags;
    private bool newfrase= false;

    private void Awake()
    {
        iconSpriteRenderer = transform.Find("timer").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text (TMP)").GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        iconSpriteRenderer.color = corInicial;
        randomRequest = GetRandomRequest();
        currentTags = foodRequests[randomRequest];
        Setup(randomRequest);
        newfrase= false;
    }


    void Update()
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
        if(newfrase){
            Reconfiguerfrase();
            newfrase=false;
        }
        
    }

    private void Reconfiguerfrase(){

        randomRequest = GetRandomRequest();
        currentTags = foodRequests[randomRequest];
        Setup(randomRequest);
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
        return randomRequest;
    }

    public float GetTempo()
    {
        return tempo;
    }

    public float Getduracao()
    {
        return duracao;
    }

    public void SetTempo(float time)
    {
        tempo = time;
    }

    public void SetDuraçao(float time)
    {
        if(duracao>20){
            duracao =duracao- time;
            Debug.Log("a duraçao ta a "+duracao);
        }
        
    }

    private string GetRandomRequest()
    {
        List<string> keys = new List<string>(foodRequests.Keys);

        // Gerar uma semente única com base no tempo e ID do objeto
        int seed = System.DateTime.Now.Millisecond + gameObject.GetInstanceID();
        System.Random random = new System.Random(seed);

        int randomIndex = random.Next(0, keys.Count);
        return keys[randomIndex];
    }
    public void Setnewfrase(bool value){
        newfrase=value;
    }
}
