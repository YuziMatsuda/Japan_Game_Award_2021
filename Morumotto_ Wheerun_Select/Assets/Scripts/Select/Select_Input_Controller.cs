using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Input_Controller : MonoBehaviour
{
    private GameObject player_input;
    private Player player;
    // bool button_flg;
    float before_flame;
    [SerializeField] private int min_scroll_number;         // 最小のスクロール値 (０固定)
    [SerializeField] private int max_scroll_number;         // 最大のスクロール値（最大ステージ数）

    // Start is called before the first frame update
    void Start()
    {
        player_input = GameObject.Find("Canvas");
        player = player_input.GetComponent<Player>();
        //button_flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.sence == Player.Character_Sence.GAME_STAGESELECT)
        {
            Player_Input();
        }
    }

    public void Player_Input()
    {
        Left_Button_Input();
        Right_Button_Input();
        B_Button_Input();
        A_Button_Input();
    }

    public void Left_Button_Input()
    {
        if (Input.GetButtonDown("Left_Input"))
        {
            if (player.select_stage_number > min_scroll_number)
            {
                player.select_stage_number--;
            }
        }
    }

    public void Right_Button_Input()
    {
        if (Input.GetButtonDown("Right_Input"))
        {
            if (player.select_stage_number < max_scroll_number)
            {
                player.select_stage_number++;
            }
        }
    }

    public void B_Button_Input()
    {
        if (Input.GetButtonDown("Decision"))
        {
            player.setSence(Player.Character_Sence.NEXT_GAMEMAIN);
        }
    }

    public void A_Button_Input()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            player.setSence(Player.Character_Sence.NEXT_GAMETITLE);
        }
    }
}
