using System;

namespace BehaviourTree
{
    /// <summary>
    /// 振舞い木の中で、実行するノード
    /// 子ノードを持つことができない
    /// 所謂葉
    /// </summary>
    public sealed class ActionNode : NodeBase
    {
        /// <summary>
        /// このノードが実行する関数
        /// <returns>実行後のこのノードの状態</returns>
        /// </summary>
        private readonly Func<Status> action;

        public ActionNode(Func<Status> action) : base()
        {
            this.action = action;
        }

        /// <summary>
        /// 振舞いを実行する
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            return action();
        }
    }
}