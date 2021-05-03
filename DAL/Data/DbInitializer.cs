using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BookSearchContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }
            var books = new Book[]
                {
                    new Book{ Title = "Алхимик",  Description = "«Алхи́мик» (порт. O Alquimista) — роман Пауло Коэльо, изданный в 1988 году и ставший мировым бестселлером. Издан более чем в 117 странах мира, переведён на 81 язык. Основной сюжет взят из европейского фольклора: по классификации фольклорных сюжетов Аарне - Томпсона - Утера — сюжет 1645 «Сокровище дома» . Типичный представитель — английская сказка «The Pedlar of Swaffham» («Сон коробейника»), а также один из эпизодов «Тысячи и одной ночи». Было выпущено более 145 тыс.книг.",
                    Publication_date = "1988", },
                    new Book{ Title = "Книжный вор",  Description = "«Книжный вор» (англ. The Book Thief) — роман австралийского писателя Маркуса Зусака, написанный в 2005 году. Находился в списке «The New York Times Best Seller list» более 230 недель. Экранизирован в 2013 году режиссёром Брайаном Персивалем. В российском прокате фильм, роль Лизель в котором исполнила 13-летняя Софи Нелисс, демонстрировался под более корректным названием «Воровка книг».",
                    Publication_date = "2005" }
                 };
            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();
            
            context.SaveChanges();

            if (context.Genres.Any())
            {
                return;
            }
            var genres = new Genre[]
                {
                    new Genre { NameGenre = "Менеджмент"},  new Genre { NameGenre = "О бизнесе популярно"}, new Genre { NameGenre = "Маркетинг, PR, реклама"}, new Genre { NameGenre = "Банковское дело"},new Genre { NameGenre = "Историческая отечественная проза"},
                    new Genre { NameGenre = "Делопроизводство"},  new Genre { NameGenre = "Зарубежная компьютерная литература"}, new Genre { NameGenre = "Современная русская литература"}, new Genre { NameGenre = "Древнерусская литература"},  new Genre { NameGenre = "Шпионские детективы"},
                    new Genre { NameGenre = "Зарубежная деловая лиетратура"},  new Genre { NameGenre = "Зарубежный юмор"}, new Genre { NameGenre = "Русская литература для детей"}, new Genre { NameGenre = "Отечественная проза для детей"},  new Genre { NameGenre = "Крутой детектив"},
                    new Genre { NameGenre = "Недвижимость"},  new Genre { NameGenre = "Зарубежная старинная литература"}, new Genre { NameGenre = "Отечественные детективы"}, new Genre { NameGenre = "Десткая познавательная и развивающая литература"},  new Genre { NameGenre = "Политические детективы"},
                    new Genre { NameGenre = "Финансы"},  new Genre { NameGenre = " Зарубежная справочная литература"}, new Genre { NameGenre = "Отечественная фантастика"}, new Genre { NameGenre = "Детская проза"},  new Genre { NameGenre = "Десткие стихи"},
                    new Genre { NameGenre = "Малый бизнес"},  new Genre { NameGenre = "Зарубежная эзотерическая литература"}, new Genre { NameGenre = "Русская классика"}, new Genre { NameGenre = "Книги для дошкольников"},  new Genre { NameGenre = "Детские приключения"},
                    new Genre { NameGenre = "Отраслевые издания"},  new Genre { NameGenre = " Зарубежная религиозная литература"}, new Genre { NameGenre = "Русское фэнтези"}, new Genre { NameGenre = "Сказки"},  new Genre { NameGenre = "Детские детективы"},
                    new Genre { NameGenre = "Государственное  и муниципальное управление"}, new Genre { NameGenre = "Зарубежные боевики"}, new Genre { NameGenre = "Отечественный мужской детектив"}, new Genre { NameGenre = "Детская фантастика"},  new Genre { NameGenre = "Любовное фэнтези"},
                    new Genre { NameGenre = "Тайм-менеджмент"}, new Genre { NameGenre = "Зарубежная психология"}, new Genre { NameGenre = "Отечественные любовные романы"}, new Genre { NameGenre = "Отечественный женский детектив"},  new Genre { NameGenre = "Буквари"},
                    new Genre { NameGenre = "Менеджмент и кадры"}, new Genre { NameGenre = "Зарубежные приключения"}, new Genre { NameGenre = "Отечественные мемуары"}, new Genre { NameGenre = "Отечественная поэзия для детей"},  new Genre { NameGenre = "Городское фэнтези"},
                    new Genre { NameGenre = "Работа с клиентами"}, new Genre { NameGenre = "Зарубежная религиозная и эзотерическая литература"}, new Genre { NameGenre = "Отечественная поэзия"}, new Genre { NameGenre = "Книги для детей"},  new Genre { NameGenre = "Боевое фэнтези"},
                    new Genre { NameGenre = "Политическое управление"}, new Genre { NameGenre = "Зарубежная публицистика"}, new Genre { NameGenre = "Советская литература"}, new Genre { NameGenre = "Сказки отечественных писателей"},  new Genre { NameGenre = "Юмористическое фэнтези"},
                    new Genre { NameGenre = "Стартапы и создание бизнеса"}, new Genre { NameGenre = "Зарубежная прикладная литература"}, new Genre { NameGenre = "Отечественная драматургия"}, new Genre { NameGenre = "Внеклассное чтение"},  new Genre { NameGenre = "Книги про вампиров"},
                    new Genre { NameGenre = "Корпоративная культура"}, new Genre { NameGenre = "Зарубежная драматургия"}, new Genre { NameGenre = "Русская классика для детей"}, new Genre { NameGenre = "Современные детективы"},  new Genre { NameGenre = "Героическое фэнтези"},
                    new Genre { NameGenre = "Переговоры"}, new Genre { NameGenre = "Зарубежная литература о культуре и искусстве"}, new Genre { NameGenre = "Классический отечественный детектив"}, new Genre { NameGenre = "Классические детективы"},  new Genre { NameGenre = "Книг про волшебников"},
                    new Genre { NameGenre = "Личная эффективность"}, new Genre { NameGenre = "Зарубежная фантастика"}, new Genre { NameGenre = "Отечественный боевик"}, new Genre { NameGenre = "Триллеры"},  new Genre { NameGenre = "Полицейские детективы"},
                    new Genre { NameGenre = "Личные финансы"}, new Genre { NameGenre = "Зарубежные детские книги"}, new Genre { NameGenre = "Современный отечественный детектив"}, new Genre { NameGenre = "Исторические детективы"},  new Genre { NameGenre = "Попаданцы"},
                    new Genre { NameGenre = "Ораторское искусство, риторика"}, new Genre { NameGenre = "Современная зарубежная литература"}, new Genre { NameGenre = "Отечественный юмор и сатира"}, new Genre { NameGenre = "Иронические детективы"},  new Genre { NameGenre = "Историческое фэнтези"},
                    new Genre { NameGenre = "Риторика"}, new Genre { NameGenre = "Фэнтези про драконов"}, new Genre { NameGenre = "Детективное фэнтези"}, new Genre { NameGenre = "Эротическое фэнтези"}, new Genre { NameGenre = "Темное фэнтези"}, new Genre { NameGenre = "Научная фантастика"},
                    new Genre { NameGenre = "Продажи"}, new Genre { NameGenre = "Боевая фантастика"}, new Genre { NameGenre = "Историческая фантастика"}, new Genre { NameGenre = "Героическая фантастика"}, new Genre { NameGenre = "Детективная фантастика"}, new Genre { NameGenre = "Космическая фантастика"}, new Genre { NameGenre = "Любовно-фантастические романы"},
                    new Genre { NameGenre = "Социальная фантастика"}, new Genre { NameGenre = "Киберпанк"}, new Genre { NameGenre = "Юмористическая фантастика"}, new Genre { NameGenre = "Стимпанк"}, new Genre { NameGenre = "ЛитРПГ"}, new Genre { NameGenre = "Историческая литература"}, new Genre { NameGenre = "Книги о войне"},
                    new Genre { NameGenre = "Контркультура"}, new Genre { NameGenre = "Исторические приключения"}, new Genre { NameGenre = "Книги о путешесвиях"}, new Genre { NameGenre = "Вестерны"}, new Genre { NameGenre = "Морские приключения"}, new Genre { NameGenre = "Книги о приключениях"},
                    new Genre { NameGenre = "Мистика"}, new Genre { NameGenre = "Ужасы"}, new Genre { NameGenre = "Биография и мемуары"}, new Genre { NameGenre = "Военное дело, спецслужбы"}, new Genre { NameGenre = "Документальная литература"}, new Genre { NameGenre = "Публицистика"}, new Genre { NameGenre = "Афоризмы и цитаты"}, new Genre { NameGenre = "Статьи"},
                    new Genre { NameGenre = "Интервью"}, new Genre { NameGenre = "Рецензии"}, new Genre { NameGenre = "Современные любовные романы"}, new Genre { NameGenre = "Короткие любовные романы"}, new Genre { NameGenre = "Остросюжетные любовные романы"}, new Genre { NameGenre = "Исторические любовные романы"}, new Genre { NameGenre = "Эротические романы"},
                    new Genre { NameGenre = "Криминальные боевики"}, new Genre { NameGenre = "Боевики"}, new Genre { NameGenre = "Общая психология"}, new Genre { NameGenre = "Практическая психология"}, new Genre { NameGenre = "Прикладная психология"}, new Genre { NameGenre = "Саморазвитие, личностый рост"},
                    new Genre { NameGenre = "Классики психологии"}, new Genre { NameGenre = "Отраслевая психология"}, new Genre { NameGenre = "Семья, брак, сексология"}, new Genre { NameGenre = "Социальная психология"}, new Genre { NameGenre = "Детская психология"}, new Genre { NameGenre = "Основы психологии"},
                    new Genre { NameGenre = "Психология управления"}, new Genre { NameGenre = "Возрастная психология"}, new Genre { NameGenre = "История психологии"}, new Genre { NameGenre = "Соционика"}, new Genre { NameGenre = "Состояния и явления психики"}, new Genre { NameGenre = "Рассказы"}, new Genre { NameGenre = "Повести"}, new Genre { NameGenre = "Очерки"},
                    new Genre { NameGenre = "Начинающие авторы"}, new Genre { NameGenre = "Сборники"},new Genre { NameGenre = "Эссе"}, new Genre { NameGenre = "Фанфик"}, new Genre { NameGenre = "Стихи и поэзия"}, new Genre { NameGenre = "Пьесы и драматургия"},
                    new Genre { NameGenre = "Гуманитарные и общественные науки"}, new Genre { NameGenre = "Школьные учебники"}, new Genre { NameGenre = "Научно-популярная литература"}, new Genre { NameGenre = "Сельское и лесное хозяйство"}, new Genre { NameGenre = "Учебники и пособия для вузов"}, new Genre { NameGenre = "Монография"},
                    new Genre { NameGenre = "Задачники"}, new Genre { NameGenre = "Методики(учебно-методические пособия)"}, new Genre { NameGenre = "Военное дело"}, new Genre { NameGenre = "Прочая образовательная лиетература"}, new Genre { NameGenre = "Медицина, здравоохранение"}, new Genre { NameGenre = "Естественные науки"}, new Genre { NameGenre = "Техничсекие науки"},
                    new Genre { NameGenre = "Кулинария"}, new Genre { NameGenre = "Искусство фотографии"}, new Genre { NameGenre = "Сделай сам"}, new Genre { NameGenre = "Воспитание детей"}, new Genre { NameGenre = "Рукоделие, ремесла"}, new Genre { NameGenre = "Мода и стиль"}, new Genre { NameGenre = "Домашние животные"}, new Genre { NameGenre = "Отдых и туризм"}, new Genre { NameGenre = "Интерьеры"},
                    new Genre { NameGenre = "Охота"}, new Genre { NameGenre = "Прикладная литература"}, new Genre { NameGenre = "Рыбалка"}, new Genre { NameGenre = "Автомобили и ПДД"}, new Genre { NameGenre = "Природа и животные"},new Genre { NameGenre = "Самосовершенствование"}, new Genre { NameGenre = "Сад и огород"}, new Genre { NameGenre = "Развлечения"}, new Genre { NameGenre = "Хобби, увлечения"},
                    new Genre { NameGenre = "Изобразительное искусство"}, new Genre { NameGenre = "Спорт, фитнес"}, new Genre { NameGenre = "Эзотерика, оккультизм"}, new Genre { NameGenre = "Практическая эзотерика"}, new Genre { NameGenre = "Йога"}, new Genre { NameGenre = "Гадание, толкование снов"},
                    new Genre { NameGenre = "Магия, колдовство"}, new Genre { NameGenre = "Астрология"}, new Genre { NameGenre = "Спиритизм, пророчества и предсказания"}, new Genre { NameGenre = "Современные религиозные течения"}, new Genre { NameGenre = "Парапсихология"}, new Genre { NameGenre = "Таинственные явления"},
                    new Genre { NameGenre = "Фэн-шуй"}, new Genre { NameGenre = "Тайные общества"}, new Genre { NameGenre = "Музыка"}, new Genre { NameGenre = "Искусствоведение"}, new Genre { NameGenre = "Кинематограф, театр"}, new Genre { NameGenre = "Архитектура"}, new Genre { NameGenre = "Телевидение"}, new Genre { NameGenre = "Критика"}, new Genre { NameGenre = "Музеи и коллекции"},
                    new Genre { NameGenre = "Опера, балет"}, new Genre { NameGenre = "Дизайн"}, new Genre { NameGenre = "История искусств"}, new Genre { NameGenre = "Ноты"}, new Genre { NameGenre = "Цирк"}, new Genre { NameGenre = "Танцы"}, new Genre { NameGenre = "Юмористическая проза"}, new Genre { NameGenre = "Юмористические стихи"}, new Genre { NameGenre = "Анекдоты"},
                    new Genre { NameGenre = "Юмор и сатира"}, new Genre { NameGenre = "Православие"}, new Genre { NameGenre = "Религии, верования, культы"},new Genre { NameGenre = "Христианство"}, new Genre { NameGenre = "Ислам"}, new Genre { NameGenre = "Буддизм"}, new Genre { NameGenre = "Религиоведение, история религий"}, new Genre { NameGenre = "Религиозные тексты"}, new Genre { NameGenre = "Духовная литература"}, 
                    new Genre { NameGenre = "Иудаизм"}, new Genre { NameGenre = "Католицизм"}, new Genre { NameGenre = "Индуизм"}, new Genre { NameGenre = "Христианское искусство"}, new Genre { NameGenre = "Протестанизм"}, new Genre { NameGenre = "Путеводители"}, new Genre { NameGenre = "Руководства"}, new Genre { NameGenre = "Энциклопедии"},
                    new Genre { NameGenre = "Справочная литература"}, new Genre { NameGenre = "Словари"}, new Genre { NameGenre = "Самоучители"}, new Genre { NameGenre = "Народная и нетрадиционная медицина"}, new Genre { NameGenre = "Здоровье"}, new Genre { NameGenre = "Похудение и диеты"}, new Genre { NameGenre = "Косметика и косметология"},
                    new Genre { NameGenre = "Прически, уход за волосами"}, new Genre { NameGenre = "Здоровое и правильное питание"}, new Genre { NameGenre = "Книги на английском"}, new Genre { NameGenre = "Книги на французском"}, new Genre { NameGenre = "Книги на белорусском"}, new Genre { NameGenre = "Книги на немецком"}, new Genre { NameGenre = "Книги на испанском"}, new Genre { NameGenre = "Книги на японском"}, new Genre { NameGenre = "Книги на китайском"},
                    new Genre { NameGenre = "Программирование"}, new Genre { NameGenre = "Программы"}, new Genre { NameGenre = "Базы данных"}, new Genre { NameGenre = "Книги о компьютерах"}, new Genre { NameGenre = "ОС и сети"}, new Genre { NameGenre = "Интернет"}, new Genre { NameGenre = "Компьютерное железо"}, new Genre { NameGenre = "Компьютерная справочная литература"},
                    new Genre { NameGenre = "Эротическая литература"}, new Genre { NameGenre = "Сексуальные рукодоства"}, new Genre { NameGenre = "Эротичсекие рассказы и истории"}, new Genre { NameGenre = "Журналы"}, new Genre { NameGenre = "Газеты"}, new Genre { NameGenre = "Альманахи"},
                    new Genre { NameGenre = "Школьные учебники"}, new Genre { NameGenre = "Прочая учебная литература"}, 
                    new Genre { NameGenre = "Интернет-бизнес"},
                    new Genre { NameGenre = "Ценные бумаги, инвестиции"},
                    new Genre { NameGenre = "Бухучет, налогообложение, аудит"},
                    new Genre { NameGenre = "Поиск работы, карьера"},
                    new Genre { NameGenre = "Кадровый менеджмент"},
                    new Genre { NameGenre = "Экономика"},
                    new Genre { NameGenre = "Зарубежная классика"},
                    new Genre { NameGenre = "Русская классика"},
                    new Genre { NameGenre = "Литература XX века"},
                    new Genre { NameGenre = "Фольклор"},
                    new Genre { NameGenre = "Литература XIX века"},
                    new Genre { NameGenre = "Европейская старинная литература"},
                    new Genre { NameGenre = "Зарубежная старинная литература"},
                    new Genre { NameGenre = "Древнерусская литература"},
                    new Genre { NameGenre = "Классическая проза"},
                    new Genre { NameGenre = "Старинная литература"},
                    new Genre { NameGenre = "Мифы, легенды, эпос"},
                    new Genre { NameGenre = "Советская литература"},
                    new Genre { NameGenre = "Античная литература"},
                    new Genre { NameGenre = "Литература XVIII века"},
                    new Genre { NameGenre = "Древневосточная литература"},
                    new Genre { NameGenre = "Зарубежная классика "},
                    new Genre { NameGenre = "Зарубежные любовные романы"},
                    new Genre { NameGenre = "Зарубежные детективы"},
                    new Genre { NameGenre = "Зарубежное фэнтези"},
                    new Genre { NameGenre = "Зарубежная деловая литература"},
                    new Genre { NameGenre = "Зарубежная поэзия"},
                    new Genre { NameGenre = "Зарубежная образовательная литература"},
                };

            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            if (context.Type_Of_Literatures.Any())
            {
                return;
            }
            var types = new Type_of_literature[]
                {
                    new Type_of_literature{ Name_Type = "Бизнес-книги" },
                    new Type_of_literature{ Name_Type = "Классическая литература" },
                    new Type_of_literature{ Name_Type = "Зарубежная литература" },
                    new Type_of_literature{ Name_Type = "Русская литература" },
                    new Type_of_literature{ Name_Type = "Детские книги" },
                    new Type_of_literature{ Name_Type = "Детективы" },
                    new Type_of_literature{ Name_Type = "Фэнтези" },
                    new Type_of_literature{ Name_Type = "Фантастика" },
                    new Type_of_literature{ Name_Type = "Современная проза" },
                    new Type_of_literature{ Name_Type = "Приключения" },
                    new Type_of_literature{ Name_Type = "Ужасы, мистика" },
                    new Type_of_literature{ Name_Type = "Публицистическая литература" },
                    new Type_of_literature{ Name_Type = "Книги для подростков" },
                    new Type_of_literature{ Name_Type = "Любовные романы" },
                    new Type_of_literature{ Name_Type = "Боевики, остросюжетная литература" },
                    new Type_of_literature{ Name_Type = "Книги по психологии" },
                    new Type_of_literature{ Name_Type = "Повести, рассказы" },
                    new Type_of_literature{ Name_Type = "Поэзия, драматургия" },
                    new Type_of_literature{ Name_Type = "Наука и образование" },
                    new Type_of_literature{ Name_Type = "Дом, семья, хобби и досуг" },
                    new Type_of_literature{ Name_Type = "Комиксы, манга" },
                    new Type_of_literature{ Name_Type = "Эзотерика" },
                    new Type_of_literature{ Name_Type = "Культура и искусство" },
                    new Type_of_literature{ Name_Type = "Юмористическая литература" },
                    new Type_of_literature{ Name_Type = "Религия" },
                    new Type_of_literature{ Name_Type = "Словари" },
                    new Type_of_literature{ Name_Type = "Справочники" },
                    new Type_of_literature{ Name_Type = "Красота и здоровье" },
                    new Type_of_literature{ Name_Type = "Книги на иностранных языках" },
                    new Type_of_literature{ Name_Type = "Компьютерная литература" },
                    new Type_of_literature{ Name_Type = "Эротика и секс" },
                    new Type_of_literature{ Name_Type = "Периодические издания" },
                    new Type_of_literature{ Name_Type = "Учебная литература" },
                    new Type_of_literature{ Name_Type = "Исторический роман" },
                    new Type_of_literature{ Name_Type = "Магический реализм" },
                    new Type_of_literature{ Name_Type = "ЛГБТ" },
                    new Type_of_literature{ Name_Type = "Реализм" }
                 };
            foreach (Type_of_literature t in types)
            {
                context.Type_Of_Literatures.Add(t);
            }
            context.SaveChanges();

        }
    }
}
