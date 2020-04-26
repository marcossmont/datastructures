namespace BinaryTree.NodeDeletion
{
    public class NodeDeletionStrategyFactory
    {
        private readonly MyBinaryTreeNode node;

        public NodeDeletionStrategyFactory(MyBinaryTreeNode node)
        {
            this.node = node;
        }
        public INodeDeletionStrategy GetImplementation()
        {
            if (node.Right == null)
            {
                return new WithoutRightChildNodeDeletionStrategy(node);
            }
            else if (node.Right.Left == null)
            {
                return new RighChildtWithoutLeftChildNodeDeletionStrategy(node);
            }
            else
            {
                return new RighChildtWitLeftChildNodeDeletionStrategy(node);
            }
        }
    }
}