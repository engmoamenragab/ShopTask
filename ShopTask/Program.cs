using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullPath = "D:\\GitHub\\asp-dotnet-core-apps\\ShopTask\\ShopTask\\bin\\Debug\\net5.0\\Shop.sqlite";
            SQLiteConnection conread = new SQLiteConnection("Data Source=" + fullPath);
            conread.Open();
            try
            {
                string selectSQL = "select BillingCountry, Sum from (SELECT I.InvoiceId, I.BillingCountry, SUM(II.UnitPrice) as Sum FROM invoices I inner join invoice_items II on II.InvoiceId == I.InvoiceId group by BillingCountry) order by Sum desc limit 2";
                SQLiteCommand SelectCommand = new SQLiteCommand(selectSQL, conread);
                Console.WriteLine(SelectCommand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
