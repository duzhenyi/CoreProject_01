using System;
using System.Collections.Generic;
using System.Text;

namespace DL.CodeGenerator.Models
{
    public class DBColumnTypes
    {
        public static IList<DBColumnDataType> DBColumnDataTypes => new List<DBColumnDataType>()
        {
            #region SqlServer，https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings

            new DBColumnDataType(){ DatabaseType = DBType.SqlServer, ColumnTypes = "bigint", CSharpType = "Int64"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "binary,image,varbinary(max),rowversion,timestamp,varbinary", CSharpType = "Byte[]"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "bit", CSharpType = "Boolean"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "char,nchar,text,ntext,varchar,nvarchar", CSharpType = "String"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "date,datetime,datetime2,smalldatetime", CSharpType ="DateTime"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "datetimeoffset", CSharpType ="DateTimeOffset"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "decimal,money,numeric,smallmoney", CSharpType ="Decimal"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "float", CSharpType ="Double"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "int", CSharpType ="Int32"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "real", CSharpType ="Single"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "smallint", CSharpType ="Int16"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "sql_variant", CSharpType ="Object"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "time", CSharpType ="TimeSpan"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "tinyint", CSharpType ="Byte"},
            new DBColumnDataType(){DatabaseType = DBType.SqlServer, ColumnTypes = "uniqueidentifier", CSharpType ="Guid"},

            #endregion

         

            #region MySQL，https://www.devart.com/dotconnect/mysql/docs/DataTypeMapping.html

            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "bool,boolean,bit(1),tinyint(1)", CSharpType ="Boolean"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "tinyint", CSharpType ="SByte"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "tinyint unsigned", CSharpType ="Byte"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "smallint, year", CSharpType ="Int16"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "int, integer, smallint unsigned, mediumint", CSharpType ="Int32"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "bigint, int unsigned, integer unsigned, bit", CSharpType ="Int64"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "float", CSharpType ="Single"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "double, real", CSharpType ="Double"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "decimal, numeric, dec, fixed, bigint unsigned, float unsigned, double unsigned, serial", CSharpType ="Decimal"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "date, timestamp, datetime", CSharpType ="DateTime"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "datetimeoffset", CSharpType ="DateTimeOffset"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "time", CSharpType ="TimeSpan"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "char, varchar, tinytext, text, mediumtext, longtext, set, enum, nchar, national char, nvarchar, national varchar, character varying", CSharpType ="String"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "binary, varbinary, tinyblob, blob, mediumblob, longblob, char byte", CSharpType ="Byte[]"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "geometry", CSharpType ="System.Data.Spatial.DbGeometry"},
            new DBColumnDataType(){ DatabaseType = DBType.MySQL, ColumnTypes = "geometry", CSharpType ="System.Data.Spatial.DbGeography"},

            #endregion

            #region Oracle, https://docs.oracle.com/cd/E14435_01/win.111/e10927/featUDTs.htm#CJABAEDD

            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "BFILE,BLOB,RAW,LONG RAW", CSharpType ="Byte[]"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "CHAR, NCHAR, VARCHAR2, CLOB, NCLOB,NVARCHAR2,REF,XMLTYPE,ROWID,LONG", CSharpType ="String"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "BINARY FLOAT,BINARY DOUBLE", CSharpType ="System.Byte"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "INTERVAL YEAR TO MONTH", CSharpType ="Int32"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "FLOAT,INTEGER,NUMBER", CSharpType ="Decimal"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "DATE, TIMESTAMP, TIMESTAMP WITH LOCAL TIME ZONE,TIMESTAMP WITH TIME ZONE", CSharpType ="DateTime"},
            new DBColumnDataType(){ DatabaseType = DBType.Oracle, ColumnTypes = "INTERVAL DAY TO SECOND", CSharpType ="TimeSpan"},

            #endregion

               #region PostgreSQL，http://www.npgsql.org/doc/types/basic.html

            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "boolean,bit(1)", CSharpType ="Boolean"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "smallint", CSharpType ="short"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "integer", CSharpType ="int"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "bigint", CSharpType ="long"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "real", CSharpType ="float"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "double precision", CSharpType ="Double"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "numeric,money", CSharpType ="decimal"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "text,character,character varying,citext,json,jsonb,xml,name", CSharpType ="String"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "point", CSharpType ="NpgsqlTypes.NpgsqlPoint"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "lseg", CSharpType ="NpgsqlTypes.NpgsqlLSeg"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "path", CSharpType ="NpgsqlTypes.NpgsqlPath"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "polygon", CSharpType ="NpgsqlTypes.NpgsqlPolygon"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "line", CSharpType ="NpgsqlTypes.NpgsqlLine"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "circle", CSharpType ="NpgsqlTypes.NpgsqlCircle"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "box", CSharpType ="NpgsqlTypes.NpgsqlBox"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "bit(n),bit varying", CSharpType ="BitArray"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "hstore", CSharpType ="IDictionary<string, string>"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "uuid", CSharpType ="Guid"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "cidr", CSharpType ="ValueTuple<IPAddress, int>"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "inet", CSharpType ="IPAddress"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "macaddr", CSharpType ="PhysicalAddress"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "tsquery", CSharpType ="NpgsqlTypes.NpgsqlTsQuery"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "tsvector", CSharpType ="NpgsqlTypes.NpgsqlTsVector"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "date,timestamp,timestamp with time zone,timestamp without time zone", CSharpType ="DateTime"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "interval,time", CSharpType ="TimeSpan"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "time with time zone", CSharpType ="DateTimeOffset"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "bytea", CSharpType ="Byte[]"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "oid,xid,cid", CSharpType ="uint"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "oidvector", CSharpType ="uint[]"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "char", CSharpType ="char"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "geometry", CSharpType ="NpgsqlTypes.PostgisGeometry"},
            new DBColumnDataType(){ DatabaseType = DBType.PostgreSQL, ColumnTypes = "record", CSharpType ="object[]"},

            #endregion
        };

    }
}
