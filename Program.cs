using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardSorting
{
    public struct card
    {
        public string from_city { get; set; }
        public string to_city { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            card[] cities = new[] {
                new card { from_city="London", to_city="Paris" },
                new card { from_city="Moscow", to_city="NY" },
                new card { from_city="NY", to_city="Tokio" },
                new card { from_city="Paris", to_city="Deli" },
                new card { from_city="Tokio", to_city="London" }
            };

            card[] sort_cities = cardSort(cities);
            foreach(card c in sort_cities)
            {
                Console.WriteLine("{0} - {1}", c.from_city, c.to_city);
            }
            Console.ReadKey();
        }


        static card[] cardSort(card[] city_list)
        {
            // begin_city - список городов отпраления
            // end_city - список гороов прибытия
            // нужны что бы исключением end_city из begin_city найти первый город отправления
            HashSet<string> begin_city = new HashSet<string> { };
            HashSet<string> end_city = new HashSet<string> { };

            // city_dict словарь упрощающий поиск карточек
            Dictionary<string, card> city_dict = new Dictionary<string, card> { };

            // массив отсортированных карточек
            card[] sort_citys = new card[city_list.Length];
            string next_city = "";

            for (int i = 0; i < city_list.Length; i++)
            {
                begin_city.Add(city_list[i].from_city);
                end_city.Add(city_list[i].to_city);
                city_dict.Add(city_list[i].from_city, city_list[i]);
            }

            // в списке остается единственная запись - первый город отправления
            next_city = begin_city.Except(end_city).FirstOrDefault();

            // заполняем массив результата
            for (int i = 0; i < city_list.Length; i++)
            {
                sort_citys[i] = city_dict[next_city];
                next_city = sort_citys[i].to_city;
            }

            return sort_citys;
        }


    }

}
