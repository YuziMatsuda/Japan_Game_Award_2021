using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Draw_Controller : MonoBehaviour
{
    // �e��摜�̃I�u�W�F�N�g
    [SerializeField] private GameObject select_background;                  // �w�i
    [SerializeField] private GameObject select_stage_screenimage_A;         // �e��X�e�[�W�A�C�R��_A(��)
    [SerializeField] private GameObject select_stage_screenimage_B;         // �e��X�e�[�W�A�C�R��_B(��)
    [SerializeField] private GameObject icon;                               // �A�C�R��
    [SerializeField] private GameObject load_now;                           // ���[�h��
    [SerializeField] private GameObject select_frame;                       // �Ԙg
    [SerializeField] private GameObject select_coment_back;                 // �R�����g�p�̔w�i
    [SerializeField] private GameObject canvas;                             // �L�����o�X
    [SerializeField] private GameObject[] clear = new GameObject[10];       // �N���A�[
    [SerializeField] private GameObject[] clear_prefab = new GameObject[10];// �N���A�[�p�̃v���n�u
    private GameObject player_Draw;                                         // �v���C���[�I�u�W�F�N�g
    private Select_Player player;                                                  // �v���C���[

    [SerializeField] private GameObject select_stage_object;                // �e��X�e�[�W�A�C�R��(��)���܂Ƃ߂�I�u�W�F�N�g
    [SerializeField] private Sprite[] select_stage_sprite;                  // �e��X�e�[�W�A�C�R���̃X�v���C�g
    [SerializeField] private Image select_stage_image;                      // �X�e�[�W�̃C���[�W

    [SerializeField] private GameObject select_back_object;                 // �w�i�摜���܂Ƃ߂�I�u�W�F�N�g
    [SerializeField] private Sprite[] select_back_sprite;                   // �w�i�摜�̃X�v���C�g
    [SerializeField] private Image select_back_image;                       // �w�i�̃C���[�W

    [SerializeField] private GameObject select_coment_object;               // �X�e�[�W�̃R�����g�摜���܂Ƃ߂�I�u�W�F�N�g
    [SerializeField] private Sprite[] select_coment_sprite;                 // �X�e�[�W�̃R�����g�摜�p�̃X�v���C�g
    [SerializeField] private Image select_coment_image;                     // �X�e�[�W�̃R�����g�摜�p�̃C���[�W

    private RectTransform load_now_rect;
    private RectTransform select_frame_rect;

    [SerializeField] private int max_stage;                                 // �ő�X�e�[�W��
    [SerializeField] private float criteria_log_pos_x;                      // �N���A���S�ƐԘg��\��������X��
    [SerializeField] private float move_log_pos_x;                          // �N���A���S�ƐԘg��\������ۂ̊Ԋu
    [SerializeField] private float log_pos_y;                               // �N���A���S�ƐԘg��\������Y��
    [SerializeField] private float fade_speed;                              // �t�F�[�h���鑬�x

    [SerializeField] private int min_scroll_number;                         // �ŏ��̃X�N���[���l (�O�Œ�)
    [SerializeField] private int max_scroll_number;                         // �ő�̃X�N���[���l�i�ő�X�e�[�W���j
    private int change_screen_number=5;                                     // ��ʂ��؂�ւ�鐔

    // Start is called before the first frame update
    void Start()
    {
        // �e�평����
        Player_Init();
        Texture_Draw_Init();
    }

    public void Player_Init()
    {
        // �v���C���[�̃R���|�[�l���g���擾
        player_Draw = GameObject.Find("Canvas");
        player = player_Draw.GetComponent<Select_Player>();
        player.setSence(Select_Player.Character_Sence.NEXT_STAGESELECT);
        // �}�E�X�J�[�\����\��
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // �X�e�[�W�ԍ����擾 (�������ɃR�����g����)
        // Set_Player_Number();
    }

    //public void Set_Player_Number()
    //{
    //    try
    //    {
    //        var sceneObj = GameObject.Find("ResponseSceneInfo");
    //        if (sceneObj != null)
    //        {
    //            var info = sceneObj.GetComponent<ResponseSceneInfo>();
    //            // �X�e�[�W�����擾�ł��܂��B
    //            Debug.Log(info._fromSceneName);
    //            // �X�e�[�W�ԍ��擾
    //            switch (info._fromSceneName)
    //            {
    //                case "Stage2_Scene": { player.select_stage_number = 1; break; }
    //                case "Stage3_Scene": { player.select_stage_number = 2; break; }
    //                case "Stage4_Scene": { player.select_stage_number = 3; break; }
    //                case "Stage5_Scene": { player.select_stage_number = 4; break; }
    //                case "Stage6_Scene": { player.select_stage_number = 5; break; }
    //                case "Stage7_Scene": { player.select_stage_number = 6; break; }
    //                case "Stage8_Scene": { player.select_stage_number = 7; break; }
    //                case "Stage9_Scene": { player.select_stage_number = 8; break; }
    //                case "Stage10_Scene": { player.select_stage_number = 9; break; }
    //                default: { player.select_stage_number = 0; break; }
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        player.select_stage_number = 0;
    //    }
    //}


    public void Texture_Draw_Init()
    {
        // �e��摜�̕\���ݒ�
        select_background.SetActive(true);
        select_stage_screenimage_A.SetActive(true);
        select_stage_screenimage_B.SetActive(false);
        icon.SetActive(true);
        load_now.SetActive(true);
        select_frame.SetActive(true);
        select_stage_object.SetActive(true);
        select_back_object.SetActive(true);
        select_coment_back.SetActive(true);
        select_coment_object.SetActive(true);
        // �X�e�[�W�A�C�R���̃e�N�X�`���̃R���|�[�l���g��ǉ��B
        select_stage_image = select_stage_object.AddComponent<Image>();
        // �w�i�̃e�N�X�`���̃R���|�[�l���g��ǉ��B
        select_back_image = select_back_object.AddComponent<Image>();
        // �X�e�[�W�p�̃R�����g�e�N�X�`���̃R���|�[�l���g��ǉ��B
        select_coment_image = select_coment_object.AddComponent<Image>();
        // �e��X�v���C�g���C���[�W�Ɋi�[
        select_stage_image.sprite = select_stage_sprite[player.select_stage_number];
        select_back_image.sprite = select_back_sprite[player.select_stage_number];
        select_coment_image.sprite = select_coment_sprite[player.select_stage_number];
        load_now_rect = load_now.GetComponent<RectTransform>();
        select_frame_rect = select_frame.GetComponent<RectTransform>();
        // �X�e�[�W�ԍ����擾 (�������ɃR�����g�ǉ�)
        player.select_stage_number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �摜�\��
        Draw_Texture(player);
    }

   public void Draw_Texture(Select_Player player)
    {
        // �v���C���[�̃V�[���J��
        switch (player.sence)
        {
            case Select_Player.Character_Sence.NEXT_STAGESELECT:{Draw_LoadNow_FadeIn(Select_Player.Character_Sence.GAME_STAGESELECT);break;}
            case Select_Player.Character_Sence.GAME_STAGESELECT:{Draw_StageSelect();break;}
            case Select_Player.Character_Sence.NEXT_GAMEMAIN:{Draw_LoadNow_FadeOut(Select_Player.Character_Sence.NEXT_GAMEMAIN);break;}
            case Select_Player.Character_Sence.NEXT_GAMETITLE:{Draw_LoadNow_FadeOut(Select_Player.Character_Sence.NEXT_GAMETITLE);break;}
        }
    }

    // �X�e�[�W�Z���N�g�V�[���̉摜�`�揈��
    public void Draw_StageSelect()
    {
        //  �X�N�V�������e��X�e�[�W�A�C�R��(��)�̐؂�ւ���z��ōs���B
        select_stage_image.sprite = select_stage_sprite[player.select_stage_number];
        //�@�w�i�̐؂�ւ���z��ōs���B
        select_back_image.sprite = select_back_sprite[player.select_stage_number];
        if (player.select_stage_number >= change_screen_number)
        {
            // �Ԙg��\�����A���E�ړ����鎖�ŐԘg���ړ�����B
            select_frame_rect.anchoredPosition = new Vector2((move_log_pos_x * player.select_stage_number) + criteria_log_pos_x - 1850.0f, log_pos_y);
            select_stage_screenimage_A.SetActive(false);
            select_stage_screenimage_B.SetActive(true);
        }
        else
        {
            // �Ԙg��\�����A���E�ړ����鎖�ŐԘg���ړ�����B
            select_frame_rect.anchoredPosition = new Vector2((move_log_pos_x * player.select_stage_number) + criteria_log_pos_x, log_pos_y);
            select_stage_screenimage_A.SetActive(true);
            select_stage_screenimage_B.SetActive(false);
        }
        //  �R�����g�̐؂�ւ���z��ōs���B
        select_coment_image.sprite = select_coment_sprite[player.select_stage_number];
    }

    // �t�F�[�h�C������
    public void Draw_LoadNow_FadeIn(Select_Player.Character_Sence Next_Scene)
    {
        float Load_Now_Max_Position = -2000.0f;
        if (load_now_rect.anchoredPosition.x >= Load_Now_Max_Position)
        {
            load_now_rect.anchoredPosition += new Vector2(fade_speed * Time.deltaTime, 0);
        }
        else
        {
            player.setSence(Next_Scene);
        }
    }

    // �t�F�[�h�A�E�g����
    public void Draw_LoadNow_FadeOut(Select_Player.Character_Sence Next_Scene)
    {
        float Load_Now_Min_Position = 0.0f;
        if (load_now_rect.anchoredPosition.x <= Load_Now_Min_Position)
        {
            load_now_rect.anchoredPosition -= new Vector2(fade_speed * Time.deltaTime, 0);
        }
        else
        {
            player.setSence(Next_Scene);
            SenceChange(Next_Scene);
        }
    }

    // �V�[���؂�ւ�����
    public void SenceChange(Select_Player.Character_Sence Next_Scene)
    {
        if (Next_Scene == Select_Player.Character_Sence.NEXT_GAMEMAIN)
        {
            player.set_Stagenumber(player.select_stage_number);
            Next_Stage_Number();
        }
        else if (Next_Scene == Select_Player.Character_Sence.NEXT_GAMETITLE)
        {
            player.before_setSence(Select_Player.Character_Sence.GAME_STAGESELECT);
            SceneManager.LoadScene("Title_Scene");
        }
    }

    // �X�e�[�W�̑J�ڐ���w��
    public void Next_Stage_Number()
    {
        switch (player.select_stage_number)
        {
            case 0:{SceneManager.LoadScene("main");break;}
            case 1:{SceneManager.LoadScene("Stage2_Scene");break;}
            case 2:{SceneManager.LoadScene("Stage3_Scene");break;}
            case 3:{SceneManager.LoadScene("Stage4_Scene");break;}
            case 4:{SceneManager.LoadScene("Stage5_Scene");break;}
            case 5:{SceneManager.LoadScene("Stage6_Scene");break;}
            case 6:{SceneManager.LoadScene("Stage7_Scene");break;}
            case 7:{SceneManager.LoadScene("Stage8_Scene");break;}
            case 8:{SceneManager.LoadScene("Stage9_Scene");break;}
            case 9:{SceneManager.LoadScene("Stage10_Scene");break;}
        }
    }
}
