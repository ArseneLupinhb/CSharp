﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IBackupAndRestoreDb
    {
        void BackDb(string backupPath);
        void RestoreDb(string restorePath);
    }
}
