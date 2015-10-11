using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientsNamesAndAddress
{
    public partial class ClientsNamesAndAddress : System.Web.UI.Page
    {
       

        protected void ButtonSearchForID_Click(object sender, EventArgs e)
        {
            this.GridViewCustomers.DataSource = null;
            this.GridViewCustomers.DataBind();
            try
            {
                int idClient = int.Parse(this.TextBoxLabel.Text);

                List<Customer> customers = new List<Customer>();

                customers = GetCustomerById(idClient); 

                if (customers.Count() == 0)
                {
                    this.LabelMassage.Text = "Data not found";
                }
                else
                {
                    this.GridViewCustomers.DataSource = customers;
                    this.GridViewCustomers.DataBind();
                    this.LabelMassage.Text = customers.Count.ToString() + " item(s).";
                } 

            }
            catch (FormatException ex)
            {
                this.LabelMassage.Text = "Error: Invalid input";
            }
            catch (Exception ex)
            {
                this.LabelMassage.Text = "Error: " + ex.ToString();
            }
        }
        private List<Customer> GetCustomerById(int idClient)
        {
            var customers = new List<Customer>();


            string sql = "SELECT ca.Id, ca.IdClient, ca.Address, cn.FirstName, cn.LastName, cn.phone, cn.email " +
            "FROM clientsaddress AS ca INNER JOIN clientsname AS cn ON ca.IdClient = cn.Id " +
            "WHERE (cn.Id = {0}) " +
            "ORDER BY ca.Address";


            try
            {
                using ( SqlConnection conn = new SqlConnection("Data Source=ELEK-PC;integrated security=SSPI;database=webappdemo;user id=Ivan;password=Ivan;"))
                {
                    SqlCommand cmd = new SqlCommand(String.Format(sql, idClient), conn);
                    SqlDataReader rdr;
                    conn.Open();

                    rdr = cmd.ExecuteReader();
                    customers.Clear();

                    while (rdr.Read())
                    {
                        Customer customer = new Customer();
                        customer.ID = rdr.GetInt32(1);
                        customer.FirstName = rdr.GetString(3);
                        customer.LastName = rdr.GetString(4);
                        customer.Phone = rdr.GetString(5);
                        customer.Email = rdr.GetString(6);
                        customer.Address = rdr.GetString(2);

                        customers.Add(customer);
                    }   
                }
                
            }
               
            catch (Exception ex)
            {
                throw ex;
                //stringError =  "Error: " + ex.ToString();
            }

            return customers;
        }
    }
}