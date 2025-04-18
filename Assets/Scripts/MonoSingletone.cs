using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instace;

    public static T Instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = FindAnyObjectByType<T>(); // ���� �����ϴ� ���� T�� �ִ��� Ȯ�� 

                if (_instace == null)
                {
                    GameObject go = new GameObject("Singletone " + typeof(T).ToString());
                    _instace = go.AddComponent<T>();

                }

                DontDestroyOnLoad(_instace.gameObject);
            }

            return _instace;

        }
    }

}