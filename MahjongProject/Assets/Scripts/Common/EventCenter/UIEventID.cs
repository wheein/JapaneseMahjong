﻿
public enum UIEventID 
{
    None = 0,

    #region event id
    // pick a tsumo hai. 
    PickHai,
    // 捨牌の選択 
    Select_SuteHai,
    // 捨牌 
    SuteHai,
    // リーチ 
    Reach,
    // ポン 
    Pon,
    // チー(左) 
    Chii_Left,
    // チー(中央) 
    Chii_Center,
    // チー(右) 
    Chii_Right,
    // 大明槓 
    DaiMinKan,
    // 加槓 
    Kakan,
    // 暗槓 
    Ankan,
    // ロンのチェック 
    Ron_Check,
    // ツモあがり 
    Tsumo_Agari,
    // ロンあがり 
    Ron_Agari,
    // 流し 
    Nagashi,
    #endregion


    // ゲームの開始 
    Start_Game,
    // 連荘
    RenChan,
    // 局の開始 
    Start_Kyoku,

    Init_Game,
    // Saifuri
    Saifuri,
    // 配牌
    HaiPai,

    On_Saifuri_End,

    Init_PlayerInfoUI,

    Saifuri_For_Haipai,
    On_Saifuri_For_Haipai_End,

    SetYama_BeforeHaipai,
    SetUI_AfterHaipai,

    // 理牌待ち 
    UI_Wait_Rihai,
    // 進行待ち 
    UI_Wait_Progress,
    // プレイヤーアクションの入力 
    UI_Input_Player_Action,

    // 流局 
    RyuuKyoku,
    // 局の終了 
    End_Kyoku,
    // ゲームの終了 
    End_Game,


}
