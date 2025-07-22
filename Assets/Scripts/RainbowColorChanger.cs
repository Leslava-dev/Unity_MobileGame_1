using UnityEngine;
using System.Collections;

public class RainbowColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;        // змінюю колір для цього об'єкту
    [SerializeField] private float colorChangeSpeed = 1f;    // із цією швидкістю буду змінювати колір

    private void Start()
    {
        if (targetRenderer != null)
        {
            StartCoroutine(ChangeColorOverTime()); // старт корутини
        }
    }

    private IEnumerator ChangeColorOverTime()
    {
        float hue = 0f; //від 0 до 1 весь спектр кольорів

        while (true)
        {
            hue += Time.deltaTime * colorChangeSpeed; //тут задам швидкість із якою буде змінюватися колір
            if (hue > 1f) hue -= 1f; //якщо перевищить 1 hue - відніму 1 і повернуся на початок веселки

            Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f); //1f повна насиченість та яскравість
            targetRenderer.material.color = rainbowColor; //змінюємо колір

            yield return null; //пауза для корутинки на 1 кадр
        }
    }
}
