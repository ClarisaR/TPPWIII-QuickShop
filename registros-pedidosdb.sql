USE PedidosDb;

GO

 -- PEDIDOS
 INSERT INTO Pedidos (IdUsuario, FechaPedido, Estado, Total, DireccionHasta, DireccionDesde) 
VALUES (1, '2025-06-12', 'Pendiente', 55758.40, 'Calle Falsa 1', 'Sucursal 1');

INSERT INTO Pedidos (IdUsuario, FechaPedido, Estado, Total, DireccionHasta, DireccionDesde) 
VALUES (1, '2025-06-13', 'Pendiente', 129240.00, 'Calle Falsa 2', 'Sucursal 2');

INSERT INTO Pedidos (IdUsuario, FechaPedido, Estado, Total, DireccionHasta, DireccionDesde) 
VALUES (1, '2025-06-14', 'Pendiente', 51297.15, 'Calle Falsa 3', 'Sucursal 3');


-- PEDIDOPRODUCTOS
INSERT INTO PedidoProductos (IdPedido, IdProducto, CantidadProductos, PrecioUnitario) 
VALUES (1, 1, 1, 42000);

INSERT INTO PedidoProductos (IdPedido, IdProducto, CantidadProductos, PrecioUnitario) 
VALUES (1, 2, 2, 6879.2);

INSERT INTO PedidoProductos (IdPedido, IdProducto, CantidadProductos, PrecioUnitario) 
VALUES (2, 3, 1, 59040);

INSERT INTO PedidoProductos (IdPedido, IdProducto, CantidadProductos, PrecioUnitario) 
VALUES (2, 4, 1, 70200);

INSERT INTO PedidoProductos (IdPedido, IdProducto, CantidadProductos, PrecioUnitario) 
VALUES (3, 5, 3, 17099.05);
