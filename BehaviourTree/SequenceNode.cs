namespace BehaviourTree
{
    /// <summary>
    /// 逐次的なノード
    /// 子を一つ以上持つことができる
    /// </summary>
    public sealed class SequenceNode : NodeBase
    {
        /// <summary>
        /// 子ノード配列
        /// </summary>
        private readonly NodeBase[] childs;

        /// <summary>
        /// 次に実行する子ノード
        /// 次に実行する子ノードが無い場合は0
        /// </summary>
        private int next;

        public SequenceNode(params NodeBase[] childs) : base()
        {
            this.childs = childs;
            this.next = 0;
        }

        /// <summary>
        /// 子ノードが成功したら、次の子ノードを再帰的に実行する。
        /// 失敗の場合は、FAILUREを返し、
        /// 実行中の場合は、RUNNINGを返す。
        /// 最後の子ノードを実行して成功したら、SUCCESSを返す。
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            switch (childs[next].Execute())
            {
                case Status.RUNNING:
                    return Status.RUNNING;
                case Status.FAILURE:
                    next = 0;
                    return Status.FAILURE;
                case Status.SUCCESS:
                    next++;
                    break;
            }
            if (next < childs.Length)
            {
                return Execute();
            }
            else
            {
                next = 0;
                return Status.SUCCESS;
            }
        }
    }
}