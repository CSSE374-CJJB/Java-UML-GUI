﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Java_UML_GUI
{
    public class JsonConfig
    {
        public String InputFolder;
        public string[] InputClasses;
        public String OutputDirectory;
        public String DotPath;
        public string[] Phases;
        public int Adapter_MethodDelegation;
        public int Decorator_MethodDelegation;
        public bool? Singleton_RequireGetInstance;
        public List<String> exclusion;

        public JsonConfig()
        {
            exclusion = new List<String>();
        }

        public static JsonConfig LoadFromFile(String path)
        {
            String toRead = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<JsonConfig>(toRead);
        }

        public void SaveToFile(String path)
        {
            String toWrtie = JsonConvert.SerializeObject(this);

            File.WriteAllText(path, toWrtie);
        }

        public string getJavaUMLArguments()
        {
            return "";
        }
    }
}
