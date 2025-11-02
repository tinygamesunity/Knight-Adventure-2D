using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class TransprencyDetection : MonoBehaviour
{

    [Range(0f, 1f)]
    [SerializeField] private float transparencyAmount = 0.8f;
    [SerializeField] private float fadeTime = 0.5f;

    SpriteRenderer _spriteRenderer;

    private float fullNonTransparencyValue = 1.0f;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision is CapsuleCollider2D)
                StartCoroutine(FadeRoutine(_spriteRenderer, fadeTime, _spriteRenderer.color.a, transparencyAmount));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision is CapsuleCollider2D)
                StartCoroutine(FadeRoutine(_spriteRenderer, fadeTime, _spriteRenderer.color.a, fullNonTransparencyValue));
        }
    }


    private IEnumerator FadeRoutine(SpriteRenderer spriteRenderer, float fadeTime, float startTransparencyAmount, float targetTransparencyAmount)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startTransparencyAmount, targetTransparencyAmount, elapsedTime / fadeTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);

            yield return null;
        }
    }
    


}
