using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Draw_Controller : MonoBehaviour
{
    // �e��摜�̃I�u�W�F�N�g
    [SerializeField] private GameObject select_background;          // �w�i
    [SerializeField] private GameObject select_stage_image;         // �e��X�e�[�W�A�C�R��(��)(��)
    [SerializeField] private GameObject select_stage_screenimage;   // �e��X�e�[�W�A�C�R��(��)
    [SerializeField] private GameObject icon;                       // �A�C�R��
    [SerializeField] private GameObject load_now;                   // ���[�h��

    // 
    [SerializeField] private GameObject select_stage_images;        // �e��X�e�[�W�A�C�R��(��)
    [SerializeField] private Sprite[] stage_image_sprite;           // �e��X�e�[�W�A�C�R���̃X�v���C�g
    public Image stage_image;                                       // �X�e�[�W

    public int stage_select_number;                                 // �X�e�[�W�ԍ�

    private RectTransform load_now_rect;
    private GameObject player_Draw;                                 // �v���C���[�I�u�W�F�N�g
    private Player player;

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
        player = player_Draw.GetComponent<Player>();
        player.getSence(Player.Character_Sence.NEXT_STAGESELECT);
        // �X�e�[�W�A�C�R���̃e�N�X�`���̃R���|�[�l���g���擾�B���̂��G���[�ɂȂ�B
        // select_stage_images = GameObject.Find("SELECT_STAGE_IMAGES");
        // stage_image = select_stage_images.GetComponent<Image>();

    }

    public void Texture_Draw_Init()
    {
        // �e��摜�̕\���ݒ�
        select_background.SetActive(true);
        select_stage_image.SetActive(true);
        select_stage_screenimage.SetActive(true);
        icon.SetActive(true);
        load_now.SetActive(true);
        // select_stage_images.SetActive(true);
        load_now_rect = load_now.GetComponent<RectTransform>();
        stage_select_number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �摜�\��
        Draw_Texture(player);
    }

    public void Draw_Texture(Player player)
    {
        // �v���C���[�̃V�[���J��
        switch(player.sence)
        {
            case Player.Character_Sence.NEXT_STAGESELECT:
            {
                Draw_LoadNow_FadeIn(Player.Character_Sence.GAME_STAGESELECT);
                break;
            }
            case Player.Character_Sence.GAME_STAGESELECT:
            {
                Draw_StageSelect();
                break;
            }
            case Player.Character_Sence.NEXT_GAMEMAIN:
            {
                Draw_LoadNow_FadeOut(Player.Character_Sence.NEXT_GAMEMAIN);
                break;
            }
            case Player.Character_Sence.NEXT_GAMETITLE:
            {
                Draw_LoadNow_FadeOut(Player.Character_Sence.NEXT_GAMETITLE);
                break;
            }
        }
    }

    public void Draw_StageSelect()
    {
        //  �����ŃX�N�V�������e��X�e�[�W�A�C�R��(��)�̐؂�ւ���z��ōs���B
        //  stage_image.sprite = stage_image_sprite[stage_select_number];
    }

    // �t�F�[�h�C������
    public void Draw_LoadNow_FadeIn(Player.Character_Sence Next_Scene)
    {
        float Load_Now_Max_Position = -1920.0f;
        if (load_now_rect.anchoredPosition.x >= Load_Now_Max_Position)
        {
            load_now_rect.anchoredPosition += new Vector2(-1000 * Time.deltaTime, 0);
        }
        else
        {
            player.getSence(Next_Scene);
        }
    }

    // �t�F�[�h�A�E�g����
    public void Draw_LoadNow_FadeOut(Player.Character_Sence Next_Scene)
    {
        float Load_Now_Min_Position = 0.0f;
        if (load_now_rect.anchoredPosition.x <= Load_Now_Min_Position)
        {
            load_now_rect.anchoredPosition -= new Vector2(-1000 * Time.deltaTime, 0);
        }
        else
        {
            player.getSence(Next_Scene);
        }
    }
}
