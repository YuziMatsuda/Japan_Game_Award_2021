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

    private Character_Sence sence;

    public Player()
    {

    }

    public Player(Character_Sence sence)
    {
        this.sence = sence;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player(Character_Sence.PUSH_GAME_START);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
