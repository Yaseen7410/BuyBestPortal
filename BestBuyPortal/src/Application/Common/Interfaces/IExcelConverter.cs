﻿using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Application.Common.Interfaces
{
    public interface IExcelConverter
    {
        DataSet Convert(Stream stream);
        byte[] Convert(IEnumerable<dynamic> data, string sheetName = "Sheet 1", Dictionary<string, string> columns = null);
    }
}
