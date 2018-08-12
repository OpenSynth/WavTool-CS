using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocalUtau.WavTools
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsStruct p=ArgsParser.parseArgs(args);
            if (p == null)
            {
                ArgsParser.printUsage();
                return;
            }

            WavTool_Prg wtool = new WavTool_Prg(p.Outputfilename);
            wtool.WavTool_Init();

            for (int w = 0; w < 5; w++)
            {
                ArgsParser.printArgs(p);
                wtool.WavTool_Append(p);
            }

            wtool.WavTool_Close();
            return;
        }
    }
}
