using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    public AudioSource audioSource; // Arraste o AudioSource no Inspector
    public AudioClip[] audioClips; // Lista de músicas para tocar
    private int lastClipIndex = -1; // Índice da última música tocada

    void Start()
    {
        // Certifique-se de que o AudioSource e os clipes estão configurados
        if (audioSource == null || audioClips.Length == 0)
        {
            Debug.LogError("AudioSource ou AudioClips não configurados!");
            return;
        }

        // Toca uma música aleatória no início
        PlayRandomClip();
    }

    void Update()
    {
        // Verifica se o áudio terminou
        if (!audioSource.isPlaying)
        {
            PlayRandomClip();
        }
    }

    void PlayRandomClip()
    {
        if (audioClips.Length == 0) return;

        int newClipIndex;

        // Gera um índice aleatório diferente do último tocado
        do
        {
            newClipIndex = Random.Range(0, audioClips.Length);
        } while (newClipIndex == lastClipIndex);

        lastClipIndex = newClipIndex;

        // Define o clipe e toca
        audioSource.clip = audioClips[newClipIndex];
        audioSource.Play();
    }
}