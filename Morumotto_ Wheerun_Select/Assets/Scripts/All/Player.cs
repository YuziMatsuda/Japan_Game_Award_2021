using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Character_Sence
    {
        PUSH_GAME_START,       // �Q�[���J�n���ɕ\��
        GAME_SELECT,           // �Q�[�����[�h��I��
        GAME_START,            // �Q�[���X�^�[�g(�Z���N�g��ʂɑJ��)
        GAME_DATADELETE_CHECK, // �Q�[���f�[�^�������m�F
        GAME_DATADELETE,       // �Q�[���f�[�^����
        GAME_END_CHECK,        // �Q�[���I�����m�F
        GAME_END,              // �Q�[���I��(exe���I��)
        NEXT_STAGESELECT,      // �X�e�[�W�Z���N�g�̑J��
        GAME_STAGESELECT,      // �X�e�[�W�Z���N�g���
        NEXT_GAMEMAIN,         // �Q�[�����C���̑J��
        NEXT_GAMETITLE         // �^�C�g���V�[���̑J��
    };

    public enum Player_Input
    {
        UP,                    // ��
        CENTER,                // �^��
        DOWN,                  // ��
    }

    public Character_Sence sence;
    public Player_Input input;
    public int select_stage_number;

    [SerializeField] private bool game_datacomplete_flg;

    /** 
     * �V�[���擾
     */
    public void getSence(Character_Sence sence)
    {
        this.sence = sence;
    }

    public void getInput(Player_Input input)
    {
        this.input = input;
    }

    public void set_Data_Complete_TrueFlg()
    {
        game_datacomplete_flg = true;
    }

    public void set_Data_Complete_FalseFlg()
    {
        game_datacomplete_flg = false;
    }

    public bool Data_Complete_FlgCheck()
    {
        if(game_datacomplete_flg==true)
        {
            return true;
        }
        return false;
    }

    public void set_stage_select_number(int select_stage_number)
    {
        this.select_stage_number = select_stage_number;
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
