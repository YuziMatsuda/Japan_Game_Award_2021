using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// プレイヤーデータ管理スクリプトクラス
/// </summary>
[System.Serializable]
public class Player_Data_Main : MonoBehaviour
{
    public string datapath;

<<<<<<< HEAD:Morumotto_ Wheerun/Assets/main_scene/Scripts/Player_Data_Main.cs
    [SerializeField] public bool[] stage_clear_number;   // クリア取得
=======
    [SerializeField] public bool[] stage_clear_number;                      // �N���A�擾
    [SerializeField] public int max_stage;
    [SerializeField] public bool delete_start;                              // �f�[�^�폜�J�n

    [SerializeField] private GameObject[] clear = new GameObject[5];        // �N���A�[
    [SerializeField] private GameObject[] clear_prefab = new GameObject[5]; // �N���A�[�p�̃v���n�u
    [SerializeField] private GameObject canvas;                             // �L�����o�X

    [SerializeField] private float criteria_log_pos_x;                      // �N���A���S�ƐԘg��\��������X��
    [SerializeField] private float move_log_pos_x;                          // �N���A���S�ƐԘg��\������ۂ̊Ԋu
    [SerializeField] private float log_pos_y;                               // �N���A���S�ƐԘg��\������Y��

    private Player player;
    private Player_Data player_data;
>>>>>>> programmer/title_sence:Morumotto_ Wheerun_Title/Assets/Scripts/All/Player_Data.cs

    public void Save_Data(Player_Data_Main player_data)
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

<<<<<<< HEAD:Morumotto_ Wheerun/Assets/main_scene/Scripts/Player_Data_Main.cs
    public void Load_Data(Player_Data_Main player_data,string datapath)
=======
    public void Load_Data(Player_Data player_data, string datapath)
>>>>>>> programmer/title_sence:Morumotto_ Wheerun_Title/Assets/Scripts/All/Player_Data.cs
    {
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
        if (player.sence == Player.Character_Sence.NEXT_STAGESELECT)
        {
            Clear_Init();
        }
    }

    public void Clear_Init()
    {
        for (int i = 0; i < max_stage; i++)
        {
            // �v���n�u�𐶐�
            clear_prefab[i] = (GameObject)Instantiate(clear[i]);
            // �L�����o�X���ɐݒ�
            clear_prefab[i].transform.SetParent(canvas.transform, false);
            // �q�G�����L�[���̕\������ύX
            clear_prefab[i].transform.SetSiblingIndex(6);
            // // �N���A�������m�F
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
                // �f�[�^�폜����
                player_data.delete_Data(player_data.max_stage);
                // �Z�[�u����
                player_data.Save_Data(player_data);
                player_data.delete_start = true;
            }
        }
    }

    public void Select_Move_DataSave()
    {
        // �Z�[�u�e�X�g
        player_data.stage_clear_number[0] = false;
        player_data.stage_clear_number[1] = true;
        player_data.stage_clear_number[2] = true;
        player_data.Save_Data(player_data);
    }
}
