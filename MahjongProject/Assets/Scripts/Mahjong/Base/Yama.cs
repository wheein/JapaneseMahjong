﻿
/// <summary>
/// 山を管理する, 所有堆起来的牌叫山牌
/// 最后的7幢牌，共14张，叫牌山
/// </summary>

public class Yama 
{
    // 山牌の配列の最大数
    public readonly static int YAMA_HAIS_MAX = 136;

    // 自摸牌の配列の最大数
    public readonly static int TSUMO_HAIS_MAX = 122;

    // 杠上开花牌の配列の最大数
    public readonly static int RINSHAN_HAIS_MAX = 4;

    // 表と裏ドラの配列の最大数
    public readonly static int DORA_HAIS_MAX = 5; //x2


    // 山牌の配列
    private Hai[] _yamaHais;


    // ツモ牌の配列
    private Hai[] _tsumoHais;

    // リンシャン(岭上开花)牌の配列
    private Hai[] _rinshanHais;

    // ツモ牌のインデックス(index)
    private int _tsumoHaisIndex = 0;

    // リンシャン牌の位置
    private int _rinshanHaisIndex = 0;


    // 表ドラ牌の配列
    private Hai[] _omoteDoraHais;

    // 裏ドラ牌の配列
    private Hai[] _uraDoraHais;


    public Yama()
    {
        _yamaHais = new Hai[YAMA_HAIS_MAX];
        _tsumoHais = new Hai[TSUMO_HAIS_MAX];
        _rinshanHais = new Hai[RINSHAN_HAIS_MAX];
        _omoteDoraHais = new Hai[DORA_HAIS_MAX];
        _uraDoraHais = new Hai[DORA_HAIS_MAX];

        for (int i = Hai.ID_ITEM_MIN; i < Hai.ID_ITEM_MAX; i++)
        {
            for( int j = 0; j < 4; j++ ){
                _yamaHais[(i * 4) + j] = new Hai(i);
            }
        }

        setTsumoHaisStartIndex(0);
    }

    // temply implement.
    public Hai[] getYamaHais()
    {
        return _yamaHais;
    }

    // ツモ牌の残り数を取得する
    public int getTsumoNokori()
    {
        return TSUMO_HAIS_MAX - _rinshanHaisIndex - _tsumoHaisIndex;
    }

    // リンシャン(岭上开花)牌の残り数を取得する
    public int getRinshanNokori()
    {
        return RINSHAN_HAIS_MAX - _rinshanHaisIndex;
    }


    // 洗牌する
    public void XiPai()
    {
        Hai temp;
        int j;

        for (int i = 0; i < YAMA_HAIS_MAX; i++) 
        {
            // get a random index.
            j = Utils.GetRandomNum(0, YAMA_HAIS_MAX);

            // exchange hais.
            temp = _yamaHais[i];
            _yamaHais[i] = _yamaHais[j];
            _yamaHais[j] = temp;
        }
    }

    /// <summary>
    /// 初始拿牌.
    /// </summary>
    public Hai[] PickHaipai()
    {
        Hai[] hais = new Hai[4];
        for( int i = 0; i < hais.Length; i++ ) 
        {
            hais[i] = new Hai( _tsumoHais[_tsumoHaisIndex] );

            _tsumoHaisIndex++;
        }

        return hais;
    }


    // ツモ牌を取得する
    public Hai PickTsumoHai()
    {
        if( getTsumoNokori() <= 0)
            return null;

        Hai tsumoHai = new Hai(_tsumoHais[_tsumoHaisIndex]);
        _tsumoHaisIndex++;

        return tsumoHai;
    }

    // リンシャン(岭上开花)牌を取得する
    public Hai PickRinshanTsumoHai()
    {
        if( getRinshanNokori() <= 0 )
            return null;

        Hai rinshanHai = new Hai(_rinshanHais[_rinshanHaisIndex]);
        _rinshanHaisIndex++;

        return rinshanHai;
    }

    // 表ドラの配列を取得する
    public Hai[] getOmoteDoraHais()
    {
        int omoteDoraHaisCount = _rinshanHaisIndex + 1;
        Hai[] omoteDoraHais = new Hai[omoteDoraHaisCount];

        for (int i = 0; i < omoteDoraHais.Length; i++)
            omoteDoraHais[i] = new Hai(this._omoteDoraHais[i]);

        return omoteDoraHais;
    }

    // 裏ドラの配列を取得する
    public Hai[] getUraDoraHais()
    {
        int uraDoraHaisCount = _rinshanHaisIndex + 1;
        Hai[] uraDoraHais = new Hai[uraDoraHaisCount];

        for (int i = 0; i < uraDoraHais.Length; i++)
            uraDoraHais[i] = new Hai(this._uraDoraHais[i]);

        return uraDoraHais;
    }

    public Hai[] getAllDoraHais()
    {
        int omoteDoraHaisLength = _rinshanHaisIndex + 1;
        int uraDoraHaisLength = _rinshanHaisIndex + 1;
        int allDoraHaisLength = omoteDoraHaisLength + uraDoraHaisLength;

        Hai[] allDoraHais = new Hai[allDoraHaisLength];

        for (int i = 0; i < omoteDoraHaisLength; i++)
            allDoraHais[i] = new Hai(this._omoteDoraHais[i]);

        for (int i = 0; i < uraDoraHaisLength; i++)
            allDoraHais[omoteDoraHaisLength + i] = new Hai(this._uraDoraHais[i]);

        return allDoraHais;
    }

    /**
     * ツモ牌の開始位置を設定する。
     *
     *  the correct array is like:
     *  
     *  Tsumo Start <--| Wareme |<-- Rinshan 2x2 <-- Doras 2x5 |<-- Tsumo End <--.
     */

    public bool setTsumoHaisStartIndex(int tsumoHaiStartIndex)
    {
        if (tsumoHaiStartIndex >= YAMA_HAIS_MAX)
            return false;

        int yamaHaisIndex = tsumoHaiStartIndex;

        // tsumo hais. 122.
        for (int i = 0; i < TSUMO_HAIS_MAX; i++)
        {
            _tsumoHais[i] = _yamaHais[yamaHaisIndex];

            yamaHaisIndex++;

            if (yamaHaisIndex >= YAMA_HAIS_MAX)
                yamaHaisIndex = 0;
        }
        _tsumoHaisIndex = 0;


        // dora hais. 1+4=5. 
        for( int i = DORA_HAIS_MAX - 1; i >= 0; i-- ) // reverse.
        {
            // 表dora.
            _omoteDoraHais[i] = _yamaHais[yamaHaisIndex];

            yamaHaisIndex++;
            if( yamaHaisIndex >= YAMA_HAIS_MAX )
                yamaHaisIndex = 0;

            // 里dora.
            _uraDoraHais[i] = _yamaHais[yamaHaisIndex];

            yamaHaisIndex++;
            if( yamaHaisIndex >= YAMA_HAIS_MAX )
                yamaHaisIndex = 0;
        }

        // rinshan hais. 4.
        for( int i = 0; i < RINSHAN_HAIS_MAX; i++ )      
        {
            _rinshanHais[i] = _yamaHais[yamaHaisIndex];

            yamaHaisIndex++;
            if( yamaHaisIndex >= YAMA_HAIS_MAX )
                yamaHaisIndex = 0;
        }

        /// reverse.
        ///   2 0  ->  0 2
        ///   3 1      1 3
        Hai temp = _rinshanHais[0];
        _rinshanHais[0] = _rinshanHais[2];
        _rinshanHais[2] = temp;

        temp = _rinshanHais[1];
        _rinshanHais[1] = _rinshanHais[3];
        _rinshanHais[3] = temp;

        _rinshanHaisIndex = 0;

        return true;
    }

    // 赤ドラ牌
    public void setRedDora(int id, int num)
    {
        if(num <= 0) 
            return;

        for(int i = 0; i < _yamaHais.Length; i++) 
        {
            if(_yamaHais[i].ID == id) {
                _yamaHais[i].IsRed = true;

                num--;

                if(num <= 0) 
                    break;
            }
        } 
    }

}