namespace BehaviourTree
{
    /// <summary>
    /// 振舞い木の状態を表す列挙型
    /// SUCCESSは成功、
    /// FAILUREは失敗、
    /// RUNNINGは実行中を表す。
    /// </summary>
    public enum Status
    {
        SUCCESS,
        FAILURE,
        RUNNING
    }

    /// <summary>
    /// 振舞い木の抽象クラス
    /// </summary>
    public abstract class NodeBase
    {
        /// <summary>
        /// このメソッドを通して振舞いを実行する
        /// このメソッドを実行したノードは必ずSUCCESS,FAILURE,RUNNINGのいずれかを返すこと
        /// </summary>
        /// <returns>実行後の状態</returns>
        public abstract Status Execute();
    }
}