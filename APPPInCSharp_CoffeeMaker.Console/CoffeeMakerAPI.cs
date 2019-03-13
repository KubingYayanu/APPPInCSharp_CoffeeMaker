namespace APPPInCSharp_CoffeeMaker.Console
{
    public enum WarmerPlateStatus
    {
        WARMER_EMPTY,
        POT_EMPTY,
        POT_NOT_EMPTY
    }

    public enum BoilerStatus
    {
        EMPTY,
        NOT_EMPTY
    }

    public enum BrewButtonStatus
    {
        PUSHED,
        NOT_PUSHED
    }

    public enum BoilerState
    {
        ON,
        OFF
    }

    public enum WarmerState
    {
        ON,
        OFF
    }

    public enum IndicatorState
    {
        ON,
        OFF
    }

    public enum ReliefValveState
    {
        OPEN,
        CLOSED
    }

    public interface CoffeeMakerAPI
    {
        /// <summary>
        /// 感測器檢測有沒有壺，壺中有沒有咖啡
        /// </summary>
        /// <returns>保溫盤感測器的狀態</returns>
        WarmerPlateStatus GetWarmerPlateStatus();

        /// <summary>
        /// 加熱器開關是浮動的，確保加熱器中至少有半杯水
        /// </summary>
        /// <returns>加熱器開關的狀態</returns>
        BoilerStatus GetBoilerStatus();

        /// <summary>
        /// 沖煮按鈕是一個瞬時性開關，可以記住自己的狀態。
        /// 每次呼叫這個函式都會回傳記憶的狀態，
        /// 然後將該狀態重置為NOT_PUSHED。
        /// </summary>
        /// <returns>回傳沖煮咖啡按鈕的狀態</returns>
        BrewButtonStatus GetBrewButtonStatus();

        /// <summary>
        /// 負責開、關加熱器中的加熱元件
        /// </summary>
        /// <param name="s"></param>
        void SetBoilerState(BoilerState s);

        /// <summary>
        /// 負責開、關保溫盤中的元件
        /// </summary>
        /// <param name="s"></param>
        void SetWarmerState(WarmerState s);

        /// <summary>
        /// 負責開、關指示燈。
        /// 沖煮完成時，燈亮；使用者按下沖煮按鈕時，燈滅。
        /// </summary>
        /// <param name="s"></param>
        void SetIndicatorState(IndicatorState s);

        /// <summary>
        /// 負責開、關減壓閥。
        /// 關閉減壓閥時，加熱器中的壓力使熱水噴灑在咖啡濾水器上。
        /// 打開減壓閥時，加熱器中的蒸氣排到外部，
        /// 加熱器中的水不會再噴到濾水器上。
        /// </summary>
        /// <param name="s"></param>
        void SetReliefValveState(ReliefValveState s);
    }
}