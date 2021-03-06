--------------------------------------------
--------------- Dump details ---------------
--------------------------------------------
-- Original file: C:\Users\jrozap\Documents\Steel Design Co\Analisis Precios Unitarios\APV 32-bit\APV2020.NET\APV2020\APV2020\MasterAPV.MDB
-- Dump date: 07-07-2020 17:14:32
--------------------------------------------

-- creating table
CREATE TABLE APUObr (
	`bno-mob-apu` DOUBLE,
	`can-ana-apu` DOUBLE,
	`can-apr-apu` DOUBLE,
	`ceq-apu-tot` DOUBLE,
	`cnt-eqp-apu` DOUBLE,
	`cnt-mat-apu` DOUBLE,
	`cnt-mob-apu` DOUBLE,
	`cnt-trn-apu` DOUBLE,
	`cod-eqp-apu` VARCHAR (8),
	`cod-mat-apu` VARCHAR (8),
	`cod-mob-apu` VARCHAR (5),
	CodNormaCov VARCHAR (14),
	`cod-obr-apu` VARCHAR (16),
	`cod-par-m` VARCHAR (14),
	`cod-trn-apu` VARCHAR (4),
	`cst-eqp-apu` DOUBLE,
	`cst-mat-apu` DOUBLE,
	`cst-trn-apu` DOUBLE,
	`dep-eqp-apu` DOUBLE,
	Dias DOUBLE,
	`fcas-apu` DOUBLE,
	`fin-obr-apu` DOUBLE,
	`hor-hmb-apu` DOUBLE,
	`id-eqp-apu` VARCHAR (4),
	`id-mat-apu` VARCHAR (3),
	`id-mob-apu` VARCHAR (4),
	`id-trn-apu` VARCHAR (2),
	`iva-apu` DOUBLE,
	`jrn-mob-apu` DOUBLE,
	NumeroControl DOUBLE,
	`num-par-apu` DOUBLE,
	PartidaTexto VARCHAR (14),
	`prc-adm-apu` DOUBLE,
	`prc-utl-apu` DOUBLE,
	`ptot-pr-apu` DOUBLE,
	`pun-adp-apu` DOUBLE,
	`pun-ana-apu` DOUBLE,
	`pun-par-apu` DOUBLE,
	`rec-typ-apu` VARCHAR (2),
	`ren-par-apu` DOUBLE,
	`tit-is-apu` VARCHAR (5),
	`tot-bno-apu` DOUBLE,
	`tot-gen-apu` DOUBLE,
	`tot-jrn-apu` DOUBLE,
	`tot-mat-apu` DOUBLE,
	`tot-trn-apu` DOUBLE,
	`und-mat-apu` DOUBLE,
	`und-par-apu` VARCHAR (5),
	`und-trn-apu` DOUBLE
);

-- creating table
CREATE TABLE Computos (
	AfectanBonos VARCHAR (5),
	Bono DOUBLE,
	BsTotal DOUBLE,
	BsUnidadDia DOUBLE,
	BsUnitario DOUBLE,
	Cantidad DOUBLE,
	CantidadDelAnalisis DOUBLE,
	CantidadDePartida DOUBLE,
	CantidadPersonas DOUBLE,
	CanTotal DOUBLE,
	CantTotPersonas DOUBLE,
	CanUnitario DOUBLE,
	Codigo DOUBLE,
	CodObr VARCHAR (16),
	Costo DOUBLE,
	Depreciacion DOUBLE,
	Descripcion VARCHAR (54),
	Dias DOUBLE,
	DiasDObr DOUBLE,
	div_cantidad VARCHAR (5),
	DivididoCantMat VARCHAR (4),
	DivididoCantMatTrans VARCHAR (5),
	DivididoCantTrans VARCHAR (5),
	HorasHombre DOUBLE,
	Jornada DOUBLE,
	Jornal DOUBLE,
	JornalBono DOUBLE,
	NumeroPartida DOUBLE,
	Porcentaje DOUBLE,
	Prestaciones DOUBLE,
	Prestaciones1 DOUBLE,
	RecType VARCHAR (3),
	Rendimiento DOUBLE,
	SalarioUnidad DOUBLE,
	TotalBono DOUBLE,
	TotalJornal DOUBLE,
	TotalJornalBono DOUBLE,
	TotalSalario DOUBLE,
	Unidad VARCHAR (4)
);

-- creating table
CREATE TABLE ConfGenAPV (
	Administracion DOUBLE,
	Base_EQP VARCHAR (9),
	Base_MAT VARCHAR (14),
	Base_MO VARCHAR (14),
	Base_Partidas VARCHAR (14),
	Cant_Analisis DOUBLE,
	Cant_Part DOUBLE,
	CIV_Firma VARCHAR (6),
	CIV_Revisa VARCHAR (6),
	Dig_Rend DOUBLE,
	Div_Mat VARCHAR (1),
	FCAS DOUBLE,
	FechaB_EQP DATETIME,
	FechaB_MAT DATETIME,
	FechaB_MO DATETIME,
	FechaB_PART DATETIME,
	IngFirma VARCHAR (30),
	IngRevisa VARCHAR (30),
	IVA DOUBLE,
	Moneda_P VARCHAR (4),
	Moneda_S VARCHAR (3),
	Obra VARCHAR (7),
	Propietario VARCHAR (1),
	Rendimiento DOUBLE,
	Utilidad DOUBLE
);

-- creating table
CREATE TABLE Configuracion (
	Administracion DOUBLE,
	AfectanPrestaciones VARCHAR (1),
	BaseEquiposUsar VARCHAR (27),
	BaseManoObraUsar VARCHAR (18),
	BaseMaterialesUsar VARCHAR (27),
	CantidadDelAnalisis DOUBLE,
	CantidadDePartida DOUBLE,
	CodigoInsumosEnAnalisis VARCHAR (1),
	DigitosRendimiento DOUBLE,
	DividirMateriales VARCHAR (1),
	EstiloDet DOUBLE,
	EstiloEnc DOUBLE,
	FCAS DOUBLE,
	HorasJornadaDiaria DOUBLE,
	ImpArchivo VARCHAR (54),
	ImpBuscarEnArchivo DOUBLE,
	ImpCopiaInsumos DOUBLE,
	ImpEstructura1 DOUBLE,
	ImpEstructura2 DOUBLE,
	ImpEstructura3 DOUBLE,
	ImpEstructura4 DOUBLE,
	ImpEstructura5 DOUBLE,
	ImpFijarArchivo DOUBLE,
	ImpGenerales1 DOUBLE,
	ImpGenerales2 DOUBLE,
	ImpGenerales3 DOUBLE,
	ImpGenerales4 DOUBLE,
	ImpGenerales5 DOUBLE,
	ImpGenerales6 DOUBLE,
	ImpProceso DOUBLE,
	ImpresionAPV VARCHAR (4),
	ImpuestoVentas DOUBLE,
	LetraDet VARCHAR (15),
	LetraEnc VARCHAR (15),
	LeydelTrabajo DOUBLE,
	MargenInf DOUBLE,
	MargenSup DOUBLE,
	MesEquiposUsar DOUBLE,
	MesManoObraUsar DOUBLE,
	MesMaterialesUsar DOUBLE,
	Moneda_P VARCHAR (3),
	Moneda_S VARCHAR (3),
	MonedaUtilizar VARCHAR (3),
	Obra VARCHAR (9),
	ObraReciente1 VARCHAR (74),
	ObraReciente10 VARCHAR (57),
	ObraReciente2 VARCHAR (66),
	ObraReciente3 VARCHAR (79),
	ObraReciente4 VARCHAR (84),
	ObraReciente5 VARCHAR (77),
	ObraReciente6 VARCHAR (70),
	ObraReciente7 VARCHAR (64),
	ObraReciente8 VARCHAR (59),
	ObraReciente9 VARCHAR (67),
	PorcentajeEnAnalisis VARCHAR (1),
	PreciosDistintosACalculados VARCHAR (1),
	Rendimiento DOUBLE,
	`Tama�oDet` DOUBLE,
	`Tama�oEnc` DOUBLE,
	TipoImpresora VARCHAR (1),
	TipoImpuestoCargado DOUBLE,
	TipoRendimiento VARCHAR (1),
	TxTAdministracion VARCHAR (32),
	TxTIVA VARCHAR (30),
	TxTJornadaDiaria VARCHAR (23),
	TxTTrabajo VARCHAR (12),
	TxTUtilidad VARCHAR (8),
	UltimaObra1 VARCHAR (1),
	UltimaObra2 VARCHAR (1),
	UltimaObra3 VARCHAR (1),
	Utilidad DOUBLE
);

-- creating table
CREATE TABLE Costos (
	Codigo_CAT_P DOUBLE,
	Codigo_CAT_SEC DOUBLE,
	Codigo_CAT_SEC1 DOUBLE,
	Codigo_Renglon_P DOUBLE,
	Codigo_Renglon_S VARCHAR (1),
	Codigo_SCAT_P DOUBLE,
	Codigo_SCAT_SEC VARCHAR (1),
	Descripcion_CAT_P VARCHAR (32),
	Descripcion_CAT_SEC VARCHAR (12),
	Descripcion_CAT_SEC1 VARCHAR (12),
	Descripcion_Renglon_P VARCHAR (30),
	Descripcion_Renglon_S VARCHAR (1),
	Descripcion_SCAT_P VARCHAR (21),
	Descripcion_SCAT_SEC VARCHAR (1)
);

-- creating table
CREATE TABLE EqpImpL (
	CodEqpLULO VARCHAR (8),
	Codigo DOUBLE,
	Depreciacion DOUBLE,
	DeprecMes1 DOUBLE,
	DeprecMes10 DOUBLE,
	DeprecMes11 DOUBLE,
	DeprecMes12 DOUBLE,
	DeprecMes2 DOUBLE,
	DeprecMes3 DOUBLE,
	DeprecMes4 DOUBLE,
	DeprecMes5 DOUBLE,
	DeprecMes6 DOUBLE,
	DeprecMes7 DOUBLE,
	DeprecMes8 DOUBLE,
	DeprecMes9 DOUBLE,
	Descripcion VARCHAR (41),
	DiferenciaDepreciacion VARCHAR (1),
	DiferenciaPrecio VARCHAR (1),
	Fecha DATETIME,
	ID DOUBLE,
	PorcentajeDepreciacion VARCHAR (1),
	PorcentajeDiferencia VARCHAR (1),
	PrecioDia DOUBLE,
	PrecioEqp DOUBLE,
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes102daMoneda DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes112daMoneda DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes122daMoneda DOUBLE,
	PrecioMes12daMoneda DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes22daMoneda DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes32daMoneda DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes42daMoneda DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes52daMoneda DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes62daMoneda DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes72daMoneda DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes82daMoneda DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioMes92daMoneda DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Suplidor VARCHAR (1),
	Tipo DOUBLE,
	Unidad VARCHAR (3)
);

-- creating table
CREATE TABLE EqpImpLBsS (
	CodEqpLULO VARCHAR (8),
	Codigo DOUBLE,
	Depreciacion DOUBLE,
	DeprecMes1 DOUBLE,
	DeprecMes10 DOUBLE,
	DeprecMes11 DOUBLE,
	DeprecMes12 DOUBLE,
	DeprecMes2 DOUBLE,
	DeprecMes3 DOUBLE,
	DeprecMes4 DOUBLE,
	DeprecMes5 DOUBLE,
	DeprecMes6 DOUBLE,
	DeprecMes7 DOUBLE,
	DeprecMes8 DOUBLE,
	DeprecMes9 DOUBLE,
	Descripcion VARCHAR (40),
	DiferenciaDepreciacion DOUBLE,
	DiferenciaPrecio DOUBLE,
	Fecha DATETIME,
	ID DOUBLE,
	PorcentajeDepreciacion DOUBLE,
	PorcentajeDiferencia DOUBLE,
	PrecioDia DOUBLE,
	PrecioEqp DOUBLE,
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes102daMoneda DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes112daMoneda DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes122daMoneda DOUBLE,
	PrecioMes12daMoneda DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes22daMoneda DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes32daMoneda DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes42daMoneda DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes52daMoneda DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes62daMoneda DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes72daMoneda DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes82daMoneda DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioMes92daMoneda DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Suplidor VARCHAR (1),
	Tipo DOUBLE,
	Unidad VARCHAR (3)
);

-- creating table
CREATE TABLE EquipoComp (
	Cantidad DOUBLE,
	Codigo VARCHAR (6),
	CodInterno VARCHAR (7),
	Depreciacion DOUBLE,
	Descripcion VARCHAR (55),
	ID DOUBLE,
	Lista DOUBLE,
	Precio DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE IndicesPAC (
	AGRUPACION VARCHAR (44),
	GRUPO DOUBLE,
	IDENTIFICACION VARCHAR (2),
	MES1 DOUBLE,
	MES10 DOUBLE,
	MES11 DOUBLE,
	MES12 DOUBLE,
	MES2 DOUBLE,
	MES3 DOUBLE,
	MES4 DOUBLE,
	MES5 DOUBLE,
	MES6 DOUBLE,
	MES7 DOUBLE,
	MES8 DOUBLE,
	MES9 DOUBLE,
	ORDEN DOUBLE,
	YEAR DOUBLE
);

-- creating table
CREATE TABLE ListaEqp (
	DBName VARCHAR (30),
	DBPath VARCHAR (150),
	ListDate DATETIME,
	ListDes VARCHAR (60),
	ListName VARCHAR (30),
	TableN VARCHAR (30)
);

-- creating table
CREATE TABLE ListaMat (
	DBName VARCHAR (13),
	DBPath VARCHAR (131),
	ListDate DATETIME,
	ListDes VARCHAR (34),
	ListName VARCHAR (22),
	TableN VARCHAR (14)
);

-- creating table
CREATE TABLE ListaMdO (
	DBName VARCHAR (13),
	DBPath VARCHAR (131),
	ListDate DATETIME,
	ListDes VARCHAR (34),
	ListName VARCHAR (24),
	TableN VARCHAR (14)
);

-- creating table
CREATE TABLE ListaTran (
	DBName VARCHAR (13),
	DBPath VARCHAR (131),
	ListDate DATETIME,
	ListDes VARCHAR (35),
	ListName VARCHAR (22),
	TableN VARCHAR (11)
);

-- creating table
CREATE TABLE MasterEqp (
	Codigo VARCHAR (8),
	Depreciacion DOUBLE,
	Descripcion VARCHAR (55),
	Fecha DATETIME,
	ID DOUBLE,
	Lista VARCHAR (2),
	PrecioBSS DOUBLE,
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioUSD DOUBLE,
	Suplidor VARCHAR (44),
	Tipo DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE MasterManoObra (
	Bono DOUBLE,
	Bono2daMoneda DOUBLE,
	BonoMes1 DOUBLE,
	BonoMes10 DOUBLE,
	BonoMes102daMoneda DOUBLE,
	BonoMes11 DOUBLE,
	BonoMes112daMoneda DOUBLE,
	BonoMes12 DOUBLE,
	BonoMes122daMoneda DOUBLE,
	BonoMes12daMoneda DOUBLE,
	BonoMes2 DOUBLE,
	BonoMes22daMoneda DOUBLE,
	BonoMes3 DOUBLE,
	BonoMes32daMoneda DOUBLE,
	BonoMes4 DOUBLE,
	BonoMes42daMoneda DOUBLE,
	BonoMes5 DOUBLE,
	BonoMes52daMoneda DOUBLE,
	BonoMes6 DOUBLE,
	BonoMes62daMoneda DOUBLE,
	BonoMes7 DOUBLE,
	BonoMes72daMoneda DOUBLE,
	BonoMes8 DOUBLE,
	BonoMes82daMoneda DOUBLE,
	BonoMes9 DOUBLE,
	BonoMes92daMoneda DOUBLE,
	Codigo VARCHAR (8),
	Descripcion VARCHAR (55),
	DiferenciaBono DOUBLE,
	DiferenciaJornal DOUBLE,
	Fecha DATETIME,
	ID DOUBLE,
	Jornal DOUBLE,
	Jornal2daMoneda DOUBLE,
	JornalMes1 DOUBLE,
	JornalMes10 DOUBLE,
	JornalMes102daMoneda DOUBLE,
	JornalMes11 DOUBLE,
	JornalMes112daMoneda DOUBLE,
	JornalMes12 DOUBLE,
	JornalMes122daMoneda DOUBLE,
	JornalMes12daMoneda DOUBLE,
	JornalMes2 DOUBLE,
	JornalMes22daMoneda DOUBLE,
	JornalMes3 DOUBLE,
	JornalMes32daMoneda DOUBLE,
	JornalMes4 DOUBLE,
	JornalMes42daMoneda DOUBLE,
	JornalMes5 DOUBLE,
	JornalMes52daMoneda DOUBLE,
	JornalMes6 DOUBLE,
	JornalMes62daMoneda DOUBLE,
	JornalMes7 DOUBLE,
	JornalMes72daMoneda DOUBLE,
	JornalMes8 DOUBLE,
	JornalMes82daMoneda DOUBLE,
	JornalMes9 DOUBLE,
	JornalMes92daMoneda DOUBLE,
	PorcentajeBono DOUBLE,
	PorcentajeJornal DOUBLE,
	Tipo DOUBLE,
	Unidad VARCHAR (4)
);

-- creating table
CREATE TABLE MasterMaterial (
	Codigo VARCHAR (9),
	Descripcion VARCHAR (56),
	Diferencia DOUBLE,
	Fecha DATETIME,
	GrupoBCV DOUBLE,
	ID DOUBLE,
	PorcentajeDiferencia DOUBLE,
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes102daMoneda DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes112daMoneda DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes122daMoneda DOUBLE,
	PrecioMes12daMoneda DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes22daMoneda DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes32daMoneda DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes42daMoneda DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes52daMoneda DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes62daMoneda DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes72daMoneda DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes82daMoneda DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioMes92daMoneda DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Suplidor VARCHAR (48),
	Tipo DOUBLE,
	Unidad VARCHAR (7)
);

-- creating table
CREATE TABLE MasterPartBsS (
	CantridadPartida DOUBLE,
	Codigo DOUBLE,
	CodigoCovenin VARCHAR (15),
	CodParL VARCHAR (8),
	Descripcion1 VARCHAR (70),
	Descripcion2 VARCHAR (70),
	Descripcion3 VARCHAR (70),
	Fecha DATETIME,
	ID DOUBLE,
	MiniDescripcion VARCHAR (60),
	PrecioAdoptado DOUBLE,
	PrecioAdoptado2Mon DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2Mon DOUBLE,
	Rendimiento DOUBLE,
	Unidad VARCHAR (7)
);

-- creating table
CREATE TABLE MasterPartidas (
	CodigoCovenin VARCHAR (14),
	CodParL VARCHAR (14),
	Descripcion1 VARCHAR (72),
	Descripcion2 VARCHAR (72),
	Descripcion3 VARCHAR (70),
	Fecha DATETIME,
	ID DOUBLE,
	MiniDescripcion VARCHAR (102),
	PrecioAdoptado DOUBLE,
	PrecioAdoptado2Mon DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2Mon DOUBLE,
	Rendimiento DOUBLE,
	Unidad VARCHAR (7)
);

-- creating table
CREATE TABLE MasterTrans (
	Codigo VARCHAR (6),
	Descripcion VARCHAR (58),
	Fecha DATETIME,
	ID DOUBLE,
	Lista DOUBLE,
	PorcApp DOUBLE,
	PrecioBSS DOUBLE,
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioUSD DOUBLE,
	Suplidor VARCHAR (1),
	Tipo DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE materialComp (
	Cantidad DOUBLE,
	CodigoMatC VARCHAR (7),
	CodMasterM VARCHAR (8),
	Descripcion VARCHAR (55),
	Lista DOUBLE,
	Precio DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE MatImpL (
	Codigo DOUBLE,
	CodMatL VARCHAR (8),
	Descripcion VARCHAR (40),
	Diferencia VARCHAR (1),
	Fecha DATETIME,
	GrupoBCV DOUBLE,
	ID DOUBLE,
	PorcentajeDiferencia VARCHAR (1),
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes102daMoneda DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes112daMoneda DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes122daMoneda DOUBLE,
	PrecioMes12daMoneda DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes22daMoneda DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes32daMoneda DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes42daMoneda DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes52daMoneda DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes62daMoneda DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes72daMoneda DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes82daMoneda DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioMes92daMoneda DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Suplidor VARCHAR (40),
	Tipo DOUBLE,
	Unidad VARCHAR (6)
);

-- creating table
CREATE TABLE MatImpLBsS (
	Codigo DOUBLE,
	CodMatLULO VARCHAR (8),
	Descripcion VARCHAR (40),
	Diferencia DOUBLE,
	Fecha DATETIME,
	GrupoBCV DOUBLE,
	ID DOUBLE,
	PorcentajeDiferencia VARCHAR (1),
	PrecioMes1 DOUBLE,
	PrecioMes10 DOUBLE,
	PrecioMes102daMoneda DOUBLE,
	PrecioMes11 DOUBLE,
	PrecioMes112daMoneda DOUBLE,
	PrecioMes12 DOUBLE,
	PrecioMes122daMoneda DOUBLE,
	PrecioMes12daMoneda DOUBLE,
	PrecioMes2 DOUBLE,
	PrecioMes22daMoneda DOUBLE,
	PrecioMes3 DOUBLE,
	PrecioMes32daMoneda DOUBLE,
	PrecioMes4 DOUBLE,
	PrecioMes42daMoneda DOUBLE,
	PrecioMes5 DOUBLE,
	PrecioMes52daMoneda DOUBLE,
	PrecioMes6 DOUBLE,
	PrecioMes62daMoneda DOUBLE,
	PrecioMes7 DOUBLE,
	PrecioMes72daMoneda DOUBLE,
	PrecioMes8 DOUBLE,
	PrecioMes82daMoneda DOUBLE,
	PrecioMes9 DOUBLE,
	PrecioMes92daMoneda DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Suplidor VARCHAR (40),
	Tipo DOUBLE,
	Unidad VARCHAR (6)
);

-- creating table
CREATE TABLE MOcomp (
	Bono DOUBLE,
	Bono2daMoneda DOUBLE,
	Cantidad DOUBLE,
	CodigoSimple VARCHAR (6),
	Descripcion VARCHAR (47),
	DescripcionSimple VARCHAR (43),
	ID DOUBLE,
	Jornal DOUBLE,
	Jornal2daMoneda DOUBLE,
	TotalBono DOUBLE,
	TotalBono2daMoneda DOUBLE,
	TotalJornal DOUBLE,
	TotalJornal2daMoneda DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE MOImpL (
	Bono DOUBLE,
	Bono2daMoneda DOUBLE,
	BonoMes1 DOUBLE,
	BonoMes10 DOUBLE,
	BonoMes102daMoneda DOUBLE,
	BonoMes11 DOUBLE,
	BonoMes112daMoneda DOUBLE,
	BonoMes12 DOUBLE,
	BonoMes122daMoneda DOUBLE,
	BonoMes12daMoneda DOUBLE,
	BonoMes2 DOUBLE,
	BonoMes22daMoneda DOUBLE,
	BonoMes3 DOUBLE,
	BonoMes32daMoneda DOUBLE,
	BonoMes4 DOUBLE,
	BonoMes42daMoneda DOUBLE,
	BonoMes5 DOUBLE,
	BonoMes52daMoneda DOUBLE,
	BonoMes6 DOUBLE,
	BonoMes62daMoneda DOUBLE,
	BonoMes7 DOUBLE,
	BonoMes72daMoneda DOUBLE,
	BonoMes8 DOUBLE,
	BonoMes82daMoneda DOUBLE,
	BonoMes9 DOUBLE,
	BonoMes92daMoneda DOUBLE,
	Codigo DOUBLE,
	CodMOLULO VARCHAR (8),
	Descripcion VARCHAR (40),
	DiferenciaBono DOUBLE,
	DiferenciaJornal DOUBLE,
	Fecha DATETIME,
	ID DOUBLE,
	Jornal DOUBLE,
	Jornal2daMoneda DOUBLE,
	JornalMes1 DOUBLE,
	JornalMes10 DOUBLE,
	JornalMes102daMoneda DOUBLE,
	JornalMes11 DOUBLE,
	JornalMes112daMoneda DOUBLE,
	JornalMes12 DOUBLE,
	JornalMes122daMoneda DOUBLE,
	JornalMes12daMoneda DOUBLE,
	JornalMes2 DOUBLE,
	JornalMes22daMoneda DOUBLE,
	JornalMes3 DOUBLE,
	JornalMes32daMoneda DOUBLE,
	JornalMes4 DOUBLE,
	JornalMes42daMoneda DOUBLE,
	JornalMes5 DOUBLE,
	JornalMes52daMoneda DOUBLE,
	JornalMes6 DOUBLE,
	JornalMes62daMoneda DOUBLE,
	JornalMes7 DOUBLE,
	JornalMes72daMoneda DOUBLE,
	JornalMes8 DOUBLE,
	JornalMes82daMoneda DOUBLE,
	JornalMes9 DOUBLE,
	JornalMes92daMoneda DOUBLE,
	PorcentajeBono DOUBLE,
	PorcentajeJornal DOUBLE,
	Tipo DOUBLE,
	Unidad VARCHAR (3)
);

-- creating table
CREATE TABLE MOImpLBsS (
	Bono DOUBLE,
	Bono2daMoneda DOUBLE,
	BonoMes1 DOUBLE,
	BonoMes10 DOUBLE,
	BonoMes102daMoneda DOUBLE,
	BonoMes11 DOUBLE,
	BonoMes112daMoneda DOUBLE,
	BonoMes12 DOUBLE,
	BonoMes122daMoneda DOUBLE,
	BonoMes12daMoneda DOUBLE,
	BonoMes2 DOUBLE,
	BonoMes22daMoneda DOUBLE,
	BonoMes3 DOUBLE,
	BonoMes32daMoneda DOUBLE,
	BonoMes4 DOUBLE,
	BonoMes42daMoneda DOUBLE,
	BonoMes5 DOUBLE,
	BonoMes52daMoneda DOUBLE,
	BonoMes6 DOUBLE,
	BonoMes62daMoneda DOUBLE,
	BonoMes7 DOUBLE,
	BonoMes72daMoneda DOUBLE,
	BonoMes8 DOUBLE,
	BonoMes82daMoneda DOUBLE,
	BonoMes9 DOUBLE,
	BonoMes92daMoneda DOUBLE,
	Codigo DOUBLE,
	CodMOLULO VARCHAR (8),
	Descripcion VARCHAR (40),
	DiferenciaBono DOUBLE,
	DiferenciaJornal DOUBLE,
	Fecha DATETIME,
	ID DOUBLE,
	Jornal DOUBLE,
	Jornal2daMoneda DOUBLE,
	JornalMes1 DOUBLE,
	JornalMes10 DOUBLE,
	JornalMes102daMoneda DOUBLE,
	JornalMes11 DOUBLE,
	JornalMes112daMoneda DOUBLE,
	JornalMes12 DOUBLE,
	JornalMes122daMoneda DOUBLE,
	JornalMes12daMoneda DOUBLE,
	JornalMes2 DOUBLE,
	JornalMes22daMoneda DOUBLE,
	JornalMes3 DOUBLE,
	JornalMes32daMoneda DOUBLE,
	JornalMes4 DOUBLE,
	JornalMes42daMoneda DOUBLE,
	JornalMes5 DOUBLE,
	JornalMes52daMoneda DOUBLE,
	JornalMes6 DOUBLE,
	JornalMes62daMoneda DOUBLE,
	JornalMes7 DOUBLE,
	JornalMes72daMoneda DOUBLE,
	JornalMes8 DOUBLE,
	JornalMes82daMoneda DOUBLE,
	JornalMes9 DOUBLE,
	JornalMes92daMoneda DOUBLE,
	PorcentajeBono DOUBLE,
	PorcentajeJornal DOUBLE,
	Tipo DOUBLE,
	Unidad VARCHAR (3)
);

-- creating table
CREATE TABLE MPartidas (
	CodigoCovenin VARCHAR (14),
	CodParL VARCHAR (14),
	Descripcion1 VARCHAR (72),
	Descripcion2 VARCHAR (72),
	Descripcion3 VARCHAR (70),
	F15 VARCHAR (1),
	F16 VARCHAR (1),
	F17 VARCHAR (1),
	F18 VARCHAR (1),
	F19 VARCHAR (1),
	F20 VARCHAR (1),
	F21 VARCHAR (14),
	F22 VARCHAR (2),
	F23 VARCHAR (4),
	F24 VARCHAR (4),
	F25 VARCHAR (3),
	F26 VARCHAR (13),
	Fecha DATETIME,
	ID DOUBLE,
	MiniDescripcion VARCHAR (61),
	PrecioAdoptado DOUBLE,
	PrecioAdoptado2Mon DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2Mon DOUBLE,
	Rendimiento DOUBLE,
	Unidad VARCHAR (7)
);

-- creating table
CREATE TABLE obras (
	Administracion DOUBLE,
	APO DOUBLE,
	BaseEQAPO VARCHAR (50),
	BaseEQCIV VARCHAR (36),
	BaseEQLulo VARCHAR (47),
	BaseMOAPO VARCHAR (50),
	BaseMOCIV VARCHAR (36),
	BaseMOLulo VARCHAR (47),
	BaseMTAPO VARCHAR (50),
	BaseMTCIV VARCHAR (36),
	BaseMTLulo VARCHAR (47),
	BasePRAPO VARCHAR (50),
	BasePRCIV VARCHAR (36),
	BasePRLulo VARCHAR (47),
	BaseTRAPO VARCHAR (50),
	BaseTRCIV VARCHAR (36),
	Cant_Analisis DOUBLE,
	Cant_Part DOUBLE,
	CIV DOUBLE,
	CIV_Firma DOUBLE,
	CIV_Revisa DOUBLE,
	`cod-obr` VARCHAR (16),
	`desc-obr` VARCHAR (54),
	Dig_Rend DOUBLE,
	Div_Mat VARCHAR (1),
	FCAS DOUBLE,
	FecBEQAPO DATETIME,
	FecBEQCIV DATETIME,
	FecBEQLulo DATETIME,
	FecBMOAPO DATETIME,
	FecBMOCIV DATETIME,
	FecBMOLulo DATETIME,
	FecBMTAPO DATETIME,
	FecBMTCIV DATETIME,
	FecBMTLulo DATETIME,
	FecBPRAPO DATETIME,
	FecBPRCIV DATETIME,
	FecBPRLulo DATETIME,
	FecBTRAPO DATETIME,
	FecBTRCIV DATETIME,
	IngFirma VARCHAR (13),
	IngRevisa VARCHAR (10),
	IVA DOUBLE,
	LULO DOUBLE,
	Moneda_P VARCHAR (4),
	Moneda_S VARCHAR (3),
	Obra VARCHAR (7),
	Propietario VARCHAR (3),
	Rendimiento DOUBLE,
	Utilidad DOUBLE
);

-- creating table
CREATE TABLE Part300 (
	Administracion DOUBLE,
	CantidadDelAnalisis DOUBLE,
	CantidadDePartida DOUBLE,
	CodigoCovenin VARCHAR (13),
	CodPart VARCHAR (13),
	Descripcion1 VARCHAR (206),
	Descripcion2 VARCHAR (1),
	Descripcion3 VARCHAR (1),
	Dias DOUBLE,
	EsTitulo VARCHAR (5),
	Financiamiento DOUBLE,
	HorasHombre DOUBLE,
	ImpuestoCargadoA DOUBLE,
	ImpuestoVentas DOUBLE,
	MiniDescripcion VARCHAR (50),
	NumeroControl DOUBLE,
	NumeroPartida DOUBLE,
	PartidaTexto DOUBLE,
	porcenlEquipos DOUBLE,
	porcenlManodeObra DOUBLE,
	porcenmateriales DOUBLE,
	porcenTransporte DOUBLE,
	PrecioAdoptado DOUBLE,
	PrecioAdoptado2daMoneda DOUBLE,
	PrecioTotal DOUBLE,
	PrecioTotal2daMoneda DOUBLE,
	PrecioUnitario DOUBLE,
	PrecioUnitario2daMoneda DOUBLE,
	Prestaciones DOUBLE,
	Rendimiento DOUBLE,
	TotalEquipos DOUBLE,
	TotalGeneral DOUBLE,
	totalManodeObra DOUBLE,
	totalmateriales DOUBLE,
	TotalTransporte DOUBLE,
	Unidad VARCHAR (5),
	Utilidad DOUBLE
);

-- creating table
CREATE TABLE PartEqC (
	Cantidad DOUBLE,
	Codigo VARCHAR (6),
	CodInterno VARCHAR (7),
	Depreciacion DOUBLE,
	Descripcion VARCHAR (55),
	ID DOUBLE,
	Lista DOUBLE,
	Precio DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE PartidasCOVENIN (
	CodigoCovenin VARCHAR (13),
	Descripcion1 VARCHAR (75),
	Descripcion2 VARCHAR (73),
	Descripcion3 VARCHAR (70),
	EsTitulo VARCHAR (5),
	MiniDescripcion VARCHAR (51),
	PcrEqp DOUBLE,
	PrcMat DOUBLE,
	PrcMdO DOUBLE,
	PrcTrans DOUBLE,
	PUBsS DOUBLE,
	PUUSD DOUBLE,
	Rendimiento DOUBLE,
	TotEqp DOUBLE,
	TotMat DOUBLE,
	TotMdO DOUBLE,
	TotTrans DOUBLE,
	Unidad VARCHAR (5)
);

-- creating table
CREATE TABLE RelCOVENIN (
	CodCovN VARCHAR (13),
	CodEqp VARCHAR (5),
	CodMat VARCHAR (8),
	CodMdO VARCHAR (5),
	CodPartAPP VARCHAR (13),
	CodTrans VARCHAR (1),
	RegTypeNC VARCHAR (2)
);

-- creating table
CREATE TABLE RelMatPart (
	CodMat VARCHAR (8),
	CodPar VARCHAR (8),
	CovPar VARCHAR (13),
	Descri VARCHAR (255),
	DesMat VARCHAR (42),
	NumPar DOUBLE
);

-- creating table
CREATE TABLE Valuaciones (
	AumentoEnPeriodo DOUBLE,
	CantidadAcumulada DOUBLE,
	CantidadAnterior DOUBLE,
	CantidadAumentoAcumulado DOUBLE,
	CantidadDePartida DOUBLE,
	CantidadPeriodo DOUBLE,
	CodigoCovenin VARCHAR (14),
	CodObr VARCHAR (16),
	CodPart VARCHAR (14),
	Descripcion1 VARCHAR (70),
	Descripcion2 VARCHAR (13),
	Descripcion3 VARCHAR (1),
	Id DOUBLE,
	MiniDescripcion VARCHAR (35),
	NumeroPartida DOUBLE,
	PartidaTexto VARCHAR (14),
	Periodo VARCHAR (4),
	PrecioTotal DOUBLE,
	PrecioUnitario DOUBLE,
	TotalAcumulado DOUBLE,
	TotalAnterior DOUBLE,
	TotalAumentoAcumulado DOUBLE,
	TotalGeneral DOUBLE,
	TotalPeriodo DOUBLE,
	Unidad VARCHAR (3)
);

