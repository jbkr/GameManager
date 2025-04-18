using UnityEngine;

public class Gong : MonoBehaviour
{
    private float acceleration = -9.8f;
    private float velocity;
    private float movingSpeed = 3.0f;
    private bool isRight = true;

    enum STATE
    {
        DROP,
        MOVE
    }

    private STATE state;

    private void Start()
    {
        state = STATE.DROP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);

        GameObject explosionEffectRes = Resources.Load<GameObject>("Prefabs/ExplosionEffect");
        GameObject explosionEffectGo = Instantiate(explosionEffectRes);
        explosionEffectGo.transform.position = transform.position;

        GameManager.Instance.Collided();
    }

    private float accTime;
    private int index;

    void Update()
    {
        switch (state)
        {
            case STATE.DROP:
                accTime += Time.deltaTime;
                if (accTime > 1.0f)
                {
                    if (index >= 3)
                    {
                        state = STATE.MOVE;
                        break;
                    }

                    transform.position += new Vector3(0, -0.5f, 0);
                    accTime = 0.0f;
                    index++;
                }
                break;
            case STATE.MOVE:
                velocity += acceleration * Time.deltaTime;
                transform.position += new Vector3(0, velocity * Time.deltaTime, 0);

                if (transform.position.x > 7.7f)
                {
                    isRight = false;
                }
                else if (transform.position.x < -7.7f)
                {
                    isRight = true;
                }

                if (transform.position.y < -3.7f)
                {
                    velocity = Mathf.Abs(velocity);
                }

                if (isRight)
                {
                    Vector3 pos = transform.position;
                    pos.x += Time.deltaTime * movingSpeed;
                    transform.position = pos;
                }
                else
                {
                    Vector3 pos = transform.position;
                    pos.x -= Time.deltaTime * movingSpeed;
                    transform.position = pos;
                }
                break;
            default:
                break;
        }
    }
}
