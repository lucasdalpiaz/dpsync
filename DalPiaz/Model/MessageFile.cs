﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalPiaz.Model
{
    public class MessageFile
    {
        public int Id { get; set; }
        #region Inputs
        public string InputXml { get; set; }
        public string Esn { get; set; }
        public string Unixtime { get; set; }
        public string Payload { get; set; }
        #endregion


        #region Outputs
        public string OutputXml { get; set; }
        public string OutputCsv { get; set; }
        public string Mobile { get; set; }
        public string DataConvertida { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        #endregion
        public string Obs { get; set; }

    }
}
