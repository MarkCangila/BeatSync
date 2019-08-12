﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BeatSync.Configs
{
    public static class FavoriteMappers
    {
        private static readonly string FilePath = Path.GetFullPath(@"UserData\FavoriteMappers.ini");
        private static string[] _mappers;
        public static string[] Mappers
        {
            get
            {
                if (_mappers == null)
                    _mappers = ReadFromFile().ToArray();
                return _mappers;
            }
        }

        public static void Initialize()
        {
            _mappers = ReadFromFile().ToArray();
        }

        private static List<string> ReadFromFile()
        {
            var mapperList = new List<string>();
            if (!File.Exists(FilePath))
                return mapperList;
            try
            {
                mapperList.AddRange(File.ReadAllLines(FilePath));
            }
            catch (Exception ex)
            {
                Logger.log.Warn(ex);
            }
            return mapperList;
        }
    }
}