using BinaryTree.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BinaryTree.Service.Controllers
{


    public class AncestorController : ApiController
    {

        public Tree tree = new Tree();

        [HttpPost]
        [Route("api/Ancestor/GetAncestorExample")]
        public int GetAncestorExampleTree([FromBody] RequestDTO request)
        {

            int response = -1;

            try
            {
                TreeNode rootNode;
                //Tree tree = new Tree();

                // árbol de ejemplo con la prueba enviada por correo
                rootNode = tree.Create();

                response = tree.LowestCommonAncestor(rootNode, request.Val1, request.Val2);

            } catch(Exception e)
            {
                throw new Exception($"Error al obtener el ancestro: {e}");
            }

            return response;

        }



        [HttpPost]
        [Route("api/Ancestor/GetAncestor")]
        public int GetAncestor([FromBody] RequestDTO request)
        {

            int response = -1;

            try
            {

                if (request.Node != null)
                {
                    response = tree.LowestCommonAncestor(
                        request.Node, request.Val1, request.Val2
                    );
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Error al obtener el ancestro: {e}");
            }

            return response;

        }


        [HttpPost]
        [Route("api/TreeNode/Create")]
        public TreeNode CreateTreeNode([FromBody] List<int> list)
        {

            if (list != null && list.Count > 0)
            {
                return tree.CreateByArray(list);
            }
            else
            {
                return new TreeNode();
            }
        }



        [HttpPost]
        [Route("api/TreeNode/CreateByExample")]
        public TreeNode GetList([FromBody] List<int> list)
        {
            return tree.Create();
        }


        /*
        [HttpGet]
        public TreeNode simpleCreate()
        {
            return tree.Create();
        }*/


        /*
        [HttpPost]
        public int GetAncestorByCreateTree([FromBody] RequestDTO request)
        {

            TreeNode rootNode;
            Tree tree = new Tree();

            // árbol de ejemplo con la prueba enviada por correo
            rootNode = tree.Create();

            return tree.LowestCommonAncestor(request.Node, request.Val1, request.Val2);

        }*/


    }
}
