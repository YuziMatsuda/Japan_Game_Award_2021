using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// ãƒ—ãƒ¬ã‚¤ãƒ¤ãƒ¼ãƒ‡ãƒ¼ã‚¿ç®¡ç†ã‚¹ã‚¯ãƒªãƒ—ãƒˆã‚¯ãƒ©ã‚¹
/// </summary>
[System.Serializable]
public class Player_Data_Main : MonoBehaviour
{
    public string datapath;

<<<<<<< HEAD:Morumotto_ Wheerun/Assets/main_scene/Scripts/Player_Data_Main.cs
    [SerializeField] public bool[] stage_clear_number;   // ã‚¯ãƒªã‚¢å–å¾—
=======
    [SerializeField] public bool[] stage_clear_number;                      // ƒNƒŠƒAæ“¾
    [SerializeField] public int max_stage;
    [SerializeField] public bool delete_start;                              // ƒf[ƒ^íœŠJn

    [SerializeField] private GameObject[] clear = new GameObject[5];        // ƒNƒŠƒA[
    [SerializeField] private GameObject[] clear_prefab = new GameObject[5]; // ƒNƒŠƒA[—p‚ÌƒvƒŒƒnƒu
    [SerializeField] private GameObject canvas;                             // ƒLƒƒƒ“ƒoƒX

    [SerializeField] private float criteria_log_pos_x;                      // ƒNƒŠƒAƒƒS‚ÆÔ˜g‚ğ•\¦‚·‚éŠî€‚ÌX²
    [SerializeField] private float move_log_pos_x;                          // ƒNƒŠƒAƒƒS‚ÆÔ˜g‚ğ•\¦‚·‚éÛ‚ÌŠÔŠu
    [SerializeField] private float log_pos_y;                               // ƒNƒŠƒAƒƒS‚ÆÔ˜g‚ğ•\¦‚·‚éY²

    private Player player;
    private Player_Data player_data;
>>>>>>> programmer/title_sence:Morumotto_ Wheerun_Title/Assets/Scripts/All/Player_Data.cs

    public void Save_Data(Player_Data_Main player_data)
    {
        // ãƒ¦ãƒ¼ã‚¶ã”ã¨ã«ä¿ç®¡ã™ã‚‹ãƒ‡ã‚£ãƒ¬ã‚¯ãƒˆãƒªãŒç•°ãªã‚‹ç‚ºã€Pathã‚’å†åº¦è¨­å®š
        datapath = Application.dataPath + "/data/data.json";
        // JSONã«å¤‰æ›
        string json = JsonUtility.ToJson(player_data);
        // ä¿å­˜å…ˆã‚’é–‹ã
        StreamWriter writer = new StreamWriter(datapath, false);
        // JSONãƒ‡ãƒ¼ã‚¿æ›¸ãè¾¼ã¿
        writer.WriteLine(json);
        // ãƒãƒƒãƒ•ã‚¡ã‚¯ãƒªã‚¢
        writer.Flush();
        // ãƒ•ã‚¡ã‚¤ãƒ«ã‚’é–‰ã˜ã‚‹
        writer.Close();
    }

<<<<<<< HEAD:Morumotto_ Wheerun/Assets/main_scene/Scripts/Player_Data_Main.cs
    public void Load_Data(Player_Data_Main player_data,string datapath)
=======
    public void Load_Data(Player_Data player_data, string datapath)
>>>>>>> programmer/title_sence:Morumotto_ Wheerun_Title/Assets/Scripts/All/Player_Data.cs
    {
        // ãƒ‘ã‚¹ã‚’èª­ã¿è¾¼ã‚€
        StreamReader reader = new StreamReader(datapath);
        // ãƒ•ã‚¡ã‚¤ãƒ«ã‚’èª­ã¿è¾¼ã‚€
        string data = reader.ReadToEnd();
        // ãƒ•ã‚¡ã‚¤ãƒ«ã‚’é–‰ã˜ã‚‹
        reader.Close();

        JsonUtility.FromJsonOverwrite(data, player_data);
    }

    private void Awake()
    {
        datapath = Application.dataPath + "/data/data.json";
    }

    // ã‚¹ãƒ†ãƒ¼ã‚¸ã‚¯ãƒªã‚¢è¨˜éŒ²æ¶ˆå»(ãƒ‡ãƒ¼ã‚¿å‰Šé™¤)
    public void delete_Data(int max_stage)
    {
        // æœ€å¤§ã®ã‚¹ãƒ†ãƒ¼ã‚¸æ•°åˆ†ã ã‘falseã«ã™ã‚‹ã€‚
        for (int i = 0; i < max_stage; i++)
        {
            stage_clear_number[i] = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        player = GetComponent<Player>();
        player_data = GameObject.Find("Canvas").GetComponent<Player_Data>();
        Load_Data(player_data, player_data.datapath);
        max_stage = 5;
        player_data.delete_start = false;
        if (player.sence == Player.Character_Sence.NEXT_STAGESELECT)
        {
            Clear_Init();
        }
    }

    public void Clear_Init()
    {
        for (int i = 0; i < max_stage; i++)
        {
            // ƒvƒŒƒnƒu‚ğ¶¬
            clear_prefab[i] = (GameObject)Instantiate(clear[i]);
            // ƒLƒƒƒ“ƒoƒX“à‚Éİ’è
            clear_prefab[i].transform.SetParent(canvas.transform, false);
            // ƒqƒGƒ‰ƒ‹ƒL[“à‚Ì•\¦‡‚ğ•ÏX
            clear_prefab[i].transform.SetSiblingIndex(6);
            // // ƒNƒŠƒAğŒ‚ğŠm”F
            if (player_data.stage_clear_number[i])
            {
                clear_prefab[i].transform.localPosition = new Vector2((move_log_pos_x * i) + criteria_log_pos_x, log_pos_y);
                clear_prefab[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.sence == Player.Character_Sence.GAME_DATADELETE)
        {
            Title_DataDelete_Check();
        }
    }

    public void Title_DataDelete_Check()
    {
        if (player.Data_Complete_FlgCheck())
        {
            if (!player_data.delete_start)
            {
                // ƒf[ƒ^íœˆ—
                player_data.delete_Data(player_data.max_stage);
                // ƒZ[ƒuˆ—
                player_data.Save_Data(player_data);
                player_data.delete_start = true;
            }
        }
    }

    public void Select_Move_DataSave()
    {
        // ƒZ[ƒuƒeƒXƒg
        player_data.stage_clear_number[0] = false;
        player_data.stage_clear_number[1] = true;
        player_data.stage_clear_number[2] = true;
        player_data.Save_Data(player_data);
    }
}
