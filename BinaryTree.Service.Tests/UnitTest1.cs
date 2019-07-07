using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree.Domain;

namespace BinaryTree.Service.Tests
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Unit test que comprueba los valores de los ancestros de acuerdo
        /// a la prueba enviada por parte de Masivian
        /// </summary>
        [TestMethod]
        public void CreateTree()
        {

            TreeNode rootNode;
            Tree tree = new Tree();

            // árbol de ejemplo con la prueba enviada por correo
            rootNode = tree.Create();

            Assert.AreEqual(tree.LowestCommonAncestor(rootNode, 29, 44), 39);
            Assert.AreEqual(tree.LowestCommonAncestor(rootNode, 44, 85), 67);
            Assert.AreEqual(tree.LowestCommonAncestor(rootNode, 83, 87), 85);

        }
    }
}
