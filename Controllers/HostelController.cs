using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace hostellers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public HostelController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("saiConnection");

            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("Connection string 'saiConnection' is not found in appsettings.json.");
        }

        [HttpPost]
        [Route("getbyhid")]
        public IActionResult GetByHid([FromBody] ValidUser host)
        {
            if (host == null)
                return BadRequest("Host object is null.");
            if (string.IsNullOrEmpty(host.HostelID))
                return BadRequest("HostelID is missing or empty.");

            var details = new List<Dictionary<string, object>>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("getbyhid", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter safely
                    SqlParameter hidParam = new SqlParameter("@HID", SqlDbType.VarChar, 50)
                    {
                        Value = string.IsNullOrEmpty(host.HostelID)
                                ? DBNull.Value
                                : host.HostelID
                    };
                    cmd.Parameters.Add(hidParam);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            details.Add(row);
                        }
                    }
                }

                return Ok(details);
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }
}
