﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace NextGenSoftware.OASIS.API.DNA
{
    public static class OASISDNAManager
    {
        public static string OASISDNAPath = "OASIS_DNA.json";
        public static OASISDNA OASISDNA { get; set; }

        public static OASISDNA LoadDNA()
        {
            return LoadDNA(OASISDNAPath);
        }

        public static OASISDNA LoadDNA(string OASISDNAPath)
        {
            if (string.IsNullOrEmpty(OASISDNAPath))
                throw new ArgumentNullException("OASISDNAPath", "OASISDNAPath cannot be null.");

            OASISDNAManager.OASISDNAPath = OASISDNAPath;

            using (StreamReader r = new StreamReader(OASISDNAPath))
            {
                string json = r.ReadToEnd();
                OASISDNA = JsonConvert.DeserializeObject<OASISDNA>(json);
                return OASISDNA;
            }
        }

        public static bool SaveDNA()
        {
            return SaveDNA(OASISDNAPath, OASISDNA);
        }

        public static bool SaveDNA(string OASISDNAPath, OASISDNA OASISDNA)
        {
            if (string.IsNullOrEmpty(OASISDNAPath))
                throw new ArgumentNullException("OASISDNAPath", "OASISDNAPath cannot be null.");

            if (OASISDNA == null)
                throw new ArgumentNullException("OASISDNA", "OASISDNA cannot be null.");

            OASISDNAManager.OASISDNA = OASISDNA;
            OASISDNAManager.OASISDNAPath = OASISDNAPath;

            string json = JsonConvert.SerializeObject(OASISDNA);
            StreamWriter writer = new StreamWriter(OASISDNAPath);
            writer.Write(json);
            writer.Close();

            return true;
        }
    }
}