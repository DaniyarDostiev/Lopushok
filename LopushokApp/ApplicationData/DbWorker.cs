using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LopushokApp.ApplicationData
{
    internal class DbWorker
    {
        private static lopushok_dbEntities _context;
        public static lopushok_dbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new lopushok_dbEntities();
            }
            return _context;
        }
    }
}
