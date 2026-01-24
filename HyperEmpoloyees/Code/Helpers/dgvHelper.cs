using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Code.Helpers
{
    public static class dgvHelper
    {
        public static bool IsEmpty(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0) return false; return true;
        }
    }
}
