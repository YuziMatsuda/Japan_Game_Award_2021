using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Sound_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip se_decision;
    [SerializeField] private AudioClip se_cancel;
    [SerializeField] private AudioClip se_scroll;
    [SerializeField] private int min_scroll_number;         // �ŏ��̃X�N���[���l (�O�Œ�)
    [SerializeField] private int max_scroll_number;         // �ő�̃X�N���[���l�i�ő�X�e�[�W���j

    private Player player;
    private AudioSource audioSource;
    private GameObject player_Draw;

    // Start is called before the first frame update
    void Start()
    {
        player_Draw = GameObject.Find("Canvas");
        player = player_Draw.GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.sence == Player.Character_Sence.GAME_STAGESELECT)
        {
            Output_Sound();
        }
    }

    public void Output_Sound()
    {
        LeftRight_Button_Sound();
        A_Button_Sound();
        B_Button_Sound();
    }

    public void LeftRight_Button_Sound()
    {
        if (Input.GetButtonDown("Left_Input") || Input.GetButtonDown("Right_Input"))
        {
            // �ŏ��X�N���[���l(0)�ƍő�X�N���[��(�ő�X�e�[�W��)�̊ԂɐԘg������ꍇ
            if(player.select_stage_number > min_scroll_number && player.select_stage_number < max_scroll_number)
            {
                audioSource.PlayOneShot(se_scroll);
            }
        }

        if (Input.GetButtonDown("Right_Input"))
        {
            // �ŏ��X�N���[���l(0)�ɐԘg������ꍇ
            if (player.select_stage_number == min_scroll_number)
            {
                audioSource.PlayOneShot(se_scroll);
            }
        }

        if (Input.GetButtonDown("Left_Input"))
        {
            // �ő�X�N���[��(�ő�X�e�[�W��)�ɐԘg������ꍇ
            if (player.select_stage_number == max_scroll_number)
            {
                audioSource.PlayOneShot(se_scroll);
            }
        }
    }

    public void B_Button_Sound()
    {
        if (Input.GetButtonDown("Decision"))
        {
            audioSource.PlayOneShot(se_decision);
        }
    }

    public void A_Button_Sound()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            audioSource.PlayOneShot(se_cancel);
        }
    }
}
