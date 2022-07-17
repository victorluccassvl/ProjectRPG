using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null) Debug.LogError("Singleton " + typeof(T).ToString() + " not found.");
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<T>();
        }
        else
        {
            Destroy(this);
        }
    }
}
