using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private int currentIndex;
    private float accTime;

    void Update()
    {
        if (currentIndex >= sprites.Length)
        {
            Destroy(gameObject);
        }

        accTime += Time.deltaTime;
        if (accTime > 0.1f)
        {
            spriteRenderer.sprite = sprites[currentIndex];
            currentIndex++;
            accTime = 0f;
        }
    }
}
