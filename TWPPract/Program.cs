﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TWPPract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свою фамилию и имя(не менее 18 символов)");
            Console.WriteLine();
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Строка пуста!");
                return;
            }
            name = name.Substring(0, 18);
            Console.WriteLine("Введено: " + name);
            TaskSolution.WriteLine("Решение ТВП для: " + name);

            var cipherName = TwpSolver.EncryptName(name);
            if (cipherName == null)
                return;
            
            TaskSolution.WriteLine("\n\n1. Зашифрованное имя и фамилия: ");
            foreach (var item in cipherName)
                TaskSolution.Write("x" + item + " ");
            
            var studentRules = TwpSolver.CreateBasicRules(cipherName);
            TaskSolution.WriteLine("\n\n\n2. Правила: ");
            foreach (var rule in studentRules)
            {
                TaskSolution.WriteLine(rule.ToString());
            }
            
            var singleRules = TwpSolver.CreateSingleRules(studentRules);
            TaskSolution.WriteLine("\n\n\n3.Новые правила: ");
            foreach (var rule in singleRules)
            {
                TaskSolution.WriteLine(rule.ToString());
            }
            
            var table = TwpSolver.CreateTable(singleRules);
            TaskSolution.WriteLine("\n\n\n4.Недетерминированная таблица");
            TaskSolution.WriteLine(table.ToString());

            var deterTable = TwpSolver.CreateDeterTable(table);
            TaskSolution.WriteLine("\n\n\n5.Детерминированная таблица");
            TaskSolution.WriteLine(deterTable.ToString());

            //TaskSolution.WriteLine("\n\n\n6.Группировка: ");
            //var minimizeTable = TwpSolver.MinimizeTable(deterTable);
            //TaskSolution.WriteLine("\n\n\n7.Минимизированная таблица");
            //TaskSolution.WriteLine(minimizeTable.ToString());

            var solFileName = $"TWP_Sol_{name}.txt";
            File.WriteAllText(solFileName, TaskSolution.ReadAll, Encoding.UTF8);
            Console.WriteLine("Решение было выгружено в файл: " + solFileName);
        }
       
    }
}
