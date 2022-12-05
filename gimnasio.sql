-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 04, 2022 at 12:42 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gimnasio`
--

-- --------------------------------------------------------

--
-- Table structure for table `codigopostal`
--

CREATE TABLE `codigopostal` (
  `cp` int(4) NOT NULL,
  `Localidad` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `codigopostal`
--

INSERT INTO `codigopostal` (`cp`, `Localidad`) VALUES
(7530, 'Coronel Pringles'),
(8000, 'Bahia Blanca'),
(8103, 'White'),
(8105, 'General Daniel Cerri'),
(8109, 'Punta Alta');

-- --------------------------------------------------------

--
-- Table structure for table `pagos`
--

CREATE TABLE `pagos` (
  `fechaPago` date NOT NULL,
  `dniSocio` int(8) NOT NULL,
  `pago` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pagos`
--

INSERT INTO `pagos` (`fechaPago`, `dniSocio`, `pago`) VALUES
('2022-02-09', 11111111, 0);

-- --------------------------------------------------------

--
-- Table structure for table `profesores`
--

CREATE TABLE `profesores` (
  `dni` int(8) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `apellido` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `profesores`
--

INSERT INTO `profesores` (`dni`, `nombre`, `apellido`) VALUES
(22334455, 'Oscar', 'Pedro'),
(44490081, 'Daniel', 'Marcos');

-- --------------------------------------------------------

--
-- Table structure for table `socio`
--

CREATE TABLE `socio` (
  `dni` int(8) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(25) NOT NULL,
  `domicilio` varchar(50) NOT NULL,
  `CP` int(5) NOT NULL,
  `fecha_nac` date NOT NULL,
  `telefono` int(10) NOT NULL,
  `email` varchar(100) NOT NULL,
  `activo` varchar(2) NOT NULL,
  `vieneVeces` int(11) NOT NULL,
  `lesionado` varchar(2) NOT NULL,
  `lesiones` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `socio`
--

INSERT INTO `socio` (`dni`, `nombre`, `apellido`, `domicilio`, `CP`, `fecha_nac`, `telefono`, `email`, `activo`, `vieneVeces`, `lesionado`, `lesiones`) VALUES
(11111111, 'Carlos', 'Sanchez', 'AAAA 1234', 8000, '2021-12-14', 123131, 'carlosanchez@gmail.com', 'Si', 3, 'No', 'Ninguna'),
(44444444, 'aaaaaaaaaaaaa', 'asddasd', 'AAAA 222', 8105, '2021-12-14', 123131, 'carlosanchez@gmail.com', 'Si', 3, 'No', 'Ninguna');

-- --------------------------------------------------------

--
-- Table structure for table `tipousuario`
--

CREATE TABLE `tipousuario` (
  `idTipo` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tipousuario`
--

INSERT INTO `tipousuario` (`idTipo`, `nombre`) VALUES
(1, 'admin'),
(2, 'usuario');

-- --------------------------------------------------------

--
-- Table structure for table `turno`
--

CREATE TABLE `turno` (
  `fechaTurno` date NOT NULL,
  `dniSocio` int(8) NOT NULL,
  `dniProfesor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `turno`
--

INSERT INTO `turno` (`fechaTurno`, `dniSocio`, `dniProfesor`) VALUES
('2022-02-14', 11111111, 44490081);

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

CREATE TABLE `usuario` (
  `idUser` int(11) NOT NULL,
  `user` varchar(45) DEFAULT NULL,
  `password` varchar(80) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `idTipoUser` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` (`idUser`, `user`, `password`, `nombre`, `idTipoUser`) VALUES
(1, 'lautaro', 'edb3b0e5141612fd944bc8c6b90d73b270703766', 'lautaro', 2),
(7, 'admin', 'd033e22ae348aeb5660fc2140aec35850c4da997', 'admin', 1),
(8, 'a', '86f7e437faa5a7fce15d1ddcb9eaeaea377667b8', 'a', 1),
(11, 'fasd', 'f10e2821bbbea527ea02200352313bc059445190', 'asdfaa', 1);

-- --------------------------------------------------------

--
-- Table structure for table `veces`
--

CREATE TABLE `veces` (
  `cantidad` int(11) NOT NULL,
  `precio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `veces`
--

INSERT INTO `veces` (`cantidad`, `precio`) VALUES
(3, 2000),
(5, 4000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `codigopostal`
--
ALTER TABLE `codigopostal`
  ADD PRIMARY KEY (`cp`);

--
-- Indexes for table `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`fechaPago`,`dniSocio`),
  ADD KEY `dniSocio` (`dniSocio`);

--
-- Indexes for table `profesores`
--
ALTER TABLE `profesores`
  ADD PRIMARY KEY (`dni`);

--
-- Indexes for table `socio`
--
ALTER TABLE `socio`
  ADD PRIMARY KEY (`dni`),
  ADD KEY `codigo_postal` (`CP`),
  ADD KEY `vieneVeces` (`vieneVeces`);

--
-- Indexes for table `tipousuario`
--
ALTER TABLE `tipousuario`
  ADD PRIMARY KEY (`idTipo`);

--
-- Indexes for table `turno`
--
ALTER TABLE `turno`
  ADD PRIMARY KEY (`fechaTurno`,`dniSocio`),
  ADD KEY `turno_socios` (`dniSocio`),
  ADD KEY `turno_profesores` (`dniProfesor`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUser`),
  ADD KEY `usuariotipo` (`idTipoUser`);

--
-- Indexes for table `veces`
--
ALTER TABLE `veces`
  ADD PRIMARY KEY (`cantidad`),
  ADD KEY `cantidad` (`cantidad`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `profesores`
--
ALTER TABLE `profesores`
  MODIFY `dni` int(8) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44490082;

--
-- AUTO_INCREMENT for table `tipousuario`
--
ALTER TABLE `tipousuario`
  MODIFY `idTipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`dniSocio`) REFERENCES `socio` (`dni`);

--
-- Constraints for table `socio`
--
ALTER TABLE `socio`
  ADD CONSTRAINT `codigo_postal` FOREIGN KEY (`CP`) REFERENCES `codigopostal` (`cp`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `socio_ibfk_1` FOREIGN KEY (`vieneVeces`) REFERENCES `veces` (`cantidad`);

--
-- Constraints for table `turno`
--
ALTER TABLE `turno`
  ADD CONSTRAINT `turno_profesores` FOREIGN KEY (`dniProfesor`) REFERENCES `profesores` (`dni`),
  ADD CONSTRAINT `turno_socios` FOREIGN KEY (`dniSocio`) REFERENCES `socio` (`dni`);

--
-- Constraints for table `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuariotipo` FOREIGN KEY (`idTipoUser`) REFERENCES `tipousuario` (`idTipo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
