using UnityEngine;

public class encher : MonoBehaviour
{
    // Altura máxima que o líquido pode alcançar quando o copo está cheio
    public float alturaMaxima = 1.7f;

    // Velocidade de enchimento do líquido
    public float velocidadeEnchimento = 0.5f;

    // Altura inicial do líquido
    private float alturaInicial;

    // Variável para controlar o enchimento
    private bool enchendo = false;

    void Start()
    {
        // Armazena a altura inicial do líquido
        alturaInicial = 0;
    }

    void Update()
    {
        // Se o copo estiver enchendo e ainda não atingiu a altura máxima
        if (enchendo && (transform.localScale.y < alturaInicial + alturaMaxima))
        {
            Debug.Log("taaaaaaaaaaaaaaaaaa");
            transform.localScale += new Vector3(0, velocidadeEnchimento * Time.deltaTime, 0);
            // Aumenta a posição no eixo Y para simular o enchimento para cima
            transform.localPosition += new Vector3(0, 0, velocidadeEnchimento * Time.deltaTime);
        }
    }

    // Método para iniciar o enchimento
    public void IniciarEnchimento()
    {
        enchendo = true;
    }

    // Método para parar o enchimento
    public void PararEnchimento()
    {
        enchendo = false;
    }
}
