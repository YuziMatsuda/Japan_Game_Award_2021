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

    [SerializeField] private GameObject[] clear = new GameObject[5];        // �N���A�[
    [SerializeField] private GameObject[] clear_prefab = new GameObject[5]; // �N���A�[�p�̃v���n�u
    [SerializeField] private GameObject canvas;                             // �L�����o�X

    [SerializeField] private float criteria_log_pos_x;                      // �N���A���S�ƐԘg��\��������X��
    [SerializeField] private float move_log_pos_x;                          // �N���A���S�ƐԘg��\������ۂ̊Ԋu
    [SerializeField] private float log_pos_y;                               // �N���A���S�ƐԘg��\������Y��

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
        if(player.sence == Player.Character_Sence.NEXT_STAGESELECT)
        {
             Clear_Init();
        }
    }

    public void Clear_Init()
    {
        for (int i = 0; i < max_stage; i++)
        {
            // �v���n�u�𐶐�
            clear_prefab[max_stage] = (GameObject)Instantiate(clear[max_stage]);
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
