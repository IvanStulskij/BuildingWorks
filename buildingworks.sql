-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 08 2022 г., 23:55
-- Версия сервера: 10.3.13-MariaDB-log
-- Версия PHP: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `buildingworks`
--

-- --------------------------------------------------------

--
-- Структура таблицы `analiticsarchive`
--

CREATE TABLE `analiticsarchive` (
  `AnaliticResultsCode` int(11) NOT NULL,
  `ObjectCode` int(11) NOT NULL,
  `PlanCode` int(11) NOT NULL,
  `PlanBenefit` float NOT NULL,
  `ExpencesForMaterials` decimal(10,0) NOT NULL,
  `ExpencesForSalary` decimal(10,0) NOT NULL,
  `ExpencesForTaxes` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `brigades`
--

CREATE TABLE `brigades` (
  `BrigadeCode` int(11) NOT NULL,
  `ObjectId` int(11) DEFAULT NULL,
  `BrigadierCode` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `brigades`
--

INSERT INTO `brigades` (`BrigadeCode`, `ObjectId`, `BrigadierCode`) VALUES
(1, 5, 1),
(4, 5, 2),
(5, NULL, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `buildingobject`
--

CREATE TABLE `buildingobject` (
  `ObjectId` int(11) NOT NULL,
  `ObjectName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ObjectCustomer` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ObjectType` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `RegionCode` int(11) NOT NULL,
  `TownCode` int(11) NOT NULL,
  `StreetCode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `buildingobject`
--

INSERT INTO `buildingobject` (`ObjectId`, `ObjectName`, `ObjectCustomer`, `ObjectType`, `RegionCode`, `TownCode`, `StreetCode`) VALUES
(5, 'Мой мир', '5', 'ffffff', 1, 1, 1),
(12, 'УО \"БГАЭК\"', 'Могилевский отдел образования', 'Образовательное учреждение', 1, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `contracts`
--

CREATE TABLE `contracts` (
  `ContractCode` int(11) NOT NULL,
  `ProviderCode` int(11) NOT NULL,
  `Conditions` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `contracts`
--

INSERT INTO `contracts` (`ContractCode`, `ProviderCode`, `Conditions`) VALUES
(1, 4, 'Условия гигантские'),
(2, 5, 'И почему условия очень большие?!');

-- --------------------------------------------------------

--
-- Структура таблицы `contractsbymaterials`
--

CREATE TABLE `contractsbymaterials` (
  `Id` int(11) NOT NULL,
  `BuildingObjectId` int(11) NOT NULL,
  `ContractId` int(11) NOT NULL,
  `MaterialId` int(11) NOT NULL,
  `Amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `contractsbymaterials`
--

INSERT INTO `contractsbymaterials` (`Id`, `BuildingObjectId`, `ContractId`, `MaterialId`, `Amount`) VALUES
(1, 5, 2, 1, 4),
(2, 5, 1, 4, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `deductions`
--

CREATE TABLE `deductions` (
  `DeductionCode` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Amount` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `materials`
--

CREATE TABLE `materials` (
  `MaterialCode` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `PricePerOne` decimal(10,2) NOT NULL,
  `Measure` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `materials`
--

INSERT INTO `materials` (`MaterialCode`, `Name`, `PricePerOne`, `Measure`) VALUES
(1, 'Балки крепленые', '1100.00', 'кол-во'),
(2, 'Бревно', '123.00', 'кол-во'),
(3, '7', '8.00', '98'),
(4, 'ds', '4.32', 'ddd');

-- --------------------------------------------------------

--
-- Структура таблицы `objectaddress`
--

CREATE TABLE `objectaddress` (
  `AddressCode` int(11) NOT NULL,
  `RegionCode` int(11) NOT NULL,
  `TownCode` int(11) NOT NULL,
  `StreetCode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `objectaddress`
--

INSERT INTO `objectaddress` (`AddressCode`, `RegionCode`, `TownCode`, `StreetCode`) VALUES
(7, 1, 1, 1),
(8, 1, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `plancompletionhistory`
--

CREATE TABLE `plancompletionhistory` (
  `CompletionHistoryCody` int(11) NOT NULL,
  `ObjectCode` int(11) NOT NULL,
  `RealCompletionTime` date NOT NULL,
  `CompletionPercent` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `plans`
--

CREATE TABLE `plans` (
  `PlanCode` int(11) NOT NULL,
  `ObjectId` int(11) NOT NULL,
  `CompleteTime` date NOT NULL,
  `IsCompleted` tinyint(1) NOT NULL,
  `Cost` decimal(10,0) NOT NULL,
  `PathToImage` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `plans`
--

INSERT INTO `plans` (`PlanCode`, `ObjectId`, `CompleteTime`, `IsCompleted`, `Cost`, `PathToImage`) VALUES
(1, 5, '2021-11-02', 0, '1000000', 'fdfdfd'),
(2, 12, '2022-02-24', 0, '50000', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `plansdetails`
--

CREATE TABLE `plansdetails` (
  `PlanDetailCode` int(11) NOT NULL,
  `PlanCode` int(11) NOT NULL,
  `WorkPart` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `IsCompleted` tinyint(1) NOT NULL,
  `ComplitionTime` date NOT NULL,
  `Price` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `plansdetails`
--

INSERT INTO `plansdetails` (`PlanDetailCode`, `PlanCode`, `WorkPart`, `IsCompleted`, `ComplitionTime`, `Price`) VALUES
(1, 1, 'jkljkljkljlkjkllkkljjlk', 0, '2021-12-09', 900),
(2, 1, 'llobnnmbmnjkkl', 1, '2021-12-31', 900),
(3, 1, 'opo[pop', 1, '2021-11-01', 766);

-- --------------------------------------------------------

--
-- Структура таблицы `providers`
--

CREATE TABLE `providers` (
  `ProviderCode` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Country` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `AdditionalData` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `providers`
--

INSERT INTO `providers` (`ProviderCode`, `Name`, `Country`, `AdditionalData`) VALUES
(1, 'first provider', 'Belarus', 'fdaadsfasdf'),
(2, 'firstProvider', 'Belarus', '1234'),
(3, 'fdfd', 'ddd', 'fdqwerfv'),
(4, 'fdfdd', 'rrrr', 'ytuuiiu'),
(5, 'ererer', 'kjlklkl;kl;lk;', 'xcvcvvcbb'),
(6, 're', 'ee', 'fdasdf'),
(7, 'gfdhgfh', 'jhjhjh', 'ffgjmmn vb bvmnmvb'),
(8, 'Иванов Сидор', 'США', 'лалалдлмждлмджсчлджмлсдлджлждлджлджл');

-- --------------------------------------------------------

--
-- Структура таблицы `regions`
--

CREATE TABLE `regions` (
  `RegionCode` int(11) NOT NULL,
  `RegionName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `regions`
--

INSERT INTO `regions` (`RegionCode`, `RegionName`) VALUES
(1, 'Могилевская'),
(8, 'Минская'),
(9, 'Витебская');

-- --------------------------------------------------------

--
-- Структура таблицы `streets`
--

CREATE TABLE `streets` (
  `StreetCode` int(11) NOT NULL,
  `StreetName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TownCode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `streets`
--

INSERT INTO `streets` (`StreetCode`, `StreetName`, `TownCode`) VALUES
(1, 'Интернациональная', 1),
(3, 'Советская', 1),
(4, 'Ленина', 4);

-- --------------------------------------------------------

--
-- Структура таблицы `taxes`
--

CREATE TABLE `taxes` (
  `TaxCode` int(11) NOT NULL,
  `Name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Percent` float DEFAULT NULL,
  `Deduction` float DEFAULT NULL,
  `MaterialId` int(11) DEFAULT NULL,
  `WorkerId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `taxes`
--

INSERT INTO `taxes` (`TaxCode`, `Name`, `Percent`, `Deduction`, `MaterialId`, `WorkerId`) VALUES
(2, 'абракадабра', 33.1, NULL, 0, 0),
(3, 'myTax', 55.7, NULL, 0, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `towns`
--

CREATE TABLE `towns` (
  `TownCode` int(11) NOT NULL,
  `TownName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `RegionCode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `towns`
--

INSERT INTO `towns` (`TownCode`, `TownName`, `RegionCode`) VALUES
(1, 'Бобруйск', 1),
(3, 'Барановичи', 8),
(4, 'Могилев', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `unregistereduserscodes`
--

CREATE TABLE `unregistereduserscodes` (
  `Code` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `unregistereduserscodes`
--

INSERT INTO `unregistereduserscodes` (`Code`) VALUES
(545);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `UserCode` int(11) NOT NULL,
  `FullName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(32) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `workers`
--

CREATE TABLE `workers` (
  `PersonnelNumber` int(11) NOT NULL,
  `FullName` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `BrigadeCode` int(11) NOT NULL,
  `StartWorkDate` date NOT NULL,
  `WorkerPost` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `workers`
--

INSERT INTO `workers` (`PersonnelNumber`, `FullName`, `BrigadeCode`, `StartWorkDate`, `WorkerPost`) VALUES
(1, 'Сидоров', 1, '2021-10-13', 'Бригадир'),
(2, 'Иванов', 1, '2017-11-14', 'Строитель'),
(3, 'Петров', 1, '2019-01-15', 'Строитель');

-- --------------------------------------------------------

--
-- Структура таблицы `workerssalaries`
--

CREATE TABLE `workerssalaries` (
  `SalaryCode` int(11) NOT NULL,
  `PersonnelNumber` int(11) NOT NULL,
  `BaseSalary` decimal(10,2) NOT NULL,
  `Experience` float NOT NULL,
  `ChildrenCount` int(11) NOT NULL,
  `WorkedDays` int(11) NOT NULL,
  `TotalAmount` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `workerssalaries`
--

INSERT INTO `workerssalaries` (`SalaryCode`, `PersonnelNumber`, `BaseSalary`, `Experience`, `ChildrenCount`, `WorkedDays`, `TotalAmount`) VALUES
(1, 1, '783.00', 12, 2, 12, 1200),
(2, 1, '783.00', 12, 2, 25, 1385);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `analiticsarchive`
--
ALTER TABLE `analiticsarchive`
  ADD PRIMARY KEY (`AnaliticResultsCode`),
  ADD KEY `ObjectCode` (`ObjectCode`,`PlanCode`),
  ADD KEY `PlanCode` (`PlanCode`);

--
-- Индексы таблицы `brigades`
--
ALTER TABLE `brigades`
  ADD PRIMARY KEY (`BrigadeCode`),
  ADD KEY `BrigadierCode` (`BrigadierCode`),
  ADD KEY `ObjectCode` (`ObjectId`) USING BTREE;

--
-- Индексы таблицы `buildingobject`
--
ALTER TABLE `buildingobject`
  ADD PRIMARY KEY (`ObjectId`),
  ADD KEY `RegionCode` (`RegionCode`),
  ADD KEY `TownCode` (`TownCode`),
  ADD KEY `StreetCode` (`StreetCode`);

--
-- Индексы таблицы `contracts`
--
ALTER TABLE `contracts`
  ADD PRIMARY KEY (`ContractCode`),
  ADD KEY `ProviderCode` (`ProviderCode`);

--
-- Индексы таблицы `contractsbymaterials`
--
ALTER TABLE `contractsbymaterials`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ContractId` (`ContractId`),
  ADD KEY `BuildingObjectId` (`BuildingObjectId`),
  ADD KEY `contractsbymaterials_ibfk_2` (`MaterialId`);

--
-- Индексы таблицы `deductions`
--
ALTER TABLE `deductions`
  ADD PRIMARY KEY (`DeductionCode`);

--
-- Индексы таблицы `materials`
--
ALTER TABLE `materials`
  ADD PRIMARY KEY (`MaterialCode`);

--
-- Индексы таблицы `objectaddress`
--
ALTER TABLE `objectaddress`
  ADD PRIMARY KEY (`AddressCode`),
  ADD KEY `RegionCode` (`RegionCode`,`TownCode`,`StreetCode`),
  ADD KEY `TownCode` (`TownCode`),
  ADD KEY `StreetCode` (`StreetCode`);

--
-- Индексы таблицы `plancompletionhistory`
--
ALTER TABLE `plancompletionhistory`
  ADD PRIMARY KEY (`CompletionHistoryCody`),
  ADD KEY `ObjectCode` (`ObjectCode`);

--
-- Индексы таблицы `plans`
--
ALTER TABLE `plans`
  ADD PRIMARY KEY (`PlanCode`),
  ADD KEY `ObjectCode` (`ObjectId`);

--
-- Индексы таблицы `plansdetails`
--
ALTER TABLE `plansdetails`
  ADD PRIMARY KEY (`PlanDetailCode`),
  ADD KEY `PlanCode` (`PlanCode`);

--
-- Индексы таблицы `providers`
--
ALTER TABLE `providers`
  ADD PRIMARY KEY (`ProviderCode`);

--
-- Индексы таблицы `regions`
--
ALTER TABLE `regions`
  ADD PRIMARY KEY (`RegionCode`);

--
-- Индексы таблицы `streets`
--
ALTER TABLE `streets`
  ADD PRIMARY KEY (`StreetCode`),
  ADD KEY `TownCode` (`TownCode`);

--
-- Индексы таблицы `taxes`
--
ALTER TABLE `taxes`
  ADD PRIMARY KEY (`TaxCode`);

--
-- Индексы таблицы `towns`
--
ALTER TABLE `towns`
  ADD PRIMARY KEY (`TownCode`),
  ADD KEY `RegionCode` (`RegionCode`);

--
-- Индексы таблицы `unregistereduserscodes`
--
ALTER TABLE `unregistereduserscodes`
  ADD PRIMARY KEY (`Code`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserCode`);

--
-- Индексы таблицы `workers`
--
ALTER TABLE `workers`
  ADD PRIMARY KEY (`PersonnelNumber`),
  ADD KEY `BrigadeCode` (`BrigadeCode`),
  ADD KEY `FullName` (`FullName`);

--
-- Индексы таблицы `workerssalaries`
--
ALTER TABLE `workerssalaries`
  ADD PRIMARY KEY (`SalaryCode`),
  ADD KEY `WorkerCode` (`PersonnelNumber`) USING BTREE;

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `analiticsarchive`
--
ALTER TABLE `analiticsarchive`
  MODIFY `AnaliticResultsCode` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `brigades`
--
ALTER TABLE `brigades`
  MODIFY `BrigadeCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `buildingobject`
--
ALTER TABLE `buildingobject`
  MODIFY `ObjectId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT для таблицы `contracts`
--
ALTER TABLE `contracts`
  MODIFY `ContractCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `contractsbymaterials`
--
ALTER TABLE `contractsbymaterials`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `deductions`
--
ALTER TABLE `deductions`
  MODIFY `DeductionCode` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `materials`
--
ALTER TABLE `materials`
  MODIFY `MaterialCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `objectaddress`
--
ALTER TABLE `objectaddress`
  MODIFY `AddressCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `plancompletionhistory`
--
ALTER TABLE `plancompletionhistory`
  MODIFY `CompletionHistoryCody` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `plans`
--
ALTER TABLE `plans`
  MODIFY `PlanCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `plansdetails`
--
ALTER TABLE `plansdetails`
  MODIFY `PlanDetailCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `providers`
--
ALTER TABLE `providers`
  MODIFY `ProviderCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `regions`
--
ALTER TABLE `regions`
  MODIFY `RegionCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `streets`
--
ALTER TABLE `streets`
  MODIFY `StreetCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `taxes`
--
ALTER TABLE `taxes`
  MODIFY `TaxCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `towns`
--
ALTER TABLE `towns`
  MODIFY `TownCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `workers`
--
ALTER TABLE `workers`
  MODIFY `PersonnelNumber` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `workerssalaries`
--
ALTER TABLE `workerssalaries`
  MODIFY `SalaryCode` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `analiticsarchive`
--
ALTER TABLE `analiticsarchive`
  ADD CONSTRAINT `analiticsarchive_ibfk_1` FOREIGN KEY (`ObjectCode`) REFERENCES `buildingobject` (`ObjectId`) ON UPDATE CASCADE,
  ADD CONSTRAINT `analiticsarchive_ibfk_2` FOREIGN KEY (`PlanCode`) REFERENCES `plans` (`PlanCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `brigades`
--
ALTER TABLE `brigades`
  ADD CONSTRAINT `brigades_ibfk_1` FOREIGN KEY (`ObjectId`) REFERENCES `buildingobject` (`ObjectId`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `brigades_ibfk_2` FOREIGN KEY (`BrigadierCode`) REFERENCES `workers` (`PersonnelNumber`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `buildingobject`
--
ALTER TABLE `buildingobject`
  ADD CONSTRAINT `buildingobject_ibfk_1` FOREIGN KEY (`RegionCode`) REFERENCES `regions` (`RegionCode`),
  ADD CONSTRAINT `buildingobject_ibfk_2` FOREIGN KEY (`TownCode`) REFERENCES `towns` (`TownCode`),
  ADD CONSTRAINT `buildingobject_ibfk_3` FOREIGN KEY (`StreetCode`) REFERENCES `streets` (`StreetCode`);

--
-- Ограничения внешнего ключа таблицы `contracts`
--
ALTER TABLE `contracts`
  ADD CONSTRAINT `contracts_ibfk_2` FOREIGN KEY (`ProviderCode`) REFERENCES `providers` (`ProviderCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `contractsbymaterials`
--
ALTER TABLE `contractsbymaterials`
  ADD CONSTRAINT `contractsbymaterials_ibfk_1` FOREIGN KEY (`ContractId`) REFERENCES `contracts` (`ContractCode`),
  ADD CONSTRAINT `contractsbymaterials_ibfk_2` FOREIGN KEY (`MaterialId`) REFERENCES `materials` (`MaterialCode`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `contractsbymaterials_ibfk_3` FOREIGN KEY (`BuildingObjectId`) REFERENCES `buildingobject` (`ObjectId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `objectaddress`
--
ALTER TABLE `objectaddress`
  ADD CONSTRAINT `objectaddress_ibfk_1` FOREIGN KEY (`RegionCode`) REFERENCES `regions` (`RegionCode`),
  ADD CONSTRAINT `objectaddress_ibfk_2` FOREIGN KEY (`TownCode`) REFERENCES `towns` (`TownCode`),
  ADD CONSTRAINT `objectaddress_ibfk_3` FOREIGN KEY (`StreetCode`) REFERENCES `streets` (`StreetCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `plancompletionhistory`
--
ALTER TABLE `plancompletionhistory`
  ADD CONSTRAINT `plancompletionhistory_ibfk_1` FOREIGN KEY (`ObjectCode`) REFERENCES `plans` (`PlanCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `plans`
--
ALTER TABLE `plans`
  ADD CONSTRAINT `plans_ibfk_1` FOREIGN KEY (`ObjectId`) REFERENCES `buildingobject` (`ObjectId`);

--
-- Ограничения внешнего ключа таблицы `plansdetails`
--
ALTER TABLE `plansdetails`
  ADD CONSTRAINT `plansdetails_ibfk_1` FOREIGN KEY (`PlanCode`) REFERENCES `plans` (`PlanCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `streets`
--
ALTER TABLE `streets`
  ADD CONSTRAINT `streets_ibfk_1` FOREIGN KEY (`TownCode`) REFERENCES `towns` (`TownCode`);

--
-- Ограничения внешнего ключа таблицы `towns`
--
ALTER TABLE `towns`
  ADD CONSTRAINT `towns_ibfk_1` FOREIGN KEY (`RegionCode`) REFERENCES `regions` (`RegionCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `workers`
--
ALTER TABLE `workers`
  ADD CONSTRAINT `workers_ibfk_1` FOREIGN KEY (`BrigadeCode`) REFERENCES `brigades` (`BrigadeCode`) ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `workerssalaries`
--
ALTER TABLE `workerssalaries`
  ADD CONSTRAINT `workerssalaries_ibfk_1` FOREIGN KEY (`PersonnelNumber`) REFERENCES `workers` (`PersonnelNumber`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
