using System;

namespace BehaviourTree
{
    /// <summary>
    /// 条件を持つノード
    /// </summary>
    public sealed class ConditionNode : NodeBase
    {
        /// <summary>
        /// このノードが実行する関数
        /// <return></return>
        /// </summary>
        private readonly Func<bool> condition;

        public ConditionNode(Func<bool> condition) : base()
        {
            this.condition = condition;
        }

        /// <summary>
        /// 振舞いを実行する
        /// </summary>
        /// <returns>実行後のこのノードの状態</returns>
        public override Status Execute()
        {
            if (condition())
            {
                return Status.SUCCESS;
            }
            else
            {
                return Status.FAILURE;
            }
        }
    }
}
