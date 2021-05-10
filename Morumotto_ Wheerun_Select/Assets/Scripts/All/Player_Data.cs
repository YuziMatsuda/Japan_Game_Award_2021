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

    [SerializeField] public bool[] stage_clear_number;   // �N���A�擾

    public void Data_Save(Player_Data player_data)
    {
        // JSON�ɕϊ�
        string json = JsonUtility.ToJson(player_data);
        // �ۑ�����J��
        StreamWriter writer = new StreamWriter(datapath, false);
        // JSON�f�[�^��������
        writer.WriteLine(json);
        // �o�b�t�@�N���A
        writer.Flush();
        // �t�@�C�������
        writer.Close();
    }

    public Player_Data Data_Load(string datapath)
    {
        // datapath = Application.dataPath + "/data/data.json";
        // �p�X��ǂݍ���
        StreamReader reader = new StreamReader(datapath);
        // �t�@�C����ǂݍ���
        string data = reader.ReadToEnd();
        // �t�@�C�������
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

    // �X�e�[�W�N���A�L�^����(�f�[�^�폜)
    public void delete_Data(int max_stage)
    {
        // �ő�̃X�e�[�W��������false�ɂ���B
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
        // �f�[�^�����[�h����B
        playerdata = playerdata.Data_Load(playerdata.datapath);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
