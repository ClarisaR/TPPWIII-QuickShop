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

DELETE FROM Productos;
DBCC CHECKIDENT ('Productos', RESEED, 0);

INSERT INTO Categorias (Nombre) 
VALUES 
  -- Ropa
  ('Buzos'),
  ('Remeras'),
  ('Pantalones'),
  ('Camperas'),
  ('Vestidos'),
  ('Calzado'),

  -- Accesorios
  ('Collares'),
  ('Pulseras'),
  ('Aros');

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
  ('XXL'),
  ('XXXL');

INSERT INTO Rubros (Nombre) 
VALUES 
  ('Mujer'),
  ('Hombre'),
  ('Infantil'),
  ('Accesorios'),
  ('Deportiva');

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
('Puerto Madero, Buenos Aires', -34.608000, -58.363200),
('Recoleta Parque, Buenos Aires', -34.585600, -58.392400),
('Monserrat, Buenos Aires', -34.615000, -58.373500),
('San Cristóbal, Buenos Aires', -34.629200, -58.396900),
('Nueva Pompeya, Buenos Aires', -34.646700, -58.380500),
('Mataderos, Buenos Aires', -34.641000, -58.501000),
('Villa Luro, Buenos Aires', -34.630800, -58.480200);

INSERT INTO Locales (Nombre, Descripcion, RubroId, DireccionId, Imagen) VALUES
('Fuse', 'none', 1, 1, 'fuse.png'),
('Istoria', 'none', 1, 2, 'istoria.png'),
('Astra', 'none', 1, 3, 'astra.png'),
('Venecia', 'none', 1, 4, 'astra.png'),
('Drop', 'none', 2, 5, 'drop.png'),
('Noou', 'none', 2, 6, 'noou.png'),
('Cosmos', 'none', 2, 7, 'cosmos.png'),
('Equus', 'none', 2, 8, 'cosmos.png'),
('Mimo Kids', 'none', 3, 9, 'mimo_kids.png'),
('Mimico', 'none', 3, 10, 'mimico.png'),
('Buma', 'none', 3, 11, 'buma.png'),
('Vector', 'none', 3, 12, 'buma.png'),
('Chloe', 'none', 4, 13, 'chloe.png'),
('Luxe Loom', 'none', 4, 14, 'luxe_loom.png'),
('Almaira', 'none', 4, 15, 'almaira.png'),
('Tinchos', 'none', 4, 16, 'almaira.png'),
('TFL', 'none', 5, 17, 'tfl.png'),
('Rossfit', 'none', 5, 18, 'rossfit.png'),
('Parner', 'none', 5, 19, 'parner.png'),
('Mira y aprende', 'none', 5, 20, 'parner.png');


INSERT INTO [ProductosDb].[dbo].[Productos] 
       ([Nombre], [Imagen], [Descripcion], [Precio], [CategoriaId], [LocalId])
VALUES
----RUBRO 1----
--Local 1
('Buzo Canguro Rosa Snoopy Tenis',
 'https://http2.mlstatic.com/D_NQ_NP_725019-MLA84094370372_052025-O.webp',
 '100% ALGODÓN, FRIZADO, ESTAMPADO POR DELANTE.',
 42000, 1, 1),

('Remera Básica Dama Mujer Algodón',
 'https://http2.mlstatic.com/D_NQ_NP_767956-MLA80429465118_112024-O.webp',
 'Remera Mujer Lisa Manga Corta 100% Algodón. Material: 100% Algodon Cuello Redondo Manga Corta',
 6879.20, 2, 1),

('Pantalón Cargo Iran Mujer',
 'https://http2.mlstatic.com/D_NQ_NP_845060-MLA85717005059_062025-O.webp',
 'Pantalón Iran Cargo de Gabardina Descubrí el Pantalón Iran Cargo, una prenda esencial para quienes buscan comodidad y estilo en su vestuario diario.',
 59040, 3, 1),

--Local 2
('Gamulán Forrado En Peluche Tori Mujer',
 'https://http2.mlstatic.com/D_NQ_NP_693778-MLA84465244898_052025-O.webp',
 'Descubrí el Gamulan Importado Tori, una prenda de calidad premium que combina calidez y estilo para acompañarte en los días más frescos.',
 70200, 4, 2),

('Vestido Basico De Morley Cuello Polera',
 'https://http2.mlstatic.com/D_NQ_NP_768924-MLA85301462672_062025-O.webp',
 'Vestido corto ajustado de manga larga, ideal para un look elegante y moderno tanto de día como de noche.',
 17099.05, 5, 2),

 ('Zapatillas Mujer Plataformas Botitas Urbanas',
 'https://http2.mlstatic.com/D_NQ_NP_815412-MLA82144985516_022025-O.webp',
 'Las Zapatillas Mujer Plataformas Sneakers Urbanas Moda Cómodas son el calzado perfecto para aquellas personas que buscan estilo.',
 41899, 6, 2),

--Local 3
('Buzo Capucha Mujer Canguro Hoodie',
 'https://http2.mlstatic.com/D_NQ_NP_785271-MLA50595028440_072022-O.webp',
 'Buzo, lisos, manga larga con capucha y bolsillo frontal tipo canguro.',
 14900, 1, 3),

('Remera Lisa Mujer 100% Algodon Premium',
 'https://http2.mlstatic.com/D_NQ_NP_774709-MLA83998878858_052025-O.webp',
 'Remera Basics 100% algodon premium. No se deforman con el uso. Elaboración propia, calce perfecto.',
 11039.08, 2, 3),

('Jean Clasico Wide Leg Mujer Elastizado',
 'https://http2.mlstatic.com/D_NQ_NP_784287-MLA84710321377_052025-O.webp',
 'Jean azul oscuro tiro alto con corte wide leg, ideal para looks urbanos y cómodos.',
 37294.10, 3, 3),

--Local 4
('Campera Cuero Ecológico Mujer Importada',
 'https://http2.mlstatic.com/D_NQ_NP_603957-MLA75609647316_042024-O.webp',
 'Campera Cuero Ecológico. Forrada. Cierres Niquelados.',
 59099.89, 4, 4),

 ('Vestido Fiesta Corto Escotado',
 'https://http2.mlstatic.com/D_NQ_NP_951504-MLA84988160039_052025-O.webp',
 'Vestido negro ajustado con escote en V y mangas largas, ideal para salidas nocturnas con estilo.',
 55200, 5, 4),

('Botas Mujer Zapatos Botinetas Botitas',
 'https://http2.mlstatic.com/D_NQ_NP_614736-MLA78507023892_082024-O.webp',
 'Botineta taco y plataforma en cuero ecológico. Capellada: Cuero ecológico. Horma: Normal.',
 58999, 6, 4),

----RUBRO 2----
--Local 5
('Buzo Thrasher Canguro',
 'https://th.bing.com/th/id/OIP.V3o4aCSkJ9JVpHvrfQks6gHaLH?rs=1&pid=ImgDetMain&cb=idpwebpc2',
 'Buzo Thrasher Canguro 100 % Original Negro Flames nuevo!!!! (DISTRIBUIDOR OFICIAL )',
 49999, 1, 5),

('Remera Manga Larga Liso Algodón 100%',
 'https://http2.mlstatic.com/D_NQ_NP_747610-MLA85879962299_062025-O.webp',
 'Remera básica negra de manga larga con cuello redondo, ideal para un look casual y versátil.',
 16500, 2, 5),

('Pantalon Cargo Hombre Gabardina',
 'https://http2.mlstatic.com/D_NQ_NP_870667-MLA84284049333_052025-O.webp',
 'Jogger cargo negro con múltiples bolsillos y cintura ajustable, perfecto para un estilo urbano y cómodo.',
 59999, 3, 5),

--Local 6
('Campera Hombre Reversible Abrigo',
 'https://http2.mlstatic.com/D_NQ_NP_605851-MLA82945654176_032025-O.webp',
 'Campera reversible con capucha desmontable, ideal para el invierno.',
 66138.80, 4, 6),

('Zapatilla Hombre Eco Cuero',
 'https://http2.mlstatic.com/D_NQ_NP_752216-MLA81773840951_012025-O.webp',
 'Diseño urbano, comodidad real. Estas zapatillas están confeccionadas en eco cuero con un diseño clásico y versátil.',
 54590.90, 6, 6),

('Buzo Canguro - Algodón Frisado',
 'https://http2.mlstatic.com/D_NQ_NP_916468-MLA82776538610_032025-O.webp',
 'Buzo canguro de algodón frisado con capucha y estampado vinílico de alta calidad.',
 39899, 1, 6),

--Local 7
('Remera Lisa Básica De Hombre',
 'https://http2.mlstatic.com/D_NQ_NP_614859-MLA82664353283_022025-O.webp',
 'Remera manga larga de hombre, 100% algodón. Ideal para un look casual y cómodo.',
 7000, 2, 7),

('Pantalon Jean Recto Clasico Hombre',
 'https://http2.mlstatic.com/D_NQ_NP_700708-MLA84288908089_052025-O.webp',
 'Pantalón jean clásico recto de hombre con excelente calce y confección.',
 29843.20, 3, 7),

('Campera Hombre Entallada Eco Cuero',
 'https://http2.mlstatic.com/D_NQ_NP_688472-MLA84866268670_052025-O.webp',
 'Campera de cuero sintético con cierre frontal y detalles acolchados en hombros y mangas, ideal para un look moderno.',
 92000, 4, 7),

--Local 8
('Botas Borcegos Hombres Cuero',
 'https://http2.mlstatic.com/D_NQ_NP_908334-MLA69778793801_062023-O.webp',
 'Borcegos de cuero nobuck, resistentes y versátiles. Perfectos para usar de día o de noche.',
 112000, 6, 8),

('Customs Ba Hoodie Buzo Friza',
 'https://http2.mlstatic.com/D_NQ_NP_747702-MLA86052208866_062025-O.webp',
 'Hoodie de algodón frizado, suave y abrigado. Ideal para un look urbano o deportivo.',
 51299.99, 1, 8),

('Remera Básica Slim Fit Entalladas',
 'https://http2.mlstatic.com/D_NQ_NP_907369-MLA84214664738_052025-O.webp',
 'Remera básica slim fit de algodón esmerilado, con diseño entallado y cómodo.',
 13900, 2, 8),

----RUBRO 3----
--Local 9
('Buzo Paw Patrol Patrulla Canina',
 'https://http2.mlstatic.com/D_NQ_NP_709584-MLA84489593957_052025-O.webp',
 'Buzo infantil de Paw Patrol con friza. Ideal para abrigar y acompañar las aventuras del día a día.',
 44900, 1, 9),

('Polera Rayada Morley Infantil',
 'https://http2.mlstatic.com/D_NQ_NP_661635-MLA83945114206_042025-O.webp',
 'Polera rayada para nenas en morley premium. Suave, cómoda y colorida.',
 12900, 2, 9),

('Pantalón Jogging Frisa Algodón Niños',
 'https://http2.mlstatic.com/D_NQ_NP_953809-MLA48240372428_112021-O.webp',
 'Jogging infantil liso con frisa. Confort y abrigo para todos los días.',
 17919, 3, 9),

--Local 10
('Campera Inflable Niño Escolar',
 'https://http2.mlstatic.com/D_NQ_NP_878936-MLA84220400736_052025-O.webp',
 'Campera inflable escolar con tela de nylon reforzada, ideal para el uso diario.',
 38307.34, 4, 10),

('Vestido De Jean Bebes Y Niñas',
 'https://http2.mlstatic.com/D_NQ_NP_670425-MLA81833441526_012025-O.webp',
 'Vestido de jean modelo Lara, ideal para media estación. Cómodo y resistente.',
 30210, 5, 10),

('Zapatillas Footy Plus Frozen',
 'https://http2.mlstatic.com/D_NQ_NP_795959-MLA83913535474_042025-O.webp',
 'Zapatillas con diseño de Frozen y luces LED al pisar. Cierre con velcro.',
 47309.05, 6, 10),

--Local 11
('Buzo Nena Niña Frizado',
 'https://http2.mlstatic.com/D_NQ_NP_841927-MLA83154275028_032025-O.webp',
 'Buzo frizado para niña, ideal para los días fríos.',
 19229.99, 1, 11),

('Remera Hydro Protección Solar Uv',
 'https://http2.mlstatic.com/D_NQ_NP_711445-MLA81650394973_122024-O.webp',
 'Remera infantil con protección solar UV, perfecta para actividades al aire libre.',
 27549, 2, 11),

('Babucha Frisada Guimel Kids',
 'https://http2.mlstatic.com/D_NQ_NP_916302-MLA84672840558_052025-O.webp',
 'Babucha de algodón frizado grueso, cómoda y abrigada para niñas y teens.',
 23000, 3, 11),

--Local 12
('Campera Naruto Uzumaki Disfraz',
 'https://http2.mlstatic.com/D_NQ_NP_612098-MLA51851997606_102022-O.webp',
 'Campera infantil inspirada en Naruto, con diseño bicolor naranja y negro. Ideal para fanáticos del anime.',
 31000, 4, 12),

('Witty Girls Vestido Dulzura',
 'https://http2.mlstatic.com/D_NQ_NP_683054-MLA83744941693_042025-O.webp',
 'Vestido manga larga con bordado y cinta en la cintura. Elegante y cómodo para ocasiones especiales.',
 37485, 5, 12),

('Zapatillas Spin Multicolor Niños',
 'https://http2.mlstatic.com/D_NQ_NP_808667-MLA76390539953_052024-O.webp',
 'Zapatillas multicolor con suela de goma, cómodas y resistentes para uso diario infantil.',
 47610, 6, 12),

----RUBRO 4----
--Local 13
('Collar Mujer Saturno luna y estrellas',
 'https://http2.mlstatic.com/D_NQ_NP_913539-MLA79587078912_102024-O.webp',
 'Collar con dije de Saturno, luna y estrellas. Accesorio moderno y delicado para resaltar cualquier look.',
 5305.53, 7, 13),

('Pulsera Piedra Volcánica Mancuerna',
 'https://http2.mlstatic.com/D_NQ_NP_668597-MLA82917933288_032025-O.webp',
 'Pulsera con piedras volcánicas negras y dije de mancuerna. Autoajustable, ideal para estilo deportivo o casual.',
 4200, 8, 13),

('Aros Ice Diamantes Hombre Mujer',
 'https://http2.mlstatic.com/D_NQ_NP_892647-MLA84326580332_052025-O.webp',
 'Aros con circonia cúbica brillante. Diseño clásico y elegante, perfectos para destacar con estilo.',
 11399, 9, 13),

--Local 14
('Collar Acero Quirúrgico',
 'https://http2.mlstatic.com/D_NQ_NP_771828-MLA76576950735_052024-O.webp',
 'Collar de acero quirúrgico de 5mm de ancho y 50cm de largo. Diseño resistente y moderno.',
 27399, 7, 14),

('Pulsera Gogo Onix Piedras Naturales',
 'https://http2.mlstatic.com/D_NQ_NP_610363-MLA78528279386_082024-O.webp',
 'Pulsera elástica de piedras naturales ónix de 8mm. Ideal para un estilo elegante y equilibrado.',
 23999, 8, 14),

('Par Aritos Abridores Oro 18 Kts',
 'https://http2.mlstatic.com/D_NQ_NP_635460-MLA84542461668_052025-O.webp',
 'Aritos abridores de oro 18K con diseño clásico. Perfectos para uso diario con cierre seguro y cómodo.',
 43500, 9, 14),

--Local 15
('Collar Astronauta Magnetico',
 'https://http2.mlstatic.com/D_NQ_NP_659981-MLA50277454414_062022-O.webp',
 'Hermoso collar de distancia para compartir con pareja, amigos o familiares.',
 76900, 7, 15),

('Pulsera Carrie Esclava Brazalete',
 'https://http2.mlstatic.com/D_NQ_NP_721891-MLA85726912910_062025-O.webp',
 'Pulsera esclava de acero quirúrgico ideal para muñecas femeninas. Elegante y resistente.',
 37200, 8, 15),

('Aritos Aros Gatita Luna Sailor',
 'https://http2.mlstatic.com/D_NQ_NP_622565-MLA79945915271_102024-O.webp',
 'Aritos inspirados en Sailor Moon con diseño kawaii de gatita Luna. Estilo único para fans del anime.',
 4900, 9, 15),

--Local 16
('Gargantilla Collar Cuarzo Rosa',
 'https://http2.mlstatic.com/D_NQ_NP_684084-MLA82898760409_032025-O.webp',
 'Set de gargantilla de cristal de roca y collar de cuarzo rosa con cadena de acero quirúrgico.',
 33000, 7, 16),

('Pulsera Mujer Roja Con Dije',
 'https://http2.mlstatic.com/D_NQ_NP_908071-MLA82612060338_032025-O.webp',
 'Pulsera roja con dije de mano Hamsa y terminaciones en acero quirúrgico.',
 12648.90, 8, 16),

('Aritos Estilo Abridores',
 'https://http2.mlstatic.com/D_NQ_NP_655979-MLA73128242486_122023-O.webp',
 'Aritos de plata 925 con diseño de luna labrada y cierre a presión.',
 8000, 9, 16),

----RUBRO 5----
--Local 17
('Remera Camiseta Térmica',
 'https://http2.mlstatic.com/D_NQ_NP_762450-MLA50259924974_062022-O.webp',
 'Remera térmica de manga larga con costuras reforzadas, secado rápido y tratamiento antibacterial.',
 17000, 2, 17),

('Babucha Mujer Deportivo Algodón',
 'https://http2.mlstatic.com/D_NQ_NP_983343-MLA84624181399_052025-O.webp',
 'Babucha de algodón frisa, ideal para días fríos y actividades deportivas.',
 25999, 3, 17),

('Campera Buzo Hombre Deportivo Friza',
 'https://http2.mlstatic.com/D_NQ_NP_821100-MLA85705053403_062025-O.webp',
 'Campera con capucha, friza interna y cierres termosellados, perfecta para entrenamientos en exteriores.',
 51418.80, 4, 17),

--Local 18
('Reebok Lite JP Jp Sin género',
 'https://http2.mlstatic.com/D_NQ_NP_954107-MLA80740866026_112024-O.webp',
 'Zapatillas unisex ideales para todo tipo de rutinas y actividades. Confort y estilo asegurado.',
 39598.90, 6, 18),

('Remera Deportiva Secado Rápido',
 'https://http2.mlstatic.com/D_NQ_NP_733654-MLA84358850011_052025-O.webp',
 'Remera ultraliviana de secado rápido, perfecta para entrenar con comodidad y estilo.',
 40409, 2, 18),

('Pantalón Deportivo Con Tiras',
 'https://http2.mlstatic.com/D_NQ_NP_823462-MLA86292342041_062025-O.webp',
 'Pantalón deportivo recto tipo jogger confeccionado en microfibra térmica.',
 29995, 3, 18),

--Local 19
('Campera Deportiva Mujer',
 'https://http2.mlstatic.com/D_NQ_NP_950849-MLA85935793651_062025-O.webp',
 'Campera deportiva femenina con cierre completo, ideal para climas fríos o entrenamiento.',
 38999, 4, 19),

('Topper Wind 5 Mujer Adultos',
 'https://http2.mlstatic.com/D_NQ_NP_959153-MLA76633722006_062024-O.webp',
 'Zapatillas con suela de goma, resistentes al desgaste e ideales para todo tipo de rutina.',
 59999, 6, 19),

('Remera Mujer Entrenamiento Deportiva',
 'https://http2.mlstatic.com/D_NQ_NP_673456-MLA49077014535_022022-O.webp',
 'Remera deportiva entallada, perfecta para actividades como running, crossfit y más.',
 13005.50, 2, 19),

--Local 20
('Jogging De Hombre - Pantalon Deportivo',
 'https://http2.mlstatic.com/D_NQ_NP_818419-MLA47718668642_092021-O.webp',
 'Jogging deportivo de hombre confeccionado con algodón y elastano, cómodo y resistente al uso diario.',
 30000, 3, 20),

('Campera Algodon Rustica Bolsillos',
 'https://http2.mlstatic.com/D_NQ_NP_679643-MLA85970971114_062025-O.webp',
 'Campera deportiva de algodón rústico con capucha, bolsillos y cierre frontal. Ideal para entrenar o vestir urbano.',
 32220, 4, 20),

('Topper Squat II Hombre Adultos',
 'https://http2.mlstatic.com/D_NQ_NP_615059-MLA76881581145_062024-O.webp',
 'Zapatillas de tela livianas, transpirables y versátiles para combinar con cualquier outfit deportivo.',
 49999.99, 6, 20);