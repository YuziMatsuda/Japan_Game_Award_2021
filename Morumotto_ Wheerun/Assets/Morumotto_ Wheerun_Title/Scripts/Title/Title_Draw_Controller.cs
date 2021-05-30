using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Draw_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject title_background_object;        // �w�i
    [SerializeField] private GameObject push_game_object;               // �Q�[���J�n���̃I�u�W�F�N�g
    [SerializeField] private GameObject select_object;                  // �Q�[���I���̃I�u�W�F�N�g
    [SerializeField] private GameObject game_datadelete_check;          // �Q�[���f�[�^�폜�m�F�̃I�u�W�F�N�g
    [SerializeField] private GameObject game_end_check;                 // �Q�[���I���̃I�u�W�F�N�g
    [SerializeField] private GameObject icon;                           // �A�C�R��
    [SerializeField] private GameObject load_now;                       // ���[�h��
    [SerializeField] private GameObject data_dalete_complete;           // �f�[�^�폜�������S
    [SerializeField] private GameObject fade_in;                        // �t�F�[�h�C��

    private RectTransform icon_rect;                                    // �A�C�R���摜�̍��W
    private RectTransform load_now_rect;                                // ���[�h���摜�̍��W
    private RectTransform data_delete_complete_rect;                    // �f�[�^�폜�����摜�̍��W
    private Image fade_Draw;        
    private GameObject player_Draw;                                     // �v���C���[�I�u�W�F�N�g
    private Player player;                                              // �v���C���[
    private Player_Data player_data;

    private float load_now_position_x;                                  // ���[�h���摜��X��
    private float data_delete_complete_position_y;                      // �f�[�^�폜�����摜��X��
    private float data_delete_complete_position_x;                      // �f�[�^�폜�����摜��Y��
    private float timer;                                                // �t�F�[�h�p�̃^�C�}�[
    [SerializeField] private float alpha;                               // �t�F�[�h�̃��l
    private float alpha_speed;                                          // �t�F�[�h�̑��x
    float red, green, blue;

    void Start()
    {
        Player_Init();
        Texture_Draw_Init();
    }

    public void Player_Init()
    {
        // �v���C���[�̃R���|�[�l���g���擾�B
        player_Draw = GameObject.Find("Canvas");
        //  player_data = GameObject.Find("Canvas").GetComponent<Player_Data>();
        //  player_data.Load_Data(player_data, player_data.datapath);
        player = player_Draw.GetComponent<Player>();
        Player_Sence_Check();
        player.setInput(Player.Player_Input.UP);
        player.set_Data_Complete_FalseFlg();
        // player_data.max_stage = 5;
        // player_data.delete_start = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Player_Sence_Check()
    {

        // player.before_check_sence = Player.Character_Sence.NEXT_GAMETITLE;
        // �������Ɉȉ��̏����ɕύX
        // player.before_check_sence = player.brfore_getSence();

        // �O��̃V�[�����i�[
        player.before_check_sence = player.brfore_getSence();

        // �������ɍ폜
        /*
        if (player.before_check_sence == null)
        {
            player.before_check_sence = Player.Character_Sence.OPENING_MOVIE;
        }
        */

        // �ȑO�̃V�[�����m�F
        if (player.before_check_sence == Player.Character_Sence.OPENING_MOVIE)
        {
            player.setSence(Player.Character_Sence.NEXT_GAMESTART);
        }
        else if (player.before_check_sence == Player.Character_Sence.GAME_STAGESELECT)
        {
            player.setSence(Player.Character_Sence.NEXT_GAMETITLE);
        }
        else
        {
            player.setSence(Player.Character_Sence.PUSH_GAME_START);
        }
    }

    public void Texture_Draw_Init()
    {
        // �e��摜�̕\���E���W�ݒ�
        title_background_object.SetActive(true);
        load_now.SetActive(true);
        icon_rect = icon.GetComponent<RectTransform>();
        load_now_rect = load_now.GetComponent<RectTransform>();
        data_delete_complete_rect = data_dalete_complete.GetComponent<RectTransform>();
        fade_Draw = fade_in.GetComponent<Image>();
        Fade_Init();            // �t�F�[�h�̏��������\�b�h
        // ���W�ʒu�̐ݒ�
        data_delete_complete_position_x = 650.0f;
        data_delete_complete_position_y = 700.0f;
        alpha_speed = 0.5f;
    }

    public void Fade_Init()
    {
        // �V�[���`�F�b�N
        if (player.sence == Player.Character_Sence.NEXT_GAMESTART)
        {
            alpha = 1;
        }
        else
        {
            alpha = 0;
        }
        if (player.sence == Player.Character_Sence.NEXT_GAMETITLE)
        {
            float load_now_position = 0.0f;
            load_now_rect.anchoredPosition = new Vector2(load_now_position, load_now_position);
        }
        else
        {
            load_now_position_x = -1920.0f;        // ���[�h��ʂ̏������W�ʒu
        }
    }


    // Update is called once per frame
    void Update()
    {
        Draw_Texture(player);
    }

    // �e�V�[���̉�ʕ`�敪�򏈗�
    public void Draw_Texture(Player player)
    {
        switch (player.sence)
        {
            case Player.Character_Sence.NEXT_GAMESTART:
            {
                NextGameStart_Draw();
                break;
            }
            case Player.Character_Sence.NEXT_GAMETITLE:
            {
                NextGameTitle_Draw();
                break;
            }
            case Player.Character_Sence.PUSH_GAME_START:
            {
                PushGameStart_Draw();
                break;
            }
            case Player.Character_Sence.GAME_SELECT:
            {
                 GameSelect_Draw(player);
                 break;
            }
            case Player.Character_Sence.GAME_START:
            {
                 GameStart_Draw();
                 break;
            }
            case Player.Character_Sence.GAME_DATADELETE_CHECK:
            {
                 GameDatadeleteCheck_Draw(player);
                 break;
            }
            case Player.Character_Sence.GAME_DATADELETE:
            {
                 break;
            }
            case Player.Character_Sence.GAME_END_CHECK:
            {
                GameEndCheck_Draw(player);
                break;
            }
            case Player.Character_Sence.GAME_END:
            {
                GameEnd_Draw();
                break;
            }
        }
    }

    // �I�[�v�j���O���[�r�[����^�C�g���֑J�ڂ������̏���
    public void NextGameStart_Draw()
    {
        push_game_object.SetActive(true);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(false);
        icon.SetActive(false);

        fade_in.SetActive(true);
        timer += Time.deltaTime;


        fade_Draw.color = new Color(0, 0, 0, alpha);
        alpha -= alpha_speed * Time.deltaTime;

        // timer >= EndTimer || 
        // �R�b�o�ߌ�Ƀt�F�[�h�A�E�g
        if (alpha <= 0)
        {
            player.sence = Player.Character_Sence.PUSH_GAME_START;
        }
    }

    // �Z���N�g�V�[������^�C�g���V�[���ɑJ�ڂ������̏���
    public void NextGameTitle_Draw()
    {
        push_game_object.SetActive(true);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(false);
        icon.SetActive(false);
        load_now.SetActive(true);
        float Load_Now_Min_Position = -1920.0f;
        if (load_now_rect.anchoredPosition.x >= Load_Now_Min_Position)
        {
            load_now_rect.anchoredPosition += new Vector2(-1000 * Time.deltaTime, 0);
        }
        else
        {
            load_now_position_x = -1920.0f;        // ���[�h��ʂ̏������W�ʒu
            player.sence = Player.Character_Sence.PUSH_GAME_START;
        }
    }

    // �uPushGameStart�v�̕\��
    public void PushGameStart_Draw()
    {
        push_game_object.SetActive(true);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(false);
        icon.SetActive(false);
    }

    //�u�Q�[�����[�h��I���v��\���Ɠ��͌�̏���
    public void GameSelect_Draw(Player player)
    {
        push_game_object.SetActive(false);
        select_object.SetActive(true);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(false);
        icon.SetActive(true);
        float updown_tex_position_x = -210.0f;
        float center_tex_position_x = -295.0f;
        float up_tex_position_y = -50.0f;
        float center_tex_position_y = -235.0f;
        float center_tex_position_z = -410.0f;

        if (player.Data_Complete_FlgCheck())
        {
            // �Q�[���f�[�^�폜����
            GameDatadelete_Draw();
        }

        switch (player.input)
        {
            case Player.Player_Input.UP:
            {
                icon_rect.anchoredPosition = new Vector2(updown_tex_position_x, up_tex_position_y);
                break;
            }
            case Player.Player_Input.CENTER:
            {
                icon_rect.anchoredPosition = new Vector2(center_tex_position_x, center_tex_position_y);
                break;
            }
            case Player.Player_Input.DOWN:
            {
                icon_rect.anchoredPosition = new Vector2(updown_tex_position_x, center_tex_position_z);
                break;
            }
        }
    }

    // �u���[�h���v�̃t�F�[�h����
    public void GameStart_Draw()
    {

        float Load_Now_Max_Position = 0.0f;
        if (load_now_rect.anchoredPosition.x <= Load_Now_Max_Position)
        {
            load_now_rect.anchoredPosition -= new Vector2(load_now_position_x * Time.deltaTime, 0);
        }
        else
        {
            // �ȑO�̃V�[�����i�[
            player.before_setSence(Player.Character_Sence.GAME_SELECT);
            // �Z���N�g�V�[���ɐ؂�ւ��鏈�����L��
            SceneManager.LoadScene("Select_Scene");
        }
    }

    // �u�Q�[���f�[�^�폜�m�F�v�̉摜��\��
    public void GameDatadeleteCheck_Draw(Player player)
    {
        push_game_object.SetActive(false);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(true);
        game_end_check.SetActive(false);
        icon.SetActive(true);
        YesNo_Draw(player);
    }

    // �u�Q�[���f�[�^���폜���܂����v�̉摜��\��
    public void GameDatadelete_Draw()
    {
        data_dalete_complete.SetActive(true);
        // player_data.Delete_Start_Data(player_data);
        /*
        if (!player_data.delete_start)
        {
            // �f�[�^�폜����
            player_data.delete_Data(player_data.max_stage);
            // �Z�[�u����
            player_data.Save_Data(player_data);
            player_data.delete_start = true;
        }
        */
        float max_rect_y = 490.0f;
        if (data_delete_complete_rect.anchoredPosition.y >= max_rect_y)
        {
            data_delete_complete_rect.anchoredPosition -= new Vector2(0.0f, data_delete_complete_position_y * Time.deltaTime * 0.5f);
        }
        else
        {
            timer += Time.deltaTime;
            float EndTime = 2.0f;
            // 2�b�o�߂�����ɁuGameSelect_Draw�v�֑J��
            if (timer >= EndTime)
            {
                timer = 0;
                data_dalete_complete.SetActive(false);
                player.set_Data_Complete_FalseFlg();
                data_delete_complete_position_y = 600.0f;
                data_delete_complete_rect.anchoredPosition = new Vector2(data_delete_complete_position_x, data_delete_complete_position_y);
            }
        }

    }

    //�u�Q�[���I���m�F�v�摜��\��
    public void GameEndCheck_Draw(Player player)
    {
        push_game_object.SetActive(false);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(true);
        icon.SetActive(true);
        YesNo_Draw(player);
    }

    //�u�͂��E�������v�̉摜�\���Ə���������
    public void YesNo_Draw(Player player)
    {
        float yes_position_x = -120.0f;
        float yes_position_y = -200.0f;
        float no_position_x = -150.0f;
        float no_position_y = -350.0f;
        switch (player.input)
        {
            case Player.Player_Input.UP:
            {
                icon_rect.anchoredPosition = new Vector2(yes_position_x, yes_position_y);
                break;
            }

            case Player.Player_Input.DOWN:
            {
                icon_rect.anchoredPosition = new Vector2(no_position_x, no_position_y);
                break;
            }
        }
    }

    // �Q�[���I������������
    public void GameEnd_Draw()
    {
        fade_in.SetActive(true);
        timer += Time.deltaTime;
        int MaxColor = 255;

        fade_Draw.color = new Color(MaxColor, MaxColor, MaxColor, alpha);
        alpha += alpha_speed * Time.deltaTime;

        // �R�b�o�ߌ�Ƀt�F�[�h�C�� (�Q�[���I���̏���)
        if (alpha >= 1)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

}
