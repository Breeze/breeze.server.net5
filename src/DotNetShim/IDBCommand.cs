namespace System.Data
{
#if DNXCORE50
    using Collections;

    // Summary:
    //     Represents an SQL statement that is executed while connected to a data source,
    //     and is implemented by .NET Framework data providers that access relational
    //     databases.
    public interface IDbCommand : IDisposable
    {
        // Summary:
        //     Gets or sets the text command to run against the data source.
        //
        // Returns:
        //     The text command to execute. The default value is an empty string ("").
        string CommandText { get; set; }
        //
        // Summary:
        //     Gets or sets the wait time before terminating the attempt to execute a command
        //     and generating an error.
        //
        // Returns:
        //     The time (in seconds) to wait for the command to execute. The default value
        //     is 30 seconds.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The property value assigned is less than 0.
        int CommandTimeout { get; set; }
        //
        // Summary:
        //     Indicates or specifies how the System.Data.IDbCommand.CommandText property
        //     is interpreted.
        //
        // Returns:
        //     One of the System.Data.CommandType values. The default is Text.
        CommandType CommandType { get; set; }
        //
        // Summary:
        //     Gets or sets the System.Data.IDbConnection used by this instance of the System.Data.IDbCommand.
        //
        // Returns:
        //     The connection to the data source.
        IDbConnection Connection { get; set; }
        //
        // Summary:
        //     Gets the System.Data.IDataParameterCollection.
        //
        // Returns:
        //     The parameters of the SQL statement or stored procedure.
        IDataParameterCollection Parameters { get; }
        //
        // Summary:
        //     Gets or sets the transaction within which the Command object of a .NET Framework
        //     data provider executes.
        //
        // Returns:
        //     the Command object of a .NET Framework data provider executes. The default
        //     value is null.
        IDbTransaction Transaction { get; set; }
        //
        // Summary:
        //     Gets or sets how command results are applied to the System.Data.DataRow when
        //     used by the System.Data.IDataAdapter.Update(System.Data.DataSet) method of
        //     a System.Data.Common.DbDataAdapter.
        //
        // Returns:
        //     One of the System.Data.UpdateRowSource values. The default is Both unless
        //     the command is automatically generated. Then the default is None.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The value entered was not one of the System.Data.UpdateRowSource values.
        UpdateRowSource UpdatedRowSource { get; set; }

        // Summary:
        //     Attempts to cancels the execution of an System.Data.IDbCommand.
        void Cancel();
        //
        // Summary:
        //     Creates a new instance of an System.Data.IDbDataParameter object.
        //
        // Returns:
        //     An IDbDataParameter object.
        IDbDataParameter CreateParameter();
        //
        // Summary:
        //     Executes an SQL statement against the Connection object of a .NET Framework
        //     data provider, and returns the number of rows affected.
        //
        // Returns:
        //     The number of rows affected.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The connection does not exist.-or- The connection is not open.
        int ExecuteNonQuery();
        //
        // Summary:
        //     Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection
        //     and builds an System.Data.IDataReader.
        //
        // Returns:
        //     An System.Data.IDataReader object.
        IDataReader ExecuteReader();
        //
        // Summary:
        //     Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection,
        //     and builds an System.Data.IDataReader using one of the System.Data.CommandBehavior
        //     values.
        //
        // Parameters:
        //   behavior:
        //     One of the System.Data.CommandBehavior values.
        //
        // Returns:
        //     An System.Data.IDataReader object.
        IDataReader ExecuteReader(CommandBehavior behavior);
        //
        // Summary:
        //     Executes the query, and returns the first column of the first row in the
        //     resultset returned by the query. Extra columns or rows are ignored.
        //
        // Returns:
        //     The first column of the first row in the resultset.
        object ExecuteScalar();
        //
        // Summary:
        //     Creates a prepared (or compiled) version of the command on the data source.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.Data.OleDb.OleDbCommand.Connection is not set.-or- The System.Data.OleDb.OleDbCommand.Connection
        //     is not System.Data.OleDb.OleDbConnection.Open().
        void Prepare();
    }

    // Summary:
    //     Represents a parameter to a Command object, and optionally, its mapping to
    //     System.Data.DataSet columns; and is implemented by .NET Framework data providers
    //     that access data sources.
    public interface IDataParameter
    {
        // Summary:
        //     Gets or sets the System.Data.DbType of the parameter.
        //
        // Returns:
        //     One of the System.Data.DbType values. The default is System.Data.DbType.String.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     The property was not set to a valid System.Data.DbType.
        DbType DbType { get; set; }
        //
        // Summary:
        //     Gets or sets a value indicating whether the parameter is input-only, output-only,
        //     bidirectional, or a stored procedure return value parameter.
        //
        // Returns:
        //     One of the System.Data.ParameterDirection values. The default is Input.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The property was not set to one of the valid System.Data.ParameterDirection
        //     values.
        ParameterDirection Direction { get; set; }
        //
        // Summary:
        //     Gets a value indicating whether the parameter accepts null values.
        //
        // Returns:
        //     true if null values are accepted; otherwise, false. The default is false.
        bool IsNullable { get; }
        //
        // Summary:
        //     Gets or sets the name of the System.Data.IDataParameter.
        //
        // Returns:
        //     The name of the System.Data.IDataParameter. The default is an empty string.
        string ParameterName { get; set; }
        //
        // Summary:
        //     Gets or sets the name of the source column that is mapped to the System.Data.DataSet
        //     and used for loading or returning the System.Data.IDataParameter.Value.
        //
        // Returns:
        //     The name of the source column that is mapped to the System.Data.DataSet.
        //     The default is an empty string.
        string SourceColumn { get; set; }
        //
        // Summary:
        //     Gets or sets the System.Data.DataRowVersion to use when loading System.Data.IDataParameter.Value.
        //
        // Returns:
        //     One of the System.Data.DataRowVersion values. The default is Current.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The property was not set one of the System.Data.DataRowVersion values.
        DataRowVersion SourceVersion { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the parameter.
        //
        // Returns:
        //     An System.Object that is the value of the parameter. The default value is
        //     null.
        object Value { get; set; }
    }

    // Summary:
    //     Describes the version of a System.Data.DataRow.
    public enum DataRowVersion
    {
        // Summary:
        //     The row contains its original values.
        Original = 256,
        //
        // Summary:
        //     The row contains current values.
        Current = 512,
        //
        // Summary:
        //     The row contains a proposed value.
        Proposed = 1024,
        //
        // Summary:
        //     The default version of System.Data.DataRowState. For a DataRowState value
        //     of Added, Modified or Deleted, the default version is Current. For a System.Data.DataRowState
        //     value of Detached, the version is Proposed.
        Default = 1536,
    }

    // Summary:
    //     Used by the Visual Basic .NET Data Designers to represent a parameter to
    //     a Command object, and optionally, its mapping to System.Data.DataSet columns.
    public interface IDbDataParameter : IDataParameter
    {
        // Summary:
        //     Indicates the precision of numeric parameters.
        //
        // Returns:
        //     The maximum number of digits used to represent the Value property of a data
        //     provider Parameter object. The default value is 0, which indicates that a
        //     data provider sets the precision for Value.
        byte Precision { get; set; }
        //
        // Summary:
        //     Indicates the scale of numeric parameters.
        //
        // Returns:
        //     The number of decimal places to which System.Data.OleDb.OleDbParameter.Value
        //     is resolved. The default is 0.
        byte Scale { get; set; }
        //
        // Summary:
        //     The size of the parameter.
        //
        // Returns:
        //     The maximum size, in bytes, of the data within the column. The default value
        //     is inferred from the the parameter value.
        int Size { get; set; }
    }
    // Summary:
    //     Collects all parameters relevant to a Command object and their mappings to
    //     System.Data.DataSet columns, and is implemented by .NET Framework data providers
    //     that access data sources.
    public interface IDataParameterCollection : IList, ICollection, IEnumerable
    {
        // Summary:
        //     Gets or sets the parameter at the specified index.
        //
        // Parameters:
        //   parameterName:
        //     The name of the parameter to retrieve.
        //
        // Returns:
        //     An System.Object at the specified index.
        object this[string parameterName] { get; set; }

        // Summary:
        //     Gets a value indicating whether a parameter in the collection has the specified
        //     name.
        //
        // Parameters:
        //   parameterName:
        //     The name of the parameter.
        //
        // Returns:
        //     true if the collection contains the parameter; otherwise, false.
        bool Contains(string parameterName);
        //
        // Summary:
        //     Gets the location of the System.Data.IDataParameter within the collection.
        //
        // Parameters:
        //   parameterName:
        //     The name of the parameter.
        //
        // Returns:
        //     The zero-based location of the System.Data.IDataParameter within the collection.
        int IndexOf(string parameterName);
        //
        // Summary:
        //     Removes the System.Data.IDataParameter from the collection.
        //
        // Parameters:
        //   parameterName:
        //     The name of the parameter.
        void RemoveAt(string parameterName);
    }

    // Summary:
    //     Provides a means of reading one or more forward-only streams of result sets
    //     obtained by executing a command at a data source, and is implemented by .NET
    //     Framework data providers that access relational databases.
    // WB: This is a DARK HOLE leading to gigantic APIs like DataTable, IDataRecord
    //     Pulling the threads on a sweater
    //     I'm stopping here w/ a fake interface
    public interface IDataReader : IDisposable, IDataRecord
    {
        // Summary:
        //     Gets a value indicating the depth of nesting for the current row.
        //
        // Returns:
        //     The level of nesting.
        int Depth { get; }
        //
        // Summary:
        //     Gets a value indicating whether the data reader is closed.
        //
        // Returns:
        //     true if the data reader is closed; otherwise, false.
        bool IsClosed { get; }
        //
        // Summary:
        //     Gets the number of rows changed, inserted, or deleted by execution of the
        //     SQL statement.
        //
        // Returns:
        //     The number of rows changed, inserted, or deleted; 0 if no rows were affected
        //     or the statement failed; and -1 for SELECT statements.
        int RecordsAffected { get; }

        // Summary:
        //     Closes the System.Data.IDataReader Object.
        void Close();
        //
        // Summary:
        //     Returns a System.Data.DataTable that describes the column metadata of the
        //     System.Data.IDataReader.
        //
        // Returns:
        //     A System.Data.DataTable that describes the column metadata.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The System.Data.IDataReader is closed.
        //DataTable GetSchemaTable();
        //
        // Summary:
        //     Advances the data reader to the next result, when reading the results of
        //     batch SQL statements.
        //
        // Returns:
        //     true if there are more rows; otherwise, false.
        bool NextResult();
        //
        // Summary:
        //     Advances the System.Data.IDataReader to the next record.
        //
        // Returns:
        //     true if there are more rows; otherwise, false.
        bool Read();
    }

    // Summary:
    //     Provides access to the column values within each row for a DataReader, and
    //     is implemented by .NET Framework data providers that access relational databases.
    public interface IDataRecord
    {
        // Summary:
        //     Gets the number of columns in the current row.
        //
        // Returns:
        //     When not positioned in a valid recordset, 0; otherwise, the number of columns
        //     in the current record. The default is -1.
        int FieldCount { get; }

        // Summary:
        //     Gets the column located at the specified index.
        //
        // Parameters:
        //   i:
        //     The zero-based index of the column to get.
        //
        // Returns:
        //     The column located at the specified index as an System.Object.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        object this[int i] { get; }
        //
        // Summary:
        //     Gets the column with the specified name.
        //
        // Parameters:
        //   name:
        //     The name of the column to find.
        //
        // Returns:
        //     The column with the specified name as an System.Object.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     No column with the specified name was found.
        object this[string name] { get; }

        // Summary:
        //     Gets the value of the specified column as a Boolean.
        //
        // Parameters:
        //   i:
        //     The zero-based column ordinal.
        //
        // Returns:
        //     The value of the column.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        bool GetBoolean(int i);
        //
        // Summary:
        //     Gets the 8-bit unsigned integer value of the specified column.
        //
        // Parameters:
        //   i:
        //     The zero-based column ordinal.
        //
        // Returns:
        //     The 8-bit unsigned integer value of the specified column.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        byte GetByte(int i);
        //
        // Summary:
        //     Reads a stream of bytes from the specified column offset into the buffer
        //     as an array, starting at the given buffer offset.
        //
        // Parameters:
        //   i:
        //     The zero-based column ordinal.
        //
        //   fieldOffset:
        //     The index within the field from which to start the read operation.
        //
        //   buffer:
        //     The buffer into which to read the stream of bytes.
        //
        //   bufferoffset:
        //     The index for buffer to start the read operation.
        //
        //   length:
        //     The number of bytes to read.
        //
        // Returns:
        //     The actual number of bytes read.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length);
        //
        // Summary:
        //     Gets the character value of the specified column.
        //
        // Parameters:
        //   i:
        //     The zero-based column ordinal.
        //
        // Returns:
        //     The character value of the specified column.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        char GetChar(int i);
        //
        // Summary:
        //     Reads a stream of characters from the specified column offset into the buffer
        //     as an array, starting at the given buffer offset.
        //
        // Parameters:
        //   i:
        //     The zero-based column ordinal.
        //
        //   fieldoffset:
        //     The index within the row from which to start the read operation.
        //
        //   buffer:
        //     The buffer into which to read the stream of bytes.
        //
        //   bufferoffset:
        //     The index for buffer to start the read operation.
        //
        //   length:
        //     The number of bytes to read.
        //
        // Returns:
        //     The actual number of characters read.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length);
        //
        // Summary:
        //     Returns an System.Data.IDataReader for the specified column ordinal.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The System.Data.IDataReader for the specified column ordinal.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        IDataReader GetData(int i);
        //
        // Summary:
        //     Gets the data type information for the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The data type information for the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        string GetDataTypeName(int i);
        //
        // Summary:
        //     Gets the date and time data value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The date and time data value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        DateTime GetDateTime(int i);
        //
        // Summary:
        //     Gets the fixed-position numeric value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The fixed-position numeric value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        decimal GetDecimal(int i);
        //
        // Summary:
        //     Gets the double-precision floating point number of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The double-precision floating point number of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        double GetDouble(int i);
        //
        // Summary:
        //     Gets the System.Type information corresponding to the type of System.Object
        //     that would be returned from System.Data.IDataRecord.GetValue(System.Int32).
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The System.Type information corresponding to the type of System.Object that
        //     would be returned from System.Data.IDataRecord.GetValue(System.Int32).
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        Type GetFieldType(int i);
        //
        // Summary:
        //     Gets the single-precision floating point number of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The single-precision floating point number of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        float GetFloat(int i);
        //
        // Summary:
        //     Returns the GUID value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The GUID value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        Guid GetGuid(int i);
        //
        // Summary:
        //     Gets the 16-bit signed integer value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The 16-bit signed integer value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        short GetInt16(int i);
        //
        // Summary:
        //     Gets the 32-bit signed integer value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The 32-bit signed integer value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        int GetInt32(int i);
        //
        // Summary:
        //     Gets the 64-bit signed integer value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The 64-bit signed integer value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        long GetInt64(int i);
        //
        // Summary:
        //     Gets the name for the field to find.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The name of the field or the empty string (""), if there is no value to return.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        string GetName(int i);
        //
        // Summary:
        //     Return the index of the named field.
        //
        // Parameters:
        //   name:
        //     The name of the field to find.
        //
        // Returns:
        //     The index of the named field.
        int GetOrdinal(string name);
        //
        // Summary:
        //     Gets the string value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The string value of the specified field.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        string GetString(int i);
        //
        // Summary:
        //     Return the value of the specified field.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     The System.Object which will contain the field value upon return.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        object GetValue(int i);
        //
        // Summary:
        //     Populates an array of objects with the column values of the current record.
        //
        // Parameters:
        //   values:
        //     An array of System.Object to copy the attribute fields into.
        //
        // Returns:
        //     The number of instances of System.Object in the array.
        int GetValues(object[] values);
        //
        // Summary:
        //     Return whether the specified field is set to null.
        //
        // Parameters:
        //   i:
        //     The index of the field to find.
        //
        // Returns:
        //     true if the specified field is set to null; otherwise, false.
        //
        // Exceptions:
        //   System.IndexOutOfRangeException:
        //     The index passed was outside the range of 0 through System.Data.IDataRecord.FieldCount.
        bool IsDBNull(int i);
    }
#endif
}