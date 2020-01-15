﻿using AutomationTraining_M7.Base_Files;
using AutomationTraining_M7.LINQ_Tests;
using AutomationTraining_M7.Page_Objects;
using AutomationTraining_M7.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutomationTraining_M7
{
    class Program : BaseTest
    {
        static void Main(string[] args)
        {
            //LINQ_Exercises objLINQ = new LINQ_Exercises();


            /*objLINQ.Exercise1();
            objLINQ.Exercise2();
            objLINQ.Exercise3();
            objLINQ.Exercise4();
            objLINQ.Exercise5();*/

            //objLINQ.Exercise1();
            //objLINQ.Exercise2();
            //objLINQ.Exercise3();
            //objLINQ.Exercise4();
            //objLINQ.Exercise5();

            //Console.ReadKey();


            //Ejercicio con Omar de crear files

            string strFileName = @"C:\Users\DanielEnriqueLunaRiv\Documents\Automation\LINQ Exercises\TempAuo123.txt";
            FileInfo objFile = new FileInfo(strFileName);

            using (StreamWriter sw = objFile.CreateText())
            {
                sw.WriteLine("Test1");
                sw.WriteLine("Test2");
                sw.WriteLine("Test3");
                sw.WriteLine("Test4");
                sw.WriteLine("Test5");
                sw.WriteLine("Test6");
            }

            //Leer un file e imprimir en la consola lo que hay en el file
            using (StreamReader sr = File.OpenText(strFileName))
            {
                string strValue = "";
                while ((strValue = sr.ReadLine()) != null)
                {
                    Console.WriteLine(strValue);
                }
            }

            Console.ReadKey();

        }
    }

}
