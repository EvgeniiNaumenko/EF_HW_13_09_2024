using HW_009_13_09_2024;

class Program
{
    //Создать таблицы: «Станция» и «Поезд». Используя метод FromSqlRaw и ExecuteSqlRaw,
    //выполнить 8 запросов для получения данных:
    //1.	Добавить данные про станции и поезда.
    //2.	Поезда у которых длительность маршрута более 5 часов.
    //3.	Общую информация о станции и ее поездах.
    //4.	Название станций у которой в наличии более 3-ех поездов.
    //5.	Все поезда, модель которых начинается на подстроку «Pell».
    //6.	Все поезда, у которых возраст более 15 лет с текущей даты.
    //7.	Получить станции, у которых в наличии хотя бы один поезд с длительность маршрутка менее 4 часов.
    //8.	Вывести все станции без поездов (на которых не будет поездов при выполнении LEFT JOIN).


    static void Main()
    {
       
        using (ApplicationContext db = new ApplicationContext())
        {
            TrainStationService trainServ = new TrainStationService(db);
            // 1. Добавить данные про станции и поезда
            trainServ.AddStationsAndTrains();

            // 2. Поезда у которых длительность маршрута более 5 часов
            var trainsOver5Hours = trainServ.GetTrainsWithDurationMoreThan5Hours();
            Console.WriteLine("Поезда у которых длительность маршрута более 5 часов");
            foreach (var train in trainsOver5Hours)
            {
                Console.WriteLine($"Train {train.Model} - Duration: {train.RouteDuration} hours");
            }

            // 3. Общая информация о станции и её поездах
            var stationsWithTrains = trainServ.GetStationsWithTrains();
            Console.WriteLine("Общая информация о станции и её поездах");
            foreach (var station in stationsWithTrains)
            {
                Console.WriteLine($"Station: {station.Name}");
            }

            // 4. Название станций у которой более 3 поездов
            var stationsMoreThan3Trains = trainServ.GetStationsWithMoreThan3Trains();
            Console.WriteLine("Название станций у которой более 3 поездов");
            foreach (var station in stationsMoreThan3Trains)
            {
                Console.WriteLine($"Station: {station.Name}");
            }

            // 5. Поезда с моделью, начинающейся на "Pell"
            var pellTrains = trainServ.GetTrainsWithModelStartingWithPell();
            Console.WriteLine("Поезда с моделью, начинающейся на Pell");
            foreach (var train in pellTrains)
            {
                Console.WriteLine($"Train: {train.Model}");
            }

            // 6. Поезда возрастом более 15 лет
            var oldTrains = trainServ.GetTrainsOlderThan15Years();
            Console.WriteLine("Поезда возрастом более 15 лет");
            foreach (var train in oldTrains)
            {
                Console.WriteLine($"Train: {train.Model}, Manufactured: {train.ManufacturingDate}");
            }

            // 7. Станции с поездами, у которых длительность маршрута менее 4 часов
            var stationsShortRoute = trainServ.GetStationsWithTrainRouteLessThan4Hours();
            Console.WriteLine("Станции с поездами, у которых длительность маршрута менее 4 часов");
            foreach (var station in stationsShortRoute)
            {
                Console.WriteLine($"Station: {station.Name}");
            }

            // 8. Станции без поездов
            var stationsWithoutTrains = trainServ.GetStationsWithoutTrains();
            Console.WriteLine("Станции без поездов");
            foreach (var station in stationsWithoutTrains)
            {
                Console.WriteLine($"Station: {station.Name}");
            }
        }
        
    }
}