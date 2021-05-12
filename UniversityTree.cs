using System;
using System.Collections.Generic;
using System.Text;

namespace University_BinaryTree_V2
{
    class UniversityTree
    {
        public PositionNode Root;
        public PositionNode temp = new PositionNode();
        public float longSalary = 0;

        public void CreatePosition(PositionNode parent, Position positionToCreate, string parentPositionName)
        {
            PositionNode newNode = new PositionNode();
            newNode.Position = positionToCreate;

            if(Root == null)
            {
                Root = newNode;
                return;
            }
            if(parent == null)
            {
                return;
            }
            if(parent.Position.Name == parentPositionName)
            {
                if(parent.Left == null)
                {
                    parent.Left = newNode;
                    return;
                }
                parent.Right = newNode;
                return;
            }
            CreatePosition(parent.Left, positionToCreate, parentPositionName);
            CreatePosition(parent.Right, positionToCreate, parentPositionName);
        }

        //Print Tree
        public void PrintTree(PositionNode from)
        {
            if(from == null)
            {
                return;
            }
            Console.WriteLine($"{from.Position.Name}: Salary: {from.Position.Salary}: Impuesto: {from.Position.Tax}");
            PrintTree(from.Left);
            PrintTree(from.Right);
        }

        //Add Salaries
        public float AddSalaries(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            return from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);
        }

        //Add Taxation
        public float AddTaxation(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            return from.Position.Tax + AddTaxation(from.Left) + AddTaxation(from.Right);
        }

        //Count Nodes
        public float CountNodes(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            float izq = CountNodes(from.Left);
            float der = CountNodes(from.Right);
            return izq + der + 1;
        }

        //Longest Salary
        public void LongestSalary(PositionNode from)
        {
            if (from == null)
            {
                return;
            }
            if (from.Position.Salary > longSalary && from.Position.Salary != Root.Position.Salary)
            {
                longSalary = from.Position.Salary;
                temp = from;
            }
            LongestSalary(from.Left);
            LongestSalary(from.Right);
        }

        //Average Salaries
        public float AverageSalaries(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            float sumSalaries = from.Position.Salary + AddSalaries(from.Left) + AddSalaries(from.Right);
            float count = CountNodes(Root);
            return sumSalaries / count;
        }

        //Average Position Salary
        public PositionNode searchNode(PositionNode from, string position)
        {
            if (from != null)
            {
                //Para saber si el nodo es el que busco
                if (from.Position.Name.Equals(position))
                {
                    return from;
                }
                else
                {
                    //Guardo nodo temporal la busqueda de izquierda
                    temp = searchNode(from.Left, position);
                    if (temp == null)
                    {
                        temp = searchNode(from.Left, position);
                    }
                    temp = searchNode(from.Right, position);
                    if(temp != null)
                    {
                        temp = searchNode(from.Right, position);
                    }
                }
                
            }
            return temp;
        }

        //Money Taxation
        public float TaxationMoney(PositionNode from)
        {
            if (from == null)
            {
                return 0;
            }
            return from.Position.Salary * from.Position.Tax + TaxationMoney(from.Right) + TaxationMoney(from.Left);
        }
    }
}
