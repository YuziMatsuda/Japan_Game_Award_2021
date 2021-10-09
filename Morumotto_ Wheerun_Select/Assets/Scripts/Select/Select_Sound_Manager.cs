using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Sound_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip se_decision;
    [SerializeField] private AudioClip se_cancel;
    [SerializeField] private AudioClip se_scroll;
    [SerializeField] private int min_scroll_number;         // 最小のスクロール値 (０固定)
    [SerializeField] private int max_scroll_number;         // 最大のスクロール値（最大ステージ数）

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
            // 最小スクロール値(0)と最大スクロール(最大ステージ数)の間に赤枠がある場合
            if(player.select_stage_number > min_scroll_number && player.select_stage_number < max_scroll_number)
            {
                audioSource.PlayOneShot(se_scroll);
            }
        }

        if (Input.GetButtonDown("Right_Input"))
        {
            // 最小スクロール値(0)に赤枠がある場合
            if (player.select_stage_number == min_scroll_number)
            {
                audioSource.PlayOneShot(se_scroll);
            }
        }

        if (Input.GetButtonDown("Left_Input"))
        {
            // 最大スクロール(最大ステージ数)に赤枠がある場合
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
