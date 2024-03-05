using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    public class ValidacionesForm
    {
        // Validar que un campo no esté vacío o contenga solo espacios
        public static bool NoEstaVacio(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validar que un campo contenga solo texto
        public static bool EsSoloTexto(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        // Validar que un campo contenga solo números
        public static bool EsSoloNumeros(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$");
        }

        // Validar que un campo tenga el formato de un email
        public static bool EsEmailValido(string input)
        {
         // Utilizamos una expresión regular para validar el formato del email
         return Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }


        // Validar que si todos los nodos hijos están chequeados, el nodo raiz se marque. En caso contrario se desmarca
        public static void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // Si el nodo tiene hijos, marcar recursivamente todos los hijos
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        public static void CheckRootNodes(TreeView treeView)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.ForeColor != Color.Gold)
                {
                    // Si el nodo raíz está marcado como verdadero, marcar todos sus hijos                
                    if (node.Checked)
                    {
                        CheckAllChildNodes(node, true);
                    }
                    else
                    {
                        // Si el nodo raíz no está marcado como verdadero, verificar si todos sus hijos están marcados
                        node.Checked = AreAllChildrenChecked(node);
                    }
                }
                
            }
        }

        public static bool AreAllChildrenChecked(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.ForeColor != Color.Gold)
                {
                    if (!node.Checked)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
