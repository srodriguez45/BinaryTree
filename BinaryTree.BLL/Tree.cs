
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree.Domain
{
    public class Tree
    {


        public TreeNode RootNode = null;


        /// <summary>
        /// Insertar un nodo. Si el parámetro <paramref name="value"/> es menor 
        /// al <see cref="Root"/> va a la izquierda, sino lo es,
        /// va a la derecha.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="value"></param>
        /// <returns>Retorna el arbol que llega como parámetro</returns>
        public TreeNode InsertTree(TreeNode tree, int value)
        {

            // Se valida si los valores no son nulos
            if (tree == null)
            {
                tree = new TreeNode();
                tree.Root = value;
            }

            // Se valida el valor de la raíz
            else if (value < tree.Root)
            {
                tree.Left = InsertTree(tree.Left, value);
            }
            else
            {
                tree.Right = InsertTree(tree.Right, value);
            }

            return tree;
            
        }


        /// <summary>
        /// Crear un árbol aleatorio, a través de un tamaño específico
        /// y números aleatorios
        /// </summary>
        /// <param name="size"></param>
        /// <param name="randomInterval"></param>
        /// <returns></returns>
        public TreeNode Create(int size, int randomInterval = 100)
        {

            var rnd = new Random();

            for (var i = 0; i < size; i++)
            {
                RootNode = InsertTree(RootNode, rnd.Next(randomInterval));
            }

            return RootNode;

        }



        /// <summary>
        /// Crear un árbol binario mediante 
        /// </summary>
        /// <param name="valueList"></param>
        /// <returns></returns>
        public TreeNode CreateByArray(List<int> valueList)
        {

            /*
            valueList.ForEach(x =>
            {
                RootNode = InsertTree(RootNode, x);
            });
            */

            foreach(var item in valueList)
            {
                RootNode = InsertTree(RootNode, item);
            }

            return RootNode;

        }


        /// <summary>
        /// Árbol quemado con el ejemplo del ejercicio
        /// </summary>
        /// <returns></returns>
        public TreeNode Create()
        {

            RootNode = InsertTree(RootNode, 67);
            RootNode = InsertTree(RootNode, 39);
            RootNode = InsertTree(RootNode, 76);
            RootNode = InsertTree(RootNode, 28);
            RootNode = InsertTree(RootNode, 44);
            RootNode = InsertTree(RootNode, 74);
            RootNode = InsertTree(RootNode, 85);
            RootNode = InsertTree(RootNode, 29);
            RootNode = InsertTree(RootNode, 83);
            RootNode = InsertTree(RootNode, 87);

            return RootNode;

        }



        /// <summary>
        /// Obtener un nodo a través de un valor numérico
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<int> GetTreeNodeByValue(TreeNode node, int value)
        {

            TreeNode parent = null;
            List<int> parentList = new List<int>();

            if (node != null)
            {
                while (node != null && node.Root != value)
                {
                    if (node != null)
                    {
                        parent = node;

                        parentList.Add(node.Root);
                        node = (value < node.Root) ? node.Left : node.Right;
                    }
                }
            }

            return parentList;

        }


        /// <summary>
        /// Obtener el ancestro más cercano a dos valores
        /// </summary>
        /// <param name="node"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public int LowestCommonAncestor(TreeNode node, int val1, int val2)
        {

            List<int> list1 = null;
            List<int> list2 = null;

            list1 = GetTreeNodeByValue(node, val1);
            list2 = GetTreeNodeByValue(node, val2);

            return list1.Intersect(list2).ToList().Last();

        }


    }

}
