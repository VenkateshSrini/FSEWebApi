-- This is a system table to track migration. This should be removed
-- or stopped from generation.
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);
--Item table
CREATE TABLE "Items" (
    "ITCODE" character(4) NOT NULL,
    "ITDESC" character varying(15) NOT NULL,
    "ITRATE" money NOT NULL,
    CONSTRAINT "Itm_Primary_key" PRIMARY KEY ("ITCODE")
);
--Supplier table
CREATE TABLE "SUPPLIER"
(
  "SUPLNO" character(4) NOT NULL,
  "SUPLNAME" character varying(15) NOT NULL,
  "SUPLADDR" character varying(40),
  CONSTRAINT suppl_primary_key PRIMARY KEY ("SUPLNO")
)

--POMaster
CREATE TABLE public."PoMasters"
(
  "PONO" character(4) NOT NULL,
  "PODATE" timestamp without time zone NOT NULL,
  "SUPLNO" character(4) NOT NULL,
  CONSTRAINT pom_primary_key PRIMARY KEY ("PONO"),
  CONSTRAINT "FK_PoMasters_SUPPLIER_SUPLNO" FOREIGN KEY ("SUPLNO")
      REFERENCES "SUPPLIER" ("SUPLNO") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
)
--PoDetails
CREATE TABLE "PoDetails"
(
  "PONO" character(4) NOT NULL,
  "ITCODE" character(4) NOT NULL,
  "QTY" integer NOT NULL,
  CONSTRAINT pod_primary_key PRIMARY KEY ("PONO", "ITCODE"),
  CONSTRAINT "FK_PoDetails_Items_ITCODE" FOREIGN KEY ("ITCODE")
      REFERENCES "Items" ("ITCODE") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE,
  CONSTRAINT "FK_PoDetails_PoMasters_PONO" FOREIGN KEY ("PONO")
      REFERENCES "PoMasters" ("PONO") MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
)
