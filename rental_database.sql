-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 18, 2014 at 02:44 AM
-- Server version: 5.5.32
-- PHP Version: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `rental_database`
--
CREATE DATABASE IF NOT EXISTS `rental_database` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `rental_database`;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE IF NOT EXISTS `customer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(20) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `address` varchar(50) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`id`, `first_name`, `last_name`, `address`, `phone_number`) VALUES
(1, 'Michael', 'Jacobe', '4 Somerset Rd Wanganui 4501', '0212369346'),
(6, 'Doggy', 'Dawgs', 'Dog Street', '021dogwassup');

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE IF NOT EXISTS `game` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(50) NOT NULL,
  `platform` varchar(10) NOT NULL,
  `year` int(11) NOT NULL,
  `publisher` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `other` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`id`, `title`, `platform`, `year`, `publisher`, `quantity`, `price`, `other`) VALUES
(1, 'Until Dawn', 'PS4', 2015, 'Sony Computer Entertainment', 15, 10, 'PSMove'),
(5, 'asfasd', 'PS4', 564, 'fdgh', 65, 67, 'fghj'),
(8, 'dfsdfg', 'WIIU', 423, 'asdfa', 23, 6765, 'sdfgsdf');

-- --------------------------------------------------------

--
-- Table structure for table `game_rental`
--

CREATE TABLE IF NOT EXISTS `game_rental` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(20) NOT NULL,
  `game_id` int(20) NOT NULL,
  `rent_date` date NOT NULL,
  `rent_due` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `game_rental`
--

INSERT INTO `game_rental` (`id`, `customer_id`, `game_id`, `rent_date`, `rent_due`) VALUES
(3, 1, 1, '2014-04-20', '2014-04-30'),
(4, 1, 5, '2014-12-12', '2014-12-13'),
(5, 6, 1, '2014-11-11', '2014-11-12');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
