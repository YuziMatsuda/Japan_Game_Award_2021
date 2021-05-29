using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player_Data : MonoBehaviour
{
    public string datapath;

    [SerializeField] public bool[] stage_clear_number;   // クリア取得
    [SerializeField] public int max_stage;
    [SerializeField] public bool delete_start;           // データ削除開始

    [SerializeField] private GameObject[] clear = new GameObject[5];        // クリアー
    [SerializeField] private GameObject[] clear_prefab = new GameObject[5]; // クリアー用のプレハブ
    [SerializeField] private GameObject canvas;                             // キャンバス

    [SerializeField] private float criteria_log_pos_x;                      // クリアロゴと赤枠を表示する基準のX軸
    [SerializeField] private float move_log_pos_x;                          // クリアロゴと赤枠を表示する際の間隔
    [SerializeField] private float log_pos_y;                               // クリアロゴと赤枠を表示するY軸

    private Player player;
    private Player_Data player_data;


    public void Save_Data(Player_Data player_data)
    {
        // ユーザごとに保管するディレクトリが異なる為、Pathを再度設定
        datapath = Application.dataPath + "/data/data.json";
        // JSONに変換
        string json = JsonUtility.ToJson(player_data);
        // 保存先を開く
        StreamWriter writer = new StreamWriter(datapath, false);
        // JSONデータ書き込み
        writer.WriteLine(json);
        // バッファクリア
        writer.Flush();
        // ファイルを閉じる
        writer.Close();
    }

    public void Load_Data(Player_Data player_data, string datapath)
    {
        // ユーザごとに保管するディレクトリが異なる為、Pathを再度設定
        datapath = Application.dataPath + "/data/data.json";
        // パスを読み込む
        StreamReader reader = new StreamReader(datapath);
        // ファイルを読み込む
        string data = reader.ReadToEnd();
        // ファイルを閉じる
        reader.Close();

        JsonUtility.FromJsonOverwrite(data, player_data);
    }

    private void Awake()
    {
        datapath = Application.dataPath + "/data/data.json";
    }

    // ステージクリア記録消去(データ削除)
    public void delete_Data(int max_stage)
    {
        // 最大のステージ数分だけfalseにする。
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
        if(player.sence == Player.Character_Sence.NEXT_STAGESELECT)
        {
             Clear_Init();
        }
    }

    public void Clear_Init()
    {
        for (int i = 0; i < max_stage; i++)
        {
            // プレハブを生成
            clear_prefab[max_stage] = (GameObject)Instantiate(clear[max_stage]);
            // キャンバス内に設定
            clear_prefab[i].transform.SetParent(canvas.transform, false);
            // ヒエラルキー内の表示順を変更
            clear_prefab[i].transform.SetSiblingIndex(6);
            // // クリア条件を確認
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
        switch(player.sence)
        {
            case Player.Character_Sence.GAME_DATADELETE:
            {
                Title_DataDelete_Check();
                break;
            }
            case Player.Character_Sence.NEXT_GAMETITLE:
            {
                Select_Move_DataSave();
                break;
            }
        }  
    }

    public void Title_DataDelete_Check()
    {
        if (player.Data_Complete_FlgCheck())
        {
            if (!player_data.delete_start)
            {
                // データ削除処理
                player_data.delete_Data(player_data.max_stage);
                // セーブ処理
                player_data.Save_Data(player_data);
                player_data.delete_start = true;
            }
        }
    }

    public void Select_Move_DataSave()
    {
        // セーブテスト
        player_data.stage_clear_number[0] = false;
        player_data.stage_clear_number[1] = true;
        player_data.stage_clear_number[2] = true;
        player_data.Save_Data(player_data);
    }
}
