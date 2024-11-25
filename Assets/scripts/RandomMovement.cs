using UnityEngine;
using System.Collections;

public class MovimentoAleatorio : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public Transform pontoC;
    public Transform looking;
    public float velocidade = 2.0f;
    public float velocidadeRotacao = 5.0f;
    private Transform destinoAtual;
    private bool noPontoC = false;
    private bool podeMover = false;
    public string tagDoFilho = "chat";

    private float GoPointC=0.70f;

    private Animator animator;
    private ChatBubble chatBubble;

    void Start()
    {
        chatBubble = GetComponentInChildren<ChatBubble>();

        if (chatBubble == null)
        {
            Debug.LogError("ChatBubble não encontrado para o cliente!");
        }

        animator = GetComponent<Animator>();
        destinoAtual = pontoA;
        podeMover = true;
    }

    void Update()
    {
        if (podeMover && !noPontoC)
        {
            MoverParaDestino();
        }

        if (noPontoC)
        {
            
            chatBubble = GetComponentInChildren<ChatBubble>();

            GirarParaOlhar(looking);

            if (chatBubble.GetTempo() >= chatBubble.GetDuracao())
            {
                ResetarCliente();
            }
        }
    }

    private void MoverParaDestino()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinoAtual.position, velocidade * Time.deltaTime);
        animator.SetBool("isWalking", true);

        Vector3 direcao = (destinoAtual.position - transform.position).normalized;
        if (direcao != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, velocidadeRotacao * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, destinoAtual.position) < 0.1f)
        {
            if (destinoAtual == pontoC)
            {
                noPontoC = true;
                AtivarFilhoPorTag();
                animator.SetBool("isWalking", false);
            }
            else
            {
                StartCoroutine(EsperarNoDestino());
            }
            podeMover = false;
        }
    }

    private void GirarParaOlhar(Transform target)
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void ResetarCliente()
    {
        chatBubble.SetTempo(0);
        DestivarFilhoPorTag();
        noPontoC = false;
        podeMover = true;
        animator.SetBool("isWalking", true);

        destinoAtual = (Random.value < 0.5f) ? pontoA : pontoB;
    }

    IEnumerator EsperarNoDestino()
    {
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(3.0f);

        if (Random.value < GoPointC)
        {
            destinoAtual = pontoC;
        }
        else
        {
            destinoAtual = (destinoAtual == pontoA) ? pontoB : pontoA;
        }

        podeMover = true;
    }

    private void AtivarFilhoPorTag()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag(tagDoFilho))
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void DestivarFilhoPorTag()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag(tagDoFilho))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void SetGoPointC(float value){
         if(GoPointC<50){
            GoPointC = GoPointC + value;
            Debug.Log("A rpobabildade ta a  " + GoPointC);
        }
    }
}
