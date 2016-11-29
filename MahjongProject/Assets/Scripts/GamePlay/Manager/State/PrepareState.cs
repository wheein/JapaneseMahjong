﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Sai sai furi for deciding Qin jia.
/// </summary>

public class PrepareState : MahjongState 
{

    public override void Enter() {
        base.Enter();

        owner.SetDelegate(OnSaifuriForQinEnd);

        EventManager.Get().SendEvent(EventId.Saifuri_For_Qin);
    }

    void OnSaifuriForQinEnd() {
        logicOwner.SetChiicha();

        // set jikazes.
        logicOwner.PrepareKyokuYama();

        EventManager.Get().SendEvent(EventId.Init_PlayerInfoUI);
        EventManager.Get().SendEvent(EventId.SetYama_BeforeHaipai);

        owner.ChangeState<HaiPaiState>();
    }
}