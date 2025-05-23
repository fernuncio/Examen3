CREATE DATABASE inventario;

use inventario;
CREATE TABLE producto
(
	id_producto INT PRIMARY KEY,
	nombre VARCHAR(120),
	descripcion VARCHAR(160),
	precio DECIMAL(10,2),
	stock INT,
	marca VARCHAR(120),
	codigo_barras VARCHAR(12)
);
