namespace System.Data
{
#if DNXCORE50
    // Summary:
    //     Represents an open connection to a data source, and is implemented by .NET
    //     Framework data providers that access relational databases.
    public interface IDbConnection : IDisposable
    {
        // Summary:
        //     Gets or sets the string used to open a database.
        //
        // Returns:
        //     A string containing connection settings.
        string ConnectionString { get; set; }
        //
        // Summary:
        //     Gets the time to wait while trying to establish a connection before terminating
        //     the attempt and generating an error.
        //
        // Returns:
        //     The time (in seconds) to wait for a connection to open. The default value
        //     is 15 seconds.
        int ConnectionTimeout { get; }
        //
        // Summary:
        //     Gets the name of the current database or the database to be used after a
        //     connection is opened.
        //
        // Returns:
        //     The name of the current database or the name of the database to be used once
        //     a connection is open. The default value is an empty string.
        string Database { get; }
        //
        // Summary:
        //     Gets the current state of the connection.
        //
        // Returns:
        //     One of the System.Data.ConnectionState values.
        ConnectionState State { get; }

        // Summary:
        //     Begins a database transaction.
        //
        // Returns:
        //     An object representing the new transaction.
        IDbTransaction BeginTransaction();
        //
        // Summary:
        //     Begins a database transaction with the specified System.Data.IsolationLevel
        //     value.
        //
        // Parameters:
        //   il:
        //     One of the System.Data.IsolationLevel values.
        //
        // Returns:
        //     An object representing the new transaction.
        IDbTransaction BeginTransaction(IsolationLevel il);
        //
        // Summary:
        //     Changes the current database for an open Connection object.
        //
        // Parameters:
        //   databaseName:
        //     The name of the database to use in place of the current database.
        void ChangeDatabase(string databaseName);
        //
        // Summary:
        //     Closes the connection to the database.
        void Close();
        //
        // Summary:
        //     Creates and returns a Command object associated with the connection.
        //
        // Returns:
        //     A Command object associated with the connection.
        IDbCommand CreateCommand();
        //
        // Summary:
        //     Opens a database connection with the settings specified by the ConnectionString
        //     property of the provider-specific Connection object.
        void Open();
    }
#endif
}
