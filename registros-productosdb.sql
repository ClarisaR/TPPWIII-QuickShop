USE ProductosDb;

GO

DELETE FROM Categorias; 
DBCC CHECKIDENT ('Categorias', RESEED, 0);

DELETE FROM Colores;
DBCC CHECKIDENT ('Colores', RESEED, 0);

DELETE FROM Talles;
DBCC CHECKIDENT ('Talles', RESEED, 0);

DELETE FROM Rubros;
DBCC CHECKIDENT ('Rubros', RESEED, 0);

DELETE FROM Direccion;
DBCC CHECKIDENT ('Direccion', RESEED, 0);

DELETE FROM Locales;
DBCC CHECKIDENT ('Locales', RESEED, 0);


INSERT INTO Categorias (Nombre) 
VALUES 
  ('Remeras y camisetas'),
  ('Pantalones'),
  ('Buzos y camperas'),
  ('Formales'),
  ('Vestidos');

INSERT INTO Colores (Nombre)
VALUES 
  ('Blanco'),
  ('Azul'),
  ('Rojo'),
  ('Negro'),
  ('Amarillo'),
  ('Naranja'),
  ('Marrón'),
  ('Violeta'),
  ('Gris');

INSERT INTO Talles (Nombre)
VALUES 
  ('S'),
  ('M'),
  ('L'),
  ('XL'),
  ('2XL'),
  ('3XL');

INSERT INTO Rubros (Nombre) 
VALUES 
  ('Mujer'),
  ('Hombre'),
  ('Infantil');

INSERT INTO Direccion (Descripcion, Latitud, Longitud) VALUES
('Palermo Soho, Buenos Aires', -34.587200, -58.430100),
('Recoleta Centro, Buenos Aires', -34.587900, -58.396500),
('Belgrano R, Buenos Aires', -34.556300, -58.455700),
('San Telmo Viejo, Buenos Aires', -34.619800, -58.372000),
('Caballito Norte, Buenos Aires', -34.613400, -58.440800),
('Almagro Sur, Buenos Aires', -34.615700, -58.425600),
('Boedo, Buenos Aires', -34.629500, -58.423000),
('La Boca, Buenos Aires', -34.634200, -58.363800),
('Villa Urquiza, Buenos Aires', -34.567800, -58.472200),
('Flores Este, Buenos Aires', -34.616100, -58.466900),
('Villa Devoto, Buenos Aires', -34.593200, -58.502100),
('Parque Chas, Buenos Aires', -34.587500, -58.473900),
('Palermo Hollywood, Buenos Aires', -34.589900, -58.417200),
('Puerto Madero, Buenos Aires', -34.608000, -58.363200);

INSERT INTO Locales (Nombre, Descripcion, RubroId, DireccionId, Imagen) VALUES
('Fuse', 'none', 1, 1, 'fuse.png'),
('Istoria', 'none', 1, 2, 'istoria.png'),
('Astra', 'none', 1, 3, 'astra.png'),
('Luxe Loom', 'none', 1, 4, 'luxe_loom.png'),
('Almaira', 'none', 1, 5, 'almaira.png'),
('Drop', 'none', 2, 6, 'drop.png'),
('Noou', 'none', 2, 7, 'noou.png'),
('Cosmos', 'none', 2, 8, 'cosmos.png'),
('Parner', 'none', 2, 9, 'parner.png'),
('TFL', 'none', 2, 10, 'tfl.png'),
('Mimo Kids', 'none', 3, 11, 'mimo_kids.png'),
('Mimico', 'none', 3, 12, 'mimico.png'),
('Buma', 'none', 3, 13, 'buma.png'),
('Nunka', 'none', 3, 14, 'nunka.png');
