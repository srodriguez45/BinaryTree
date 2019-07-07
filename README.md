# Árbol binario
Generar y consultar ancestros en un árbol binario, el puerto en los endpoints puede cambiar al momento de correr el proyecto de forma local.

## Endpoint Crear un árbol binario a través de un listado de números
Crear un árbol binario a través de un listado de enteros en el siguiente endpoint:

[http://localhost:53141/api/TreeNode/Create](http://localhost:53141/api/TreeNode/Create)

### Request body
Cómo json se puede utilizar el siguiente body en la opción raw en POSTMAN:

```json
[67, 39, 76, 28, 44, 74, 85, 29, 83, 87]
```
### Content type, Accept: 

application/json


### Response:

```json
{
    "Root": 67,
    "Left": {
        "Root": 39,
        "Left": {
            "Root": 28,
            "Left": null,
            "Right": {
                "Root": 29,
                "Left": null,
                "Right": null
            }
        },
        "Right": {
            "Root": 44,
            "Left": null,
            "Right": null
        }
    },
    "Right": {
        "Root": 76,
        "Left": {
            "Root": 74,
            "Left": null,
            "Right": null
        },
        "Right": {
            "Root": 85,
            "Left": {
                "Root": 83,
                "Left": null,
                "Right": null
            },
            "Right": {
                "Root": 87,
                "Left": null,
                "Right": null
            }
        }
    }
}
```

---


## Endpoint Obtener el ancestro a través de dos valores enteros y un árbol binario
Consultar el ancestro más cercano para dos valores.

[http://localhost:53141/api/Ancestor/GetAncestor](http://localhost:53141/api/Ancestor/GetAncestor)

### Request body
Cómo json se puede utilizar el siguiente body en la opción raw en POSTMAN:

```json
{
	"Val1": 83,
	"Val2": 47,
	"Node": {
	    "Root": 67,
	    "Left": {
	        "Root": 39,
	        "Left": {
	            "Root": 28,
	            "Left": null,
	            "Right": {
	                "Root": 29,
	                "Left": null,
	                "Right": null
	            }
	        },
	        "Right": {
	            "Root": 44,
	            "Left": null,
	            "Right": null
	        }
	    },
	    "Right": {
	        "Root": 76,
	        "Left": {
	            "Root": 74,
	            "Left": null,
	            "Right": null
	        },
	        "Right": {
	            "Root": 85,
	            "Left": {
	                "Root": 83,
	                "Left": null,
	                "Right": null
	            },
	            "Right": {
	                "Root": 87,
	                "Left": null,
	                "Right": null
	            }
	        }
	    }
	}
}
```
Los valores Val1 y Val2 son datos del árbol binario, el arbol binario se puede crear en el primer endpoint y pegarlo en el nodo: "Node"

### Content type, Accept: 
application/json

### Response:
Número entero con el valor de la raíz del TreeNode.

---

# Pruebas unitarias:
Las pruebas unitarias se realizaron con los siguientes Assert y se pueden encontrar adjuntas en el proyecto BinaryTree.Service.Tests:


```C#
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
```

