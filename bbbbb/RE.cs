using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbbbb
{
    public class RE
    {
        private Node root;

        public RE(List<int> regEx)
        {
            this.root = BuildRegExTree(regEx);
        }

        public void SetRoot(Node root)
        {
            this.root = root;
        }
        public Node GetRoot()
        {
            return this.root;
        }

        /// <summary>
        /// </summary>
        /// <param name="regEx"></param>
        private Node BuildRegExTree(List<int> regEx)
        {
            if (regEx == null || regEx.Count <= 0) return null;
            List<Node> nodeList = new List<Node>();

            for (int i = 0; i < regEx.Count; i++)
            {
                Node nodeI = new Node(regEx[i]);
                if (nodeI.GetValueType().Equals(VALUE_TYPE.VALUE_TYPE_UNDEFINE)) return null;
                nodeList.Add(nodeI);
            }

            Stack<Node> oprStack = new Stack<Node>();//操作符栈
            Stack<Node> opdStack = new Stack<Node>();//操作数栈
            //将运算优先级最低的符号入栈
            oprStack.Push(new Node(-1));

            for (int i = 0; i < nodeList.Count; i++)
            {
                Node node = nodeList[i];
                VALUE_TYPE nodeIType = nodeList[i].GetValueType();
                if (nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_ASCII))
                {
                    opdStack.Push(node);
                }
                else if (nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_OPERATOR) || nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_BRACKET))
                {
                    //结束符
                    if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR))
                    {

                        while (oprStack.Peek() != null)
                        {
                            Node oprTop = oprStack.Pop();
                            if (
                                oprTop.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO) ||
                                oprTop.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE)
                                )
                            {
                                Node opdTop = opdStack.Pop();
                                Node opdSec = opdStack.Pop();
                                Node n = new Node(oprTop.value, opdTop, opdSec);
                                opdStack.Push(n);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Node result = opdStack.Pop();
                        return result;
                    }
                    else if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO))
                    {
                        //结束字符
                        Node topOneOpd = opdStack.Pop();
                        Node parentNode = new Node(node.value, topOneOpd, null);
                        opdStack.Push(parentNode);
                    }
                    else if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LEFTBRACET))
                    {
                        oprStack.Push(node);
                    }
                    else if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_RIGHTBRACET))
                    {
                        //右括号
                        while (oprStack.Peek() != null)
                        {
                            Node oprTop = oprStack.Pop();
                            if (
                                oprTop.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_HUO) ||
                                oprTop.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_LIANJIE)
                                )
                            {
                                Node opdTop = opdStack.Pop();
                                Node opdSec = opdStack.Pop();
                                Node n = new Node(oprTop.value, opdTop, opdSec);
                                opdStack.Push(n);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Node top = oprStack.Peek();
                        if (top != null)
                        {
                            int priResult = Node.ComparePri(top, node);
                            if (priResult == -2)
                            {
                                Console.WriteLine("比较优先级出现错误");
                                return null;
                                //比较优先级发生错误
                            }
                            else if (priResult == -1)
                            {
                                oprStack.Push(node);
                            }
                            else if (priResult == 1)
                            {
                                //符号栈顶元素优先级大于当前符号优先级，那么要进行运算
                                Node topOneOpd = opdStack.Pop();
                                Node topTwoOpd = opdStack.Pop();
                                Node topOneOpr = oprStack.Pop();
                                Node parentNode = new Node(topOneOpr.value, topOneOpd, topTwoOpd);
                                opdStack.Push(parentNode);
                                oprStack.Push(node);
                            }
                            else if (priResult == 0)
                            {
                                Console.WriteLine("---------------------");
                                return opdStack.Pop();
                            }
                        }
                    }
                }
            }
            return null;
        }

        public void PrintRE()
        {
            Node.PrintTree(root);
        }
        public static NFA GetNFA_(Node node)
        {
            Dictionary<Node, FA> dic = new Dictionary<Node, FA>();
            GetNFA(node, dic);
            NFA nfa = new NFA(dic[node]);
            return nfa;
        }

        //后序遍历生成NFA
        public static void GetNFA(Node root, Dictionary<Node, FA> dic)
        {
            if(root != null && root.lChild != null)
            {
                GetNFA(root.lChild, dic);
            }
            if(root != null && root.rChild != null)
            {
                GetNFA(root.rChild, dic);
            }
            if(root != null)
            {
                Console.WriteLine(root.value);
                if(root.IfIsLeaf())
                {
                    FA fa = new FA();
                    Vertex x = new Vertex();
                    Vertex y = new Vertex();
                    Arc arc = new Arc(y, (TRANSFER_CHARACTER)Enum.ToObject(typeof(TRANSFER_CHARACTER), root.value));
                    x.AddArc(arc);
                    fa.headVerList.Add(x);
                    fa.headVerList.Add(y);
                    fa.startVertex = x;
                    fa.endVertex = y;

                    dic.Add(root, fa);
                }
                else
                {
                    if(root.rChild == null)
                    {
                        FA fa = FA.GetNewFAByOlds(dic[root.lChild], null, root.GetValueTypeConcrete());
                        dic.Add(root, fa);
                    }
                    else
                    {
                        FA fa = FA.GetNewFAByOlds(dic[root.lChild], dic[root.rChild], root.GetValueTypeConcrete());
                        dic.Add(root, fa);
                    }
                    
                }
            }
        }
    }
}
