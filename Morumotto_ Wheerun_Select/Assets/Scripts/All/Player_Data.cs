using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player_Data : MonoBehaviour
{
    public string datapath;
    private GameObject player_data_obj;
    private Player player;

    [SerializeField] public bool[] stage_clear_number;   // クリア取得

    public void Data_Save(Player_Data player_data)
    {
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

    public Player_Data Data_Load(string datapath)
    {
        // datapath = Application.dataPath + "/data/data.json";
        // パスを読み込む
        StreamReader reader = new StreamReader(datapath);
        // ファイルを読み込む
        string data = reader.ReadToEnd();
        // ファイルを閉じる
        reader.Close();

        return JsonUtility.FromJson<Player_Data>(data);
    }

    private void Awake()
    {
        datapath = Application.dataPath + "/data/data.json";
    }

    public void save()
    {
        Player_Data playerdata = new Player_Data();
        playerdata.stage_clear_number[0] = false;
        playerdata.stage_clear_number[1] = true;
        playerdata.Data_Save(playerdata);
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
        player_data_obj = GameObject.Find("Canvas");
        player = player_data_obj.GetComponent<Player>();
        Player_Data playerdata = new Player_Data();
        // データをロードする。
        playerdata = playerdata.Data_Load(playerdata.datapath);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
