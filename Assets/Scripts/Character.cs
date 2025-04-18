using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Sprite[] idleSprites;

    [SerializeField]
    private Sprite[] moveSprites;

    private SpriteRenderer spriteRenderer;
    private float movingSpeed = 5.0f;

    enum STATE
    {
        IDLE,
        MOVE,
    }

    private STATE state = STATE.IDLE;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private int currentIndex;
    private float accTime;

    void Animation(Sprite[] sprites)
    {
        accTime += Time.deltaTime;
        if (accTime > 0.1)
        {
            spriteRenderer.sprite = sprites[currentIndex];
            currentIndex++;
            accTime = 0f;
        }
        if (currentIndex > sprites.Length - 1)
        {
            currentIndex = 0;
        }
    }

    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                Animation(idleSprites);
                break;
            case STATE.MOVE:
                Animation(moveSprites);
                break;
            default:
                break;
        }

        MoveInput();
    }

    void MoveInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * movingSpeed;
            spriteRenderer.flipX = true;
            state = STATE.MOVE;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * movingSpeed;
            spriteRenderer.flipX = false;
            state = STATE.MOVE;
        }
        else
        {
            state = STATE.IDLE;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletRes = Resources.Load<GameObject>("Prefabs/Bullet");
            GameObject bulletGo = Instantiate(bulletRes);
            bulletGo.transform.position = transform.position + new Vector3(0, 0.1f, 0);
        }
    }

}
