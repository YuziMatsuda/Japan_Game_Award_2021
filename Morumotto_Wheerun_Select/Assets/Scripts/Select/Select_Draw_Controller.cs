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
    [SerializeField] private GameObject select_stage_screenimage_A;         // 各種ステージアイコン_A(小)
    [SerializeField] private GameObject select_stage_screenimage_B;         // 各種ステージアイコン_B(小)
    [SerializeField] private GameObject icon;                               // アイコン
    [SerializeField] private GameObject load_now;                           // ロード中
    [SerializeField] private GameObject select_frame;                       // 赤枠
    [SerializeField] private GameObject select_coment_back;                 // コメント用の背景
    [SerializeField] private GameObject canvas;                             // キャンバス
    [SerializeField] private GameObject[] clear = new GameObject[10];       // クリアー
    [SerializeField] private GameObject[] clear_prefab = new GameObject[10];// クリアー用のプレハブ
    private GameObject player_Draw;                                         // プレイヤーオブジェクト
    private Select_Player player;                                                  // プレイヤー

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

    [SerializeField] private int min_scroll_number;                         // 最小のスクロール値 (０固定)
    [SerializeField] private int max_scroll_number;                         // 最大のスクロール値（最大ステージ数）
    private int change_screen_number=5;                                     // 画面が切り替わる数

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
        player = player_Draw.GetComponent<Select_Player>();
        player.setSence(Select_Player.Character_Sence.NEXT_STAGESELECT);
        // マウスカーソル非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // ステージ番号を取得 (結合時にコメント解除)
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
    //            // ステージ名が取得できます。
    //            Debug.Log(info._fromSceneName);
    //            // ステージ番号取得
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
        // 各種画像の表示設定
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
        // ステージ番号を取得 (結合時にコメント追加)
        player.select_stage_number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 画像表示
        Draw_Texture(player);
    }

   public void Draw_Texture(Select_Player player)
    {
        // プレイヤーのシーン遷移
        switch (player.sence)
        {
            case Select_Player.Character_Sence.NEXT_STAGESELECT:{Draw_LoadNow_FadeIn(Select_Player.Character_Sence.GAME_STAGESELECT);break;}
            case Select_Player.Character_Sence.GAME_STAGESELECT:{Draw_StageSelect();break;}
            case Select_Player.Character_Sence.NEXT_GAMEMAIN:{Draw_LoadNow_FadeOut(Select_Player.Character_Sence.NEXT_GAMEMAIN);break;}
            case Select_Player.Character_Sence.NEXT_GAMETITLE:{Draw_LoadNow_FadeOut(Select_Player.Character_Sence.NEXT_GAMETITLE);break;}
        }
    }

    // ステージセレクトシーンの画像描画処理
    public void Draw_StageSelect()
    {
        //  スクショした各種ステージアイコン(大)の切り替えを配列で行う。
        select_stage_image.sprite = select_stage_sprite[player.select_stage_number];
        //　背景の切り替えを配列で行う。
        select_back_image.sprite = select_back_sprite[player.select_stage_number];
        if (player.select_stage_number >= change_screen_number)
        {
            // 赤枠を表示し、左右移動する事で赤枠も移動する。
            select_frame_rect.anchoredPosition = new Vector2((move_log_pos_x * player.select_stage_number) + criteria_log_pos_x - 1850.0f, log_pos_y);
            select_stage_screenimage_A.SetActive(false);
            select_stage_screenimage_B.SetActive(true);
        }
        else
        {
            // 赤枠を表示し、左右移動する事で赤枠も移動する。
            select_frame_rect.anchoredPosition = new Vector2((move_log_pos_x * player.select_stage_number) + criteria_log_pos_x, log_pos_y);
            select_stage_screenimage_A.SetActive(true);
            select_stage_screenimage_B.SetActive(false);
        }
        //  コメントの切り替えを配列で行う。
        select_coment_image.sprite = select_coment_sprite[player.select_stage_number];
    }

    // フェードイン処理
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

    // フェードアウト処理
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

    // シーン切り替え処理
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

    // ステージの遷移先を指定
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
