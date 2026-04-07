using Microsoft.Data.Sqlite;

namespace APISicilyLines
{
    public class DatabaseService
    {
        private string _dbPath = "sicilylinesdb.db";

        public DatabaseService()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Client (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nom TEXT,
                    Prenom TEXT,
                    Email TEXT,
                    Telephone TEXT,
                    Adresse TEXT,
                    Ville TEXT,
                    CodePostal TEXT,
                    MotDePasse TEXT
                );
                CREATE TABLE IF NOT EXISTS Reservation (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    NomTraversee TEXT,
                    DateDepart TEXT,
                    ClientId INTEGER
                );
                INSERT OR IGNORE INTO Client VALUES (1, 'Dupont', 'Jean', 'jean.dupont@email.com', '0612345678', '12 rue de la Paix', 'Paris', '75000', 'Gospel14');
                INSERT OR IGNORE INTO Reservation VALUES (1, 'Marseille - Tunis', '2025-12-10', 1);
                INSERT OR IGNORE INTO Reservation VALUES (2, 'Gênes - Palerme', '2026-05-20', 1);
                INSERT OR IGNORE INTO Reservation VALUES (3, 'Barcelone - Alger', '2024-08-03', 1);
                INSERT OR IGNORE INTO Reservation VALUES (4, 'Nice - Bastia', '2026-07-15', 1);
            ";
            command.ExecuteNonQuery();
        }

        public Client GetClient(string pseudo)
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Client LIMIT 1";
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Client
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Email = reader.GetString(3),
                    Telephone = reader.GetString(4),
                    Adresse = reader.GetString(5),
                    Ville = reader.GetString(6),
                    CodePostal = reader.GetString(7),
                    MotDePasse = reader.GetString(8)
                };
            }
            return null;
        }

        public List<Reservation> GetReservations(int clientId)
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Reservation WHERE ClientId = @clientId";
            command.Parameters.AddWithValue("@clientId", clientId);
            using var reader = command.ExecuteReader();
            var reservations = new List<Reservation>();
            while (reader.Read())
            {
                reservations.Add(new Reservation
                {
                    Id = reader.GetInt32(0),
                    NomTraversee = reader.GetString(1),
                    DateDepart = DateTime.Parse(reader.GetString(2)),
                    ClientId = reader.GetInt32(3)
                });
            }
            return reservations;
        }

        public bool UpdateClient(Client client)
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"UPDATE Client SET Email=@email, Telephone=@tel, 
                Adresse=@adresse, Ville=@ville, CodePostal=@cp WHERE Id=@id";
            command.Parameters.AddWithValue("@email", client.Email);
            command.Parameters.AddWithValue("@tel", client.Telephone);
            command.Parameters.AddWithValue("@adresse", client.Adresse);
            command.Parameters.AddWithValue("@ville", client.Ville);
            command.Parameters.AddWithValue("@cp", client.CodePostal);
            command.Parameters.AddWithValue("@id", client.Id);
            command.ExecuteNonQuery();
            return true;
        }
    }
}