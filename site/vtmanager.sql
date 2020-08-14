-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Апр 02 2020 г., 17:16
-- Версия сервера: 5.5.62
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `vtmanager`
--

-- --------------------------------------------------------

--
-- Структура таблицы `deliveries`
--

CREATE TABLE `deliveries` (
  `id` int(11) NOT NULL,
  `providerId` int(11) NOT NULL,
  `resourceId` int(11) NOT NULL,
  `personalId` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `deliveryDate` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица произведённых поставок';

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `vtId` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица с заказами клиентов.';

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`id`, `vtId`, `userId`, `count`, `date`) VALUES
(1, 2, 1, 4, '2020-04-02'),
(2, 3, 1, 1, '2020-04-02'),
(3, 4, 1, 2, '2020-04-02'),
(4, 5, 1, 1, '2020-04-02'),
(5, 2, 1, 6, '2020-04-02'),
(6, 3, 1, 6, '2020-04-02'),
(7, 4, 1, 9, '2020-04-02'),
(8, 3, 2, 5, '2020-04-02'),
(9, 5, 2, 10, '2020-04-02');

-- --------------------------------------------------------

--
-- Структура таблицы `personal`
--

CREATE TABLE `personal` (
  `id` int(11) NOT NULL,
  `login` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL,
  `sess` int(11) NOT NULL DEFAULT '1234',
  `firstName` varchar(90) NOT NULL,
  `lastName` varchar(90) NOT NULL,
  `thirdName` varchar(90) NOT NULL,
  `bDay` date NOT NULL,
  `post` varchar(255) NOT NULL,
  `workshopId` int(11) NOT NULL,
  `workLength` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица персонала, учавствующего в производстве.';

--
-- Дамп данных таблицы `personal`
--

INSERT INTO `personal` (`id`, `login`, `pass`, `sess`, `firstName`, `lastName`, `thirdName`, `bDay`, `post`, `workshopId`, `workLength`) VALUES
(1, 'admin', '0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c', 1234, 'admin', 'admin', 'admin', '2020-02-15', 'Разработчик', 1, '2019-01-01'),
(3, 'Anline', '1294756jg3', 5678, 'Тярина', 'Анна', 'Валентиновна', '1997-02-02', 'Кладовщик', 1, '2018-12-02'),
(4, 'Verhilly', '1234', 9012, 'Антонов', 'Сергей', 'Тереньтьев', '1981-06-20', 'Литейщик', 1, '2011-11-03'),
(5, 'andrew45rus', '5gh5hj324g5j34kj', 3456, 'Фертилов', 'Андрей', 'Семёнович', '1987-02-02', 'Начальник цеха', 1, '2014-04-12'),
(6, 'AMaksimov', '797979230102d', 6985, 'Максимов', 'Сергей', 'Владимирович', '1988-03-10', 'Радиотехник', 2, '2020-03-09'),
(7, 'AGagarina', 'mda123456', 4589, 'Гагарина', 'Алина', 'Валентиновна', '1989-06-20', 'Кладовщик', 1, '2020-03-02'),
(8, 'RSeleznev', 'dhgr6h6y67', 3244, 'Селезнёв', 'Роман', 'Евгениевич', '1979-01-22', 'Начальник цеха', 2, '2020-03-01'),
(9, 'EVershinin', 'crush69609606', 6541, 'Вершинин', 'Евгений', 'Викторович', '1995-06-06', 'Радиотехник', 2, '2020-03-01'),
(10, 'AGlebov', 'ddf5h6hhujm', 6542, 'Глебов', 'Алексей', 'Петрович', '1984-03-09', 'Инженер-Радиотехник', 2, '2020-03-01');

-- --------------------------------------------------------

--
-- Структура таблицы `processing`
--

CREATE TABLE `processing` (
  `id` int(11) NOT NULL,
  `storageId` int(11) NOT NULL,
  `personalId` int(11) NOT NULL,
  `vtId` int(11) NOT NULL,
  `shift` int(11) NOT NULL,
  `date` date NOT NULL,
  `count` int(11) NOT NULL,
  `plan` int(11) NOT NULL,
  `fact` int(11) NOT NULL,
  `done` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `processing`
--

INSERT INTO `processing` (`id`, `storageId`, `personalId`, `vtId`, `shift`, `date`, `count`, `plan`, `fact`, `done`) VALUES
(1, 1, 4, 2, 1, '2020-02-02', 1000, 1000, 1000, 0),
(2, 1, 4, 3, 2, '2020-03-08', 750, 700, 750, 0),
(3, 1, 6, 4, 3, '2020-03-01', 750, 800, 750, 0),
(4, 1, 6, 5, 4, '2020-03-15', 1000, 1000, 1000, 0),
(5, 1, 6, 6, 5, '2020-03-16', 800, 800, 800, 1),
(6, 1, 10, 7, 6, '2020-03-10', 190, 200, 190, 1),
(8, 1, 10, 9, 7, '2020-03-03', 750, 750, 750, 1),
(24, 1, 9, 2, 7, '2020-03-03', 750, 750, 750, 1),
(23, 1, 9, 4, 7, '2020-03-03', 750, 750, 750, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `providers`
--

CREATE TABLE `providers` (
  `id` int(11) NOT NULL,
  `organization` varchar(255) NOT NULL,
  `manager` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `fax` int(6) NOT NULL,
  `email` varchar(120) NOT NULL,
  `address` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица с поставщиками, распространяющими лампы с завода.';

-- --------------------------------------------------------

--
-- Структура таблицы `resource`
--

CREATE TABLE `resource` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `units` enum('Граммы','Килограммы','Тонны','Миллилитры','Литры','Единицы') NOT NULL,
  `priceOfUnit` int(11) NOT NULL,
  `costPerShift` float(11,2) NOT NULL,
  `resourceQuality` enum('Стандартное','Хорошее','Отличное','Низкое') NOT NULL DEFAULT 'Стандартное'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица, описывающая исходное сырьё.';

--
-- Дамп данных таблицы `resource`
--

INSERT INTO `resource` (`id`, `name`, `units`, `priceOfUnit`, `costPerShift`, `resourceQuality`) VALUES
(1, 'Кварцевый песок', 'Тонны', 1200, 1.74, 'Стандартное'),
(2, 'Кремний кристаллический', 'Тонны', 104000, 1.46, 'Стандартное'),
(4, 'Боросиликатная смесь', 'Килограммы', 790, 0.07, 'Стандартное'),
(5, 'Бисфенол-А', 'Литры', 1670, 0.06, 'Хорошее'),
(6, 'Эпихлоргидрин', 'Килограммы', 133, 0.11, 'Стандартное'),
(7, 'Политетрафторэтилен', 'Килограммы', 1250, 0.09, 'Хорошее'),
(8, 'Ацетон', 'Литры', 125, 0.35, 'Стандартное'),
(9, 'Стальные заготовки', 'Единицы', 135, 14.00, 'Отличное'),
(10, 'Вольфрамовые заготовки', 'Единицы', 890, 5.50, 'Отличное'),
(11, 'Нихромовые заготовки', 'Единицы', 450, 9.00, 'Хорошее'),
(12, 'Канталовые заготовки', 'Единицы', 550, 7.00, 'Отличное'),
(13, 'Инконель-625 заготовки', 'Единицы', 2600, 0.02, 'Отличное'),
(3, 'Графеновая плёнка', 'Килограммы', 1450, 0.14, 'Хорошее');

-- --------------------------------------------------------

--
-- Структура таблицы `storages`
--

CREATE TABLE `storages` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `personalId` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Склады.';

--
-- Дамп данных таблицы `storages`
--

INSERT INTO `storages` (`id`, `name`, `personalId`) VALUES
(1, 'СГД', 3),
(2, 'Склад сухих смесей', 3),
(3, 'Склад химикатов и парафинов', 7);

-- --------------------------------------------------------

--
-- Структура таблицы `storage_contains`
--

CREATE TABLE `storage_contains` (
  `id` int(11) NOT NULL,
  `storageId` int(11) NOT NULL,
  `resourceId` int(11) NOT NULL,
  `count` double(11,2) NOT NULL,
  `importDate` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `storage_contains`
--

INSERT INTO `storage_contains` (`id`, `storageId`, `resourceId`, `count`, `importDate`) VALUES
(1, 2, 1, 49956.50, '2020-02-02'),
(2, 2, 2, 14963.50, '2020-03-01'),
(3, 3, 4, 598.26, '2020-03-01'),
(4, 1, 10, 3362.50, '2020-03-01'),
(5, 1, 9, 4650.00, '2020-03-01'),
(6, 1, 11, 2775.00, '2020-03-01'),
(7, 1, 12, 1825.00, '2020-03-01'),
(8, 1, 13, 99.50, '2020-03-01'),
(9, 3, 5, 198.50, '2020-03-01'),
(10, 3, 6, 597.24, '2020-03-01'),
(11, 3, 7, 297.74, '2020-03-01'),
(12, 3, 8, 991.25, '2020-03-01'),
(13, 3, 3, 496.50, '2020-03-12');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(120) NOT NULL,
  `pass` int(11) NOT NULL,
  `fullName` varchar(255) NOT NULL,
  `phone` int(11) NOT NULL,
  `address` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица с клиентами, которые зарегистрированны на сайте.';

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `fullName`, `phone`, `address`) VALUES
(1, 'Alex', 1234, 'Alex Man Dodo', 657432, 'Broklyn, NY 11230'),
(2, 'Petre', 6606, 'Ивкин Пётр Валентинович', 890254557, 'г. Калуга, ул. Ленина 32, кв. 40');

-- --------------------------------------------------------

--
-- Структура таблицы `vt`
--

CREATE TABLE `vt` (
  `id` int(11) NOT NULL,
  `mark` varchar(25) NOT NULL,
  `vtType` enum('Диод','Триод','Пентод','Гептод','Триод-Гептод','Двойной диод','Двойной триод','Кенотрон') NOT NULL,
  `cathodeType` enum('Оксидный','Плёночный','Полупроводниковый','Стальной','Вольфрамовый') NOT NULL,
  `cellType` enum('Октальный','Штырьковый','Цилиндрический','') NOT NULL,
  `voltage` float NOT NULL,
  `amperage` int(11) NOT NULL,
  `pinsOfCap` int(2) NOT NULL DEFAULT '4',
  `name` varchar(255) NOT NULL,
  `info` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Полное описания марки радиолампы и её характеристик.';

--
-- Дамп данных таблицы `vt`
--

INSERT INTO `vt` (`id`, `mark`, `vtType`, `cathodeType`, `cellType`, `voltage`, `amperage`, `pinsOfCap`, `name`, `info`) VALUES
(3, '6К7', 'Пентод', 'Оксидный', 'Октальный', 6.3, 300, 7, 'Пентод 6К7 ', 'Пентод 6К7 предназначен для усиления напряжения ВЧ. Применяется в приемной аппаратуре в каскадах усиления ВЧ и ПЧ, в регулируемых схемах и измерительной аппаратуре, а также в качестве предварительного усилителя НЧ на сопротивлениях.'),
(2, '6К4', 'Пентод', 'Оксидный', 'Октальный', 6.3, 300, 8, 'Пентод 6К4', 'Пентод 6К4 предназначен для регулируемого усиления напряжения ВЧ. Применяется в каскадах ВЧ и ПЧ. '),
(4, '6Ж3', 'Пентод', 'Оксидный', 'Октальный', 6.3, 300, 8, 'Пентод 6Ж3', 'Пентод 6Ж3 предназначен для усиления напряжения ВЧ. Применяется в каскадах промежуточной частоты звукового канала телевизионных приемников.'),
(5, '6С1П', 'Триод', 'Оксидный', 'Штырьковый', 6.3, 150, 4, 'Триод 6С1П', 'Триод 6С1П предназначен для усиления, детектирования и генерирования частот в диапазоне КВ и УКВ. Может быть использован для усиления напряжения низкой частоты.'),
(6, '6С2С', 'Триод', 'Оксидный', 'Цилиндрический', 5.5, 270, 6, 'Триод 6С2С', 'Триод 6С2С предназначен для усиления напряжения в предварительных каскадах УНЧ высококачественных усилителей; в качестве отдельного гетеродина в супергетеродинных телевизионных и вещательных приемниках.'),
(7, '6И1П', 'Триод-Гептод', 'Плёночный', 'Штырьковый', 7.4, 400, 9, 'Триод-гептод 6И1П', 'Триод-гептод 6И1П предназначен для преобразования частоты с одновременным автоматическим регулированием усиления в супергетеродинных приемниках.'),
(8, '6Х2П', 'Двойной диод', 'Оксидный', 'Штырьковый', 6.9, 300, 7, 'Двойной диод с отдельными катодами 6Х2П', 'Двойной диод 6Х2П предназначен для детектирования и выпрямления переменного тока; в качестве детектора и детектора АРУ в супергетеродинных приемниках; в каскадах дискриминаторов и дробного детектора в приемниках с ЧМ.'),
(9, '6Х6С', 'Двойной диод', 'Оксидный', 'Октальный', 6.3, 260, 4, 'Двойной диод с отдельными катодами 6Х6С', 'Двойной диод 6Х6С предназначен для детектирования и выпрямления переменного напряжения. Применяется в вещательных и телевизионных приемниках в качестве детектора.'),
(10, '6Ц10П', 'Кенотрон', 'Плёночный', 'Штырьковый', 6.9, 450, 4, 'Демпферный диод 6Ц10П', 'Демпферный диод 6Ц10П применяется для работы в блоках строчной развертки телевизионных приемников.');

-- --------------------------------------------------------

--
-- Структура таблицы `vt_lots`
--

CREATE TABLE `vt_lots` (
  `id` int(11) NOT NULL,
  `vtId` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `storageId` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Таблица с готовыми партиями ламп';

--
-- Дамп данных таблицы `vt_lots`
--

INSERT INTO `vt_lots` (`id`, `vtId`, `count`, `storageId`) VALUES
(1, 2, 750, 1),
(2, 3, 0, 1),
(3, 4, 750, 1),
(4, 5, 0, 1),
(5, 6, 800, 1),
(6, 7, 190, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `workshops`
--

CREATE TABLE `workshops` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `storageId` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  `creatingDate` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Описание цехов производства.';

--
-- Дамп данных таблицы `workshops`
--

INSERT INTO `workshops` (`id`, `name`, `storageId`, `owner`, `creatingDate`) VALUES
(1, 'Цех пиролиза и закаливания', 1, 5, '2020-02-02'),
(2, 'Цех поляризации', 1, 8, '2020-03-01');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `deliveries`
--
ALTER TABLE `deliveries`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `personal`
--
ALTER TABLE `personal`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `processing`
--
ALTER TABLE `processing`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `providers`
--
ALTER TABLE `providers`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `resource`
--
ALTER TABLE `resource`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `storages`
--
ALTER TABLE `storages`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `storage_contains`
--
ALTER TABLE `storage_contains`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `vt`
--
ALTER TABLE `vt`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `vt_lots`
--
ALTER TABLE `vt_lots`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `workshops`
--
ALTER TABLE `workshops`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `personal`
--
ALTER TABLE `personal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `processing`
--
ALTER TABLE `processing`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT для таблицы `providers`
--
ALTER TABLE `providers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `resource`
--
ALTER TABLE `resource`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `storages`
--
ALTER TABLE `storages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `storage_contains`
--
ALTER TABLE `storage_contains`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `vt`
--
ALTER TABLE `vt`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT для таблицы `vt_lots`
--
ALTER TABLE `vt_lots`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `workshops`
--
ALTER TABLE `workshops`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
