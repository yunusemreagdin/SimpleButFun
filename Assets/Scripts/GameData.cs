using UnityEngine;

//Basit bir state machine kontrolu ile Oyun Basladi mı ? Bitti mi ? Oyunda mıyım ? durumlarını kontrol ediyorum.
public enum State
{
    State_Before_Start,
    State_In_Game,
    State_End_Game
}
public class GameData : MonoBehaviour
{
    #region Singleton

    private static GameData instance = null;

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameData>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SingletonController";
                    instance = go.AddComponent<GameData>();
                    DontDestroyOnLoad(go);
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private GameData()
    {
        
    }


    #endregion

    #region Variables

    private int _gold;
    private State _currentState = State.State_Before_Start;
    private int currentLevel = 0;

    #endregion


    #region Setters

    public void Set_Gold(int _gold)
    {
        this._gold = _gold;
    }
    public void Set_CurrentState(State _currentState)
    {
        this._currentState = _currentState;
    }

    #endregion

    #region Getters

    public int Get_Gold()
    {
        return _gold;
    }
    
    public State Get_CurrentState()
    {
        return _currentState;
    }
    public int Get_Level()
    {
        return currentLevel;
    }

    #endregion
   
    
   
}
