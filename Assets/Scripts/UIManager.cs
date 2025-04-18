using UnityEngine;

public class UIManager : MonoSingletone<UIManager>
{
    public void CollidedUI()
    {
        scoreUI.Score();
    }

    private ScoreUI scoreUI;
    private GameObject startUIGo;
    private GameObject modeUIGo;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CreateStartUI()
    {
        GameObject startUIRes = Resources.Load<GameObject>("Prefabs/StartUI");
        startUIGo = Instantiate(startUIRes, transform, false);

        StartUI startUI = startUIGo.GetComponent<StartUI>();
        startUI.AddStartButtonEvent(OnClickStartButton);
    }

    void OnClickStartButton()
    {
        Destroy(startUIGo);

        CreateModeUI();
    }

    void CreateModeUI()
    {
        GameObject modeUIRes = Resources.Load<GameObject>("Prefabs/ModeUI");
        modeUIGo = Instantiate(modeUIRes, transform, false);
        ModeUI modeUI = modeUIGo.GetComponent<ModeUI>();
        modeUI.AddTimeAttackEvent(OnClickTimeAttackButton);
        modeUI.AddStageModeEvent(OnClickStageModeButton);
    }

    public void CreateScoreUI()
    {
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefabs/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, transform, false);
        scoreUI = scoreUIGo.GetComponent<ScoreUI>();
    }


    void OnClickTimeAttackButton()
    {
        Destroy(modeUIGo);
        GameManager.Instance.LoadTimeAttackMode();
    }

    void OnClickStageModeButton()
    {

    }
}
