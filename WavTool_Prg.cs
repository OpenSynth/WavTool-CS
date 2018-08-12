using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VocalUtau.WavTools
{
    class WavTool_Prg
    {
        string outfile_wavhdr;
        string outfile_wavdat;
        long MaxLength = 0;
        public WavTool_Prg(string Outputfilename)
        {
           outfile_wavhdr = Outputfilename + ".whd";
           outfile_wavdat = Outputfilename + ".dat";
           MaxLength = 0;
        }

        public void WavTool_Init()
        {
            if (!System.IO.File.Exists(outfile_wavhdr))
            {
                WavFile_Heads.wfh_init(outfile_wavhdr);
            }
            if (!System.IO.File.Exists(outfile_wavdat))
            {
                WavFile_Datas.wfd_init(outfile_wavdat);
            }
        }

        public void WavTool_Append(ArgsStruct p)
        {
            int len = 0;
            len = WavFile_Datas.wfd_append(outfile_wavdat, p.Inputfilename, p.Offset, p.Length, p.Ovr, p.PV);
            MaxLength += len;
        }

        public void WavTool_Close()
        {
            int len = (int)MaxLength;
            if (WavFile_Heads.wfh_checkIslegal(outfile_wavhdr))
            {
                int result = WavFile_Heads.wfh_putlength(outfile_wavhdr, len);
            }
        }
    }
}
