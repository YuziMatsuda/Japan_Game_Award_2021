using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player_Data : MonoBehaviour
{
    public string datapath;

    [SerializeField] public bool[] stage_clear_number;   // �N���A�擾

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

    public void Load_Data(Player_Data player_data,string datapath)
    {
        // �p�X��ǂݍ���
        StreamReader reader = new StreamReader(datapath);
        // �t�@�C����ǂݍ���
        string data = reader.ReadToEnd();
        // �t�@�C�������
        reader.Close();

        JsonUtility.FromJsonOverwrite(data,player_data);
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
