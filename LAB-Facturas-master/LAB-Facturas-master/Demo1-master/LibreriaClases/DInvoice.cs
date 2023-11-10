using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DInvoice
    {
        public static string connectionString = "Data Source=LAB1504-27\\SQLEXPRESS;Initial Catalog=Factura;User ID=Jeferson;Password=ades1234";

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string procedure = "ListarInvoices";

                using (SqlCommand command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoice listinvoice = new Invoice
                            {
                                InvoiceId = reader.GetInt32(reader.GetOrdinal("invoice_id")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("customer_id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("date")),
                                Total = reader.GetDecimal(reader.GetOrdinal("total")),
                                Active = reader.GetBoolean(reader.GetOrdinal("active"))
                            };

                            invoices.Add(listinvoice);
                        }
                    }
                }
                connection.Close();
            }

            return invoices;
        }


    }
}
