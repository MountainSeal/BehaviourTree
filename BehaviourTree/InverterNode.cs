namespace BehaviourTree
{
    /// <summary>
    /// 状態を反転させるノード
    /// </summary>
    public sealed class InverterNode : NodeBase
    {
        /// <summary>
        /// 子ノード
        /// </summary>
        private readonly NodeBase child;

        public InverterNode(NodeBase child) : base()
        {
            this.child = child;
        }

        /// <summary>
        /// 成功と失敗子ノードを実行し、結果を逆にして返す。
        /// 実行中であれば、そのまま返す。
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            switch (child.Execute())
            {
                case Status.SUCCESS:
                    return Status.FAILURE;
                case Status.FAILURE:
                    return Status.SUCCESS;
                default:
                    return Status.RUNNING;
            }
        }
    }
}