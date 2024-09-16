using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_009_13_09_2024
{
    public class TrainStationService
    {
        private readonly ApplicationContext _context;

        public TrainStationService(ApplicationContext context)
        {
            _context = context;
        }


        public void AddStationsAndTrains()
        {
            var sqlStations = @"
                INSERT INTO Stations (Name) VALUES 
                ('Station A'), ('Station B'), ('Station C');
                ";

            var sqlTrains = @"
                INSERT INTO Trains (Model, ManufacturingDate, RouteDuration, StationId) VALUES 
                ('PellFast', '2000-01-01', 6, 1),
                ('PellSpeed', '2010-05-23', 3.5, 1),
                ('BoltExpress', '2005-12-10', 4, 2),
                ('PellStorm', '1995-03-15', 7.5, 3),
                ('TrainMaster', '2008-07-18', 8, 3);
                ";

            _context.Database.ExecuteSqlRaw(sqlStations);
            _context.Database.ExecuteSqlRaw(sqlTrains);
        }
        public List<Train> GetTrainsWithDurationMoreThan5Hours()
        {
            return _context.Trains
                           .FromSqlRaw("SELECT * FROM Trains WHERE RouteDuration > 5")
                           .ToList();
        }
        public List<Station> GetStationsWithTrains()
        {
            return _context.Stations
                           .FromSqlRaw(@"
                       SELECT s.Id, s.Name 
                       FROM Stations s
                       JOIN Trains t ON s.Id = t.StationId")
                           .ToList();
        }
        public List<Station> GetStationsWithMoreThan3Trains()
        {
            return _context.Stations
                           .FromSqlRaw(@"
                       SELECT s.Id, s.Name 
                       FROM Stations s
                       JOIN Trains t ON s.Id = t.StationId
                       GROUP BY s.Id, s.Name
                       HAVING COUNT(t.Id) > 3")
                           .ToList();
        }
        public List<Train> GetTrainsWithModelStartingWithPell()
        {
            return _context.Trains
                           .FromSqlRaw("SELECT * FROM Trains WHERE Model LIKE 'Pell%'")
                           .ToList();
        }
        public List<Train> GetTrainsOlderThan15Years()
        {
            return _context.Trains
                           .FromSqlRaw(@"
                       SELECT * 
                       FROM Trains 
                       WHERE DATEDIFF(year, ManufacturingDate, GETDATE()) > 15")
                           .ToList();
        }
        public List<Station> GetStationsWithTrainRouteLessThan4Hours()
        {
            return _context.Stations
                           .FromSqlRaw(@"
                       SELECT DISTINCT s.Id, s.Name 
                       FROM Stations s
                       JOIN Trains t ON s.Id = t.StationId
                       WHERE t.RouteDuration < 4")
                           .ToList();
        }
        public List<Station> GetStationsWithoutTrains()
        {
            return _context.Stations
                           .FromSqlRaw(@"
                       SELECT s.Id, s.Name 
                       FROM Stations s
                       LEFT JOIN Trains t ON s.Id = t.StationId
                       WHERE t.Id IS NULL")
                           .ToList();
        }

    }
}
