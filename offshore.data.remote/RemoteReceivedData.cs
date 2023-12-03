using Microsoft.Data.SqlClient;

namespace offshore.data.remote;

public record ReceivedRecord(int Id, string Date, string Ref, string Raw);

public class RemoteReceivedData
{
    public uint GetLastReceivedDataRecordId()
    {
        using (SqlConnection connection = new SqlConnection("Server=pdomarine.dyndns.org\\PDOTELSVR\\OFFOPSSQL,2301;Database=40OPSTEL122023;Uid=sa;Pwd=Offshore$$;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false"))
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.CommandText = "select top 1 RecDataID from tblRecData order by RecDataID desc";

                connection.Open();
                var commandReader = command.ExecuteReader();
                while (commandReader.Read())
                {
                    if (uint.TryParse(commandReader["RecDataID"].ToString(), out var returnValue))
                    {
                        Console.WriteLine($"last id = {returnValue}");
                        connection.Close();
                        return returnValue;
                    }
                }
            }
            connection.Close();
        }

        return 0;
    }
    public IList<ReceivedRecord> GetOneHundredAndFiftyReceivedDataRecordsAfterId(int id)
    {
        List<ReceivedRecord> records = [];
        using (SqlConnection connection = new SqlConnection("Server=pdomarine.dyndns.org\\PDOTELSVR\\OFFOPSSQL,2301;Database=40OPSTEL122023;Uid=sa;Pwd=Offshore$$;TrustServerCertificate=True;Encrypt=false"))
        {
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.CommandText = "select top 150 * from tblRecData where RecDataID > @id order by RecDataID asc";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                var commandReader = command.ExecuteReader();
                while (commandReader.Read())
                {
                    records.Add(new ReceivedRecord(int.Parse(commandReader["RecDataID"].ToString()!)
                                                            , commandReader["RecDataDate"].ToString()!
                                                            , commandReader["RecDataRef"].ToString()!
                                                            , commandReader["RecDataRaw"].ToString()!));
                }
                connection.Close();
            }
        }

        return records;
    }
}
