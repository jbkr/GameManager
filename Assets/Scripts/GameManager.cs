using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{
    public void Collided()
    {
        UIManager.Instance.CollidedUI();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        UIManager.Instance.CreateStartUI();
    }

    private float accTime;
    private int index;

    void Update()
    {
        accTime += Time.deltaTime;
        if (accTime >= 1.0f)
        {
            accTime = 0f;
            index++;
        }
    }

    public void LoadTimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync("GameScene");

        GameObject characterRes = Resources.Load<GameObject>("Prefabs/Character");
        GameObject characterGo = Instantiate(characterRes);
        characterGo.transform.position = new Vector3(0, -3.2f, 0);

        GameObject gongRes = Resources.Load<GameObject>("Prefabs/Gong");
        GameObject gongGo = Instantiate(gongRes);

        gongGo.transform.position = new Vector3(0, 4.5f, 0);

        UIManager.Instance.CreateScoreUI();
    }
}
