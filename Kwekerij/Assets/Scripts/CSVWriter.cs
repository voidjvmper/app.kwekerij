using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace VUSSK_GeneticEvolution
{
    public static class CSVWriter 
    {
        private static string filename = "";
     
        public static void WriteHeader(string pTitles)
        {
            InternalHeader("times", "Time (milliseconds)", pTitles);
            InternalHeader("fitnesses", "Generational High (%)", pTitles);     
        }

        private static void InternalHeader(string pFilename, string pHeaderText, string pTitles)
        {
            filename = Application.dataPath + "/" + pFilename + ".csv";
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine(pHeaderText);
            tw.Close();

            tw = new StreamWriter(filename, true);
            tw.WriteLine(", " + pTitles);
            tw.WriteLine("");
            tw.Close();
        }

        public static void WriteOne(string pFileName, string pData, string pCounter)
        {
            filename = Application.dataPath + "/" + pFileName + ".csv";
            TextWriter tw = new StreamWriter(filename, true);
            tw.WriteLine("x" + pCounter + ", " + pData);
            tw.Close();
        }

        public static void WriteCSV(string pTitles, string pTimes_1, string pTimes_1k, string pTimes_10k, string pFitness_1, string pFitness_1k, string pFitness_10k)
        {
            
            
            /*tw.WriteLine("x1000, " + pTimes_1k);
            tw.WriteLine("x10,000, " + pTimes_10k);
            tw.WriteLine("");
            tw.WriteLine("");
            tw.WriteLine("Generational High (%)");
            tw.WriteLine(", " + pTitles);
            tw.WriteLine("");
            tw.WriteLine("x1, " + pFitness_1);
            tw.WriteLine("x1000, " + pFitness_1k);
            tw.WriteLine("x10,000, " + pFitness_10k);
            tw.Close();*/

        }
    }
}
