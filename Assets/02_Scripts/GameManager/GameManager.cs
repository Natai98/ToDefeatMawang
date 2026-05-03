using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("플레이어 정보")]
    public GameObject player;
    public string playerName;
    public int money;

    [Header("InputSystem 정보")]
    public PlayerControls controls;

    [Header("Stat 정보")]
    public float hp;
    public float maxHp;
    public float mp;
    public float maxMp;
    public float def;
    public float atk;

    private void Start()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
        InitialStat();
        player = this.gameObject;
    }

    private void InitialStat()
    {
        hp = 20f;
        maxHp = 20f;
        mp = 10f;
        maxMp = 10f;
        def = 0f;
        atk = 1.0f;
    }

    void OnEnable()
    {
        if(controls != null) controls.Player.Enable();
    }

    void OnDisable()
    {
        if(controls != null) controls.Player.Disable();
    }

}
