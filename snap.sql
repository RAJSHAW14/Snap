-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jul 29, 2020 at 07:56 AM
-- Server version: 5.7.21
-- PHP Version: 5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `snap`
--

-- --------------------------------------------------------

--
-- Table structure for table `acc_d_return`
--

DROP TABLE IF EXISTS `acc_d_return`;
CREATE TABLE IF NOT EXISTS `acc_d_return` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `number` double DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `for_vendor` varchar(45) DEFAULT NULL,
  `issue_date` varchar(45) DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  `item` varchar(95) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `acc_grn`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `acc_grn`;
CREATE TABLE IF NOT EXISTS `acc_grn` (
`transaction_type` varchar(45)
,`number` double
,`item_code` varchar(45)
,`rate` varchar(45)
,`uom` varchar(45)
,`qty` varchar(45)
,`ex_tax_mt` double(14,2)
,`date` varchar(45)
,`reff_po_number` varchar(45)
,`bill_number` varchar(45)
,`bill_date` varchar(45)
,`vendor` varchar(75)
,`gst_amt` double(14,2)
,`inc_tax_amt` double(14,2)
,`item_name` varchar(150)
,`item_catagory` varchar(100)
,`gst` varchar(20)
,`hsn` int(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `acc_item_issue`
--

DROP TABLE IF EXISTS `acc_item_issue`;
CREATE TABLE IF NOT EXISTS `acc_item_issue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` varchar(45) DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `for_vendor` varchar(45) DEFAULT NULL,
  `issue_date` varchar(45) DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  `item` varchar(95) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_item_issue`
--

INSERT INTO `acc_item_issue` (`id`, `req_number`, `batchcode`, `department`, `designer`, `item_code`, `name`, `qty`, `rate`, `amount`, `unit`, `for_vendor`, `issue_date`, `p_code`, `item`) VALUES
(13, '2', 'PR250', 'SAREE', 'asd', 'acc-1', 'leather', '3', '500', '1500', 'mtr/sq', 'abc', '02-12-2019', '', 'pcs'),
(14, '2', 'PR250', 'SAREE', 'asd', 'box-frame', 'consum', '2', '125', '250', 'pcs', 'abc', '02-12-2019', '', 'cluthc'),
(15, '2', 'PR250', 'SAREE', 'asd', 'box-frame', 'consum', '1', '125', '125', 'pcs', 'abc', '02-12-2019', '', 'cluthc'),
(16, '2', 'PR250', 'SAREE', 'asd', 'acc-1', 'leather', '2', '500', '1000', 'mtr/sq', 'abc', '02-12-2019', '', 'pcs'),
(17, '2', 'PR250', 'SAREE', 'asd', 'acc-1', 'leather', '1', '500', '500', 'mtr/sq', 'abc', '02-12-2019', '', 'pcs'),
(18, '3', 'PR003', 'SAREE', 'asb', 'acc-1', 'leather', '50', '500', '25000', 'mtr/sq', 'test', '10-12-2019', '', 'bag'),
(19, '4', '', 'abc', 'asb', 'box-frame', 'consum', '15', '125', '1875', 'pcs', '', '10-12-2019', 'ada', 'clutch');

-- --------------------------------------------------------

--
-- Stand-in structure for view `acc_pending_request`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `acc_pending_request`;
CREATE TABLE IF NOT EXISTS `acc_pending_request` (
`req_number` double
,`batchcode` varchar(45)
,`department` varchar(45)
,`designer` varchar(45)
,`for_vendor` varchar(145)
,`req_date` varchar(45)
,`p_code` varchar(145)
,`item` varchar(95)
);

-- --------------------------------------------------------

--
-- Table structure for table `acc_product`
--

DROP TABLE IF EXISTS `acc_product`;
CREATE TABLE IF NOT EXISTS `acc_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_code` varchar(45) DEFAULT NULL,
  `style_code` varchar(45) DEFAULT NULL,
  `product` varchar(45) DEFAULT NULL,
  `size` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `store` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `client` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_product`
--

INSERT INTO `acc_product` (`id`, `product_code`, `style_code`, `product`, `size`, `type`, `store`, `color`, `client`, `date`) VALUES
(1, '1', '2', '3', '4', '5', '6', '7', '', '06-01-2020'),
(2, 'abc', 'abc001', 'bag', '44', 'order', 'delhi', 'red', 'na', '07-01-2020'),
(3, 'abc1', 'abc001', 'bag', '44', 'order', 'delhi', 'red', 'na', '07-01-2020');

-- --------------------------------------------------------

--
-- Table structure for table `acc_qc_master`
--

DROP TABLE IF EXISTS `acc_qc_master`;
CREATE TABLE IF NOT EXISTS `acc_qc_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item_name` varchar(145) DEFAULT NULL,
  `check_list` varchar(95) DEFAULT NULL,
  `parameter` varchar(95) DEFAULT NULL,
  `remarks` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_qc_master`
--

INSERT INTO `acc_qc_master` (`id`, `item_name`, `check_list`, `parameter`, `remarks`) VALUES
(11, 'BAG', 'BCA', 'GOOD', ''),
(14, 'BELT', 'AD', 'REJECTED', ''),
(13, 'BELT', 'ABC', 'AVERAGE', ''),
(12, 'BAG', 'GA', 'AVERAGE', ''),
(10, 'BAG', 'ABC', 'AVERAGE', '');

-- --------------------------------------------------------

--
-- Table structure for table `acc_qc_transaction_list`
--

DROP TABLE IF EXISTS `acc_qc_transaction_list`;
CREATE TABLE IF NOT EXISTS `acc_qc_transaction_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_code` varchar(95) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `style_code` varchar(45) DEFAULT NULL,
  `product` varchar(45) DEFAULT NULL,
  `size` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `client_store` varchar(45) DEFAULT NULL,
  `check_list` varchar(45) DEFAULT NULL,
  `parameter` varchar(45) DEFAULT NULL,
  `d_remakrs` varchar(95) DEFAULT NULL,
  `qc_parameter` varchar(45) DEFAULT NULL,
  `qc_remarks` varchar(45) DEFAULT NULL,
  `d_status` varchar(45) DEFAULT NULL,
  `final_status` varchar(45) DEFAULT NULL,
  `id_number` int(11) DEFAULT NULL,
  `final_qc_person` varchar(95) DEFAULT NULL,
  `final_qc_remarks` varchar(255) DEFAULT NULL,
  `final_qc_date` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `client` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_qc_transaction_list`
--

INSERT INTO `acc_qc_transaction_list` (`id`, `product_code`, `date`, `style_code`, `product`, `size`, `type`, `client_store`, `check_list`, `parameter`, `d_remakrs`, `qc_parameter`, `qc_remarks`, `d_status`, `final_status`, `id_number`, `final_qc_person`, `final_qc_remarks`, `final_qc_date`, `color`, `client`) VALUES
(1, 'AB003', '02-03-2019', 'AB002/19', 'BAG', '42', 'ORDER', 'DELHI', 'SIZE', '40', 'OK', '40', '', 'APPROVED', 'APPROVED', 1, '', 'approved', NULL, NULL, NULL),
(2, 'ABC001', '05-02-2019', 'ABC001', 'BELT', '40', 'ORDER', 'LAKE ROAD', 'SIZE', '90', 'OK', '90', '', 'REJECTED', 'REJECTED', 2, 'ABHISHEK', 'REJECTED', NULL, NULL, NULL),
(3, 'ABC001', '05-02-2019', 'ABC001', 'BELT', '40', 'ORDER', 'LAKE ROAD', 'LEATHER QUALITY', '50', 'OK', '50', '', 'REJECTED', 'REJECTED', 2, 'ABHISHEK', 'REJECTED', NULL, NULL, NULL),
(4, 'ABC001', '05-02-2019', 'ABC001', 'BELT', '40', 'ORDER', 'LAKE ROAD', 'WIDTH', '30\"', 'OK', '30\"', '', 'REJECTED', 'REJECTED', 2, 'ABHISHEK', 'REJECTED', NULL, NULL, NULL),
(5, 'ABC001', '05-02-2019', 'ABC001', 'BELT', '40', 'ORDER', 'LAKE ROAD', 'THEIS', '50\"', '50', '50\"', '', 'REJECTED', 'REJECTED', 2, 'ABHISHEK', 'REJECTED', NULL, NULL, NULL),
(6, 'ABC001', '04-01-2019', 'DELHI', 'BAG', 'NA', 'ORDER', 'DELHI', 'BCA', 'GOOD', 'OK', 'GOOD', '', 'APPROVED', 'APPROVED', 3, 'BANI', 'APPROVED', '03-01-2019', NULL, NULL),
(7, 'ABC001', '04-01-2019', 'DELHI', 'BAG', 'NA', 'ORDER', 'DELHI', 'GA', 'AVERAGE', 'OK', 'AVERAGE', '', 'APPROVED', 'APPROVED', 3, 'BANI', 'APPROVED', '03-01-2019', NULL, NULL),
(8, 'ABC001', '04-01-2019', 'DELHI', 'BAG', 'NA', 'ORDER', 'DELHI', 'ABC', 'AVERAGE', 'OK', 'AVERAGE', '', 'APPROVED', 'APPROVED', 3, 'BANI', 'APPROVED', '03-01-2019', NULL, NULL),
(9, 'sad', '  -  -', '', '', '', '', '', 'BCA', 'GOOD', '', NULL, NULL, 'SENT TO QC', NULL, 4, NULL, NULL, NULL, NULL, NULL),
(10, 'sad', '  -  -', '', '', '', '', '', 'GA', 'AVERAGE', '', NULL, NULL, 'SENT TO QC', NULL, 4, NULL, NULL, NULL, NULL, NULL),
(11, 'sad', '  -  -', '', '', '', '', '', 'ABC', 'AVERAGE', '', NULL, NULL, 'SENT TO QC', NULL, 4, NULL, NULL, NULL, NULL, NULL),
(12, 'ABC', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'BCA', 'GOOD', '', 'GOOD', '', 'APPROVED', 'APPROVED', 5, 'abc', '', '07-01-2020', 'red', 'na'),
(13, 'ABC', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'GA', 'AVERAGE', '', 'AVERAGE', '', 'APPROVED', 'APPROVED', 5, 'abc', '', '07-01-2020', 'red', 'na'),
(14, 'ABC', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'ABC', 'AVERAGE', '', 'AVERAGE', '', 'APPROVED', 'APPROVED', 5, 'abc', '', '07-01-2020', 'red', 'na'),
(15, 'ABC1', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'AD', 'REJECTED', '', 'REJECTED', '', 'REJECTED', 'REJECTED', 6, 'a', '', '07-01-2020', 'red', 'na'),
(16, 'ABC1', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'ABC', 'AVERAGE', '', 'AVERAGE', '', 'REJECTED', 'REJECTED', 6, 'a', '', '07-01-2020', 'red', 'na'),
(17, 'ABC1', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'AD', 'REJECTED', '', 'REJECTED', '', 'APPROVED', 'APPROVED', 7, 'a', '', '07-01-2020', 'red', 'na'),
(18, 'ABC1', '  -  -', 'abc001', 'bag', '44', 'order', 'delhi', 'ABC', 'AVERAGE', '', 'AVERAGE', '', 'APPROVED', 'APPROVED', 7, 'a', '', '07-01-2020', 'red', 'na');

-- --------------------------------------------------------

--
-- Table structure for table `acc_request`
--

DROP TABLE IF EXISTS `acc_request`;
CREATE TABLE IF NOT EXISTS `acc_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` double DEFAULT NULL,
  `number` varchar(45) DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `item_name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `pending_qty` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `req_date` varchar(45) DEFAULT NULL,
  `for_vendor` varchar(145) DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  `item` varchar(95) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_request`
--

INSERT INTO `acc_request` (`id`, `req_number`, `number`, `batchcode`, `department`, `designer`, `item_code`, `item_name`, `qty`, `unit`, `pending_qty`, `status`, `req_date`, `for_vendor`, `p_code`, `item`) VALUES
(23, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(24, 1, NULL, 'PR0026', 'SAREE', '', 'ab', 'a', '1', '', '1', NULL, '02-12-2019', '', '', ''),
(25, 2, NULL, 'PR250', 'SAREE', 'asd', 'box-frame', 'consum', '5', 'pcs', '2', NULL, '02-12-2019', 'abc', '', 'cluthc'),
(26, 2, NULL, 'PR250', 'SAREE', 'asd', 'acc-1', 'leather', '6', 'mtr/sq', '0', NULL, '02-12-2019', 'abc', '', 'pcs'),
(27, 3, NULL, 'PR003', 'SAREE', 'asb', 'acc-1', 'leather', '50', 'mtr/sq', '0', NULL, '10-12-2019', 'test', '', 'bag'),
(28, 4, NULL, '', 'abc', 'asb', 'box-frame', 'consum', '15', 'pcs', '0', NULL, '10-12-2019', '', 'ada', 'clutch');

-- --------------------------------------------------------

--
-- Stand-in structure for view `acc_style_cositng`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `acc_style_cositng`;
CREATE TABLE IF NOT EXISTS `acc_style_cositng` (
`style_code` varchar(45)
,`style_colour` varchar(45)
,`description` varchar(200)
,`mrp` varchar(45)
,`style_id` varchar(45)
,`hardware` double(10,2)
,`hand_emb` double(10,2)
,`machine_emb` double(10,2)
,`fabrication` double(10,2)
,`digital_print` double(10,2)
,`lining_quilting` double(10,2)
,`leather` double(10,2)
,`fabric` double(10,2)
,`dye` double(10,2)
,`emb_mat` double(10,2)
,`others` double(10,2)
,`hardware_polish` double(10,2)
,`packing` double(10,2)
,`overhead` double(10,2)
,`grand_total` double(10,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `acc_style_emb_mat_details`
--

DROP TABLE IF EXISTS `acc_style_emb_mat_details`;
CREATE TABLE IF NOT EXISTS `acc_style_emb_mat_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_id` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `non_fabric_code` varchar(45) DEFAULT NULL,
  `rate` double(10,2) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `total` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_style_emb_mat_details`
--

INSERT INTO `acc_style_emb_mat_details` (`id`, `style_id`, `component`, `non_fabric_code`, `rate`, `uom`, `qty`, `total`) VALUES
(2, '7', '', 'AVON-1', 5460.00, 'KG', 2.00, 10920.00),
(3, '7', '', 'M-10', 224.00, 'REEL', 10.00, 2240.00);

-- --------------------------------------------------------

--
-- Table structure for table `acc_style_fabric_details`
--

DROP TABLE IF EXISTS `acc_style_fabric_details`;
CREATE TABLE IF NOT EXISTS `acc_style_fabric_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_id` varchar(45) DEFAULT NULL,
  `part` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `width` double(10,2) DEFAULT NULL,
  `height` double(10,2) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `area` double(10,2) DEFAULT NULL,
  `fabric_rate` double(10,2) DEFAULT NULL,
  `wastage` varchar(45) DEFAULT NULL,
  `total` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_style_fabric_details`
--

INSERT INTO `acc_style_fabric_details` (`id`, `style_id`, `part`, `fabric_code`, `width`, `height`, `qty`, `area`, `fabric_rate`, `wastage`, `total`) VALUES
(2, '7', '', 'd-14', 50.00, 50.00, 2.00, 3.23, 630.00, '25', 2540.32),
(3, '7', '', 'D-155', 10.00, 20.00, 1.00, 0.13, 525.00, '10', 74.52);

-- --------------------------------------------------------

--
-- Table structure for table `acc_style_hardware_details`
--

DROP TABLE IF EXISTS `acc_style_hardware_details`;
CREATE TABLE IF NOT EXISTS `acc_style_hardware_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_id` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `rate` double(10,2) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `total` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_style_hardware_details`
--

INSERT INTO `acc_style_hardware_details` (`id`, `style_id`, `component`, `item_code`, `rate`, `qty`, `uom`, `total`) VALUES
(2, '7', '', 'acc-1', 590.00, 2.00, 'mtr/sq', 1180.00),
(3, '7', '', 'acc-1', 590.00, 1.00, 'mtr/sq', 590.00);

-- --------------------------------------------------------

--
-- Table structure for table `acc_style_leather_details`
--

DROP TABLE IF EXISTS `acc_style_leather_details`;
CREATE TABLE IF NOT EXISTS `acc_style_leather_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_id` varchar(45) DEFAULT NULL,
  `part` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `width` double(10,2) DEFAULT NULL,
  `height` double(10,2) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `area` double(10,2) DEFAULT NULL,
  `rate` double(10,2) DEFAULT NULL,
  `wastage` varchar(45) DEFAULT NULL,
  `total` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 COMMENT='	';

--
-- Dumping data for table `acc_style_leather_details`
--

INSERT INTO `acc_style_leather_details` (`id`, `style_id`, `part`, `item_code`, `width`, `height`, `qty`, `area`, `rate`, `wastage`, `total`) VALUES
(4, '7', '', 'acc-1', 50.00, 10.00, 2.00, 6.94, 590.00, '25', 5121.53),
(3, '7', '', 'acc-1', 10.00, 20.00, 2.00, 2.78, 590.00, '25', 2048.61),
(5, '7', '', 'acc-1', 30.00, 40.00, 1.00, 8.33, 590.00, '10', 5408.33);

-- --------------------------------------------------------

--
-- Table structure for table `acc_style_summery`
--

DROP TABLE IF EXISTS `acc_style_summery`;
CREATE TABLE IF NOT EXISTS `acc_style_summery` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_id` varchar(45) DEFAULT NULL,
  `hardware` double(10,2) DEFAULT NULL,
  `hand_emb` double(10,2) DEFAULT NULL,
  `machine_emb` double(10,2) DEFAULT NULL,
  `fabrication` double(10,2) DEFAULT NULL,
  `digital_print` double(10,2) DEFAULT NULL,
  `lining_quilting` double(10,2) DEFAULT NULL,
  `leather` double(10,2) DEFAULT NULL,
  `fabric` double(10,2) DEFAULT NULL,
  `dye` double(10,2) DEFAULT NULL,
  `emb_mat` double(10,2) DEFAULT NULL,
  `others` double(10,2) DEFAULT NULL,
  `hardware_polish` double(10,2) DEFAULT NULL,
  `packing` double(10,2) DEFAULT NULL,
  `overhead_PER` varchar(45) DEFAULT NULL,
  `overhead` double(10,2) DEFAULT NULL,
  `grand_total` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_style_summery`
--

INSERT INTO `acc_style_summery` (`id`, `style_id`, `hardware`, `hand_emb`, `machine_emb`, `fabrication`, `digital_print`, `lining_quilting`, `leather`, `fabric`, `dye`, `emb_mat`, `others`, `hardware_polish`, `packing`, `overhead_PER`, `overhead`, `grand_total`) VALUES
(2, '7', 1770.00, 40.00, 50.00, 60.00, 100.00, 25.00, 12578.47, 2614.84, 60.00, 13160.00, 500.00, 10.00, 50.00, '25', 38710.39, 69678.70);

-- --------------------------------------------------------

--
-- Table structure for table `acc_transactions`
--

DROP TABLE IF EXISTS `acc_transactions`;
CREATE TABLE IF NOT EXISTS `acc_transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transaction_type` varchar(45) DEFAULT NULL,
  `number` double DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `ex_tax_mt` double(14,2) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `reff_po_number` varchar(45) DEFAULT NULL,
  `bill_number` varchar(45) DEFAULT NULL,
  `bill_date` varchar(45) DEFAULT NULL,
  `vendor` varchar(75) DEFAULT NULL,
  `gst_amt` double(14,2) DEFAULT NULL,
  `inc_tax_amt` double(14,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `acc_transactions`
--

INSERT INTO `acc_transactions` (`id`, `transaction_type`, `number`, `item_code`, `rate`, `uom`, `qty`, `ex_tax_mt`, `date`, `reff_po_number`, `bill_number`, `bill_date`, `vendor`, `gst_amt`, `inc_tax_amt`) VALUES
(1, 'GRN', 1, 'ab', NULL, NULL, NULL, 123.00, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 'grn', 1, 'ab', NULL, NULL, NULL, 23.00, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'GRN', 2, 'acc-1', '500', 'mtr/sq', '10', 5000.00, '12-02-2019', 'abc', 'a', '12-02-2019', 'abhi', 900.00, 5900.00),
(6, 'GRN', 2, 'acc-1', '500', 'mtr/sq', '15', 7500.00, '12-02-2019', 'abc', 'a', '12-02-2019', 'abhi', 1350.00, 8850.00),
(7, 'GRN', 3, 'box-frame', '125', 'pcs', '500', 62500.00, '  -  -', 'avc', '', '12-02-2019', 'abhi', 11250.00, 73750.00),
(8, 'P-RETURN', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(10, 'P-RETURN', 1, 'box-frame', '125', 'pcs', '300', 37500.00, '  -  -', '', '', '  -  -', 'av', 6750.00, 44250.00),
(11, 'GRN', 4, 'acc-1', '500', 'mtr/sq', '20', 10000.00, '12-10-2019', '20', '123456', '12-10-2019', 'jowan', 1800.00, 11800.00),
(12, 'GRN', 4, 'acc-1', '500', 'mtr/sq', '50', 25000.00, '12-10-2019', '20', '123456', '12-10-2019', 'jowan', 4500.00, 29500.00),
(13, 'P-RETURN', 2, 'acc-1', '500', 'mtr/sq', '20', 10000.00, '12-10-2019', 'ada', '', '  -  -', 'journ', 1800.00, 11800.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `batchcode_id_product_code`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `batchcode_id_product_code`;
CREATE TABLE IF NOT EXISTS `batchcode_id_product_code` (
`product_code` varchar(250)
,`batcode_id` int(11)
,`batchcode` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `batch_code_master`
--

DROP TABLE IF EXISTS `batch_code_master`;
CREATE TABLE IF NOT EXISTS `batch_code_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `batchcode` varchar(45) DEFAULT NULL,
  `batchsize` int(11) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `generation_date` varchar(45) DEFAULT NULL,
  `style_code` varchar(45) DEFAULT NULL,
  `style_colour` varchar(45) DEFAULT NULL,
  `consumtion_require` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `designer_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `batch_code_master`
--

INSERT INTO `batch_code_master` (`id`, `batchcode`, `batchsize`, `department`, `generation_date`, `style_code`, `style_colour`, `consumtion_require`, `designer`, `designer_code`) VALUES
(1, 'PR0026', 6, 'SAREE', '07/08/2019', 'gh005', 'red', NULL, NULL, NULL),
(2, 'PR250', 5, 'SAREE', '07/08/2019', 'gh005', 'red', NULL, NULL, NULL),
(3, 'PR003', 5, 'SAREE', '09/08/2019', 'gh002', 'pink', 'YES', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `batch_fabric_consumption`
--

DROP TABLE IF EXISTS `batch_fabric_consumption`;
CREATE TABLE IF NOT EXISTS `batch_fabric_consumption` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `batch_id` int(11) DEFAULT NULL,
  `sty_fabric_consumption_id` int(11) DEFAULT NULL,
  `toal_consumption_qty` int(11) DEFAULT NULL,
  `request_qty` int(11) DEFAULT NULL,
  `pending_qty` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `batch_fabric_consumption`
--

INSERT INTO `batch_fabric_consumption` (`id`, `batch_id`, `sty_fabric_consumption_id`, `toal_consumption_qty`, `request_qty`, `pending_qty`) VALUES
(16, 3, 5, 100, NULL, 100),
(15, 3, 4, 300, NULL, 300),
(14, 3, 3, 100, NULL, 100);

-- --------------------------------------------------------

--
-- Table structure for table `cmc_design`
--

DROP TABLE IF EXISTS `cmc_design`;
CREATE TABLE IF NOT EXISTS `cmc_design` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `design_code` varchar(45) NOT NULL,
  `design_type` varchar(45) DEFAULT NULL,
  `machine_type` varchar(45) DEFAULT NULL,
  `design_description` varchar(250) DEFAULT NULL,
  `stitiches` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `appx_mc_time` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `emb_code` varchar(45) DEFAULT NULL,
  `digital` varchar(45) DEFAULT NULL,
  `remarks` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`,`design_code`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COMMENT='		';

--
-- Dumping data for table `cmc_design`
--

INSERT INTO `cmc_design` (`id`, `design_code`, `design_type`, `machine_type`, `design_description`, `stitiches`, `color`, `appx_mc_time`, `uom`, `emb_code`, `digital`, `remarks`) VALUES
(1, 'D-119', 'CORDING', '38cm', 'TEST', '40', 'RED', '25', 'PER MTR', '', '', ''),
(2, 'D-118', 'CORDING', '38cm', 'TEST', '40', 'RED', '25', 'PER MTR', '', '', ''),
(3, 'D-101', 'CORDING', '38cm', 'TEST', '40', 'RED', '25', 'PER MTR', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `cmc_mat`
--

DROP TABLE IF EXISTS `cmc_mat`;
CREATE TABLE IF NOT EXISTS `cmc_mat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mat_code` varchar(45) NOT NULL,
  `mat_type` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `stock` double(12,2) DEFAULT '0.00',
  `min_stock` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`mat_code`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_mat`
--

INSERT INTO `cmc_mat` (`id`, `mat_code`, `mat_type`, `uom`, `stock`, `min_stock`) VALUES
(1, 'M-10', 'MANISH', 'REEL', 521.00, '500'),
(2, 'TESTED-TIKKI-5', 'TESTED TIKKI', 'KG', 81.00, '30');

-- --------------------------------------------------------

--
-- Table structure for table `cmc_mat_stock_transaction`
--

DROP TABLE IF EXISTS `cmc_mat_stock_transaction`;
CREATE TABLE IF NOT EXISTS `cmc_mat_stock_transaction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `mat_code` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `stock` varchar(45) DEFAULT NULL,
  `entry_type` varchar(45) DEFAULT NULL,
  `for_order_number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_mat_stock_transaction`
--

INSERT INTO `cmc_mat_stock_transaction` (`id`, `date`, `mat_code`, `uom`, `stock`, `entry_type`, `for_order_number`) VALUES
(1, '2020-02-11', 'TESTED-TIKKI-5', 'KG', '31', NULL, NULL),
(2, '2020-02-11', 'M-10', 'REEL', '501', NULL, NULL),
(3, '2020-02-12', 'M-10', 'REEL', '20', 'IN', NULL),
(5, '2020-02-12', 'M-10', 'REEL', '50', 'OUT', 'RC/KDK/2019/222'),
(6, '2020-02-12', 'M-10', 'REEL', '20', 'IN', NULL),
(7, '2020-02-12', 'M-10', 'REEL', '20', 'OUT', 'RA'),
(8, '2020-06-12', 'TESTED-TIKKI-5', 'KG', '50', 'IN', NULL),
(9, '2020-06-12', 'M-10', 'REEL', '50', 'IN', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `cmc_order_entry`
--

DROP TABLE IF EXISTS `cmc_order_entry`;
CREATE TABLE IF NOT EXISTS `cmc_order_entry` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) NOT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `design_code` varchar(45) DEFAULT NULL,
  `fabric` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `component` varchar(145) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `fab_qty_details` varchar(45) DEFAULT NULL,
  `mat` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`,`order_number`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_order_entry`
--

INSERT INTO `cmc_order_entry` (`id`, `order_number`, `batchcode`, `department`, `designer`, `design_code`, `fabric`, `color`, `component`, `date`, `status`, `fab_qty_details`, `mat`) VALUES
(1, '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '2020-12-12', NULL, NULL, NULL),
(2, 'RCKDK', 'PR0026', 'SAREE', '', 'D-119', 'DUPION', '', '', '2020-02-10', NULL, NULL, NULL),
(3, 'yf001', 'PR0026', 'SAREE', '', 'D-119', '', '', '', '2020-02-10', NULL, NULL, NULL),
(4, 'R', 'PR0026', 'SAREE', '', 'D-118', '', '', '', '2020-02-10', NULL, NULL, NULL),
(5, 'asd', 'PR003', 'SAREE', '', 'D-119', '', '', '', '2020-02-23', NULL, NULL, NULL),
(6, 'he', 'PR003', 'SAREE', '', 'D-118', '20', '', '', '2020-02-10', 'DELIVERED', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `cmc_order_p_code`
--

DROP TABLE IF EXISTS `cmc_order_p_code`;
CREATE TABLE IF NOT EXISTS `cmc_order_p_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) DEFAULT NULL,
  `p_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_order_p_code`
--

INSERT INTO `cmc_order_p_code` (`id`, `order_number`, `p_code`) VALUES
(1, 'RCKDK', 'ABC0006'),
(2, 'RCKDK', 'ABC0007'),
(3, 'RCKDK', 'ABC0008'),
(4, 'RCKDK', 'ABC0011'),
(5, 'yf001', 'ABC0006'),
(6, 'yf001', 'ABC0008'),
(7, 'yf001', 'ABC0011'),
(8, 'asd', 'GHABC0007'),
(9, 'asd', 'GHABC0008'),
(10, 'he', 'GHABC0008'),
(11, 'he', 'GHABC0010');

-- --------------------------------------------------------

--
-- Stand-in structure for view `cmc_order_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `cmc_order_view`;
CREATE TABLE IF NOT EXISTS `cmc_order_view` (
`id` int(11)
,`order_number` varchar(45)
,`date` date
,`batchcode` varchar(45)
,`department` varchar(45)
,`designer` varchar(45)
,`design_code` varchar(45)
,`fabric` varchar(45)
,`color` varchar(45)
,`component` varchar(145)
,`status` varchar(45)
,`design_type` varchar(45)
,`design_description` varchar(250)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `cmc_prodcution_time_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `cmc_prodcution_time_view`;
CREATE TABLE IF NOT EXISTS `cmc_prodcution_time_view` (
`id` int(11)
,`order_number` varchar(45)
,`start_date` date
,`start_time` time
,`end_date` date
,`end_time` time
,`total_hour` varchar(45)
,`non_working_hour` varchar(45)
,`effective_time` varchar(45)
,`non_working_remarks` varchar(150)
,`per_hr_rate` varchar(45)
,`total_cost` varchar(45)
,`design_code` varchar(45)
,`batchcode` varchar(45)
,`department` varchar(45)
,`designer` varchar(45)
,`fabric` varchar(45)
,`color` varchar(45)
,`component` varchar(145)
,`date` date
,`fab_qty_details` varchar(45)
,`design_type` varchar(45)
,`machine_type` varchar(45)
,`design_description` varchar(250)
);

-- --------------------------------------------------------

--
-- Table structure for table `cmc_production_time_calc`
--

DROP TABLE IF EXISTS `cmc_production_time_calc`;
CREATE TABLE IF NOT EXISTS `cmc_production_time_calc` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `start_time` time DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `end_time` time DEFAULT NULL,
  `total_hour` varchar(45) DEFAULT NULL,
  `non_working_hour` varchar(45) DEFAULT NULL,
  `effective_time` varchar(45) DEFAULT NULL,
  `non_working_remarks` varchar(150) DEFAULT NULL,
  `per_hr_rate` varchar(45) DEFAULT NULL,
  `total_cost` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_production_time_calc`
--

INSERT INTO `cmc_production_time_calc` (`id`, `order_number`, `start_date`, `start_time`, `end_date`, `end_time`, `total_hour`, `non_working_hour`, `effective_time`, `non_working_remarks`, `per_hr_rate`, `total_cost`) VALUES
(1, 'RCKDK', '2020-02-09', '23:00:00', '2020-02-10', '23:00:00', '24', '', '24', '', '250', '6000');

-- --------------------------------------------------------

--
-- Table structure for table `cmc_production_time_calc_p_code`
--

DROP TABLE IF EXISTS `cmc_production_time_calc_p_code`;
CREATE TABLE IF NOT EXISTS `cmc_production_time_calc_p_code` (
  `int` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) DEFAULT NULL,
  `p_code` varchar(45) DEFAULT NULL,
  `cost` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`int`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cmc_production_time_calc_p_code`
--

INSERT INTO `cmc_production_time_calc_p_code` (`int`, `order_number`, `p_code`, `cost`) VALUES
(1, 'RCKDK', 'ABC0006', '1500'),
(2, 'RCKDK', 'ABC0007', '1500'),
(3, 'RCKDK', 'ABC0008', '1500'),
(4, 'RCKDK', 'ABC0011', '1500');

-- --------------------------------------------------------

--
-- Table structure for table `component_master`
--

DROP TABLE IF EXISTS `component_master`;
CREATE TABLE IF NOT EXISTS `component_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `component` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `component_master`
--

INSERT INTO `component_master` (`id`, `component`) VALUES
(1, 'componet'),
(2, 'coment');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
CREATE TABLE IF NOT EXISTS `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `department_name` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`id`, `department_name`) VALUES
(1, 'LEHENGA'),
(2, 'KURTA');

-- --------------------------------------------------------

--
-- Table structure for table `designer_master`
--

DROP TABLE IF EXISTS `designer_master`;
CREATE TABLE IF NOT EXISTS `designer_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `designer_code` varchar(45) DEFAULT NULL,
  `desinger_name` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `designer_master`
--

INSERT INTO `designer_master` (`id`, `designer_code`, `desinger_name`, `department`) VALUES
(1, 'RJJ', 'RAJ', 'LEHENGA');

-- --------------------------------------------------------

--
-- Table structure for table `dpr_entry`
--

DROP TABLE IF EXISTS `dpr_entry`;
CREATE TABLE IF NOT EXISTS `dpr_entry` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(145) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `gate_number` varchar(45) DEFAULT NULL,
  `karigar_name` varchar(145) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `start1` varchar(45) DEFAULT NULL,
  `end1` varchar(45) DEFAULT NULL,
  `start2` varchar(45) DEFAULT NULL,
  `end2` varchar(45) DEFAULT NULL,
  `start3` varchar(45) DEFAULT NULL,
  `end3` varchar(45) DEFAULT NULL,
  `start4` varchar(45) DEFAULT NULL,
  `end4` varchar(45) DEFAULT NULL,
  `total_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dpr_entry`
--

INSERT INTO `dpr_entry` (`id`, `order_number`, `date`, `gate_number`, `karigar_name`, `unit`, `component`, `start1`, `end1`, `start2`, `end2`, `start3`, `end3`, `start4`, `end4`, `total_time`) VALUES
(1, 'RC/2252/16', '16-09-2019', 'T-12', 'ABH', 'MIRAZ-2', '', '08:00', '12:20', '12:30', '12:45', '13:30', '16:00', '00:00', '00:00', '111:05'),
(2, 'RC/2252/16', '17-09-2019', 'T-12', 'ABH', 'MIRAZ-2', '', '09:00', '12:20', '12:30', '12:45', '13:30', '15:00', '00:00', '00:00', '05:05'),
(3, 'RC/2252/16', '16-09-2019', 'T-12', 'ABH', 'MIRAZ-2', '', '00:00', '00:00', '00:00', '00:00', '16:00', '17:00', '00:00', '00:00', '01:00'),
(4, 'RC/2252/17', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '12:30');

-- --------------------------------------------------------

--
-- Stand-in structure for view `dpr_order_time`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `dpr_order_time`;
CREATE TABLE IF NOT EXISTS `dpr_order_time` (
`order_number` varchar(145)
,`total_time` time
,`unit` varchar(45)
,`date` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `drop_down_master`
--

DROP TABLE IF EXISTS `drop_down_master`;
CREATE TABLE IF NOT EXISTS `drop_down_master` (
  `id` int(11) NOT NULL,
  `master` varchar(45) DEFAULT NULL,
  `master_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `emb_consumption`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `emb_consumption`;
CREATE TABLE IF NOT EXISTS `emb_consumption` (
`emb_id` int(11)
,`emb_code` varchar(45)
,`emb_name` varchar(300)
,`uom` varchar(45)
,`emb_type` varchar(45)
,`time` varchar(45)
,`per_hr_rate` varchar(45)
,`remarks` varchar(45)
,`emb_cost` varchar(45)
,`mat_cost` varchar(45)
,`total_cost` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `emb_consumption_header`
--

DROP TABLE IF EXISTS `emb_consumption_header`;
CREATE TABLE IF NOT EXISTS `emb_consumption_header` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_id` int(11) DEFAULT NULL,
  `time` varchar(45) DEFAULT NULL,
  `per_hr_rate` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `emb_cost` varchar(45) DEFAULT NULL,
  `mat_cost` varchar(45) DEFAULT NULL,
  `total_cost` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_consumption_header`
--

INSERT INTO `emb_consumption_header` (`id`, `emb_id`, `time`, `per_hr_rate`, `remarks`, `emb_cost`, `mat_cost`, `total_cost`) VALUES
(5, 3, '300', '40', 'test', '200', '9105', '9305'),
(7, 4, '200', '60', 'TEST', '200', '81900', '82100'),
(8, 5, NULL, NULL, 'test', NULL, '114.4', NULL),
(9, 7, NULL, NULL, '', NULL, '1144000', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `emb_consumption_line`
--

DROP TABLE IF EXISTS `emb_consumption_line`;
CREATE TABLE IF NOT EXISTS `emb_consumption_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_id` varchar(45) DEFAULT NULL,
  `item_code` varchar(145) DEFAULT NULL,
  `name` varchar(145) DEFAULT NULL,
  `cat` varchar(145) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `qty` double(10,4) DEFAULT NULL,
  `wastage` varchar(45) DEFAULT NULL,
  `final_qty` double(10,4) DEFAULT NULL,
  `amt` double(10,2) DEFAULT NULL,
  `remarks` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_consumption_line`
--

INSERT INTO `emb_consumption_line` (`id`, `emb_id`, `item_code`, `name`, `cat`, `rate`, `unit`, `qty`, `wastage`, `final_qty`, `amt`, `remarks`) VALUES
(17, '3', 'M-10', 'MANISH', 'THREAD', '200', 'REEL', 2.0000, '10', 2.2000, 440.00, ''),
(18, '3', 'AVON-1', 'AVON', 'CUTDANA', '500', 'KG', 1.0000, '10', 1.1000, 550.00, 'test'),
(15, '3', 'M-10', 'MANISH', 'THREAD', '50', 'REEL', 6.0000, '5', 6.3000, 315.00, ''),
(16, '3', 'AVON-1', 'AVON', 'CUTDANA', '5200', 'KG', 1.0000, '50', 1.5000, 7800.00, ''),
(20, '4', 'AVON-1', 'AVON', 'CUTDANA', '5200', 'KG', 15.0000, '5', 15.7500, 81900.00, 'THIS IS TEST'),
(21, '5', 'AVON-1', 'AVON', 'CUTDANA', '5200', 'KG', 0.0200, '10', 0.0200, 114.40, ''),
(22, '7', 'AVON-1', 'AVON', 'CUTDANA', '5200', 'KG', 200.0000, '10', 220.0000, 1144000.00, '');

-- --------------------------------------------------------

--
-- Table structure for table `emb_drop_down`
--

DROP TABLE IF EXISTS `emb_drop_down`;
CREATE TABLE IF NOT EXISTS `emb_drop_down` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uom` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `per_hr_rate` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_drop_down`
--

INSERT INTO `emb_drop_down` (`id`, `uom`, `type`, `per_hr_rate`) VALUES
(1, '1760 SQ INCH', 'HAND', '40'),
(2, 'MTR', NULL, NULL),
(3, 'PCS', 'MACHINE', '60'),
(4, NULL, 'HIHLIGHT', '50');

-- --------------------------------------------------------

--
-- Table structure for table `emb_master`
--

DROP TABLE IF EXISTS `emb_master`;
CREATE TABLE IF NOT EXISTS `emb_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_code` varchar(45) DEFAULT NULL,
  `emb_name` varchar(300) NOT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `na_rate` double(10,2) DEFAULT '0.00',
  `fixed_rate` double(10,2) DEFAULT '0.00',
  `costing_rate` double(10,2) DEFAULT '0.00',
  `emb_type` varchar(45) DEFAULT NULL,
  `mat_rate` double(10,2) DEFAULT '0.00',
  `vendor_allocate` varchar(45) DEFAULT 'NO',
  `cmc_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`emb_name`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_master`
--

INSERT INTO `emb_master` (`id`, `emb_code`, `emb_name`, `uom`, `na_rate`, `fixed_rate`, `costing_rate`, `emb_type`, `mat_rate`, `vendor_allocate`, `cmc_code`) VALUES
(4, 'ABC001/19', 'EMB TEST', 'MTR', 300.00, 400.00, 82100.00, 'MACHINE', NULL, NULL, NULL),
(3, 'ABC001', 'THIS IS TEST', '1760 SQ INCH', 125.00, 600.00, 9305.00, 'HAND', NULL, NULL, NULL),
(5, 'abc001', 'test', '1760 SQ INCH', 500.00, 450.00, 500.00, 'HAND', NULL, NULL, NULL),
(6, 'ABC001', 'TEST1', '1760 SQ INCH', 200.00, 500.00, 300.00, 'HAND', NULL, NULL, NULL),
(7, 'abc', 'test3', '1760 SQ INCH', 500.00, 400.00, 300.00, 'HAND', 1144000.00, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `emb_order`
--

DROP TABLE IF EXISTS `emb_order`;
CREATE TABLE IF NOT EXISTS `emb_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) DEFAULT NULL,
  `fab_qty_detail` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `emb_code` varchar(45) DEFAULT NULL,
  `emb_name` varchar(250) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `unit_type` varchar(45) DEFAULT NULL,
  `remarks` varchar(150) DEFAULT NULL,
  `batchcode` varchar(60) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `number_of_p_code` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_order`
--

INSERT INTO `emb_order` (`id`, `order_number`, `fab_qty_detail`, `uom`, `emb_code`, `emb_name`, `unit`, `unit_type`, `remarks`, `batchcode`, `qty`, `number_of_p_code`, `status`) VALUES
(3, 'RC/2252/16', 'TEST', 'MTR', '25', 'TEST', 'MIRAZ-2', 'IN-HOUSE', 'TEST', 'PR003', '20', NULL, NULL),
(4, 'k/18', NULL, NULL, NULL, NULL, 'MIRAZ-2', 'IN-HOUSE', NULL, NULL, NULL, NULL, NULL),
(5, 'rc/17', NULL, NULL, NULL, NULL, 'MIRAZ-2', 'IN-HOUSE', NULL, NULL, NULL, NULL, NULL),
(6, 'abhi', 'aad', 'ad', 'ad', 'da', 'MIRAZ-2', 'IN-HOUSE', 'dad', 'dad', '1', '0', NULL),
(7, 'abhi', 'aad', 'ad', 'ad', 'da', 'MIRAZ-2', 'IN-HOUSE', 'dad', 'dad', '1', '0', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `emb_order_product_code`
--

DROP TABLE IF EXISTS `emb_order_product_code`;
CREATE TABLE IF NOT EXISTS `emb_order_product_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_order_id` varchar(45) DEFAULT NULL,
  `product_code` varchar(145) DEFAULT NULL,
  `qty` double DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_order_product_code`
--

INSERT INTO `emb_order_product_code` (`id`, `emb_order_id`, `product_code`, `qty`, `uom`) VALUES
(1, '3', 'GHABC0007', 6.66666666666667, 'MTR'),
(2, '3', 'GHABC0008', 6.66666666666667, 'MTR'),
(3, '3', 'GHABC0009', 6.66666666666667, 'MTR');

-- --------------------------------------------------------

--
-- Stand-in structure for view `emb_pending_consumption`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `emb_pending_consumption`;
CREATE TABLE IF NOT EXISTS `emb_pending_consumption` (
`emb_id` int(11)
,`emb_code` varchar(45)
,`emb_name` varchar(300)
,`uom` varchar(45)
,`mat_cost` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `emb_p_code`
--

DROP TABLE IF EXISTS `emb_p_code`;
CREATE TABLE IF NOT EXISTS `emb_p_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` varchar(45) DEFAULT NULL,
  `p_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_p_code`
--

INSERT INTO `emb_p_code` (`id`, `order_id`, `p_code`) VALUES
(1, 'RC//2019-20/0006', 'GHABC0007'),
(2, 'RC//2019-20/0006', 'GHABC0008'),
(3, 'RC//2019-20/0006', 'GHABC0009'),
(4, 'RC//2019-20/0007', 'ABC0006'),
(5, 'RC//2019-20/0007', 'ABC0008'),
(6, 'RC//2019-20/0007', 'ABC0009'),
(7, 'RC/RJJ/2019-20/0008', 'GHABC0006'),
(8, 'RC/RJJ/2019-20/0008', 'GHABC0007'),
(9, 'RC/RJJ/2019-20/0009', 'GHABC0007'),
(10, 'RC/RJJ/2019-20/0009', 'GHABC0008'),
(11, 'RC/RJJ/2019-20/0009', 'GHABC0009'),
(12, 'RC/RJJ/2019-20/0009', 'GHABC0010');

-- --------------------------------------------------------

--
-- Table structure for table `emb_receive`
--

DROP TABLE IF EXISTS `emb_receive`;
CREATE TABLE IF NOT EXISTS `emb_receive` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` varchar(45) DEFAULT NULL,
  `line` varchar(45) DEFAULT NULL,
  `meter` varchar(45) DEFAULT NULL,
  `pieces` varchar(45) DEFAULT NULL,
  `set` varchar(45) DEFAULT NULL,
  `inch_1` varchar(45) DEFAULT NULL,
  `inch_2` varchar(45) DEFAULT NULL,
  `inch_3` varchar(45) DEFAULT NULL,
  `total_job_receive` varchar(45) DEFAULT NULL,
  `Item_qty_receive` varchar(45) DEFAULT NULL,
  `total_receiving_amount` varchar(45) DEFAULT NULL,
  `receive_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_receive`
--

INSERT INTO `emb_receive` (`id`, `order_id`, `line`, `meter`, `pieces`, `set`, `inch_1`, `inch_2`, `inch_3`, `total_job_receive`, `Item_qty_receive`, `total_receiving_amount`, `receive_date`) VALUES
(1, '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '20', '2', NULL, NULL),
(2, '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, '40', '5', NULL, NULL),
(3, '0', '', '', '', '', '', '', '', '', '', '', '11/09/2019'),
(4, '8', '', '30', '5', '', '30', '55', '60', '12750', '', '3259.94318181818', '11/09/2019'),
(5, '8', '', '30', '20', '', '30', '50', '60', '48000', '', '12272.7272727273', '11/09/2019'),
(6, '0', '', '', '', '', '', '', '', '', '', '', '11/09/2019');

-- --------------------------------------------------------

--
-- Stand-in structure for view `emb_receive_comparision`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `emb_receive_comparision`;
CREATE TABLE IF NOT EXISTS `emb_receive_comparision` (
`order_id` varchar(45)
,`total job receive` double
,`total qty receive` double
);

-- --------------------------------------------------------

--
-- Table structure for table `emb_tracker`
--

DROP TABLE IF EXISTS `emb_tracker`;
CREATE TABLE IF NOT EXISTS `emb_tracker` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_number` varchar(45) DEFAULT NULL,
  `order_type` varchar(45) DEFAULT NULL,
  `date` varchar(45) DEFAULT NULL,
  `department` varchar(85) DEFAULT NULL,
  `batchcode` varchar(145) DEFAULT NULL,
  `v_emb_code` varchar(45) DEFAULT NULL,
  `karigar_name` varchar(145) DEFAULT NULL,
  `designer` varchar(145) DEFAULT NULL,
  `design_code` varchar(45) DEFAULT NULL,
  `design_description` varchar(245) DEFAULT NULL,
  `emb_unit` varchar(45) DEFAULT NULL,
  `no_of_p_code` varchar(45) DEFAULT NULL,
  `item` varchar(45) DEFAULT NULL,
  `fabric` varchar(100) DEFAULT NULL,
  `colour` varchar(45) DEFAULT NULL,
  `fab_qty_detail` varchar(100) DEFAULT NULL,
  `meter` varchar(45) DEFAULT NULL,
  `pieces` varchar(45) DEFAULT NULL,
  `set` varchar(45) DEFAULT NULL,
  `line_1` varchar(45) DEFAULT NULL,
  `inch_1` varchar(45) DEFAULT NULL,
  `inch_2` varchar(45) DEFAULT NULL,
  `inch_3` varchar(45) DEFAULT NULL,
  `item_qty` varchar(45) DEFAULT NULL,
  `total_job_issue` varchar(45) DEFAULT NULL,
  `item_pending_qty` varchar(45) DEFAULT NULL,
  `pending_job_issue` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `rate_type` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `lead_time` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_tracker`
--

INSERT INTO `emb_tracker` (`id`, `order_number`, `order_type`, `date`, `department`, `batchcode`, `v_emb_code`, `karigar_name`, `designer`, `design_code`, `design_description`, `emb_unit`, `no_of_p_code`, `item`, `fabric`, `colour`, `fab_qty_detail`, `meter`, `pieces`, `set`, `line_1`, `inch_1`, `inch_2`, `inch_3`, `item_qty`, `total_job_issue`, `item_pending_qty`, `pending_job_issue`, `status`, `rate`, `rate_type`, `amount`, `lead_time`) VALUES
(2, 'RC/RJJ/2019-20/0002', 'OUT-HOUSE', '06/09/2019', 'LEHENGA', 'PR003', '', '', 'RAJ', '1', 'test', '1760 SQ INCH', '3', '', 'DUPION', '', '', '', '2', '', '', '1', '2', '3', '', '9', '', '9', 'OPEN', '450', 'FIXED', '2.30113636363636', NULL),
(3, 'RC/RJJ/2019-20/0003', 'OUT-HOUSE', '07/09/2019', 'LEHENGA', 'PR004', '', '', 'RAJ', '1', 'test', '1760 SQ INCH', '0', '', 'DUPION', 'RED', '12', '', '1', '', '', '20', '25', '30', '', '675', '', '675', 'OPEN', '450', 'FIXED', '172.59', NULL),
(4, 'RC//2019-20/0004', 'OUT-HOUSE', '07/09/2019', 'LEHENGA', 'PR003', '', '', '', '1', 'test', '1760 SQ INCH', '3', '', '', '', '', '', '2', '', '', '20', '30', '40', '2', '2000', '2', '2000', 'OPEN', '450', 'FIXED', '511.36', NULL),
(5, 'RC//2019-20/0005', 'OUT-HOUSE', '07/09/2019', 'LEHENGA', 'PR003', '', '', '', '1', 'test', '1760 SQ INCH', '2', '', '', '', '', '', '2', '', '', '22', '33', '44', '2', '2420', '2', '2420', 'OPEN', '450', 'FIXED', '618.75', NULL),
(6, 'RC//2019-20/0006', 'OUT-HOUSE', '07/09/2019', 'LEHENGA', 'PR003', '', '', '', '1', 'test', '1760 SQ INCH', '3', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'OPEN', '450', 'FIXED', '', NULL),
(7, 'RC//2019-20/0007', 'OUT-HOUSE', '07/09/2019', 'LEHENGA', 'PR250', '', '', '', '', '', '', '3', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', 'OPEN', '', '', '', NULL),
(8, 'RC/RJJ/2019-20/0008', 'IN-HOUSE', '11/09/2019', 'LEHENGA', 'PR003', '', 'MIRAZ-2', 'RAJ', '1', 'test', '1760 SQ INCH', '2', 'componet', 'dupion', '', '', '', '20', '', '', '30', '55', '60', '', '51000', '', '51000', 'OPEN', '450', 'FIXED', '13039.77', NULL),
(9, 'RC/RJJ/2019-20/0009', 'IN-HOUSE', '11/09/2019', 'LEHENGA', 'PR003', '', '', 'RAJ', '1', 'test', '1760 SQ INCH', '0', '', '', '', '', '', '1', '', '', '20', '30', '40', '', '1000', '', '1000', 'OPEN', '450', 'FIXED', '255.68', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `emb_unit`
--

DROP TABLE IF EXISTS `emb_unit`;
CREATE TABLE IF NOT EXISTS `emb_unit` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` varchar(100) DEFAULT NULL,
  `unit_name` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `emb_unit`
--

INSERT INTO `emb_unit` (`id`, `type`, `unit_name`) VALUES
(1, 'IN-HOUSE', 'MIRAZ-2');

-- --------------------------------------------------------

--
-- Table structure for table `emb_vendor`
--

DROP TABLE IF EXISTS `emb_vendor`;
CREATE TABLE IF NOT EXISTS `emb_vendor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_id` varchar(45) DEFAULT NULL,
  `vendor_name` varchar(45) DEFAULT NULL,
  `n_a_rate` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='	';

-- --------------------------------------------------------

--
-- Table structure for table `fabric_grn`
--

DROP TABLE IF EXISTS `fabric_grn`;
CREATE TABLE IF NOT EXISTS `fabric_grn` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `po_number` varchar(45) DEFAULT NULL,
  `vendor` varchar(45) DEFAULT NULL,
  `po_date` varchar(45) DEFAULT NULL,
  `grn_number` varchar(45) DEFAULT NULL,
  `grn_date` date DEFAULT NULL,
  `bill_number` varchar(45) DEFAULT NULL,
  `bill_date` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `fabric_name` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `gst` varchar(45) DEFAULT NULL,
  `hsn` varchar(45) DEFAULT NULL,
  `total_amount` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='			';

-- --------------------------------------------------------

--
-- Table structure for table `fabric_grn_header`
--

DROP TABLE IF EXISTS `fabric_grn_header`;
CREATE TABLE IF NOT EXISTS `fabric_grn_header` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `vendor` varchar(45) DEFAULT NULL,
  `grn_number` varchar(45) DEFAULT NULL,
  `grn_date` date DEFAULT NULL,
  `bill_number` varchar(45) DEFAULT NULL,
  `bill_date` date DEFAULT NULL,
  `freight` varchar(45) DEFAULT NULL,
  `total` double(10,2) DEFAULT NULL,
  `edit_status` varchar(45) DEFAULT NULL,
  `reverse` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 COMMENT='			';

--
-- Dumping data for table `fabric_grn_header`
--

INSERT INTO `fabric_grn_header` (`id`, `vendor`, `grn_number`, `grn_date`, `bill_number`, `bill_date`, `freight`, `total`, `edit_status`, `reverse`) VALUES
(1, 'MK SILK', 'GRN/1/2019-20', '2020-02-17', '', '2020-02-17', '23.00', 17453.00, 'NO', 'REVERSE'),
(2, 'TEST', 'GRN/1/2019-20', '2020-02-19', 'CHEC', '2020-02-18', '500.00', 38120.00, 'NO', 'REVERSE'),
(3, 'TEST', 'GRN/3/2019-20', '2020-02-19', 'abc', '2020-02-11', '200.00', 252200.00, 'NO', NULL),
(4, 'TEST', 'GRN/4/2019-20', '2020-02-19', 'd-200', '2020-02-10', '500.00', 52895.00, 'NO', NULL),
(5, 'TEST', 'GRN/5/2019-20', '2020-02-19', '', '2020-02-19', '', 118650.00, 'NO', NULL),
(6, 'TEST', 'GRN/6/2019-20', '2020-02-20', '', '2020-02-20', '300', 102900.00, 'NO', 'REVERSE');

-- --------------------------------------------------------

--
-- Table structure for table `fabric_grn_line`
--

DROP TABLE IF EXISTS `fabric_grn_line`;
CREATE TABLE IF NOT EXISTS `fabric_grn_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grn_number` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `item_name` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `amount` double(10,2) DEFAULT NULL,
  `gst` varchar(45) DEFAULT NULL,
  `hsn` varchar(45) DEFAULT NULL,
  `gst_amount` double(10,2) DEFAULT NULL,
  `total_amount` double(10,2) DEFAULT NULL,
  `than_status` varchar(45) DEFAULT NULL,
  `po_id` int(11) DEFAULT NULL,
  `order_qty` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_grn_line`
--

INSERT INTO `fabric_grn_line` (`id`, `grn_number`, `item_code`, `item_name`, `rate`, `uom`, `qty`, `amount`, `gst`, `hsn`, `gst_amount`, `total_amount`, `than_status`, `po_id`, `order_qty`) VALUES
(1, 'GRN/1/2019-20', 'D-14', 'DUPION', '800', 'MTR', '20', 16000.00, '5', '5007', 800.00, 16800.00, 'DONE', 2, NULL),
(2, 'GRN/1/2019-20', '80-gm-crepe', 'crepe', '600', 'mtr', '1', 600.00, '5', '5007', 30.00, 630.00, 'DONE', 3, NULL),
(3, 'GRN/1/2019-20', 'D-90', 'DUPION', '565', 'MTR', '20', 11300.00, '5', '5007', 565.00, 11865.00, 'DONE', 4, NULL),
(4, 'GRN/1/2019-20', 'D-155', 'DUPION', '400', 'MTR', '60', 24000.00, '5', '5007', 1200.00, 25200.00, 'DONE', 5, NULL),
(5, 'GRN/3/2019-20', 'D-155', 'DUPION', '400', 'MTR', '600', 240000.00, '5', '5007', 12000.00, 252000.00, 'DONE', 6, NULL),
(6, 'GRN/4/2019-20', 'D-90', 'DUPION', '565', 'MTR', '60', 33900.00, '5', '5007', 1695.00, 35595.00, 'DONE', 13, NULL),
(7, 'GRN/4/2019-20', 'D-14', 'DUPION', '800', 'MTR', '20', 16000.00, '5', '5007', 800.00, 16800.00, 'PENDING', 14, NULL),
(8, 'GRN/5/2019-20', 'D-90', 'DUPION', '565', 'MTR', '200', 113000.00, '5', '5007', 5650.00, 118650.00, 'DONE', 10, NULL),
(9, 'GRN/6/2019-20', '80-gm-crepe', 'crepe', '600', 'mtr', '30', 18000.00, '5', '5007', 900.00, 18900.00, 'PENDING', 15, NULL),
(10, 'GRN/6/2019-20', 'D-14', 'DUPION', '800', 'MTR', '100', 80000.00, '5', '5007', 4000.00, 84000.00, 'DONE', 16, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_issue`
--

DROP TABLE IF EXISTS `fabric_issue`;
CREATE TABLE IF NOT EXISTS `fabric_issue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` varchar(45) DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `fab_qty_details` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `fabric_name` varchar(105) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `qty` double(10,2) DEFAULT '0.00',
  `amount` double(10,2) DEFAULT '0.00',
  `than_number` varchar(45) DEFAULT NULL,
  `issue_date` date DEFAULT NULL,
  `req_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_issue`
--

INSERT INTO `fabric_issue` (`id`, `req_number`, `batchcode`, `department`, `designer`, `fab_qty_details`, `fabric_code`, `fabric_name`, `rate`, `uom`, `qty`, `amount`, `than_number`, `issue_date`, `req_id`) VALUES
(1, 'REQ/2/2019-20', 'PR0026', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 20.00, 8000.00, 'T16', '2020-02-19', 3),
(2, 'REQ/3/2019-20', 'PR0026', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 10.00, 4000.00, 'T16', '2020-02-19', 4),
(3, 'REQ/3/2019-20', 'PR0026', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 10.00, 4000.00, 'T18', '2020-02-19', 4),
(4, 'REQ/4/2019-20', 'PR0026', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 20.00, 8000.00, 'T16', '2020-02-19', 5),
(5, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 5.00, 2000.00, 'T18', '2020-02-19', 6),
(6, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '', 'D-90', 'DUPION', '565', 'MTR', 5.00, 2825.00, 'T22', '2020-02-19', 7),
(7, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '', 'D-90', 'DUPION', '565', 'MTR', 1.00, 565.00, 'T22', '2020-02-19', 7),
(8, 'REQ/6/2019-20', 'PR0026', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 20.00, 8000.00, 'T16', '2020-02-19', 8),
(9, 'REQ/7/2019-20', 'PR0026', 'SAREE', '', '26X1', 'D-14', 'DUPION', '800', 'MTR', 20.00, 16000.00, 'T40', '2020-02-20', 9),
(10, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '', 'D-155', 'DUPION', '400', 'MTR', 15.00, 6000.00, 'T16', '2020-02-20', 6);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_issue_product`
--

DROP TABLE IF EXISTS `fabric_issue_product`;
CREATE TABLE IF NOT EXISTS `fabric_issue_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `p_code` varchar(45) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `amount` double(10,2) DEFAULT NULL,
  `issue_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_issue_product`
--

INSERT INTO `fabric_issue_product` (`id`, `p_code`, `qty`, `amount`, `issue_id`) VALUES
(1, 'ABC0009', 6.67, 2666.67, 4),
(2, 'ABC0010', 6.67, 2666.67, 4),
(3, 'ABC0012', 6.67, 2666.67, 4),
(4, 'GHABC0006', 2.50, 1000.00, 5),
(5, 'GHABC0007', 2.50, 1000.00, 5),
(6, 'GHABC0007', 2.50, 1412.50, 6),
(7, 'GHABC0009', 2.50, 1412.50, 6),
(8, 'GHABC0007', 0.50, 282.50, 7),
(9, 'GHABC0009', 0.50, 282.50, 7),
(10, 'ABC0010', 10.00, 4000.00, 8),
(11, 'ABC0012', 10.00, 4000.00, 8),
(12, 'ABC0007', 5.00, 4000.00, 9),
(13, 'ABC0008', 5.00, 4000.00, 9),
(14, 'ABC0010', 5.00, 4000.00, 9),
(15, 'ABC0012', 5.00, 4000.00, 9),
(16, 'GHABC0006', 5.00, 2000.00, 10),
(17, 'GHABC0007', 5.00, 2000.00, 10),
(18, 'GHABC0009', 5.00, 2000.00, 10);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_po`
--

DROP TABLE IF EXISTS `fabric_po`;
CREATE TABLE IF NOT EXISTS `fabric_po` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `po_number` int(11) DEFAULT NULL,
  `po_date` date DEFAULT NULL,
  `fabric_name` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `vendor` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `order_qty` varchar(45) DEFAULT NULL,
  `dod` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `lap_dip` varchar(45) DEFAULT NULL,
  `remarks` varchar(250) DEFAULT NULL,
  `pending_qty` varchar(45) DEFAULT NULL,
  `gst` varchar(45) DEFAULT NULL,
  `hsn` varchar(45) DEFAULT NULL,
  `total_amt` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=latin1 COMMENT='			';

--
-- Dumping data for table `fabric_po`
--

INSERT INTO `fabric_po` (`id`, `po_number`, `po_date`, `fabric_name`, `fabric_code`, `color`, `vendor`, `rate`, `order_qty`, `dod`, `amount`, `lap_dip`, `remarks`, `pending_qty`, `gst`, `hsn`, `total_amt`, `uom`) VALUES
(12, 4, '2020-02-20', 'DUPION', 'D-155', '', 'TEST', '400', '20', '  -  -', '8000', '', '', '20', '5', '5007', '8400', 'MTR'),
(2, 1, '2020-02-20', 'DUPION', 'D-14', '', 'MK SILK', '800', '20', '2020-02-20', '16000', '', '', '0', '5', '5007', '16800', 'MTR'),
(3, 1, '2020-02-20', 'crepe', '80-gm-crepe', '', 'MK SILK', '600', '1', '2020-02-20', '600', '', '', '0', '5', '5007', '630', 'mtr'),
(4, 2, '2020-02-20', 'DUPION', 'D-90', 'BLACK', 'TEST', '565', '20', '2020-02-20', '11300', '', '', '0', '5', '5007', '11865', 'MTR'),
(5, 2, '2020-02-20', 'DUPION', 'D-155', '', 'TEST', '400', '60', '2020-02-20', '24000', '', '', '0', '5', '5007', '25200', 'MTR'),
(11, 3, '2020-02-20', 'DUPION', 'D-155', '', 'test', '400', '20', '20-20-0220', '8000', '', '', '20', '5', '5007', '8400', 'MTR'),
(10, 3, '2020-02-20', 'DUPION', 'D-90', 'BLACK', 'test', '565', '2000', '20-20-0220', '1130000', '', '', '1800', '5', '5007', '1186500', 'MTR'),
(13, 4, '2020-02-20', 'DUPION', 'D-90', 'BLACK', 'TEST', '565', '60', '  -  -', '33900', '', '', '0', '5', '5007', '35595', 'MTR'),
(14, 4, '2020-02-20', 'DUPION', 'D-14', '', 'TEST', '800', '20', '  -  -', '16000', '', '', '0', '5', '5007', '16800', 'MTR'),
(15, 4, '2020-02-20', 'crepe', '80-gm-crepe', '', 'TEST', '600', '30', '  -  -', '18000', '', '', '0', '5', '5007', '18900', 'mtr'),
(16, 5, '2020-02-20', 'DUPION', 'D-14', '', 'TEST', '800', '500', '20-02-2020', '400000', '', '', '400', '5', '5007', '420000', 'MTR'),
(17, 5, '2020-02-20', 'DUPION', 'D-155', '', 'TEST', '400', '200', '20-02-2020', '80000', '', '', '200', '5', '5007', '84000', 'MTR');

-- --------------------------------------------------------

--
-- Stand-in structure for view `fabric_p_code_wise_issue`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `fabric_p_code_wise_issue`;
CREATE TABLE IF NOT EXISTS `fabric_p_code_wise_issue` (
`req_number` varchar(45)
,`batchcode` varchar(45)
,`department` varchar(45)
,`designer` varchar(45)
,`fab_qty_details` varchar(45)
,`fabric_code` varchar(45)
,`fabric_name` varchar(105)
,`rate` varchar(45)
,`uom` varchar(45)
,`issue_date` date
,`p_code` varchar(45)
,`qty` double(10,2)
,`amount` double(10,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_qc_check_list`
--

DROP TABLE IF EXISTS `fabric_qc_check_list`;
CREATE TABLE IF NOT EXISTS `fabric_qc_check_list` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `check_list` varchar(95) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_qc_check_list`
--

INSERT INTO `fabric_qc_check_list` (`id`, `check_list`) VALUES
(1, 'COLOUR APPROVAL'),
(2, 'DESIGN APPROVAL	'),
(3, 'DYE-UPTAKE'),
(4, 'PRINTABILITY'),
(5, 'GSM'),
(6, 'EPI / PPI'),
(7, 'TENSILE STRENGTH (KG)'),
(8, 'RUBBING FASTNESS (WET)'),
(9, 'RUBBING FASTNESS (DRY)'),
(10, 'VISUAL FABRIC INSPECTION'),
(11, '\"WIDTH\"\" (STANDARD/ACTUAL)\"');

-- --------------------------------------------------------

--
-- Table structure for table `fabric_qc_header`
--

DROP TABLE IF EXISTS `fabric_qc_header`;
CREATE TABLE IF NOT EXISTS `fabric_qc_header` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `than_id` varchar(45) DEFAULT NULL,
  `qc_person_name` varchar(45) DEFAULT NULL,
  `remarks` varchar(150) DEFAULT NULL,
  `for_department` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_qc_header`
--

INSERT INTO `fabric_qc_header` (`id`, `than_id`, `qc_person_name`, `remarks`, `for_department`, `date`, `status`) VALUES
(1, '15', 'chec', '', 'LEHENGA', '2020-02-10', 'APPROVE'),
(2, '17', 'test', '', '', '2020-02-19', 'APPROVE'),
(3, '20', 'TEST', '', '', '2020-02-19', 'APPROVE'),
(4, '16', 'TEST', 'NO OK', '', '2020-02-19', 'REJECT'),
(5, '36', 'ABHI', '', 'KURTA', '2020-02-20', 'APPROVE'),
(6, '19', 'check', '', '', '2020-02-21', 'APPROVE'),
(7, '21', 'da', '', '', '2020-02-21', 'APPROVE'),
(8, '37', 'abc', '', 'L+M+S', '2020-06-12', 'APPROVE'),
(9, '38', 'abc', '', 'L+K+M', '2020-06-12', 'APPROVE');

-- --------------------------------------------------------

--
-- Table structure for table `fabric_qc_line`
--

DROP TABLE IF EXISTS `fabric_qc_line`;
CREATE TABLE IF NOT EXISTS `fabric_qc_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fabric_qc_header_id` int(11) DEFAULT NULL,
  `check_list` varchar(95) DEFAULT NULL,
  `parameter` varchar(45) DEFAULT NULL,
  `remarks` varchar(105) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_qc_line`
--

INSERT INTO `fabric_qc_line` (`id`, `fabric_qc_header_id`, `check_list`, `parameter`, `remarks`) VALUES
(1, 1, 'COLOUR APPROVAL', '', ''),
(2, 1, 'DESIGN APPROVAL	', '', ''),
(3, 1, 'DYE-UPTAKE', '', ''),
(4, 1, 'PRINTABILITY', '', ''),
(5, 1, 'GSM', '', ''),
(6, 1, 'EPI / PPI', '', ''),
(7, 1, 'TENSILE STRENGTH (KG)', '', ''),
(8, 1, 'RUBBING FASTNESS (WET)', '', ''),
(9, 1, 'RUBBING FASTNESS (DRY)', '', ''),
(10, 1, 'VISUAL FABRIC INSPECTION', '', ''),
(11, 1, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(12, 2, 'COLOUR APPROVAL', '', ''),
(13, 2, 'DESIGN APPROVAL	', '', ''),
(14, 2, 'DYE-UPTAKE', '', ''),
(15, 2, 'PRINTABILITY', '', ''),
(16, 2, 'GSM', '', ''),
(17, 2, 'EPI / PPI', '', ''),
(18, 2, 'TENSILE STRENGTH (KG)', '', ''),
(19, 2, 'RUBBING FASTNESS (WET)', '', ''),
(20, 2, 'RUBBING FASTNESS (DRY)', '', ''),
(21, 2, 'VISUAL FABRIC INSPECTION', '', ''),
(22, 2, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(23, 3, 'COLOUR APPROVAL', '', ''),
(24, 3, 'DESIGN APPROVAL	', '', ''),
(25, 3, 'DYE-UPTAKE', '', ''),
(26, 3, 'PRINTABILITY', '', ''),
(27, 3, 'GSM', '', ''),
(28, 3, 'EPI / PPI', '', ''),
(29, 3, 'TENSILE STRENGTH (KG)', '', ''),
(30, 3, 'RUBBING FASTNESS (WET)', '', ''),
(31, 3, 'RUBBING FASTNESS (DRY)', '', ''),
(32, 3, 'VISUAL FABRIC INSPECTION', '', ''),
(33, 3, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(34, 4, 'COLOUR APPROVAL', '', ''),
(35, 4, 'DESIGN APPROVAL	', '', ''),
(36, 4, 'DYE-UPTAKE', '', ''),
(37, 4, 'PRINTABILITY', '', ''),
(38, 4, 'GSM', '', ''),
(39, 4, 'EPI / PPI', '', ''),
(40, 4, 'TENSILE STRENGTH (KG)', '', ''),
(41, 4, 'RUBBING FASTNESS (WET)', '', ''),
(42, 4, 'RUBBING FASTNESS (DRY)', '', ''),
(43, 4, 'VISUAL FABRIC INSPECTION', '', ''),
(44, 4, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(45, 5, 'COLOUR APPROVAL', 'OK', ''),
(46, 5, 'DESIGN APPROVAL	', 'OK', ''),
(47, 5, 'DYE-UPTAKE', 'OK', ''),
(48, 5, 'PRINTABILITY', 'OK', ''),
(49, 5, 'GSM', 'OK', ''),
(50, 5, 'EPI / PPI', 'OK', ''),
(51, 5, 'TENSILE STRENGTH (KG)', 'OK', ''),
(52, 5, 'RUBBING FASTNESS (WET)', 'OK', ''),
(53, 5, 'RUBBING FASTNESS (DRY)', 'OK', ''),
(54, 5, 'VISUAL FABRIC INSPECTION', 'OK', ''),
(55, 5, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', 'OK', ''),
(56, 6, 'COLOUR APPROVAL', '', ''),
(57, 6, 'DESIGN APPROVAL	', '', ''),
(58, 6, 'DYE-UPTAKE', '', ''),
(59, 6, 'PRINTABILITY', '', ''),
(60, 6, 'GSM', '', ''),
(61, 6, 'EPI / PPI', '', ''),
(62, 6, 'TENSILE STRENGTH (KG)', '', ''),
(63, 6, 'RUBBING FASTNESS (WET)', '', ''),
(64, 6, 'RUBBING FASTNESS (DRY)', '', ''),
(65, 6, 'VISUAL FABRIC INSPECTION', '', ''),
(66, 6, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(67, 7, 'COLOUR APPROVAL', '', ''),
(68, 7, 'DESIGN APPROVAL	', '', ''),
(69, 7, 'DYE-UPTAKE', '', ''),
(70, 7, 'PRINTABILITY', '', ''),
(71, 7, 'GSM', '', ''),
(72, 7, 'EPI / PPI', '', ''),
(73, 7, 'TENSILE STRENGTH (KG)', '', ''),
(74, 7, 'RUBBING FASTNESS (WET)', '', ''),
(75, 7, 'RUBBING FASTNESS (DRY)', '', ''),
(76, 7, 'VISUAL FABRIC INSPECTION', '', ''),
(77, 7, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(78, 8, 'COLOUR APPROVAL', '', ''),
(79, 8, 'DESIGN APPROVAL	', '', ''),
(80, 8, 'DYE-UPTAKE', '', ''),
(81, 8, 'PRINTABILITY', '', ''),
(82, 8, 'GSM', '', ''),
(83, 8, 'EPI / PPI', '', ''),
(84, 8, 'TENSILE STRENGTH (KG)', '', ''),
(85, 8, 'RUBBING FASTNESS (WET)', '', ''),
(86, 8, 'RUBBING FASTNESS (DRY)', '', ''),
(87, 8, 'VISUAL FABRIC INSPECTION', '', ''),
(88, 8, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', ''),
(89, 9, 'COLOUR APPROVAL', '', ''),
(90, 9, 'DESIGN APPROVAL	', '', ''),
(91, 9, 'DYE-UPTAKE', '', ''),
(92, 9, 'PRINTABILITY', '', ''),
(93, 9, 'GSM', '', ''),
(94, 9, 'EPI / PPI', '', ''),
(95, 9, 'TENSILE STRENGTH (KG)', '', ''),
(96, 9, 'RUBBING FASTNESS (WET)', '', ''),
(97, 9, 'RUBBING FASTNESS (DRY)', '', ''),
(98, 9, 'VISUAL FABRIC INSPECTION', '', ''),
(99, 9, '\"WIDTH\"\" (STANDARD/ACTUAL)\"', '', '');

-- --------------------------------------------------------

--
-- Stand-in structure for view `fabric_request`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `fabric_request`;
CREATE TABLE IF NOT EXISTS `fabric_request` (
);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_requisition`
--

DROP TABLE IF EXISTS `fabric_requisition`;
CREATE TABLE IF NOT EXISTS `fabric_requisition` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` varchar(45) DEFAULT NULL,
  `batch_code` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `desinger` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `fabric_name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `fab_qty_details` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `pending_qty` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_requisition`
--

INSERT INTO `fabric_requisition` (`id`, `req_number`, `batch_code`, `department`, `desinger`, `date`, `fabric_code`, `fabric_name`, `qty`, `uom`, `fab_qty_details`, `remarks`, `pending_qty`) VALUES
(1, 'REQ/1/2019-20', 'PR0026', 'SAREE', '', '2020-02-18', 'D-14', 'DUPION', '2', 'MTR', '', '', '2'),
(2, 'REQ/1/2019-20', 'PR0026', 'SAREE', '', '2020-02-18', '80-gm-crepe', 'crepe', '1', 'mtr', '', '', '1'),
(3, 'REQ/2/2019-20', 'PR0026', 'SAREE', '', '2020-02-19', 'D-155', 'DUPION', '20', 'MTR', '', '', '0'),
(4, 'REQ/3/2019-20', 'PR0026', 'SAREE', '', '2020-02-19', 'D-155', 'DUPION', '20', 'MTR', '', '', '0'),
(5, 'REQ/4/2019-20', 'PR0026', 'SAREE', '', '2020-02-19', 'D-155', 'DUPION', '20', 'MTR', '', '', '0'),
(6, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '2020-02-19', 'D-155', 'DUPION', '20', 'MTR', '', '', '0'),
(7, 'REQ/5/2019-20', 'PR003', 'SAREE', '', '2020-02-19', 'D-90', 'DUPION', '30', 'MTR', '', '', '24'),
(8, 'REQ/6/2019-20', 'PR0026', 'SAREE', '', '2020-02-19', 'D-155', 'DUPION', '20', 'MTR', '', '', '0'),
(9, 'REQ/7/2019-20', 'PR0026', 'SAREE', '', '2020-02-20', 'D-14', 'DUPION', '20', 'MTR', '26X1', '', '0'),
(10, 'REQ/8/2019-20', 'PR0026', 'SAREE', '', '2020-06-14', 'D-14', 'DUPION', '50', 'MTR', '', '', '50'),
(11, 'REQ/8/2019-20', 'PR0026', 'SAREE', '', '2020-06-14', '80-gm-crepe', 'crepe', '10', 'mtr', '', '', '10');

-- --------------------------------------------------------

--
-- Table structure for table `fabric_requisition_product`
--

DROP TABLE IF EXISTS `fabric_requisition_product`;
CREATE TABLE IF NOT EXISTS `fabric_requisition_product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `request_id` varchar(45) DEFAULT NULL,
  `product_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_requisition_product`
--

INSERT INTO `fabric_requisition_product` (`id`, `request_id`, `product_code`) VALUES
(1, 'REQ/1/2019-20', 'ABC0010'),
(2, 'REQ/1/2019-20', 'ABC0011'),
(3, 'REQ/2/2019-20', 'ABC0007'),
(4, 'REQ/2/2019-20', 'ABC0009'),
(5, 'REQ/2/2019-20', 'ABC0011'),
(6, 'REQ/3/2019-20', 'ABC0010'),
(7, 'REQ/3/2019-20', 'ABC0011'),
(8, 'REQ/4/2019-20', 'ABC0009'),
(9, 'REQ/4/2019-20', 'ABC0010'),
(10, 'REQ/4/2019-20', 'ABC0012'),
(11, 'REQ/5/2019-20', 'GHABC0006'),
(12, 'REQ/5/2019-20', 'GHABC0007'),
(13, 'REQ/5/2019-20', 'GHABC0009'),
(14, 'REQ/6/2019-20', 'ABC0010'),
(15, 'REQ/6/2019-20', 'ABC0011'),
(16, 'REQ/6/2019-20', 'ABC0012'),
(17, 'REQ/7/2019-20', 'ABC0007'),
(18, 'REQ/7/2019-20', 'ABC0008'),
(19, 'REQ/7/2019-20', 'ABC0010'),
(20, 'REQ/7/2019-20', 'ABC0012'),
(21, 'REQ/8/2019-20', 'ABC0009'),
(22, 'REQ/8/2019-20', 'ABC0011'),
(23, 'REQ/8/2019-20', 'ABC0012');

-- --------------------------------------------------------

--
-- Stand-in structure for view `fabric_stock_summery`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `fabric_stock_summery`;
CREATE TABLE IF NOT EXISTS `fabric_stock_summery` (
`fabric_code` varchar(45)
,`sent_to_qc` double
,`APPROVE` double
,`RECEIVE` double
,`CUTTING` double
,`RETURN` double
,`REJECT` double
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `fabric_than`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `fabric_than`;
CREATE TABLE IF NOT EXISTS `fabric_than` (
`id` int(11)
,`grn_number` varchar(45)
,`item_code` varchar(45)
,`qty` varchar(45)
,`than_status` varchar(45)
,`vendor` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_than_details`
--

DROP TABLE IF EXISTS `fabric_than_details`;
CREATE TABLE IF NOT EXISTS `fabric_than_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grn_line_number` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `than_number` varchar(45) DEFAULT NULL,
  `than_qty` double(10,2) DEFAULT NULL,
  `grn_number` varchar(45) DEFAULT NULL,
  `pending_than_qty` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `erp_than_number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fabric_than_details`
--

INSERT INTO `fabric_than_details` (`id`, `grn_line_number`, `fabric_code`, `than_number`, `than_qty`, `grn_number`, `pending_than_qty`, `status`, `erp_than_number`) VALUES
(1, '1', 'D-14', 'T3', 20.00, 'GRN/1/2019-20', '20', 'RECEIVE', NULL),
(2, '2', '80-gm-crepe', 'T3', 1.00, 'GRN/1/2019-20', '1', 'RECEIVE', NULL),
(3, '3', 'D-90', 'T3', 10.00, 'GRN/1/2019-20', '10', 'RECEIVE', NULL),
(4, '3', 'D-90', 'T4', 10.00, 'GRN/1/2019-20', '10', 'SENT TO QC', NULL),
(5, '4', 'D-155', 'T5', 20.00, 'GRN/1/2019-20', '20', 'RECEIVE', NULL),
(6, '4', 'D-155', 'T6', 4.00, 'GRN/1/2019-20', '4', 'RECEIVE', NULL),
(7, '4', 'D-155', 'T7', 20.00, 'GRN/1/2019-20', '20', 'RECEIVE', NULL),
(8, '4', 'D-155', 'T8', 10.00, 'GRN/1/2019-20', '10', 'RECEIVE', NULL),
(9, '4', 'D-155', 'T9', 6.00, 'GRN/1/2019-20', '6', 'RECEIVE', NULL),
(10, '5', 'D-155', 'T11', 20.00, 'GRN/3/2019-20', '20', 'RECEIVE', NULL),
(11, '5', 'D-155', 'T12', 200.00, 'GRN/3/2019-20', '200', 'RECEIVE', NULL),
(12, '5', 'D-155', 'T13', 30.00, 'GRN/3/2019-20', '30', 'RECEIVE', NULL),
(13, '5', 'D-155', 'T14', 150.00, 'GRN/3/2019-20', '150', 'RECEIVE', NULL),
(14, '5', 'D-155', 'T15', 20.00, 'GRN/3/2019-20', '20', 'RECEIVE', NULL),
(15, '5', 'D-155', 'T16', 100.00, 'GRN/3/2019-20', '15', 'CUTTING', NULL),
(16, '5', 'D-155', 'T17', 40.00, 'GRN/3/2019-20', '40', 'REJECT', NULL),
(17, '5', 'D-155', 'T18', 15.00, 'GRN/3/2019-20', '0', 'CUTTING', NULL),
(18, '5', 'D-155', 'T19', 15.00, 'GRN/3/2019-20', '15', 'SENT TO QC', NULL),
(19, '5', 'D-155', 'T20', 10.00, 'GRN/3/2019-20', '10', 'CUTTING', NULL),
(20, '6', 'D-90', 'T22', 6.00, 'GRN/4/2019-20', '0', 'CUTTING', NULL),
(21, '6', 'D-90', 'T23', 6.00, 'GRN/4/2019-20', '6', 'CUTTING', NULL),
(22, '6', 'D-90', 'T24', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(23, '6', 'D-90', 'T25', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(24, '6', 'D-90', 'T26', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(25, '6', 'D-90', 'T27', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(26, '6', 'D-90', 'T28', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(27, '6', 'D-90', 'T29', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(28, '6', 'D-90', 'T30', 6.00, 'GRN/4/2019-20', '6', 'SENT TO QC', NULL),
(29, '6', 'D-90', 'T31', 6.00, 'GRN/4/2019-20', '6', 'RECEIVE', NULL),
(30, '8', 'D-90', 'T33', 10.00, 'GRN/5/2019-20', '10', 'RECEIVE', NULL),
(31, '8', 'D-90', 'T34', 15.00, 'GRN/5/2019-20', '15', 'RECEIVE', NULL),
(32, '8', 'D-90', 'T35', 100.00, 'GRN/5/2019-20', '100', 'RECEIVE', NULL),
(33, '8', 'D-90', 'T36', 20.00, 'GRN/5/2019-20', '20', 'RECEIVE', NULL),
(34, '8', 'D-90', 'T37', 50.00, 'GRN/5/2019-20', '50', 'RECEIVE', NULL),
(35, '8', 'D-90', 'T38', 5.00, 'GRN/5/2019-20', '5', 'RECEIVE', NULL),
(36, '10', 'D-14', 'T40', 20.00, 'GRN/6/2019-20', '0', 'CUTTING', NULL),
(37, '10', 'D-14', 'T41', 20.00, 'GRN/6/2019-20', '20', 'CUTTING', NULL),
(38, '10', 'D-14', 'T42', 20.00, 'GRN/6/2019-20', '20', 'CUTTING', NULL),
(39, '10', 'D-14', 'T43', 20.00, 'GRN/6/2019-20', '20', 'RECEIVE', NULL),
(40, '10', 'D-14', 'T44', 20.00, 'GRN/6/2019-20', '20', 'RECEIVE', NULL);

-- --------------------------------------------------------

--
-- Stand-in structure for view `fabric_than_details_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `fabric_than_details_view`;
CREATE TABLE IF NOT EXISTS `fabric_than_details_view` (
`id` int(11)
,`fabric_code` varchar(45)
,`than_number` varchar(45)
,`than_qty` double(10,2)
,`status` varchar(45)
,`grn_number` varchar(45)
,`vendor` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `fabric_than_issue`
--

DROP TABLE IF EXISTS `fabric_than_issue`;
CREATE TABLE IF NOT EXISTS `fabric_than_issue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `issue_id` varchar(45) DEFAULT NULL,
  `than_number` varchar(45) DEFAULT NULL,
  `than_issue_qty` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Stand-in structure for view `grn_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `grn_view`;
CREATE TABLE IF NOT EXISTS `grn_view` (
`item_code` varchar(45)
,`name` varchar(45)
,`qty` varchar(45)
,`unit` varchar(45)
,`total` varchar(45)
,`rate` varchar(45)
,`amount` varchar(45)
,`grn_number` double
,`vendor` varchar(45)
,`bill_number` varchar(45)
,`bill_date` varchar(45)
,`grn_date` date
,`po_reff` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE IF NOT EXISTS `item` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `item_code` varchar(45) NOT NULL,
  `item_name` varchar(150) DEFAULT NULL,
  `item_catagory` varchar(100) DEFAULT NULL,
  `uom` varchar(20) DEFAULT NULL,
  `gst` varchar(20) DEFAULT NULL,
  `hsn` int(11) DEFAULT NULL,
  `unit_price` double(14,2) DEFAULT NULL,
  `last_purchase_price` double(14,2) DEFAULT NULL,
  `current_valuation` double(14,2) DEFAULT NULL,
  `inventory` double(14,3) DEFAULT NULL,
  `item_type` varchar(45) DEFAULT NULL,
  `color` varchar(85) DEFAULT NULL,
  `width` varchar(45) DEFAULT NULL,
  `purchase_uom` varchar(45) DEFAULT NULL,
  `purchase_rate` double(10,2) DEFAULT NULL,
  `type_of_item` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`,`item_code`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`ID`, `item_code`, `item_name`, `item_catagory`, `uom`, `gst`, `hsn`, `unit_price`, `last_purchase_price`, `current_valuation`, `inventory`, `item_type`, `color`, `width`, `purchase_uom`, `purchase_rate`, `type_of_item`) VALUES
(1, 'D-14', 'DUPION', 'PREDYED DUPION', 'MTR', '5', 5007, 800.00, 800.00, NULL, 120.000, 'FABRIC', NULL, NULL, NULL, NULL, NULL),
(5, '80-gm-crepe', 'crepe', 'crepe', 'mtr', '5', 5007, 600.00, 600.00, NULL, 31.000, 'FABRIC', NULL, NULL, NULL, NULL, NULL),
(3, 'D-155', 'DUPION', 'DUP', 'MTR', '5', 5007, 400.00, 400.00, NULL, 558.000, 'FABRIC', NULL, NULL, NULL, NULL, NULL),
(6, 'TESTED-TIKKI-5', 'TESTED TIKKI', 'TIKKI', 'KG', '5%', 5007, 500.00, 500.00, NULL, 17.000, 'NON-FABRIC', NULL, NULL, NULL, NULL, NULL),
(7, 'AVON-1', 'AVON', 'CUTDANA', 'KG', '5', 5007, 5200.00, 5200.00, NULL, 44.500, 'NON-FABRIC', NULL, NULL, NULL, NULL, NULL),
(8, 'STONE-NO-5', 'LOCAL STONE', 'STONE', 'PCS', '18', 20087, 2.00, 2.00, NULL, 11.000, 'NON-FABRIC', NULL, NULL, NULL, NULL, NULL),
(10, 'M-10', 'MANISH', 'THREAD', 'REEL', '12', 6053, 17.00, 200.00, NULL, 40.000, 'NON-FABRIC', NULL, NULL, NULL, NULL, NULL),
(11, 'ab', 'a', 'a', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'ACC', NULL, NULL, NULL, NULL, NULL),
(12, 'acc-1', 'leather', 'buff', 'mtr/sq', '18', 9007, 600.00, 600.00, NULL, 19.000, 'ACC', 'red', NULL, NULL, NULL, NULL),
(13, 'box-frame', 'consum', 'frame', 'pcs', '18', 5007, 125.00, 125.00, NULL, 182.000, 'ACC', 'black', NULL, NULL, NULL, NULL),
(14, 'TOTLAJ', 'CHECK', NULL, 'MTR', '18', 5007, 12.00, 300.00, NULL, NULL, 'S-FABRIC', NULL, NULL, NULL, NULL, NULL),
(15, 'AC', 'TTT', NULL, 'PCS', '5', 5007, NULL, 300.00, NULL, NULL, 'S-FABRIC', NULL, NULL, NULL, NULL, NULL),
(16, 'D-90', 'DUPION', 'WHITE', 'MTR', '5', 5007, 565.00, 565.00, NULL, 274.000, 'FABRIC', 'BLACK', '55', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `item_serial`
--

DROP TABLE IF EXISTS `item_serial`;
CREATE TABLE IF NOT EXISTS `item_serial` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item_code` varchar(45) DEFAULT NULL,
  `item_serial` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `it_item`
--

DROP TABLE IF EXISTS `it_item`;
CREATE TABLE IF NOT EXISTS `it_item` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `serial_number` varchar(145) NOT NULL,
  `catagory` varchar(145) DEFAULT NULL,
  `brand` varchar(145) DEFAULT NULL,
  `purchase_date` date DEFAULT NULL,
  `warrenty_valid` date DEFAULT NULL,
  `vendor` varchar(145) DEFAULT NULL,
  `bill_number` varchar(45) DEFAULT NULL,
  `assign_user` varchar(45) DEFAULT 'IT',
  PRIMARY KEY (`id`,`serial_number`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `it_item`
--

INSERT INTO `it_item` (`id`, `serial_number`, `catagory`, `brand`, `purchase_date`, `warrenty_valid`, `vendor`, `bill_number`, `assign_user`) VALUES
(8, '55651', 'Acer Laptop', 'ad', '2020-06-12', '2020-06-12', 'afad', 'aj', 'IT'),
(7, 'OPTOCAL', 'Mouse', 'adjba', '2020-06-12', '2020-06-12', 'adc', 'ad', 'raj'),
(5, '55125ABC', 'Acer Laptop', 'Acer', '2020-06-12', '2020-06-12', 'abhi', 'abc123', 'sunny'),
(9, 'MOUSE', 'Mouse', 'abce', '2020-06-12', '2020-06-12', 'kris', '123', 'raj'),
(10, 'MOUSE1', 'Mouse', 'abc', '2020-06-12', '2020-06-12', 'abc', 'abc123', 'sunny');

-- --------------------------------------------------------

--
-- Table structure for table `it_item_catagory`
--

DROP TABLE IF EXISTS `it_item_catagory`;
CREATE TABLE IF NOT EXISTS `it_item_catagory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Catagory` varchar(145) DEFAULT NULL,
  `it_stock` double(5,2) DEFAULT '0.00',
  `total_stock` double(5,2) DEFAULT '0.00',
  `user_stock` double(5,2) DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `it_item_catagory`
--

INSERT INTO `it_item_catagory` (`id`, `Catagory`, `it_stock`, `total_stock`, `user_stock`) VALUES
(1, 'Acer Laptop', 1.00, 2.00, 1.00),
(5, 'Wire', 0.00, 0.00, 0.00),
(3, 'Mouse', 0.00, 3.00, 3.00),
(4, 'Keyboard', 0.00, 0.00, 0.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `it_item_receive`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `it_item_receive`;
CREATE TABLE IF NOT EXISTS `it_item_receive` (
);

-- --------------------------------------------------------

--
-- Table structure for table `it_user`
--

DROP TABLE IF EXISTS `it_user`;
CREATE TABLE IF NOT EXISTS `it_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(145) DEFAULT NULL,
  `user_name` varchar(145) DEFAULT NULL,
  `department` varchar(145) DEFAULT NULL,
  `ext_number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `it_user`
--

INSERT INTO `it_user` (`id`, `user_id`, `user_name`, `department`, `ext_number`) VALUES
(1, 'abhishek', 'Abhishek Shaw', 'LEHENGA', '223'),
(3, 'sunny', 'sunny shaw', 'LEHENGA', '556'),
(4, 'raj', 'shaw', 'KURTA', '225');

-- --------------------------------------------------------

--
-- Table structure for table `it_user_transaction`
--

DROP TABLE IF EXISTS `it_user_transaction`;
CREATE TABLE IF NOT EXISTS `it_user_transaction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(145) DEFAULT NULL,
  `serial_number` varchar(145) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `issue_date` varchar(45) DEFAULT NULL,
  `submit_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `karigar_master`
--

DROP TABLE IF EXISTS `karigar_master`;
CREATE TABLE IF NOT EXISTS `karigar_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `gate_number` varchar(45) DEFAULT NULL,
  `name` varchar(145) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `karigar_master`
--

INSERT INTO `karigar_master` (`id`, `gate_number`, `name`, `unit`) VALUES
(1, 'T-12', 'ABH', 'MIRAZ-2'),
(2, '1', 'ab', 'MIRAZ-2'),
(3, 't-3', 'ad', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_d_return`
--

DROP TABLE IF EXISTS `non_fabric_d_return`;
CREATE TABLE IF NOT EXISTS `non_fabric_d_return` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `remarks` varchar(145) DEFAULT NULL,
  `return_from` varchar(45) DEFAULT NULL,
  `non_fabric_code` varchar(45) DEFAULT NULL,
  `categories` varchar(45) DEFAULT NULL,
  `sub_categories` varchar(145) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_grn_header`
--

DROP TABLE IF EXISTS `non_fabric_grn_header`;
CREATE TABLE IF NOT EXISTS `non_fabric_grn_header` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grn_number` double DEFAULT NULL,
  `vendor` varchar(45) DEFAULT NULL,
  `total_amount` varchar(45) DEFAULT NULL,
  `freidge` varchar(45) DEFAULT NULL,
  `bill_number` varchar(45) DEFAULT NULL,
  `bill_date` varchar(45) DEFAULT NULL,
  `grn_date` date DEFAULT NULL,
  `gst_amount` varchar(45) DEFAULT NULL,
  `po_reff` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_grn_header`
--

INSERT INTO `non_fabric_grn_header` (`id`, `grn_number`, `vendor`, `total_amount`, `freidge`, `bill_number`, `bill_date`, `grn_date`, `gst_amount`, `po_reff`) VALUES
(10, 3, 'RAJ', '275653.32', NULL, 'ABC', '17/10/2019', '2019-11-11', NULL, '123'),
(7, 1, 'abhishek', '2625', NULL, '', '  /  /', '2020-05-05', NULL, ''),
(8, 2, 'abhishek', '1278.48', NULL, '', '  /  /', '2019-11-11', NULL, ''),
(11, 4, 'abhishek', '380.8', NULL, '123', '13/11/2019', '2019-11-11', NULL, 'ABC001');

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_grn_line`
--

DROP TABLE IF EXISTS `non_fabric_grn_line`;
CREATE TABLE IF NOT EXISTS `non_fabric_grn_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `grn_number` double DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `sub_categories` varchar(145) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `gst` varchar(45) DEFAULT NULL,
  `hsn` varchar(45) DEFAULT NULL,
  `total` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_grn_line`
--

INSERT INTO `non_fabric_grn_line` (`id`, `grn_number`, `item_code`, `name`, `sub_categories`, `unit`, `qty`, `rate`, `gst`, `hsn`, `total`, `amount`) VALUES
(2, 1, 'TESTED-TIKKI-5', 'TESTED TIKKI', NULL, 'KG', '5', '500', '5', '5007', '2625', '2500'),
(21, 2, 'M-10', 'MANISH', 'THREAD', 'REEL', '12', '17', '12', '6053', '228.48', '204'),
(27, 3, 'STONE-NO-5', 'LOCAL STONE', '', 'PCS', '12', '2', '18', '20087', '28.32', '24'),
(26, 3, 'TESTED-TIKKI-5', 'TESTED TIKKI', '', 'KG', '5', '500', '5', '5007', '2625', '2500'),
(25, 4, 'M-10', 'MANISH', 'THREAD', 'REEL', '20', '17', '12', '6053', '380.8', '340'),
(22, 2, 'TESTED-TIKKI-5', 'TESTED TIKKI', 'TIKKI', 'KG', '2', '500', '5', '5007', '1050', '1000'),
(28, 3, 'AVON-1', 'AVON', '', 'KG', '50', '5200', '5', '5007', '273000', '260000');

-- --------------------------------------------------------

--
-- Stand-in structure for view `non_fabric_issue_cat`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `non_fabric_issue_cat`;
CREATE TABLE IF NOT EXISTS `non_fabric_issue_cat` (
`issue_date` date
,`item_code` varchar(45)
,`name` varchar(45)
,`item_catagory` varchar(100)
,`amount` varchar(45)
,`qty` varchar(45)
,`unit` varchar(45)
);

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_item_issue`
--

DROP TABLE IF EXISTS `non_fabric_item_issue`;
CREATE TABLE IF NOT EXISTS `non_fabric_item_issue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` varchar(45) DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `for_vendor` varchar(45) DEFAULT NULL,
  `issue_date` date DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  `item` varchar(95) DEFAULT NULL,
  `issue_date1` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_item_issue`
--

INSERT INTO `non_fabric_item_issue` (`id`, `req_number`, `batchcode`, `department`, `designer`, `item_code`, `name`, `qty`, `rate`, `amount`, `unit`, `for_vendor`, `issue_date`, `p_code`, `item`, `issue_date1`) VALUES
(1, '3', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '6', '500', '3000', 'KG', 'ABC', '2019-10-15', NULL, NULL, NULL),
(2, '3', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '3', '500', '1500', 'KG', '', '2019-10-15', NULL, NULL, NULL),
(3, '4', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '4', '500', '2000', 'KG', '', '2019-10-15', NULL, NULL, NULL),
(4, '6', 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '.5', '5200', '2600', 'KG', '', '2019-10-15', NULL, NULL, NULL),
(5, '7', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '10', '500', '5000', 'KG', '', '2019-10-15', NULL, NULL, NULL),
(6, '7', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '5', '500', '2500', 'KG', '', '2019-10-15', NULL, NULL, NULL),
(7, '7', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '1', '500', '500', 'KG', '', '2019-10-15', '', '', '2020-01-01'),
(8, '7', 'PR0026', 'SAREE', '', 'M-10', 'MANISH', '20', '17', '340', 'REEL', '', '2019-10-15', NULL, NULL, '2019-11-13'),
(9, '6', 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '1', '5200', '5200', 'KG', '', '2019-10-15', '', '', '2019-11-15'),
(10, '6', 'PR003', 'SAREE', '', 'STONE-NO-5', 'LOCAL STONE', '1', '2', '2', 'PCS', '', '2019-10-15', '', '', NULL),
(11, '14', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '2', '500', '1000', 'KG', '', '2019-10-15', '', 'coment', NULL),
(12, '5', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '0', '500', '0', 'KG', '', '2019-10-15', '', '', NULL),
(13, '14', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '1', '500', '500', 'KG', '', '2020-02-11', '', 'coment', NULL),
(14, '14', 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '2', '500', '1000', 'KG', '', '2020-02-11', '', 'coment', NULL),
(15, '17', 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '2', '5200', '10400', 'KG', 'abc', '2020-06-05', NULL, '', NULL),
(16, '16', 'PR003', 'SAREE', '', 'aVON-1', 'AVON', '1', '5200', '5200', 'KG', '', '2020-06-05', NULL, '', NULL),
(17, '16', 'PR003', 'SAREE', '', 'aVON-1', 'AVON', '.5', '5200', '2600', 'KG', '', '2020-06-05', NULL, '', NULL),
(18, '16', 'PR003', 'SAREE', '', 'aVON-1', 'AVON', '0.5', '5200', '2600', 'KG', '', '2020-06-05', NULL, '', NULL),
(19, NULL, NULL, 'lehenga', NULL, NULL, NULL, NULL, NULL, '2600', NULL, NULL, '2020-06-05', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_item_issue_p_code`
--

DROP TABLE IF EXISTS `non_fabric_item_issue_p_code`;
CREATE TABLE IF NOT EXISTS `non_fabric_item_issue_p_code` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `p_code` varchar(45) DEFAULT NULL,
  `issue_id` varchar(45) DEFAULT NULL,
  `qty` double(10,2) DEFAULT NULL,
  `amount` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_item_issue_p_code`
--

INSERT INTO `non_fabric_item_issue_p_code` (`id`, `p_code`, `issue_id`, `qty`, `amount`) VALUES
(1, 'GHABC0006', '15', 0.67, 3466.67),
(2, 'GHABC0008', '15', 0.67, 3466.67),
(3, 'GHABC0009', '15', 0.67, 3466.67),
(4, 'ABC0008', '16', 1.00, 5200.00),
(5, 'ABC0008', '17', 0.50, 2600.00),
(6, 'ABC0008', '18', 0.50, 2600.00);

-- --------------------------------------------------------

--
-- Stand-in structure for view `non_fabric_pending_request`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `non_fabric_pending_request`;
CREATE TABLE IF NOT EXISTS `non_fabric_pending_request` (
`req_number` double
,`batchcode` varchar(45)
,`department` varchar(45)
,`designer` varchar(45)
,`for_vendor` varchar(145)
,`req_date` date
,`p_code` varchar(145)
,`item` varchar(95)
);

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_p_code_request`
--

DROP TABLE IF EXISTS `non_fabric_p_code_request`;
CREATE TABLE IF NOT EXISTS `non_fabric_p_code_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` varchar(45) DEFAULT NULL,
  `product_code` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_p_code_request`
--

INSERT INTO `non_fabric_p_code_request` (`id`, `req_number`, `product_code`) VALUES
(1, '4', 'ABC0007'),
(2, '4', 'ABC0008'),
(3, '4', 'ABC0009'),
(4, '5', 'ABC0006'),
(5, '5', 'ABC0007'),
(6, '5', 'ABC0008'),
(7, '5', 'ABC0010'),
(8, '6', 'GHABC0005'),
(9, '6', 'GHABC0006'),
(10, '6', 'GHABC0007'),
(11, '6', 'GHABC0009'),
(12, '7', 'ABC0006'),
(13, '7', 'ABC0007'),
(14, '7', 'ABC0008'),
(15, '7', 'ABC0010'),
(16, '7', 'ABC0012'),
(17, '16', 'ABC0008'),
(18, '17', 'GHABC0006'),
(19, '17', 'GHABC0008'),
(20, '17', 'GHABC0009');

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_p_return_header`
--

DROP TABLE IF EXISTS `non_fabric_p_return_header`;
CREATE TABLE IF NOT EXISTS `non_fabric_p_return_header` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `return_number` varchar(45) DEFAULT NULL,
  `return_date` varchar(45) DEFAULT NULL,
  `vendor` varchar(45) DEFAULT NULL,
  `against_grn` varchar(45) DEFAULT NULL,
  `against_bill_number` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `remarks` varchar(245) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_p_return_header`
--

INSERT INTO `non_fabric_p_return_header` (`id`, `return_number`, `return_date`, `vendor`, `against_grn`, `against_bill_number`, `amount`, `remarks`) VALUES
(1, '0', NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_p_return_line`
--

DROP TABLE IF EXISTS `non_fabric_p_return_line`;
CREATE TABLE IF NOT EXISTS `non_fabric_p_return_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `return_number` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `sub_categories` varchar(85) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `gst` varchar(45) DEFAULT NULL,
  `hsn` varchar(45) DEFAULT NULL,
  `total` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_p_return_line`
--

INSERT INTO `non_fabric_p_return_line` (`id`, `return_number`, `item_code`, `name`, `sub_categories`, `unit`, `qty`, `rate`, `gst`, `hsn`, `total`, `amount`) VALUES
(1, '2', 'M-10', 'MANISH', 'THREAD', 'REEL', '20', '17', '12', '6053', '380.8', '340'),
(2, '0', 'M-10', 'MANISH', 'THREAD', 'REEL', '20', '17', '12', '6053', '380.8', '340'),
(3, '1', 'M-10', 'MANISH', 'THREAD', 'REEL', '20', '17', '12', '6053', '380.8', '340'),
(4, '0', 'M-10', 'MANISH', 'THREAD', 'REEL', '20', '17', '12', '6053', '380.8', '340'),
(5, '0', 'TESTED-TIKKI-5', 'TESTED TIKKI', 'TIKKI', 'KG', '20', '500', '5', '5007', '10500', '10000');

-- --------------------------------------------------------

--
-- Table structure for table `non_fabric_request`
--

DROP TABLE IF EXISTS `non_fabric_request`;
CREATE TABLE IF NOT EXISTS `non_fabric_request` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `req_number` double DEFAULT NULL,
  `number` varchar(45) DEFAULT NULL,
  `batchcode` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `designer` varchar(45) DEFAULT NULL,
  `item_code` varchar(45) DEFAULT NULL,
  `item_name` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `pending_qty` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `req_date` date DEFAULT NULL,
  `for_vendor` varchar(145) DEFAULT NULL,
  `p_code` varchar(145) DEFAULT NULL,
  `item` varchar(95) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `non_fabric_request`
--

INSERT INTO `non_fabric_request` (`id`, `req_number`, `number`, `batchcode`, `department`, `designer`, `item_code`, `item_name`, `qty`, `unit`, `pending_qty`, `status`, `req_date`, `for_vendor`, `p_code`, `item`) VALUES
(1, 1, NULL, 'ad', 'a', NULL, NULL, NULL, NULL, NULL, '0', NULL, NULL, NULL, NULL, NULL),
(2, 1, NULL, 'ad', 'a', NULL, NULL, NULL, NULL, NULL, '0', NULL, NULL, NULL, NULL, NULL),
(3, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '0', NULL, NULL, NULL, NULL, NULL),
(4, 3, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '5', 'KG', '0', NULL, NULL, '', NULL, NULL),
(5, 3, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '6', 'KG', '0', NULL, NULL, '', NULL, NULL),
(6, 4, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '5', 'KG', '0', NULL, NULL, '', NULL, NULL),
(7, 4, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '12', 'KG', '0', NULL, NULL, '', NULL, NULL),
(8, 5, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '5', 'KG', '0', NULL, NULL, '', NULL, NULL),
(9, 6, NULL, 'PR003', 'SAREE', '', 'STONE-NO-5', 'LOCAL STONE', '12', 'PCS', '0', NULL, NULL, '', NULL, NULL),
(10, 6, NULL, 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '.5', 'KG', '0', NULL, NULL, '', NULL, NULL),
(11, 6, NULL, 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '12', 'KG', '0', NULL, NULL, '', NULL, NULL),
(12, 7, NULL, 'PR0026', 'SAREE', '', 'M-10', 'MANISH', '20', 'REEL', '0', NULL, NULL, '', NULL, NULL),
(13, 7, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '20', 'KG', '0', NULL, NULL, '', NULL, NULL),
(14, 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(15, 8, NULL, '1', '', '', 'M-10', 'MANISH', '10', 'REEL', '0', NULL, NULL, '', '', 'border'),
(16, 11, NULL, '1', '', '', 'M-10', 'MANISH', '4', 'REEL', '0', NULL, NULL, '', '', 'da'),
(17, 12, NULL, 'PR0026', 'SAREE', 'RAJ', 'AVON-1', 'AVON', '1', 'KG', '0', NULL, NULL, '', '', 'coment'),
(18, 13, NULL, 'PR0026', 'SAREE', 'RAJ', 'AVON-1', 'AVON', '4', 'KG', '0', NULL, NULL, 'xyz', 'abc', 'componet'),
(19, 14, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '2', 'KG', '-1', NULL, NULL, '', '', 'coment'),
(20, 15, NULL, 'PR0026', 'SAREE', '', 'M-10', 'MANISH', '50', 'REEL', '50', NULL, NULL, '', '', 'SAREEE'),
(21, 15, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '60', 'KG', '60', NULL, NULL, '', '', '13'),
(22, 15, NULL, 'PR0026', 'SAREE', '', 'TESTED-TIKKI-5', 'TESTED TIKKI', '30', 'KG', '30', NULL, NULL, '', '', '12'),
(23, 16, NULL, 'PR003', 'SAREE', '', 'aVON-1', 'AVON', '2', 'KG', '0', NULL, '2020-06-05', '', NULL, ''),
(24, 17, NULL, 'PR003', 'SAREE', '', 'AVON-1', 'AVON', '2', 'KG', '0', NULL, '2020-06-05', 'abc', NULL, '');

-- --------------------------------------------------------

--
-- Table structure for table `no_series`
--

DROP TABLE IF EXISTS `no_series`;
CREATE TABLE IF NOT EXISTS `no_series` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `department` varchar(85) DEFAULT NULL,
  `order_type` varchar(45) DEFAULT NULL,
  `table_for` varchar(45) DEFAULT NULL,
  `prefix` varchar(45) DEFAULT NULL,
  `last_number` varchar(45) DEFAULT NULL,
  `f.y` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `no_series`
--

INSERT INTO `no_series` (`id`, `department`, `order_type`, `table_for`, `prefix`, `last_number`, `f.y`) VALUES
(1, 'LEHENGA', 'OUT-HOUSE', 'emb_tracker', 'RC', '0007', '2019-20'),
(2, 'KURTA', 'OUT-HOUSE', 'emb_tracker', 'K', '1', '2019-20'),
(3, 'emb_name', NULL, 'emb_order', NULL, NULL, NULL),
(4, 'LEHENGA', 'IN-HOUSE', 'emb_tracker', 'RC', '0009', '2019-20'),
(5, 'FABRIC', 'GRN', 'fabric_grn', 'GRN', '6', '2019-20'),
(6, 'FABRIC', NULL, 'fabric_than', 'T', '45', '2019-20'),
(7, NULL, NULL, 'fabric_req', 'REQ', '8', '2019-20');

-- --------------------------------------------------------

--
-- Table structure for table `product_code_master`
--

DROP TABLE IF EXISTS `product_code_master`;
CREATE TABLE IF NOT EXISTS `product_code_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `batcode_id` int(11) DEFAULT NULL,
  `product_code` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product_code_master`
--

INSERT INTO `product_code_master` (`id`, `batcode_id`, `product_code`) VALUES
(1, 1, 'ABC0006'),
(2, 1, 'ABC0007'),
(3, 1, 'ABC0008'),
(4, 1, 'ABC0009'),
(5, 1, 'ABC0010'),
(6, 1, 'ABC0011'),
(7, 1, 'ABC0012'),
(8, 2, 'ABC0005'),
(9, 2, 'ABC0006'),
(10, 2, 'ABC0007'),
(11, 2, 'ABC0008'),
(12, 2, 'ABC0009'),
(13, 2, 'ABC0010'),
(14, 3, 'GHABC0005'),
(15, 3, 'GHABC0006'),
(16, 3, 'GHABC0007'),
(17, 3, 'GHABC0008'),
(18, 3, 'GHABC0009'),
(19, 3, 'GHABC0010');

-- --------------------------------------------------------

--
-- Table structure for table `product_code_routing_date`
--

DROP TABLE IF EXISTS `product_code_routing_date`;
CREATE TABLE IF NOT EXISTS `product_code_routing_date` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_code` varchar(85) DEFAULT NULL,
  `component` varchar(145) DEFAULT NULL,
  `stating_date` varchar(45) DEFAULT NULL,
  `desinger` varchar(45) DEFAULT NULL,
  `fabric_req` varchar(45) DEFAULT NULL,
  `actual_fabric` varchar(45) DEFAULT NULL,
  `fab_remarks` varchar(45) DEFAULT NULL,
  `fab_status` varchar(45) DEFAULT NULL,
  `dye_req` varchar(45) DEFAULT NULL,
  `actual_dye` varchar(45) DEFAULT NULL,
  `dye_remarks` varchar(45) DEFAULT NULL,
  `dye_status` varchar(45) DEFAULT NULL,
  `print_req` varchar(45) DEFAULT NULL,
  `actual_print` varchar(45) DEFAULT NULL,
  `print_remakrs` varchar(45) DEFAULT NULL,
  `print_status` varchar(45) DEFAULT NULL,
  `over_dye_req` varchar(45) DEFAULT NULL,
  `over_dye_actual` varchar(45) DEFAULT NULL,
  `over_dye_remaks` varchar(45) DEFAULT NULL,
  `over_dye_status` varchar(45) DEFAULT NULL,
  `cmc_req` varchar(45) DEFAULT NULL,
  `actual_cmc` varchar(45) DEFAULT NULL,
  `cmc_remakrs` varchar(45) DEFAULT NULL,
  `cmc_status` varchar(45) DEFAULT NULL,
  `highlight_req` varchar(45) DEFAULT NULL,
  `actual_highlight` varchar(45) DEFAULT NULL,
  `highlight_remakrs` varchar(45) DEFAULT NULL,
  `highlight_status` varchar(45) DEFAULT NULL,
  `stitiching_req` varchar(45) DEFAULT NULL,
  `stitiching_actual` varchar(45) DEFAULT NULL,
  `stitichign_remarks` varchar(45) DEFAULT NULL,
  `stitiching_status` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `style_code` varchar(45) DEFAULT NULL,
  `final_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product_code_routing_date`
--

INSERT INTO `product_code_routing_date` (`id`, `product_code`, `component`, `stating_date`, `desinger`, `fabric_req`, `actual_fabric`, `fab_remarks`, `fab_status`, `dye_req`, `actual_dye`, `dye_remarks`, `dye_status`, `print_req`, `actual_print`, `print_remakrs`, `print_status`, `over_dye_req`, `over_dye_actual`, `over_dye_remaks`, `over_dye_status`, `cmc_req`, `actual_cmc`, `cmc_remakrs`, `cmc_status`, `highlight_req`, `actual_highlight`, `highlight_remakrs`, `highlight_status`, `stitiching_req`, `stitiching_actual`, `stitichign_remarks`, `stitiching_status`, `color`, `style_code`, `final_status`) VALUES
(1, '123', NULL, NULL, NULL, NULL, '  -  -', '', 'OPEN', NULL, '  -  -', '', 'CLOSE', NULL, '  -  -', '', 'CLOSE', NULL, '  -  -', '', 'OPEN', NULL, '  -  -', '', '', NULL, '  -  -', '', '', NULL, '  -  -', '', '', NULL, NULL, NULL),
(2, 'KI0009/19/DPR/001/19-20', NULL, '27-11-2019', 'ABHI', '29-11-2019', '29-11-2019', '', 'OPEN', '30-11-2019', '31-11-2019', '', '', '01-12-2019', '  -  -', '', '', '01-12-2019', '  -  -', '', '', '05-12-2019', '  -  -', '', '', '04-12-2019', '  -  -', '', 'OPEN', '05-12-2019', '  -  -', '', '', 'RED', 'KI0009/19', 'CLOSE'),
(3, 'KI/0097/ABC', NULL, '29-11-2019', 'ABHI', '01-12-2019', '02-12-2019', 'RECEIVE', 'OPEN', '02-12-2019', '  -  -', '', 'OPEN', '04-12-2019', '  -  -', '', '', '04-12-2019', '  -  -', '', '', '08-12-2019', '  -  -', '', '', '11-12-2019', '  -  -', '', '', '13-12-2019', '  -  -', '', '', 'RED', 'KI0097/19', 'OPEN');

-- --------------------------------------------------------

--
-- Table structure for table `product_fabric_consumption`
--

DROP TABLE IF EXISTS `product_fabric_consumption`;
CREATE TABLE IF NOT EXISTS `product_fabric_consumption` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `batch_id` int(11) DEFAULT NULL,
  `product_code_id` int(11) DEFAULT NULL,
  `style_consumption_id` int(11) DEFAULT NULL,
  `total_qty` double DEFAULT NULL,
  `requested_qty` double DEFAULT NULL,
  `pending_qty` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=67 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product_fabric_consumption`
--

INSERT INTO `product_fabric_consumption` (`id`, `batch_id`, `product_code_id`, `style_consumption_id`, `total_qty`, `requested_qty`, `pending_qty`) VALUES
(57, 3, 16, 5, 100, 90, 50),
(56, 3, 16, 4, 300, 290, 30),
(55, 3, 16, 3, 100, 90, 100),
(54, 3, 15, 5, 100, 0, 100),
(53, 3, 15, 4, 300, 0, 300),
(52, 3, 15, 3, 100, 0, 100),
(51, 3, 14, 5, 100, 0, 100),
(50, 3, 14, 4, 300, 0, 300),
(49, 3, 14, 3, 100, 0, 100),
(58, 3, 17, 3, 100, 100, 100),
(59, 3, 17, 4, 300, 300, 300),
(60, 3, 17, 5, 100, 100, 100),
(61, 3, 18, 3, 100, 100, 100),
(62, 3, 18, 4, 300, 50, 300),
(63, 3, 18, 5, 100, 20, 100),
(64, 3, 19, 3, 100, 50, 100),
(65, 3, 19, 4, 300, 0, 300),
(66, 3, 19, 5, 100, 0, 100);

-- --------------------------------------------------------

--
-- Stand-in structure for view `product_fabric_consumption_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `product_fabric_consumption_view`;
CREATE TABLE IF NOT EXISTS `product_fabric_consumption_view` (
`pending to request` double
,`product_code_id` int(11)
,`style_consumption_id` int(11)
,`Product Consumption id` int(11)
,`component` varchar(150)
,`fabric_code` varchar(145)
,`fabric_name` varchar(145)
,`unit` varchar(145)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `product_id`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `product_id`;
CREATE TABLE IF NOT EXISTS `product_id` (
`product_code_id` int(11)
,`product_code` varchar(250)
);

-- --------------------------------------------------------

--
-- Table structure for table `style_consumption_fabric`
--

DROP TABLE IF EXISTS `style_consumption_fabric`;
CREATE TABLE IF NOT EXISTS `style_consumption_fabric` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_code` varchar(145) DEFAULT NULL,
  `style_colour` varchar(145) DEFAULT NULL,
  `component` varchar(150) DEFAULT NULL,
  `fabric_code` varchar(145) DEFAULT NULL,
  `fabric_name` varchar(145) DEFAULT NULL,
  `unit` varchar(145) DEFAULT NULL,
  `qty` varchar(145) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_consumption_fabric`
--

INSERT INTO `style_consumption_fabric` (`id`, `style_code`, `style_colour`, `component`, `fabric_code`, `fabric_name`, `unit`, `qty`) VALUES
(2, 'gh005', 'red', 'coment', 'D-155', 'DUPION', 'MTR', '15'),
(3, 'gh002', 'pink', 'coment', 'D-14', 'DUPION', 'MTR', '20'),
(4, 'gh002', 'pink', 'componet', 'D-155', 'DUPION', 'MTR', '60'),
(5, 'gh002', 'pink', 'coment', 'D-155', 'DUPION', 'MTR', '20');

-- --------------------------------------------------------

--
-- Table structure for table `style_emb_consumption`
--

DROP TABLE IF EXISTS `style_emb_consumption`;
CREATE TABLE IF NOT EXISTS `style_emb_consumption` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_id` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `emb_name` varchar(250) DEFAULT NULL,
  `emb_code` varchar(45) DEFAULT NULL,
  `emb_qty` varchar(45) DEFAULT NULL,
  `emb_uom` varchar(45) DEFAULT NULL,
  `emb_rate` varchar(45) DEFAULT NULL,
  `amount` varchar(45) DEFAULT NULL,
  `rate_type` varchar(45) DEFAULT NULL,
  `cmc_code` varchar(45) DEFAULT NULL,
  `emb_type` varchar(45) DEFAULT NULL,
  `remarks` varchar(100) DEFAULT NULL,
  `style_id` int(11) DEFAULT NULL,
  `erp_component` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_emb_consumption`
--

INSERT INTO `style_emb_consumption` (`id`, `emb_id`, `component`, `emb_name`, `emb_code`, `emb_qty`, `emb_uom`, `emb_rate`, `amount`, `rate_type`, `cmc_code`, `emb_type`, `remarks`, `style_id`, `erp_component`) VALUES
(2, '1', 'LEHENGA', 'THIS IS TEST', 'ABC001', '1', '1760 SQ INCH', '600', '600', 'Fixed Rate', '', 'HAND', 'THIS IS TEST STYLE', 4, NULL),
(3, '1', 'LEHENGA', 'THIS IS TEST', 'ABC001', '1', '1760 SQ INCH', '600', '600', 'Fixed Rate', '', 'HAND', 'THIS IS TEST STYLE', 4, NULL),
(4, '1', 'KURTA', 'THIS IS TEST', 'ABC001', '1', '1760 SQ INCH', '600', '600', 'Fixed Rate', '', 'HAND', 'THIS IS TEST', 5, NULL),
(7, '1', '', 'TEst', 'abc001', '1', '1760 SQ INCH', '450', '450', 'Fixed Rate', '', 'HAND', '', 9, ''),
(10, '1', '', 'TEst', 'abc001', '1', '1760 SQ INCH', '450', '450', 'Fixed Rate', '', 'HAND', '', 6, '');

-- --------------------------------------------------------

--
-- Table structure for table `style_fabric_dye_print`
--

DROP TABLE IF EXISTS `style_fabric_dye_print`;
CREATE TABLE IF NOT EXISTS `style_fabric_dye_print` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `erp_component` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `phase` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `fabirc_rate` double(10,2) DEFAULT NULL,
  `fabric_cost` double(10,2) DEFAULT NULL,
  `dye_qty` varchar(45) DEFAULT '0.00',
  `dye_rate` varchar(45) DEFAULT '0.00',
  `dye_cost` varchar(45) DEFAULT '0.00',
  `print_qy` varchar(45) DEFAULT '0.00',
  `print_rate` varchar(45) DEFAULT '0.00',
  `print_cost` varchar(45) DEFAULT '0.00',
  `style_id` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_fabric_dye_print`
--

INSERT INTO `style_fabric_dye_print` (`id`, `erp_component`, `component`, `fabric_code`, `phase`, `qty`, `uom`, `fabirc_rate`, `fabric_cost`, `dye_qty`, `dye_rate`, `dye_cost`, `print_qy`, `print_rate`, `print_cost`, `style_id`) VALUES
(2, 'LEHENGA', 'KALI', 'D-155', 'PHASE-1', '15', 'MTR', 400.00, 6000.00, '15.00', '40.00', '600.00', '8.00', '350.00', '2800.00', 4),
(3, 'LEHENGA', 'KALI', 'D-155', 'PHASE-1', '15', 'MTR', 400.00, 6000.00, '15.00', '40.00', '600.00', '8.00', '350.00', '2800.00', 4),
(5, 'KURTA', 'KURTA', 'D-14', '', '20', 'MTR', 900.00, 18000.00, '20.00', '40.00', '800.00', '20.00', '350.00', '7000.00', 5),
(6, 'KALIDAR', 'KURTA', 'D-155', '', '30', 'MTR', 400.00, 12000.00, '10.00', '40.00', '400.00', '30.00', '40.00', '1200.00', 5),
(11, '', '', 'D-155', '', '30', 'MTR', 400.00, 12000.00, '30', '75', '2250', '30', '75', '2250', 9),
(12, '', '', 'D-14', '', '20', 'MTR', 800.00, 16000.00, '20', '250', '5000', '30', '150', '4500', 9),
(15, '', '', 'D-14', '', '20', 'MTR', 800.00, 16000.00, '30', '20', '600', '30', '20', '600', 6);

-- --------------------------------------------------------

--
-- Table structure for table `style_master`
--

DROP TABLE IF EXISTS `style_master`;
CREATE TABLE IF NOT EXISTS `style_master` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_code` varchar(45) DEFAULT NULL,
  `style_colour` varchar(45) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `catagory` varchar(45) DEFAULT NULL,
  `item_type` varchar(45) DEFAULT NULL,
  `designed_year` int(11) DEFAULT NULL,
  `fabric_cost` varchar(45) DEFAULT '0',
  `dye_cost` varchar(45) DEFAULT '0',
  `print_cost` varchar(45) DEFAULT '0',
  `emb_cost` varchar(45) DEFAULT '0',
  `mat_cost` varchar(45) DEFAULT '0',
  `stiching_cost` varchar(45) DEFAULT '0',
  `total_cost` varchar(45) DEFAULT '0',
  `mrp` varchar(45) DEFAULT NULL,
  `consumption_status` varchar(45) DEFAULT 'PENDING',
  `style_type` varchar(45) DEFAULT NULL,
  `s_fabric_cost` varchar(45) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_master`
--

INSERT INTO `style_master` (`id`, `style_code`, `style_colour`, `description`, `catagory`, `item_type`, `designed_year`, `fabric_cost`, `dye_cost`, `print_cost`, `emb_cost`, `mat_cost`, `stiching_cost`, `total_cost`, `mrp`, `consumption_status`, `style_type`, `s_fabric_cost`) VALUES
(1, 'GH001/18', 'RED', 'PINK', 'LEHENGA', NULL, NULL, 'DONE', NULL, NULL, NULL, NULL, NULL, '0', NULL, 'PENDING', 'APP', '0'),
(2, 'gh002', 'pink', 'pale pink kurta', 'kurta', NULL, 2019, 'DONE', 'PENDING', 'PENDING', NULL, NULL, NULL, '0', NULL, 'PENDING', 'APP', '0'),
(3, 'gh002', 'pink', 'pale pink kurta', 'kurta', NULL, 2019, 'DONE', 'PENDING', 'PENDING', NULL, NULL, NULL, '0', NULL, 'PENDING', 'APP', '0'),
(4, 'ABC001/19', 'RED', 'THIS IS TEST STYLE', 'LEHENGA', NULL, 2019, '0', '0', '0', '0', '9105', '0', '9705', NULL, 'PENDING', 'APP', '0'),
(5, 'ABC005/19', 'RED', 'THIS IS TEST', 'KURTA', NULL, 2019, '27000', '1200', '8200', '0', '9105', '1800', '47905', NULL, 'DONE', 'APP', '0'),
(6, 'test', 'test', 'this is style', 'lehenga', NULL, 2018, '16000', '1020', '880', '450', '4', '300', '28250', NULL, 'DONE', 'APP', '9600'),
(7, 'ABE001/19', 'RED', 'TEST', 'BAG', NULL, NULL, '0', '0', '0', '0', '0', '0', '0', '17500', 'DONE', 'ACC', '0'),
(8, 'ABE001/18', 'PINK', 'THIS IS TEST', 'BELT', NULL, NULL, '0', '0', '0', '0', '0', '0', '0', '9900', 'PENDING', 'ACC', '0'),
(9, 'KKK', 'RED', 'TEST', 'KURTA', NULL, 2018, '56000', '7250', '13500', '450', '4', '0', '105200', NULL, 'DONE', 'APP', '28000');

-- --------------------------------------------------------

--
-- Table structure for table `style_mat_consumption`
--

DROP TABLE IF EXISTS `style_mat_consumption`;
CREATE TABLE IF NOT EXISTS `style_mat_consumption` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `emb_id` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `emb_name` varchar(250) DEFAULT NULL,
  `mat_code` varchar(45) DEFAULT NULL,
  `per_unit_qty` varchar(45) DEFAULT NULL,
  `total_qty` varchar(45) DEFAULT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `per_unit_amount` varchar(45) DEFAULT NULL,
  `total_amount` varchar(45) DEFAULT NULL,
  `style_id` varchar(45) DEFAULT NULL,
  `erp_component` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_mat_consumption`
--

INSERT INTO `style_mat_consumption` (`id`, `emb_id`, `component`, `emb_name`, `mat_code`, `per_unit_qty`, `total_qty`, `unit`, `rate`, `per_unit_amount`, `total_amount`, `style_id`, `erp_component`) VALUES
(1, '1', 'LEHENGA', 'THIS IS TEST', 'M-10', '2.2', '2.2', 'REEL', '200', '440', '440', '4', NULL),
(2, '1', 'LEHENGA', 'THIS IS TEST', 'AVON-1', '1.1', '1.1', 'KG', '500', '550', '550', '4', NULL),
(3, '1', 'LEHENGA', 'THIS IS TEST', 'M-10', '6.3', '6.3', 'REEL', '50', '315', '315', '4', NULL),
(4, '1', 'LEHENGA', 'THIS IS TEST', 'AVON-1', '1.5', '1.5', 'KG', '5200', '7800', '7800', '4', NULL),
(5, '1', 'KURTA', 'THIS IS TEST', 'M-10', '2.2', '2.2', 'REEL', '200', '440', '440', '5', NULL),
(6, '1', 'KURTA', 'THIS IS TEST', 'AVON-1', '1.1', '1.1', 'KG', '500', '550', '550', '5', NULL),
(7, '1', 'KURTA', 'THIS IS TEST', 'M-10', '6.3', '6.3', 'REEL', '50', '315', '315', '5', NULL),
(8, '1', 'KURTA', 'THIS IS TEST', 'AVON-1', '1.5', '1.5', 'KG', '5200', '7800', '7800', '5', NULL),
(11, '1', '', 'TEst', 'M-10', '0.02', '0.02', 'REEL', '200', '4', '4', '9', ''),
(14, '1', '', 'TEst', 'M-10', '0.02', '0.02', 'REEL', '200', '4', '4', '6', '');

-- --------------------------------------------------------

--
-- Table structure for table `style_product_lead_time`
--

DROP TABLE IF EXISTS `style_product_lead_time`;
CREATE TABLE IF NOT EXISTS `style_product_lead_time` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `style_code` varchar(45) DEFAULT NULL,
  `style_color` varchar(45) DEFAULT NULL,
  `description` varchar(145) DEFAULT NULL,
  `fabric` varchar(45) DEFAULT NULL,
  `dye` varchar(45) DEFAULT NULL,
  `print` varchar(45) DEFAULT NULL,
  `over_dye` varchar(45) DEFAULT NULL,
  `cmc` varchar(45) DEFAULT NULL,
  `highlight` varchar(45) DEFAULT NULL,
  `stitichin` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_product_lead_time`
--

INSERT INTO `style_product_lead_time` (`id`, `style_code`, `style_color`, `description`, `fabric`, `dye`, `print`, `over_dye`, `cmc`, `highlight`, `stitichin`) VALUES
(1, 'abc', 'abc', 'aaa', '2', '3', '1', '2', '3', '4', '1'),
(2, 'KI0009/19', 'RED', 'KURTA', '2', '1', '1', '0', '4', '3', '1'),
(3, 'KI0057/18', 'PINK', 'KURTA', '2', '1', '3', '1', '3', '12', '4'),
(4, 'KI0095/19', 'RED', 'KURTA', '2', '1', '0', '0', '3', '4', '1'),
(5, 'KI0097/19', 'red', 'kurta', '2', '1', '2', '0', '4', '7', '2');

-- --------------------------------------------------------

--
-- Table structure for table `style_s_fabric`
--

DROP TABLE IF EXISTS `style_s_fabric`;
CREATE TABLE IF NOT EXISTS `style_s_fabric` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `erp_component` varchar(45) DEFAULT NULL,
  `component` varchar(45) DEFAULT NULL,
  `fabric_code` varchar(45) DEFAULT NULL,
  `phase` varchar(45) DEFAULT NULL,
  `qty` varchar(45) DEFAULT NULL,
  `uom` varchar(45) DEFAULT NULL,
  `fabirc_rate` double(10,2) DEFAULT NULL,
  `fabric_cost` double(10,2) DEFAULT NULL,
  `dye_qty` varchar(45) DEFAULT '0.00',
  `dye_rate` varchar(45) DEFAULT '0.00',
  `dye_cost` varchar(45) DEFAULT '0.00',
  `print_qy` varchar(45) DEFAULT '0.00',
  `print_rate` varchar(45) DEFAULT '0.00',
  `print_cost` varchar(45) DEFAULT '0.00',
  `style_id` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `style_s_fabric`
--

INSERT INTO `style_s_fabric` (`id`, `erp_component`, `component`, `fabric_code`, `phase`, `qty`, `uom`, `fabirc_rate`, `fabric_cost`, `dye_qty`, `dye_rate`, `dye_cost`, `print_qy`, `print_rate`, `print_cost`, `style_id`) VALUES
(11, '', '', 'D-155', '', '30', 'MTR', 400.00, 12000.00, '30', '75', '2250', '30', '75', '2250', 9),
(12, '', '', 'D-14', '', '20', 'MTR', 800.00, 16000.00, '20', '250', '5000', '30', '150', '4500', 9),
(15, '', '', 'TOTLAJ', '', '2', 'MTR', 300.00, 600.00, '20', '7', '140', '20', '7', '140', 6),
(16, '', '', 'TOTLAJ', '', '30', 'MTR', 300.00, 9000.00, '20', '7', '140', '', '', '0', 6);

-- --------------------------------------------------------

--
-- Table structure for table `test`
--

DROP TABLE IF EXISTS `test`;
CREATE TABLE IF NOT EXISTS `test` (
  `name` int(11) NOT NULL AUTO_INCREMENT,
  `da` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`name`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `test`
--

INSERT INTO `test` (`name`, `da`) VALUES
(1, 'System.Windows.Forms.TextBox, Text: ds'),
(2, 'ad');

-- --------------------------------------------------------

--
-- Table structure for table `unit_time_slot`
--

DROP TABLE IF EXISTS `unit_time_slot`;
CREATE TABLE IF NOT EXISTS `unit_time_slot` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unit_name` varchar(45) DEFAULT NULL,
  `start_1` varchar(45) DEFAULT NULL,
  `end_1` varchar(45) DEFAULT NULL,
  `start_2` varchar(45) DEFAULT NULL,
  `end_2` varchar(45) DEFAULT NULL,
  `start_3` varchar(45) DEFAULT NULL,
  `end_3` varchar(45) DEFAULT NULL,
  `start_4` varchar(45) DEFAULT NULL,
  `end_4` varchar(45) DEFAULT NULL,
  `last_update` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `unit_time_slot`
--

INSERT INTO `unit_time_slot` (`id`, `unit_name`, `start_1`, `end_1`, `start_2`, `end_2`, `start_3`, `end_3`, `start_4`, `end_4`, `last_update`) VALUES
(1, 'MIRAZ-2', '09:00', '12:20', '12:30', '12:45', '13:30', '18:00', '18:40', '21:30', '09-09-2019');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` varchar(45) DEFAULT NULL,
  `user_password` varchar(45) DEFAULT NULL,
  `department` varchar(45) DEFAULT NULL,
  `user_permission` varchar(45) DEFAULT NULL,
  `name` varchar(75) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `user_id`, `user_password`, `department`, `user_permission`, `name`) VALUES
(1, 'RAJ', 'raj', 'lehenga', 'DPR', 'Raj'),
(2, 'ABHI', 'ABHI', NULL, 'ADMIN', 'Abhishek');

-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
CREATE TABLE IF NOT EXISTS `vendor` (
  `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `vendor_name` varchar(100) DEFAULT NULL,
  `address` varchar(250) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `state` varchar(45) DEFAULT NULL,
  `state_code` int(11) DEFAULT NULL,
  `phone_number` varchar(45) DEFAULT NULL,
  `pan_number` varchar(45) DEFAULT NULL,
  `gst_number` varchar(45) DEFAULT NULL,
  `vendor_type` varchar(45) DEFAULT NULL,
  `address_1` varchar(45) DEFAULT NULL,
  `pincode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vendor`
--

INSERT INTO `vendor` (`id`, `vendor_name`, `address`, `city`, `state`, `state_code`, `phone_number`, `pan_number`, `gst_number`, `vendor_type`, `address_1`, `pincode`) VALUES
(2, 'abhishek', '9 bl roy road', 'howrah', 'west bengal', 7, '8617246472', '25625', '2256', 'NON-FABRIC', NULL, NULL),
(3, 'RAJ', 'HOWRAH', 'HOWRAH', 'WEST BENGAL', 19, 'DADAD', '125', '2531', 'NON-FABRIC', NULL, NULL),
(4, 'MK SILK', ' ', '', 'WEST BENGAL', NULL, '861', '1', '1', 'FABRIC', ' ', '711101'),
(5, 'TEST', 'ADDREESS', '', 'TEST', NULL, 'TEST', 'TEST', 'TEST', 'FABRIC', 'TEST', 'TEST');

-- --------------------------------------------------------

--
-- Structure for view `acc_grn`
--
DROP TABLE IF EXISTS `acc_grn`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `acc_grn`  AS  select `acc_transactions`.`transaction_type` AS `transaction_type`,`acc_transactions`.`number` AS `number`,`acc_transactions`.`item_code` AS `item_code`,`acc_transactions`.`rate` AS `rate`,`acc_transactions`.`uom` AS `uom`,`acc_transactions`.`qty` AS `qty`,`acc_transactions`.`ex_tax_mt` AS `ex_tax_mt`,`acc_transactions`.`date` AS `date`,`acc_transactions`.`reff_po_number` AS `reff_po_number`,`acc_transactions`.`bill_number` AS `bill_number`,`acc_transactions`.`bill_date` AS `bill_date`,`acc_transactions`.`vendor` AS `vendor`,`acc_transactions`.`gst_amt` AS `gst_amt`,`acc_transactions`.`inc_tax_amt` AS `inc_tax_amt`,`item`.`item_name` AS `item_name`,`item`.`item_catagory` AS `item_catagory`,`item`.`gst` AS `gst`,`item`.`hsn` AS `hsn` from (`acc_transactions` join `item` on((`acc_transactions`.`item_code` = `item`.`item_code`))) ;

-- --------------------------------------------------------

--
-- Structure for view `acc_pending_request`
--
DROP TABLE IF EXISTS `acc_pending_request`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `acc_pending_request`  AS  select distinct `acc_request`.`req_number` AS `req_number`,`acc_request`.`batchcode` AS `batchcode`,`acc_request`.`department` AS `department`,`acc_request`.`designer` AS `designer`,`acc_request`.`for_vendor` AS `for_vendor`,`acc_request`.`req_date` AS `req_date`,`acc_request`.`p_code` AS `p_code`,`acc_request`.`item` AS `item` from `acc_request` where (`acc_request`.`pending_qty` > 0) ;

-- --------------------------------------------------------

--
-- Structure for view `acc_style_cositng`
--
DROP TABLE IF EXISTS `acc_style_cositng`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `acc_style_cositng`  AS  select `style_master`.`style_code` AS `style_code`,`style_master`.`style_colour` AS `style_colour`,`style_master`.`description` AS `description`,`style_master`.`mrp` AS `mrp`,`acc_style_summery`.`style_id` AS `style_id`,`acc_style_summery`.`hardware` AS `hardware`,`acc_style_summery`.`hand_emb` AS `hand_emb`,`acc_style_summery`.`machine_emb` AS `machine_emb`,`acc_style_summery`.`fabrication` AS `fabrication`,`acc_style_summery`.`digital_print` AS `digital_print`,`acc_style_summery`.`lining_quilting` AS `lining_quilting`,`acc_style_summery`.`leather` AS `leather`,`acc_style_summery`.`fabric` AS `fabric`,`acc_style_summery`.`dye` AS `dye`,`acc_style_summery`.`emb_mat` AS `emb_mat`,`acc_style_summery`.`others` AS `others`,`acc_style_summery`.`hardware_polish` AS `hardware_polish`,`acc_style_summery`.`packing` AS `packing`,`acc_style_summery`.`overhead` AS `overhead`,`acc_style_summery`.`grand_total` AS `grand_total` from (`acc_style_summery` join `style_master` on((`style_master`.`id` = `acc_style_summery`.`style_id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `batchcode_id_product_code`
--
DROP TABLE IF EXISTS `batchcode_id_product_code`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `batchcode_id_product_code`  AS  select `product_code_master`.`product_code` AS `product_code`,`product_code_master`.`batcode_id` AS `batcode_id`,`batch_code_master`.`batchcode` AS `batchcode` from (`product_code_master` join `batch_code_master` on((`product_code_master`.`batcode_id` = `batch_code_master`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `cmc_order_view`
--
DROP TABLE IF EXISTS `cmc_order_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `cmc_order_view`  AS  select `cmc_order_entry`.`id` AS `id`,`cmc_order_entry`.`order_number` AS `order_number`,`cmc_order_entry`.`date` AS `date`,`cmc_order_entry`.`batchcode` AS `batchcode`,`cmc_order_entry`.`department` AS `department`,`cmc_order_entry`.`designer` AS `designer`,`cmc_order_entry`.`design_code` AS `design_code`,`cmc_order_entry`.`fabric` AS `fabric`,`cmc_order_entry`.`color` AS `color`,`cmc_order_entry`.`component` AS `component`,`cmc_order_entry`.`status` AS `status`,`cmc_design`.`design_type` AS `design_type`,`cmc_design`.`design_description` AS `design_description` from (`cmc_order_entry` join `cmc_design` on((`cmc_order_entry`.`design_code` = `cmc_design`.`design_code`))) ;

-- --------------------------------------------------------

--
-- Structure for view `cmc_prodcution_time_view`
--
DROP TABLE IF EXISTS `cmc_prodcution_time_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `cmc_prodcution_time_view`  AS  select `cmc_production_time_calc`.`id` AS `id`,`cmc_production_time_calc`.`order_number` AS `order_number`,`cmc_production_time_calc`.`start_date` AS `start_date`,`cmc_production_time_calc`.`start_time` AS `start_time`,`cmc_production_time_calc`.`end_date` AS `end_date`,`cmc_production_time_calc`.`end_time` AS `end_time`,`cmc_production_time_calc`.`total_hour` AS `total_hour`,`cmc_production_time_calc`.`non_working_hour` AS `non_working_hour`,`cmc_production_time_calc`.`effective_time` AS `effective_time`,`cmc_production_time_calc`.`non_working_remarks` AS `non_working_remarks`,`cmc_production_time_calc`.`per_hr_rate` AS `per_hr_rate`,`cmc_production_time_calc`.`total_cost` AS `total_cost`,`cmc_order_entry`.`design_code` AS `design_code`,`cmc_order_entry`.`batchcode` AS `batchcode`,`cmc_order_entry`.`department` AS `department`,`cmc_order_entry`.`designer` AS `designer`,`cmc_order_entry`.`fabric` AS `fabric`,`cmc_order_entry`.`color` AS `color`,`cmc_order_entry`.`component` AS `component`,`cmc_order_entry`.`date` AS `date`,`cmc_order_entry`.`fab_qty_details` AS `fab_qty_details`,`cmc_design`.`design_type` AS `design_type`,`cmc_design`.`machine_type` AS `machine_type`,`cmc_design`.`design_description` AS `design_description` from ((`cmc_production_time_calc` join `cmc_order_entry` on((`cmc_production_time_calc`.`order_number` = `cmc_order_entry`.`order_number`))) join `cmc_design` on((`cmc_order_entry`.`design_code` = `cmc_design`.`design_code`))) ;

-- --------------------------------------------------------

--
-- Structure for view `dpr_order_time`
--
DROP TABLE IF EXISTS `dpr_order_time`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `dpr_order_time`  AS  select `dpr_entry`.`order_number` AS `order_number`,sec_to_time(sum(time_to_sec(`dpr_entry`.`total_time`))) AS `total_time`,`dpr_entry`.`unit` AS `unit`,`dpr_entry`.`date` AS `date` from `dpr_entry` group by `dpr_entry`.`order_number` ;

-- --------------------------------------------------------

--
-- Structure for view `emb_consumption`
--
DROP TABLE IF EXISTS `emb_consumption`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `emb_consumption`  AS  select `emb_consumption_header`.`emb_id` AS `emb_id`,`emb_master`.`emb_code` AS `emb_code`,`emb_master`.`emb_name` AS `emb_name`,`emb_master`.`uom` AS `uom`,`emb_master`.`emb_type` AS `emb_type`,`emb_consumption_header`.`time` AS `time`,`emb_consumption_header`.`per_hr_rate` AS `per_hr_rate`,`emb_consumption_header`.`remarks` AS `remarks`,`emb_consumption_header`.`emb_cost` AS `emb_cost`,`emb_consumption_header`.`mat_cost` AS `mat_cost`,`emb_consumption_header`.`total_cost` AS `total_cost` from (`emb_consumption_header` join `emb_master` on((`emb_consumption_header`.`emb_id` = `emb_master`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `emb_pending_consumption`
--
DROP TABLE IF EXISTS `emb_pending_consumption`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `emb_pending_consumption`  AS  select `emb_consumption_header`.`emb_id` AS `emb_id`,`emb_master`.`emb_code` AS `emb_code`,`emb_master`.`emb_name` AS `emb_name`,`emb_master`.`uom` AS `uom`,`emb_consumption_header`.`mat_cost` AS `mat_cost` from (`emb_master` join `emb_consumption_header` on((`emb_consumption_header`.`emb_id` = `emb_master`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `emb_receive_comparision`
--
DROP TABLE IF EXISTS `emb_receive_comparision`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `emb_receive_comparision`  AS  select `emb_receive`.`order_id` AS `order_id`,sum(`emb_receive`.`total_job_receive`) AS `total job receive`,sum(`emb_receive`.`Item_qty_receive`) AS `total qty receive` from `emb_receive` group by `emb_receive`.`order_id` ;

-- --------------------------------------------------------

--
-- Structure for view `fabric_p_code_wise_issue`
--
DROP TABLE IF EXISTS `fabric_p_code_wise_issue`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `fabric_p_code_wise_issue`  AS  select `fabric_issue`.`req_number` AS `req_number`,`fabric_issue`.`batchcode` AS `batchcode`,`fabric_issue`.`department` AS `department`,`fabric_issue`.`designer` AS `designer`,`fabric_issue`.`fab_qty_details` AS `fab_qty_details`,`fabric_issue`.`fabric_code` AS `fabric_code`,`fabric_issue`.`fabric_name` AS `fabric_name`,`fabric_issue`.`rate` AS `rate`,`fabric_issue`.`uom` AS `uom`,`fabric_issue`.`issue_date` AS `issue_date`,`fabric_issue_product`.`p_code` AS `p_code`,`fabric_issue_product`.`qty` AS `qty`,`fabric_issue_product`.`amount` AS `amount` from (`fabric_issue_product` join `fabric_issue` on((`fabric_issue_product`.`issue_id` = `fabric_issue`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `fabric_request`
--
DROP TABLE IF EXISTS `fabric_request`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `fabric_request`  AS  select `fabric_requisition`.`requisition_number` AS `requisition_number`,`fabric_requisition`.`req_date` AS `req_date`,`fabric_requisition`.`batch_code` AS `batch_code`,`batch_code_master`.`department` AS `department`,count(distinct `fabric_requisition`.`product_code`) AS `COUNT_OF_PRODUCTCODE`,`fabric_requisition`.`compoent` AS `compoent`,`fabric_requisition`.`fabric_code` AS `fabric_code`,`fabric_requisition`.`fabric_name` AS `fabric_name`,`fabric_requisition`.`unit` AS `unit`,sum(`fabric_requisition`.`requested_qty`) AS `SUM_OF_requested_qty`,sum(`fabric_requisition`.`pending_qty`) AS `SUM_OF_pending_qty` from (`fabric_requisition` join `batch_code_master` on((`batch_code_master`.`batchcode` = `fabric_requisition`.`batch_code`))) where (`fabric_requisition`.`pending_qty` > 0) group by `fabric_requisition`.`requisition_number`,`fabric_requisition`.`batch_code`,`fabric_requisition`.`fabric_code`,`fabric_requisition`.`compoent` ;

-- --------------------------------------------------------

--
-- Structure for view `fabric_stock_summery`
--
DROP TABLE IF EXISTS `fabric_stock_summery`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `fabric_stock_summery`  AS  select `fabric_than_details`.`fabric_code` AS `fabric_code`,sum(if((`fabric_than_details`.`status` = 'SENT TO QC'),`fabric_than_details`.`pending_than_qty`,0)) AS `sent_to_qc`,sum(if((`fabric_than_details`.`status` = 'APPROVE'),`fabric_than_details`.`pending_than_qty`,0)) AS `APPROVE`,sum(if((`fabric_than_details`.`status` = 'RECEIVE'),`fabric_than_details`.`pending_than_qty`,0)) AS `RECEIVE`,sum(if((`fabric_than_details`.`status` = 'CUTTING'),`fabric_than_details`.`pending_than_qty`,0)) AS `CUTTING`,sum(if((`fabric_than_details`.`status` = 'RETURN'),`fabric_than_details`.`pending_than_qty`,0)) AS `RETURN`,sum(if((`fabric_than_details`.`status` = 'REJECT'),`fabric_than_details`.`pending_than_qty`,0)) AS `REJECT` from `fabric_than_details` group by `fabric_than_details`.`fabric_code` ;

-- --------------------------------------------------------

--
-- Structure for view `fabric_than`
--
DROP TABLE IF EXISTS `fabric_than`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `fabric_than`  AS  select `fabric_grn_line`.`id` AS `id`,`fabric_grn_line`.`grn_number` AS `grn_number`,`fabric_grn_line`.`item_code` AS `item_code`,`fabric_grn_line`.`qty` AS `qty`,`fabric_grn_line`.`than_status` AS `than_status`,`fabric_grn_header`.`vendor` AS `vendor` from (`fabric_grn_line` join `fabric_grn_header` on((`fabric_grn_line`.`grn_number` = `fabric_grn_header`.`grn_number`))) ;

-- --------------------------------------------------------

--
-- Structure for view `fabric_than_details_view`
--
DROP TABLE IF EXISTS `fabric_than_details_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `fabric_than_details_view`  AS  select `fabric_than_details`.`id` AS `id`,`fabric_than_details`.`fabric_code` AS `fabric_code`,`fabric_than_details`.`than_number` AS `than_number`,`fabric_than_details`.`than_qty` AS `than_qty`,`fabric_than_details`.`status` AS `status`,`fabric_than_details`.`grn_number` AS `grn_number`,`fabric_grn_header`.`vendor` AS `vendor` from (`fabric_than_details` join `fabric_grn_header` on((`fabric_than_details`.`grn_number` = `fabric_grn_header`.`grn_number`))) ;

-- --------------------------------------------------------

--
-- Structure for view `grn_view`
--
DROP TABLE IF EXISTS `grn_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `grn_view`  AS  select `non_fabric_grn_line`.`item_code` AS `item_code`,`non_fabric_grn_line`.`name` AS `name`,`non_fabric_grn_line`.`qty` AS `qty`,`non_fabric_grn_line`.`unit` AS `unit`,`non_fabric_grn_line`.`total` AS `total`,`non_fabric_grn_line`.`rate` AS `rate`,`non_fabric_grn_line`.`amount` AS `amount`,`non_fabric_grn_header`.`grn_number` AS `grn_number`,`non_fabric_grn_header`.`vendor` AS `vendor`,`non_fabric_grn_header`.`bill_number` AS `bill_number`,`non_fabric_grn_header`.`bill_date` AS `bill_date`,`non_fabric_grn_header`.`grn_date` AS `grn_date`,`non_fabric_grn_header`.`po_reff` AS `po_reff` from (`non_fabric_grn_line` join `non_fabric_grn_header` on((`non_fabric_grn_line`.`grn_number` = `non_fabric_grn_header`.`grn_number`))) ;

-- --------------------------------------------------------

--
-- Structure for view `it_item_receive`
--
DROP TABLE IF EXISTS `it_item_receive`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `it_item_receive`  AS  select `it_item`.`catagory` AS `catagory`,`it_item`.`company` AS `company`,`it_user_transaction`.`user_id` AS `user_id`,`it_user_transaction`.`serial_number` AS `serial_number`,`it_user_transaction`.`status` AS `status`,`it_user_transaction`.`issue_date` AS `issue_date`,`it_user_transaction`.`id` AS `user_trnasction_id` from (`it_user_transaction` join `it_item` on((`it_user_transaction`.`serial_number` = `it_item`.`serial_number`))) ;

-- --------------------------------------------------------

--
-- Structure for view `non_fabric_issue_cat`
--
DROP TABLE IF EXISTS `non_fabric_issue_cat`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `non_fabric_issue_cat`  AS  select `non_fabric_item_issue`.`issue_date` AS `issue_date`,`non_fabric_item_issue`.`item_code` AS `item_code`,`non_fabric_item_issue`.`name` AS `name`,`item`.`item_catagory` AS `item_catagory`,`non_fabric_item_issue`.`amount` AS `amount`,`non_fabric_item_issue`.`qty` AS `qty`,`non_fabric_item_issue`.`unit` AS `unit` from (`non_fabric_item_issue` join `item` on((`non_fabric_item_issue`.`item_code` = `item`.`item_code`))) ;

-- --------------------------------------------------------

--
-- Structure for view `non_fabric_pending_request`
--
DROP TABLE IF EXISTS `non_fabric_pending_request`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `non_fabric_pending_request`  AS  select distinct `non_fabric_request`.`req_number` AS `req_number`,`non_fabric_request`.`batchcode` AS `batchcode`,`non_fabric_request`.`department` AS `department`,`non_fabric_request`.`designer` AS `designer`,`non_fabric_request`.`for_vendor` AS `for_vendor`,`non_fabric_request`.`req_date` AS `req_date`,`non_fabric_request`.`p_code` AS `p_code`,`non_fabric_request`.`item` AS `item` from `non_fabric_request` where (`non_fabric_request`.`pending_qty` > 0) ;

-- --------------------------------------------------------

--
-- Structure for view `product_fabric_consumption_view`
--
DROP TABLE IF EXISTS `product_fabric_consumption_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `product_fabric_consumption_view`  AS  select (coalesce(`product_fabric_consumption`.`total_qty`,0) - coalesce(`product_fabric_consumption`.`requested_qty`,0)) AS `pending to request`,`product_fabric_consumption`.`product_code_id` AS `product_code_id`,`product_fabric_consumption`.`style_consumption_id` AS `style_consumption_id`,`product_fabric_consumption`.`id` AS `Product Consumption id`,`style_consumption_fabric`.`component` AS `component`,`style_consumption_fabric`.`fabric_code` AS `fabric_code`,`style_consumption_fabric`.`fabric_name` AS `fabric_name`,`style_consumption_fabric`.`unit` AS `unit` from (`product_fabric_consumption` join `style_consumption_fabric` on((`product_fabric_consumption`.`style_consumption_id` = `style_consumption_fabric`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `product_id`
--
DROP TABLE IF EXISTS `product_id`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `product_id`  AS  select distinct `product_fabric_consumption`.`product_code_id` AS `product_code_id`,`product_code_master`.`product_code` AS `product_code` from (`product_fabric_consumption` join `product_code_master` on((`product_fabric_consumption`.`product_code_id` = `product_code_master`.`id`))) ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
