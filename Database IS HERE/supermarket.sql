-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 19, 2019 at 05:33 AM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `supermarket`
--

-- --------------------------------------------------------

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
CREATE TABLE IF NOT EXISTS `sale` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stock_id` int(11) NOT NULL,
  `qty` int(11) NOT NULL,
  `amount` float NOT NULL,
  `recipt_status` int(11) DEFAULT '0',
  `created_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `sale_ibfk_1` (`stock_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sale`
--

INSERT INTO `sale` (`id`, `stock_id`, `qty`, `amount`, `recipt_status`, `created_date`) VALUES
(20, 3, 1, 2.5, 1, '2019-10-15 09:52:28'),
(21, 5, 2, 6, 1, '2019-10-15 09:52:36'),
(22, 3, 1, 2.5, 1, '2019-10-15 09:56:21'),
(23, 3, 1, 2.5, 1, '2019-10-15 11:05:51'),
(24, 5, 2, 6, 1, '2019-10-15 11:05:58'),
(25, 3, 1, 2.5, 1, '2019-10-15 11:06:00'),
(26, 6, 6, 24, 1, '2019-10-16 12:34:37'),
(27, 5, 2, 6, 1, '2019-10-16 12:34:45'),
(28, 3, 2, 5, 1, '2019-10-19 05:27:38');

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `barcode` int(8) NOT NULL,
  `price` float NOT NULL,
  `type` varchar(20) NOT NULL,
  `total_qty` int(11) NOT NULL,
  `image` varchar(20) DEFAULT NULL,
  `created_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`id`, `name`, `barcode`, `price`, `type`, `total_qty`, `image`, `created_date`) VALUES
(3, 'coca', 1, 2.5, 'Soft Drink', 88, NULL, '2019-10-15 07:29:56'),
(5, 'bacchus', 2, 3, 'Soft Drink', 83, NULL, '2019-10-15 09:08:24'),
(6, 'mama', 3, 4, 'Snack', 80, NULL, '2019-10-15 09:08:43');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `sale`
--
ALTER TABLE `sale`
  ADD CONSTRAINT `sale_ibfk_1` FOREIGN KEY (`stock_id`) REFERENCES `stock` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
