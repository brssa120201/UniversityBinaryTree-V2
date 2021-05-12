using System;

namespace University_BinaryTree_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Position rectorPosition = new Position();
            rectorPosition.Name = "Rector";
            rectorPosition.Salary = 1000;
            rectorPosition.Tax = 0.30f;

            Position viceFinPosition = new Position();
            viceFinPosition.Name = "Vicerrector Financiero";
            viceFinPosition.Salary = 750;
            viceFinPosition.Tax = 0.28f;

            Position viceAcadPosition = new Position();
            viceAcadPosition.Name = "Vicerrector Academico";
            viceAcadPosition.Salary = 780;
            viceAcadPosition.Tax = 0.26f;

            Position contadorPosition = new Position();
            contadorPosition.Name = "Contador Financiero";
            contadorPosition.Salary = 500;
            contadorPosition.Tax = 0.24f;

            Position jefeFinPosition = new Position();
            jefeFinPosition.Name = "Jefe Financiero";
            jefeFinPosition.Salary = 610;
            jefeFinPosition.Tax = 0.22f;

            Position secFin1Position = new Position();
            secFin1Position.Name = "Secretaria Financiera 1";
            secFin1Position.Salary = 350;
            secFin1Position.Tax = 0.20f;

            Position secFin2Position = new Position();
            secFin2Position.Name = "Secretaria Financiera 2";
            secFin2Position.Salary = 310;
            secFin2Position.Tax = 0.18f;

            Position jefeRegPosition = new Position();
            jefeRegPosition.Name = "Jefe de Registro";
            jefeRegPosition.Salary = 640;
            jefeRegPosition.Tax = 0.16f;

            Position secReg1Position = new Position();
            secReg1Position.Name = "Secretaria de Registro 1";
            secReg1Position.Salary = 360;
            secReg1Position.Tax = 0.14f;

            Position secReg2Position = new Position();
            secReg2Position.Name = "Secretaria de Registro 2";
            secReg2Position.Salary = 400;
            secReg2Position.Tax = 0.12f;

            Position asisReg1Position = new Position();
            asisReg1Position.Name = "Asistente de Registro 1";
            asisReg1Position.Salary = 170;
            asisReg1Position.Tax = 0.10f;

            Position asisReg2Position = new Position();
            asisReg2Position.Name = "Asistente de Registro 2";
            asisReg2Position.Salary = 250;
            asisReg2Position.Tax = 0.8f;

            Position mensRegPosition = new Position();
            mensRegPosition.Name = "Mensajero de Registro";
            mensRegPosition.Salary = 90;
            mensRegPosition.Tax = 0.6f;


            UniversityTree universityTree = new UniversityTree();
            universityTree.CreatePosition(null, rectorPosition, null);

            universityTree.CreatePosition(universityTree.Root, viceFinPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, contadorPosition, viceFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeFinPosition, viceFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, viceAcadPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeRegPosition, viceAcadPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secReg1Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secReg2Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, asisReg1Position, secReg2Position.Name);
            universityTree.CreatePosition(universityTree.Root, mensRegPosition, asisReg1Position.Name);
            universityTree.CreatePosition(universityTree.Root, asisReg2Position, secReg2Position.Name);

            Console.WriteLine($"DATOS ARBOL");
            universityTree.PrintTree(universityTree.Root);
            Console.WriteLine($"-------------------------------------------------------------");

            //Total Salary
            float totalSalary = universityTree.AddSalaries(universityTree.Root);
            Console.WriteLine($"Total Salaries: {totalSalary}");
            //Total Taxation
            float totalTax = universityTree.AddTaxation(universityTree.Root);
            Console.WriteLine($"Total Taxation: {totalTax}");
            //Count Nodes
            float contador = universityTree.CountNodes(universityTree.Root);
            Console.WriteLine($"Contador: {contador}");
            Console.WriteLine($"-------------------------------------------------------------");

            //Longest Salary
            universityTree.LongestSalary(universityTree.Root);
            Console.WriteLine($"The highest salary is: {universityTree.longSalary}" + " and he wins it: " + universityTree.temp.Position.Name);
            Console.WriteLine($"-------------------------------------------------------------");
            //Average Salary
            float averageSalary = universityTree.AverageSalaries(universityTree.Root);
            Console.WriteLine($"Average: {averageSalary}");
            Console.WriteLine($"-------------------------------------------------------------");
            //Average Salary Position
            PositionNode position = universityTree.searchNode(universityTree.Root, "Contador Financiero");
            float sumSalaryPosition = universityTree.AddSalaries(position);
            float countPosition = universityTree.CountNodes(position);
            Console.WriteLine($"According to the position given the average wages is: {position.Position.Name}" + $" is: {sumSalaryPosition / countPosition} ");
            Console.WriteLine($"-------------------------------------------------------------");
            //Total Salary Taxation
            float taxSalary = universityTree.TaxationMoney(universityTree.Root);
            Console.WriteLine($"Taxation Salaries: {taxSalary}");
            Console.WriteLine($"-------------------------------------------------------------");
            Console.ReadLine();

        }
    }
}
