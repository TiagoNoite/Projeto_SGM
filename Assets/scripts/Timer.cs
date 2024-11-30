using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para mudar de cena
using TMPro; // Para trabalhar com TextMeshPro
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeToMenu = 600f; // Tempo em segundos antes de ir para o menu
    public string menuSceneName = "Menu inicial"; // Nome da cena do menu principal
    public TextMeshPro timerText; // Referência ao TextMeshPro para exibir o tempo

    private float currentTime;

    void Start()
    {
        // Inicializa o tempo atual com o tempo definido
        currentTime = timeToMenu;

        // Inicia a corrotina
        StartCoroutine(GoToMenuAfterDelay());
    }

    void Update()
    {
        // Atualiza o tempo restante
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // Atualiza o texto do timer no TextMeshPro
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    IEnumerator GoToMenuAfterDelay()
    {
        // Espera pelo tempo definido
        yield return new WaitForSeconds(timeToMenu);

        // Carrega a cena do menu principal
        SceneManager.LoadScene(menuSceneName);
    }
}
