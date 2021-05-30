using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Draw_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject title_background_object;        // 背景
    [SerializeField] private GameObject push_game_object;               // ゲーム開始時のオブジェクト
    [SerializeField] private GameObject select_object;                  // ゲーム選択のオブジェクト
    [SerializeField] private GameObject game_datadelete_check;          // ゲームデータ削除確認のオブジェクト
    [SerializeField] private GameObject game_end_check;                 // ゲーム終了のオブジェクト
    [SerializeField] private GameObject icon;                           // アイコン
    [SerializeField] private GameObject load_now;                       // ロード中
    [SerializeField] private GameObject data_dalete_complete;           // データ削除完了ロゴ
    [SerializeField] private GameObject fade_in;                        // フェードイン

    private RectTransform icon_rect;                                    // アイコン画像の座標
    private RectTransform load_now_rect;                                // ロード中画像の座標
    private RectTransform data_delete_complete_rect;                    // データ削除完了画像の座標
    private Image fade_Draw;        
    private GameObject player_Draw;                                     // プレイヤーオブジェクト
    private Player player;                                              // プレイヤー
    private Player_Data player_data;

    private float load_now_position_x;                                  // ロード中画像のX軸
    private float data_delete_complete_position_y;                      // データ削除完了画像のX軸
    private float data_delete_complete_position_x;                      // データ削除完了画像のY軸
    private float timer;                                                // フェード用のタイマー
    [SerializeField] private float alpha;                               // フェードのα値
    private float alpha_speed;                                          // フェードの速度
    float red, green, blue;

    void Start()
    {
        Player_Init();
        Texture_Draw_Init();
    }

    public void Player_Init()
    {
        // プレイヤーのコンポーネントを取得。
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
        // 結合時に以下の処理に変更
        // player.before_check_sence = player.brfore_getSence();

        // 前回のシーンを格納
        player.before_check_sence = player.brfore_getSence();

        // 結合時に削除
        /*
        if (player.before_check_sence == null)
        {
            player.before_check_sence = Player.Character_Sence.OPENING_MOVIE;
        }
        */

        // 以前のシーンを確認
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
        // 各種画像の表示・座標設定
        title_background_object.SetActive(true);
        load_now.SetActive(true);
        icon_rect = icon.GetComponent<RectTransform>();
        load_now_rect = load_now.GetComponent<RectTransform>();
        data_delete_complete_rect = data_dalete_complete.GetComponent<RectTransform>();
        fade_Draw = fade_in.GetComponent<Image>();
        Fade_Init();            // フェードの初期化メソッド
        // 座標位置の設定
        data_delete_complete_position_x = 650.0f;
        data_delete_complete_position_y = 700.0f;
        alpha_speed = 0.5f;
    }

    public void Fade_Init()
    {
        // シーンチェック
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
            load_now_position_x = -1920.0f;        // ロード画面の初期座標位置
        }
    }


    // Update is called once per frame
    void Update()
    {
        Draw_Texture(player);
    }

    // 各シーンの画面描画分岐処理
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

    // オープニングムービーからタイトルへ遷移した時の処理
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
        // ３秒経過後にフェードアウト
        if (alpha <= 0)
        {
            player.sence = Player.Character_Sence.PUSH_GAME_START;
        }
    }

    // セレクトシーンからタイトルシーンに遷移した時の処理
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
            load_now_position_x = -1920.0f;        // ロード画面の初期座標位置
            player.sence = Player.Character_Sence.PUSH_GAME_START;
        }
    }

    // 「PushGameStart」の表示
    public void PushGameStart_Draw()
    {
        push_game_object.SetActive(true);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(false);
        icon.SetActive(false);
    }

    //「ゲームモードを選択」を表示と入力後の処理
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
            // ゲームデータ削除完了
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

    // 「ロード中」のフェード処理
    public void GameStart_Draw()
    {

        float Load_Now_Max_Position = 0.0f;
        if (load_now_rect.anchoredPosition.x <= Load_Now_Max_Position)
        {
            load_now_rect.anchoredPosition -= new Vector2(load_now_position_x * Time.deltaTime, 0);
        }
        else
        {
            // 以前のシーンを格納
            player.before_setSence(Player.Character_Sence.GAME_SELECT);
            // セレクトシーンに切り替える処理を記載
            SceneManager.LoadScene("Select_Scene");
        }
    }

    // 「ゲームデータ削除確認」の画像を表示
    public void GameDatadeleteCheck_Draw(Player player)
    {
        push_game_object.SetActive(false);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(true);
        game_end_check.SetActive(false);
        icon.SetActive(true);
        YesNo_Draw(player);
    }

    // 「ゲームデータを削除しました」の画像を表示
    public void GameDatadelete_Draw()
    {
        data_dalete_complete.SetActive(true);
        // player_data.Delete_Start_Data(player_data);
        /*
        if (!player_data.delete_start)
        {
            // データ削除処理
            player_data.delete_Data(player_data.max_stage);
            // セーブ処理
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
            // 2秒経過した後に「GameSelect_Draw」へ遷移
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

    //「ゲーム終了確認」画像を表示
    public void GameEndCheck_Draw(Player player)
    {
        push_game_object.SetActive(false);
        select_object.SetActive(false);
        game_datadelete_check.SetActive(false);
        game_end_check.SetActive(true);
        icon.SetActive(true);
        YesNo_Draw(player);
    }

    //「はい・いいえ」の画像表示と処理を実装
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

    // ゲーム終了処理を実装
    public void GameEnd_Draw()
    {
        fade_in.SetActive(true);
        timer += Time.deltaTime;
        int MaxColor = 255;

        fade_Draw.color = new Color(MaxColor, MaxColor, MaxColor, alpha);
        alpha += alpha_speed * Time.deltaTime;

        // ３秒経過後にフェードイン (ゲーム終了の処理)
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
