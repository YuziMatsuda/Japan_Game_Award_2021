using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player_Data : MonoBehaviour
{
    public string datapath;

    [SerializeField] public bool[] stage_clear_number;   // �N���A�擾
    [SerializeField] public int max_stage;
    [SerializeField] public bool delete_start;           // �f�[�^�폜�J�n

    private Player player;
    private Player_Data player_data;

    public void Save_Data(Player_Data player_data)
    {
        // ���[�U���Ƃɕۊǂ���f�B���N�g�����قȂ�ׁAPath���ēx�ݒ�
        datapath = Application.dataPath + "/data/data.json";
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

    public void Load_Data(Player_Data player_data, string datapath)
    {
        // ���[�U���Ƃɕۊǂ���f�B���N�g�����قȂ�ׁAPath���ēx�ݒ�
        datapath = Application.dataPath + "/data/data.json";
        // �p�X��ǂݍ���
        StreamReader reader = new StreamReader(datapath);
        // �t�@�C����ǂݍ���
        string data = reader.ReadToEnd();
        // �t�@�C�������
        reader.Close();

        JsonUtility.FromJsonOverwrite(data, player_data);
    }

    private void Awake()
    {
        datapath = Application.dataPath + "/data/data.json";
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
        Init();
    }

    public void Init()
    {
        player = GetComponent<Player>();
        player_data = GameObject.Find("Canvas").GetComponent<Player_Data>();
        Load_Data(player_data, player_data.datapath);
        max_stage = 5;
        player_data.delete_start = false;
    }

    // Update is called once per frame
    void Update()
    {
        Title_DataDelete_Check();
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
}
