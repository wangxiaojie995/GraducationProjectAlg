using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbbbb
{
    public class Class1
    {

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="regEx"></param>
        public Node BuildRegExTree(List<int> regEx)
        {
            if (regEx == null || regEx.Count <= 0) return null;
            List<Node> nodeList = new List<Node>();

            for(int i = 0; i < regEx.Count; i++)
            {
                Node nodeI = new Node(regEx[i]);
                if (nodeI.GetValueType().Equals(VALUE_TYPE.VALUE_TYPE_UNDEFINE)) return null;
                nodeList.Add(nodeI);
            }

            Stack<Node> oprStack = new Stack<Node>();//操作符栈
            Stack<Node> opdStack = new Stack<Node>();//操作数栈
            //将运算优先级最低的符号入栈
            oprStack.Push(new Node(-1));

            for(int i = 0; i < nodeList.Count; i++)
            {
                Node node = nodeList[i];
                VALUE_TYPE nodeIType = nodeList[i].GetValueType();
                if( nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_ASCII) ||nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_BRACKET) )
                {
                    //如果是右括号，那么将操作数栈顶数出栈，直到第一个左括号，再将操作数与符号栈的第一个符号做运算
                    //如果是非括号的操作数，直接进栈
                    if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_RIGHTBRACET))
                    {

                    }
                    else
                    {
                        opdStack.Push(node);
                    }
                }else if(nodeIType.Equals(VALUE_TYPE.VALUE_TYPE_OPERATOR))
                {
                    //结束符
                    if(node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_MINPOR))
                    {
                        //结束字符
                        Node topOneOpd = opdStack.Pop();
                        Node topTwoOpd = opdStack.Pop();
                        Node topOneOpr = oprStack.Pop();
                        Node parentNode = new Node(topOneOpr.value, topOneOpd, topTwoOpd);
                        opdStack.Push(parentNode);
                        Node result = opdStack.Pop();
                        Node.PrintTree(result);
                    }
                    else if (node.GetValueTypeConcrete().Equals(VALUE_TYPE_CONCRETE.VALUE_TYPE_CONCRETE_BIBAO))
                    {
                        //结束字符
                        Node topOneOpd = opdStack.Pop();
                        Node parentNode = new Node(node.value, topOneOpd, null);
                        opdStack.Push(parentNode);
                    }
                    else
                    {
                        Node top = oprStack.Peek();
                        if (top != null)
                        {
                            int priResult = Node.ComparePri(top, node);
                            if (priResult == -2)
                            {
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
                                return opdStack.Pop();
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
