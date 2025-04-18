using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private float movingSpeed = 5;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private int currentIndex;
    private float accTime;

    void Update()
    {
        if (transform.position.y > 7.0f)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.up * Time.deltaTime * movingSpeed;


        accTime += Time.deltaTime;
        if (accTime > 0.1)
        {
            spriteRenderer.sprite = sprites[currentIndex];
            currentIndex++;
            accTime = 0f;
        }

        if (currentIndex >= sprites.Length)
        {
            currentIndex = 0;
        }

    }
}
