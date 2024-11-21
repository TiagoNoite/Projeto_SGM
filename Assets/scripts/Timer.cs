using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para mudar de cena
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeToMenu = 600f; // Tempo em segundos antes de ir para o menu
    public string menuSceneName = "Menu inicial"; // Nome da cena do menu principal

    void Start()
    {
        // Inicia a corrotina
        StartCoroutine(GoToMenuAfterDelay());
    }

    IEnumerator GoToMenuAfterDelay()
    {
        // Espera pelo tempo definido
        yield return new WaitForSeconds(timeToMenu);

        // Carrega a cena do menu principal
        SceneManager.LoadScene(menuSceneName);
    }
}
