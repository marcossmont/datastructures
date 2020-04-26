namespace BinaryTree.NodeDeletion
{
    internal class RighChildtWithoutLeftChildNodeDeletionStrategy : INodeDeletionStrategy
    {
        private MyBinaryTreeNode node;

        public RighChildtWithoutLeftChildNodeDeletionStrategy(MyBinaryTreeNode node)
        {
            this.node = node;
        }

        public MyBinaryTreeNode Delete()
        {
            node.Right.Left = node.Left;
            return node.Right;
        }
    }
}