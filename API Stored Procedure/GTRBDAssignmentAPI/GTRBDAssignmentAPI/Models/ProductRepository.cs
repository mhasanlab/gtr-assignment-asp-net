using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GTRBDAssignmentAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }
        // Get All Products
        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.SpProductSelectAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product product = new Product();
                        product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        product.ProductName = rdr["ProductName"].ToString();
                        product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        product.SupplierId = Convert.ToInt32(rdr["SupplierId"]);
                        product.PurchaseDate = Convert.ToDateTime(rdr["PurchaseDate"]);
                        product.UnitPrice = Convert.ToDecimal(rdr["UnitPrice"]);
                        product.CurrentStock = Convert.ToDecimal(rdr["CurrentStock"]);
                        products.Add(product);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //products = null;
                }
            }
            return products;
        }

        // Get All Products By ID

        public Product GetProductById(int id)
        {
            Product product = new Product();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.SpProductSelectById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        product.ProductName = rdr["ProductName"].ToString();
                        product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        product.SupplierId = Convert.ToInt32(rdr["SupplierId"]);
                        product.PurchaseDate = Convert.ToDateTime(rdr["PurchaseDate"]);
                        product.UnitPrice = Convert.ToDecimal(rdr["UnitPrice"]);
                        product.CurrentStock = Convert.ToDecimal(rdr["CurrentStock"]);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
            return product;
        }

        // Add Products

        public Product AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.SpInsertProduct", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    cmd.Parameters.AddWithValue("@ProductName ", product.ProductName);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                    cmd.Parameters.AddWithValue("@PurchaseDate", product.PurchaseDate);
                    cmd.Parameters.AddWithValue("@UnitePrice", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@CurrentStock", product.CurrentStock);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //product = null;
                }
            }
            return product;
        }


        public Product UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("dbo.SpUpdateProduct", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProductId ", product.ProductId);
                    cmd.Parameters.AddWithValue("@ProductName ", product.ProductName);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@SupplierId", product.SupplierId);
                    cmd.Parameters.AddWithValue("@PurchaseDate", product.PurchaseDate);
                    cmd.Parameters.AddWithValue("@UnitePrice", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@CurrentStock", product.CurrentStock);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //product = null;
                }
            }

            return product;
        }

        public void DeleteProduct(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpDeleteProduct", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
        }
 
        
    }
}
