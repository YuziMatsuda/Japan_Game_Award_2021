using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select_Draw_Controller : MonoBehaviour
{
    // 各種画像のオブジェクト
    [SerializeField] private GameObject select_background;                  // 背景
    [SerializeField] private GameObject select_stage_screenimage;           // 各種ステージアイコン(小)
    [SerializeField] private GameObject icon;                               // アイコン
    [SerializeField] private GameObject load_now;                           // ロード中
    [SerializeField] private GameObject select_frame;                       // 赤枠
    [SerializeField] private GameObject select_coment_back;                 // コメント用の背景
    [SerializeField] private GameObject canvas;                             // キャンバス
    [SerializeField] private GameObject[] clear = new GameObject[5];        // クリアー
    [SerializeField] private GameObject[] clear_prefab = new GameObject[5]; // クリアー用のプレハブ
    private GameObject player_Draw;                                         // プレイヤーオブジェクト
    private Player player;                                                  // プレイヤー

    [SerializeField] private GameObject select_stage_object;                // 各種ステージアイコン(大)をまとめるオブジェクト
    [SerializeField] private Sprite[] select_stage_sprite;                  // 各種ステージアイコンのスプライト
    [SerializeField] private Image select_stage_image;                      // ステージのイメージ

    [SerializeField] private GameObject select_back_object;                 // 背景画像をまとめるオブジェクト
    [SerializeField] private Sprite[] select_back_sprite;                   // 背景画像のスプライト
    [SerializeField] private Image select_back_image;                       // 背景のイメージ

    [SerializeField] private GameObject select_coment_object;               // ステージのコメント画像をまとめるオブジェクト
    [SerializeField] private Sprite[] select_coment_sprite;                 // ステージのコメント画像用のスプライト
    [SerializeField] private Image select_coment_image;                     // ステージのコメント画像用のイメージ

    private RectTransform load_now_rect;
    private RectTransform select_frame_rect;

    [SerializeField] private int max_stage;                                 // 最大ステージ数
    [SerializeField] private float criteria_log_pos_x;                      // クリアロゴと赤枠を表示する基準のX軸
    [SerializeField] private float move_log_pos_x;                          // クリアロゴと赤枠を表示する際の間隔
    [SerializeField] private float log_pos_y;                               // クリアロゴと赤枠を表示するY軸
    [SerializeField] private float fade_speed;                              // フェードする速度

    // Start is called before the first frame update
    void Start()
    {
        // 各種初期化
        Player_Init();
        Texture_Draw_Init();
    }

    public void Player_Init()
    {
        // プレイヤーのコンポーネントを取得
        player_Draw = GameObject.Find("Canvas");
        player = player_Draw.GetComponent<Player>();
        player.setSence(Player.Character_Sence.NEXT_STAGESELECT);
        // マウスカーソル非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Texture_Draw_Init()
    {
        // 各種画像の表示設定
        select_background.SetActive(true);
        select_stage_screenimage.SetActive(true);
        icon.SetActive(true);
        load_now.SetActive(true);
        select_frame.SetActive(true);
        select_stage_object.SetActive(true);
        select_back_object.SetActive(true);
        select_coment_back.SetActive(true);
        select_coment_object.SetActive(true);
        // ステージアイコンのテクスチャのコンポーネントを追加。
        select_stage_image = select_stage_object.AddComponent<Image>();
        // 背景のテクスチャのコンポーネントを追加。
        select_back_image = select_back_object.AddComponent<Image>();
        // ステージ用のコメントテクスチャのコンポーネントを追加。
        select_coment_image = select_coment_object.AddComponent<Image>();
        // 各種スプライトをイメージに格納
        select_stage_image.sprite = select_stage_sprite[player.select_stage_number];
        select_back_image.sprite = select_back_sprite[player.select_stage_number];
        select_coment_image.sprite = select_coment_sprite[player.select_stage_number];
        load_now_rect = load_now.GetComponent<RectTransform>();
        select_frame_rect = select_frame.GetComponent<RectTransform>();
        player.select_stage_number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 画像表示
        Draw_Texture(player);
    }

   public void Draw_Texture(Player player)
    {
        // プレイヤーのシーン遷移
        switch (player.sence)
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

    // ステージセレクトシーンの画像描画処理
    public void Draw_StageSelect()
    {
        //  スクショした各種ステージアイコン(大)の切り替えを配列で行う。
        select_stage_image.sprite = select_stage_sprite[player.select_stage_number];
        //　背景の切り替えを配列で行う。
        select_back_image.sprite = select_back_sprite[player.select_stage_number];
        // 赤枠を表示し、左右移動する事で赤枠も移動する。
        select_frame_rect.anchoredPosition = new Vector2((move_log_pos_x * player.select_stage_number) + criteria_log_pos_x, log_pos_y);
        //  コメントの切り替えを配列で行う。
        select_coment_image.sprite = select_coment_sprite[player.select_stage_number];
    }

    // フェードイン処理
    public void Draw_LoadNow_FadeIn(Player.Character_Sence Next_Scene)
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

    // フェードアウト処理
    public void Draw_LoadNow_FadeOut(Player.Character_Sence Next_Scene)
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

    // シーン切り替え処理
    public void SenceChange(Player.Character_Sence Next_Scene)
    {
        if (Next_Scene == Player.Character_Sence.NEXT_GAMEMAIN)
        {
            player.set_Stagenumber(player.select_stage_number);
            Next_Stage_Number();
        }
        else if (Next_Scene == Player.Character_Sence.NEXT_GAMETITLE)
        {
            player.before_setSence(Player.Character_Sence.GAME_STAGESELECT);
            SceneManager.LoadScene("Title_Scene");
        }
    }

    // ステージの遷移先を指定
    public void Next_Stage_Number()
    {
        switch (player.select_stage_number)
        {
            case 0:
            {
                SceneManager.LoadScene("main");
                break;
            }
            case 1:
            {
                SceneManager.LoadScene("Stage2_Scene");
                break;
            }
            case 2:
            {
                SceneManager.LoadScene("Stage3_Scene");
                break;
            }
            case 3:
            {
                SceneManager.LoadScene("Stage4_Scene");
                break;
            }
            case 4:
            {
                SceneManager.LoadScene("Stage5_Scene");
                break;
            }
        }
    }
}
