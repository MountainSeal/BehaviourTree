namespace BehaviourTree
{
    /// <summary>
    /// 択一的なノード
    /// 子を一つ以上持つことができる(0ではない)
    /// </summary>
    public sealed class SelectorNode : NodeBase
    {
        /// <summary>
        /// 子ノード配列
        /// </summary>
        private readonly NodeBase[] childs;

        /// <summary>
        /// 状態がRUNNINGな子ノードのインデックス
        /// RUNNINGな子ノードを持たない場合は-1
        /// </summary>
        private int selector;

        public SelectorNode(params NodeBase[] childs) : base()
        {
            this.childs = childs;
            this.selector = -1;
        }

        /// <summary>
        /// 子ノードが成功したら、SUCCESSを返し、
        /// 実行中であれば、RUNNINGを返す。
        /// 失敗したら次の子ノードを実行し、
        /// すべて失敗したらFAILUREを返す。
        /// 
        /// もし既に実行中の子ノードがあれば、
        /// その子ノードを実行して返す。
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            if (selector == -1)
            {
                for (int i = 0; i < childs.Length; i++)
                {
                    switch (childs[i].Execute())
                    {
                        case Status.RUNNING:
                            selector = i;
                            return Status.RUNNING;
                        case Status.SUCCESS:
                            selector = -1;
                            return Status.SUCCESS;
                        case Status.FAILURE:
                            continue;
                    }
                }
            }
            else
            {
                return childs[selector].Execute();
            }
            return Status.FAILURE;
        }
    }
}
