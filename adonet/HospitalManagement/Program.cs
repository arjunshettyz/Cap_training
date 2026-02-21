using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Connection String
string connectionString = "Server=.;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True";

builder.Services.AddSingleton(new AppointmentService(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


// ================= MODEL =================

public class Appointment
{
    public int Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; }
}


// ================= SERVICE (ADO.NET) =================

public class AppointmentService
{
    private readonly string _connectionString;

    public AppointmentService(string connectionString)
    {
        _connectionString = connectionString;
    }

    // CREATE
    public void AddAppointment(Appointment appointment)
    {
        using SqlConnection con = new SqlConnection(_connectionString);

        string query = @"INSERT INTO Appointments 
                        (PatientName, DoctorName, AppointmentDate, Status)
                        VALUES (@PatientName, @DoctorName, @AppointmentDate, @Status)";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@PatientName", appointment.PatientName);
        cmd.Parameters.AddWithValue("@DoctorName", appointment.DoctorName);
        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
        cmd.Parameters.AddWithValue("@Status", appointment.Status);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // READ ALL
    public List<Appointment> GetAppointments()
    {
        List<Appointment> list = new();

        using SqlConnection con = new SqlConnection(_connectionString);

        SqlCommand cmd = new SqlCommand("SELECT * FROM Appointments", con);

        con.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Appointment
            {
                Id = (int)reader["Id"],
                PatientName = reader["PatientName"].ToString(),
                DoctorName = reader["DoctorName"].ToString(),
                AppointmentDate = (DateTime)reader["AppointmentDate"],
                Status = reader["Status"].ToString()
            });
        }

        return list;
    }

    // UPDATE
    public void UpdateAppointment(Appointment appointment)
    {
        using SqlConnection con = new SqlConnection(_connectionString);

        string query = @"UPDATE Appointments 
                         SET PatientName=@PatientName,
                             DoctorName=@DoctorName,
                             AppointmentDate=@AppointmentDate,
                             Status=@Status
                         WHERE Id=@Id";

        SqlCommand cmd = new SqlCommand(query, con);

        cmd.Parameters.AddWithValue("@Id", appointment.Id);
        cmd.Parameters.AddWithValue("@PatientName", appointment.PatientName);
        cmd.Parameters.AddWithValue("@DoctorName", appointment.DoctorName);
        cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
        cmd.Parameters.AddWithValue("@Status", appointment.Status);

        con.Open();
        cmd.ExecuteNonQuery();
    }

    // DELETE
    public void DeleteAppointment(int id)
    {
        using SqlConnection con = new SqlConnection(_connectionString);

        SqlCommand cmd = new SqlCommand(
            "DELETE FROM Appointments WHERE Id=@Id", con);

        cmd.Parameters.AddWithValue("@Id", id);

        con.Open();
        cmd.ExecuteNonQuery();
    }
}


// ================= CONTROLLER =================

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService service;

    public AppointmentController(AppointmentService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAppointments());
    }

    [HttpPost]
    public IActionResult Create(Appointment appointment)
    {
        service.AddAppointment(appointment);
        return Ok("Appointment Created");
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Appointment appointment)
    {
        appointment.Id = id;
        service.UpdateAppointment(appointment);
        return Ok("Appointment Updated");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        service.DeleteAppointment(id);
        return Ok("Appointment Deleted");
    }
}