﻿using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IFileDal
    {
        string SetTweetMediaFile(Tweet tweet);
        bool FileIsExist(string filePath);
    }
}
