-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 02 2024 г., 10:46
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Kurs`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Batch`
--

CREATE TABLE `Batch` (
  `BatchID` int UNSIGNED NOT NULL,
  `BatchTypeID` int UNSIGNED NOT NULL,
  `ShipmentID` int UNSIGNED NOT NULL,
  `Volume` int NOT NULL
) ;

--
-- Дамп данных таблицы `Batch`
--

INSERT INTO `Batch` (`BatchID`, `BatchTypeID`, `ShipmentID`, `Volume`) VALUES
(3, 1, 1, 100),
(4, 3, 2, 1000),
(5, 1, 2, 1000),
(6, 4, 3, 100000);

-- --------------------------------------------------------

--
-- Структура таблицы `BatchType`
--

CREATE TABLE `BatchType` (
  `BatchTypeID` int UNSIGNED NOT NULL,
  `TypeName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `BatchType`
--

INSERT INTO `BatchType` (`BatchTypeID`, `TypeName`) VALUES
(1, 'решебники'),
(2, '\"Разрешённые\" вещества'),
(3, 'хлеб свежий'),
(4, 'кубинские сигары'),
(5, '0_0'),
(7, 'камни'),
(8, 'ноутбуки сус');

-- --------------------------------------------------------

--
-- Структура таблицы `Customs`
--

CREATE TABLE `Customs` (
  `CustomsID` int UNSIGNED NOT NULL,
  `StateID` int UNSIGNED NOT NULL,
  `CustomsLocation` varchar(100) NOT NULL,
  `CustomsName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Customs`
--

INSERT INTO `Customs` (`CustomsID`, `StateID`, `CustomsLocation`, `CustomsName`) VALUES
(1, 1, 'ул. Смешногорская 14', 'Сибирское таможенное управление'),
(2, 2, 'ул. Непонятная 1001', 'Южное таможенное управление'),
(3, 3, 'ул. Шпрот 2', 'Центральная таможня');

-- --------------------------------------------------------

--
-- Структура таблицы `Process`
--

CREATE TABLE `Process` (
  `ProcessID` int UNSIGNED NOT NULL,
  `CustomsID` int UNSIGNED NOT NULL,
  `BatchTypeID` int UNSIGNED NOT NULL,
  `Volume` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Process`
--

INSERT INTO `Process` (`ProcessID`, `CustomsID`, `BatchTypeID`, `Volume`) VALUES
(1, 1, 2, 600),
(2, 2, 3, 10),
(3, 3, 1, 450),
(4, 1, 1, 50),
(5, 1, 3, 50),
(6, 1, 4, 50),
(7, 1, 5, 50);

-- --------------------------------------------------------

--
-- Структура таблицы `Schedule`
--

CREATE TABLE `Schedule` (
  `ScheduleID` int UNSIGNED NOT NULL,
  `CustomsID` int UNSIGNED NOT NULL,
  `ShipmentID` int UNSIGNED NOT NULL,
  `Time` time NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Schedule`
--

INSERT INTO `Schedule` (`ScheduleID`, `CustomsID`, `ShipmentID`, `Time`, `Date`) VALUES
(1, 1, 1, '00:05:00', '2024-05-20'),
(2, 2, 2, '16:30:00', '2024-05-20'),
(3, 3, 3, '08:00:00', '2024-05-20');

-- --------------------------------------------------------

--
-- Структура таблицы `Shipment`
--

CREATE TABLE `Shipment` (
  `ShipmentID` int UNSIGNED NOT NULL,
  `StateID` int UNSIGNED NOT NULL,
  `ShipmentName` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `Shipment`
--

INSERT INTO `Shipment` (`ShipmentID`, `StateID`, `ShipmentName`) VALUES
(1, 1, 'Грузовик Камаз'),
(2, 2, 'Грузовик MAN'),
(3, 3, 'грузовой контейнер');

-- --------------------------------------------------------

--
-- Структура таблицы `State`
--

CREATE TABLE `State` (
  `StateID` int UNSIGNED NOT NULL,
  `StateName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Дамп данных таблицы `State`
--

INSERT INTO `State` (`StateID`, `StateName`) VALUES
(1, 'Российская Федерация'),
(2, 'СеверноЮжная Корея'),
(3, 'Атлантида'),
(14, 'Югославия'),
(15, 'Корания');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Batch`
--
ALTER TABLE `Batch`
  ADD PRIMARY KEY (`BatchID`),
  ADD KEY `BatchTypeID` (`BatchTypeID`),
  ADD KEY `ShipmentID` (`ShipmentID`);

--
-- Индексы таблицы `BatchType`
--
ALTER TABLE `BatchType`
  ADD PRIMARY KEY (`BatchTypeID`);

--
-- Индексы таблицы `Customs`
--
ALTER TABLE `Customs`
  ADD PRIMARY KEY (`CustomsID`),
  ADD KEY `StateID` (`StateID`);

--
-- Индексы таблицы `Process`
--
ALTER TABLE `Process`
  ADD PRIMARY KEY (`ProcessID`),
  ADD KEY `BatchTypeID` (`BatchTypeID`),
  ADD KEY `CustomsID` (`CustomsID`);

--
-- Индексы таблицы `Schedule`
--
ALTER TABLE `Schedule`
  ADD PRIMARY KEY (`ScheduleID`),
  ADD KEY `CustomsID` (`CustomsID`);

--
-- Индексы таблицы `Shipment`
--
ALTER TABLE `Shipment`
  ADD PRIMARY KEY (`ShipmentID`),
  ADD KEY `StateID` (`StateID`);

--
-- Индексы таблицы `State`
--
ALTER TABLE `State`
  ADD PRIMARY KEY (`StateID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Batch`
--
ALTER TABLE `Batch`
  MODIFY `BatchID` int UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `BatchType`
--
ALTER TABLE `BatchType`
  MODIFY `BatchTypeID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `Customs`
--
ALTER TABLE `Customs`
  MODIFY `CustomsID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Process`
--
ALTER TABLE `Process`
  MODIFY `ProcessID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `Schedule`
--
ALTER TABLE `Schedule`
  MODIFY `ScheduleID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Shipment`
--
ALTER TABLE `Shipment`
  MODIFY `ShipmentID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `State`
--
ALTER TABLE `State`
  MODIFY `StateID` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Batch`
--
ALTER TABLE `Batch`
  ADD CONSTRAINT `batch_ibfk_1` FOREIGN KEY (`BatchTypeID`) REFERENCES `BatchType` (`BatchTypeID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `batch_ibfk_2` FOREIGN KEY (`ShipmentID`) REFERENCES `Shipment` (`ShipmentID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `Customs`
--
ALTER TABLE `Customs`
  ADD CONSTRAINT `customs_ibfk_1` FOREIGN KEY (`StateID`) REFERENCES `State` (`StateID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `Process`
--
ALTER TABLE `Process`
  ADD CONSTRAINT `process_ibfk_1` FOREIGN KEY (`BatchTypeID`) REFERENCES `BatchType` (`BatchTypeID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `process_ibfk_2` FOREIGN KEY (`CustomsID`) REFERENCES `Customs` (`CustomsID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `Schedule`
--
ALTER TABLE `Schedule`
  ADD CONSTRAINT `schedule_ibfk_1` FOREIGN KEY (`CustomsID`) REFERENCES `Customs` (`CustomsID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `schedule_ibfk_2` FOREIGN KEY (`ScheduleID`) REFERENCES `Shipment` (`ShipmentID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Ограничения внешнего ключа таблицы `Shipment`
--
ALTER TABLE `Shipment`
  ADD CONSTRAINT `shipment_ibfk_1` FOREIGN KEY (`StateID`) REFERENCES `State` (`StateID`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
