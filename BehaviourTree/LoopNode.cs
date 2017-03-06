namespace BehaviourTree
{
    /// <summary>
    /// 繰り返しを行うノード
    /// </summary>
    public sealed class LoopNode : NodeBase
    {
        /// <summary>
        /// 子ノード
        /// </summary>
        private readonly NodeBase child;

        public LoopNode(NodeBase child) : base()
        {
            this.child = child;
        }

        /// <summary>
        /// 子ノードを実行して、
        /// 成功または実行中なら再度実行し、
        /// 失敗ならFAILUREを返す。
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            switch (child.Execute())
            {
                case Status.FAILURE:
                    return Status.FAILURE;
                default:
                    return Execute();
            }
        }
    }
}