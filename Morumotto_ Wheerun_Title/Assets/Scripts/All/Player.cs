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
        GAME_END               // �Q�[���I��(exe���I��)
    };

    public enum Player_Input
    {
        UP,                    // ��
        CENTER,                // �^��
        DOWN,                  // ��
    }

    public Character_Sence sence;
    public Player_Input input;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
